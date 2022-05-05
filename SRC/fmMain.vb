Public Class fmMain
    Private _it As iTuneLibrary = Nothing
    Private _EnableEvent As Boolean = False

    '* WindowsMediaPlayerコントロールを使用時はプロジェクトファイルの最後(</project>の前)に次のコードを追加するとワーニングが表示されない
    '*  <!-- Comment out Or set to 'false' to get warnings about TLB conversion -->
    '*  <PropertyGroup>
    '*    <ResolveComReferenceSilent>True</ResolveComReferenceSilent>
    '*  </PropertyGroup>
    '*
    '*  「AxInterop.WMPLib」「Interop.WMPLib」のプロパティ「相互運用型の埋め込み」をFalseにする事
    '*
    '* AACGain v1.9: https://www.rarewares.org/aac-encoders.php
    '*               https://www.rarewares.org/files/aac/aacgain_1_9.zip
    '*

    ''' <summary>
    ''' 指定したDataGridViewの描画モードをダブルバッファに設定
    ''' </summary>
    ''' <param name="dgv"></param>
    Private Sub EnableDoubleBuffer(dgv As DataGridView)
        Dim dgvtype As System.Type = GetType(DataGridView)
        Dim dgvPropertyInfo As System.Reflection.PropertyInfo = dgvtype.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        dgvPropertyInfo.SetValue(dgv, True, Nothing)
    End Sub

    '* イベント
    '* 　　フォームロード
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Begin(Me)
        Me.Text = getAssemblyName()
        Me.MinimumSize = Me.Size

        Me.EnableDoubleBuffer(Me.DataGridView_PlayList)
        With Me.DataGridView_PlayList
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.None
        End With

        Me.EnableDoubleBuffer(Me.DataGridView_TrackList)
        With Me.DataGridView_TrackList
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.None
        End With

        With Me.TextBox_Information
            .BorderStyle = BorderStyle.None
        End With

        Me.WMP.settings.volume = 100

        Me.ToolStripStatusLabel_LibraryFile.Text = ""
        Me.Visible = True

        '* iTuneLibrary.xmlオープン
        Dim FilePath As String = COMMON.Setting.iTuneLibraryFilePath
        If Not Me.OpeniTuneLibraryFile(False) Then
            Application.Exit()
            Return
        End If

        Me._EnableEvent = True
    End Sub

    '* イベント
    '* 　　メニューバー→ファイル→iTunesライブラリファイルを開く
    Private Sub ToolStripMenuItem_OpenITunes_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_OpenITunes.Click
        Me.OpeniTuneLibraryFile(True)
    End Sub

    '* イベント
    '* 　　メニューバー→ヘルプ→アプリケーション情報
    Private Sub ToolStripMenuItem_AppInfo_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_AppInfo.Click
        Using fm As New fmVersion
            fm.ShowDialog(Me)
        End Using
    End Sub

    '* イベント
    '* 　　メニューバー→ファイr→プレイリストファイル出力
    Private Sub ToolStripMenuItem_FileCopy_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_FileCopy.Click
        Dim dgv As DataGridView = Me.DataGridView_TrackList

        Dim tbl As DataTable = DirectCast(dgv.DataSource, DataView).Table
        If tbl.Rows.Count <= 0 Then
            MessageBox.Show("プレイリスト内に曲が登録されていません。", getAssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf tbl.Rows.Count >= 10000 Then
            MessageBox.Show("プレイリスト内の曲が多すぎます。", getAssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim dicFileName As New Dictionary(Of String, String)
        For Each row As DataRow In tbl.Rows
            If CType(row("Location"), String).Length <= 0 Then
                MessageBox.Show($"クラウドからダウンロードされていない曲が有ります。{vbCrLf}{row("Name")}", getAssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim fname As String = StrConv(System.IO.Path.GetFileName(row("Location")), VbStrConv.Lowercase)
            If dicFileName.ContainsKey(fname) Then
                Dim sts As DialogResult = MessageBox.Show($"ファイルが重複していますが続行しますか？{vbCrLf}{row("Name")}", getAssemblyName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                If sts = DialogResult.No Then Return
            End If

            If Not dicFileName.ContainsKey(fname) Then dicFileName.Add(fname, row("Name"))
        Next

        Using fm As New fmCopy
            fm.TextBox_Src.Text = Me.GroupBox_PlayListItem.Text
            fm.TextBox_PlayListName.Text = $"{tbl.TableName}.m3u"
            fm.TextBox_Src.Tag = DirectCast(Me.DataGridView_TrackList.DataSource, DataView).Table
            fm.ShowDialog(Me)
        End Using
        MessageBox.Begin(Me)
    End Sub

    '* イベント
    '* 　　Button　再読込
    Private Sub Button_ReLoad_Click(sender As Object, e As EventArgs) Handles Button_ReLoad.Click
        Me._EnableEvent = False

        Dim dgv As DataGridView = Me.DataGridView_PlayList
        Dim SelectId As Integer = If(dgv.SelectedRows.Count > 0, CType(dgv.SelectedRows(0).Cells(1).Value, Integer), -1)
        If Me.OpeniTuneLibraryFile(False, SelectId) Then
            MessageBox.Show("再読込を行いました。", getAssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me._EnableEvent = True
    End Sub

    '*　イベント
    '*　　　トラックアイテムダブルクリック
    Private Sub DataGridView_TrackList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_TrackList.CellDoubleClick
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        If e.RowIndex >= 0 Then
            Dim fileName As String = dgv.Rows(e.RowIndex).Cells("Location").Value
            Me.WMP.URL = fileName
        End If
    End Sub

    '*　イベント
    '*　　　プレイリストアイテム選択チェンジ
    Private Sub DataGridView_PlayList_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView_PlayList.SelectionChanged
        If Not Me._EnableEvent Then Return
        Me.SelectPlayList()
        Me.ActiveControl = Me.DataGridView_PlayList
    End Sub

    ''' <summary>
    ''' 選択中のプレイリストのトラック情報をトラック一覧に表示
    ''' </summary>
    Private Sub SelectPlayList()
        Dim rEnableEvent As Boolean = Me._EnableEvent
        Me._EnableEvent = False

        Dim dgv As DataGridView = Me.DataGridView_PlayList
        Dim dgRow As DataGridViewRow = Nothing
        Dim PlayListId As Integer = -99

        dgv.Enabled = False

        If dgv.SelectedRows.Count > 0 Then
            dgRow = dgv.SelectedRows(0)
            PlayListId = CType(dgRow.Cells(1).Value, Integer)
        End If
        Dim tbl As DataTable = Me._it.GetPlayListItemTable(PlayListId)

        With Me.DataGridView_TrackList
            .DataSource = New DataView(tbl)
            For i As Integer = 6 To .Columns.Count - 1
                .Columns(i).Visible = False
            Next
            For i As Integer = 0 To 5
                Dim w As Integer = .Columns(i).Width
                .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                If w < .Columns(i).Width Then .Columns(i).Width = .Columns(i).Width
                .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Next
        End With

        If PlayListId >= 0 Then
            Dim tm As UInt64 = 0
            Dim size As UInt64 = 0
            For Each row As DataRow In tbl.Rows
                tm += CType(row("TotalTime"), UInt64)
                size += CType(row("Size"), UInt64)
            Next

            Dim sz As String = ""
            If size < (1024 * 1024 * 1024) Then
                sz = (size / 1024 / 1024).ToString("#0.00MB")
            ElseIf size < (1024UL * 1024 * 1024 * 1024) Then
                sz = (size / 1024 / 1024 / 1024).ToString("#0.00GB")
            End If

            tm = ((tm \ 1000) + 30) \ 60
            Dim tim As String = ""
            If tm <= 120 Then
                tim = $"{tm.ToString}分"
            ElseIf tm <= 1440 Then
                tim = $"{(tm \ 60).ToString}時間+{(tm Mod 60).ToString}分"
            Else
                tim = $"{(tm \ 1440).ToString}日+{((tm Mod 1440) \ 60).ToString}時間"
            End If

            Me.GroupBox_PlayListItem.Text = $"【{StrConv(dgRow.Cells(0).Value, vbWide)}】 / {tbl.Rows.Count}曲 / {tim} / {sz}"
        Else
            Me.GroupBox_PlayListItem.Text = ""
        End If

        dgv.Enabled = True

        Me._EnableEvent = rEnableEvent
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="isNewOpen"></param>
    ''' <returns></returns>
    Private Function OpeniTuneLibraryFile(isNewOpen As Boolean, Optional SelectPlayLisId As Integer = -1) As Boolean
        Dim rEnableEvent As Boolean = Me._EnableEvent
        Me._EnableEvent = False

        Dim ShowDialog As Boolean = isNewOpen
        Dim fileName As String = COMMON.Setting.iTuneLibraryFilePath
        Do
            If ShowDialog Then
                Using ofd As New OpenFileDialog()
                    With ofd
                        .FileName = "iTunes Library.xml"

                        Dim dir As String = If(fileName IsNot Nothing, System.IO.Path.GetDirectoryName(fileName), System.Environment.GetFolderPath(Environment.SpecialFolder.MyMusic))
                        .InitialDirectory = dir

                        .Filter = "iTunesライブラリファイル(*.xml)|*.xml|すべてのファイル(*.*)|*.*"
                        .FilterIndex = 0
                        .Title = "iTunesライブラリファイルを選択してください"
                        .RestoreDirectory = True
                        .CheckFileExists = True
                        .CheckPathExists = True
                        If .ShowDialog() = DialogResult.OK Then
                            fileName = .FileName
                        Else
                            fileName = Nothing
                            Exit Do
                        End If
                    End With
                End Using
            End If

            If Not System.IO.File.Exists(fileName) Then
                MessageBox.Show($"iTunesライブラリファイル {fileName} が存在しません。", getAssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim it As New iTuneLibrary(fileName)
                If it.Begin() Then
                    Me._it = it
                    Exit Do
                Else
                    MessageBox.Show($"iTunesライブラリの読み込み中にエラーが発生しました。{it.GetLastError()}", getAssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            ShowDialog = True
        Loop

        If fileName IsNot Nothing Then
            COMMON.Setting.iTuneLibraryFilePath = fileName

            Me.ToolStripStatusLabel_LibraryFile.Text = fileName

            Dim inf As iTuneLibrary.LibraryInformation = Me._it.GetHeader()
            Dim sb As New Text.StringBuilder
            With inf
                sb.AppendLine($"PlayListVersion: { .PlayListVersion}")
                sb.AppendLine($"MajorVersion: { .MajorVersion}")
                sb.AppendLine($"MinorVersion: { .MinorVersion}")
                sb.AppendLine($"ApplicationVersion: { .ApplicationVersion}")
                sb.AppendLine($"Date: { .DateString}")
                sb.AppendLine($"Features: { .Features}")
                sb.AppendLine($"ShowContentRatings: { .ShowContentRatings}")
                sb.AppendLine($"LibraryPersistentID: { .LibraryPersistentID}")
            End With

            With Me.TextBox_Information
                .Text = sb.ToString
                .SelectionLength = 0
            End With

            With Me.DataGridView_PlayList
                .Enabled = False
                .DataSource = New DataView(Me._it.GetPlayListTable())
                .Columns(0).Width = .Width
                .Columns(1).Visible = False
                If SelectPlayLisId >= 0 Then
                    For Each dgRow As DataGridViewRow In .Rows
                        If CType(dgRow.Cells(1).Value, Integer) = SelectPlayLisId Then
                            dgRow.Selected = True
                            Exit For
                        End If
                    Next
                End If
                .Enabled = True
            End With

            Me.SelectPlayList()
            If ShowDialog Then MessageBox.Show("iTunesライブラリファイルを読み込みました。", getAssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        Me.ActiveControl = Me.DataGridView_PlayList

        Me._EnableEvent = rEnableEvent
        Return (fileName IsNot Nothing)
    End Function

End Class

