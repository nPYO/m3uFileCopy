Imports System.ComponentModel

Public Class fmCopy
    Private _EnableEvent As Boolean = False
    Private _isPause As Boolean = False
    Private _isAbrot As Boolean = False
    Private _isStop As Boolean = False
    Private _isFileCopying As Boolean = False

    Private Sub fmCopy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Begin(Me)
        Me.Text = getAssemblyName()
        Me.MinimumSize = Me.Size

        Me.TextBox_Information.BorderStyle = BorderStyle.None
        Me.ToolStripProgressBar_CopyFile.Visible = False
        Me.ToolStripStatusLabel_Info.Text = ""

        With Me.TextBox_OutputPath
            .Text = COMMON.Setting.OutputPath
            .SelectionStart = .Text.Length
            .SelectionLength = 0
        End With

        Select Case COMMON.Setting.FileNameMode
            Case 0
                Me.RadioButton1.Checked = True
            Case 1
                Me.RadioButton2.Checked = True
            Case 2
                Me.RadioButton3.Checked = True
        End Select

        Me.CheckBox1.Checked = COMMON.Setting.DisablePlayTime
        Me.CheckBox2.Checked = COMMON.Setting.RemoveTrickNumber

        Me.MakePlayList()

        With Me.TextBox_PlayListName
            .SelectionStart = .Text.Length
            .SelectionLength = 0
        End With
        Me.ActiveControl = Me.TextBox_PlayListName

        Me._EnableEvent = True
    End Sub

    Private Sub fmCopy_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Me._isFileCopying Then
            Me._isPause = True
            If MessageBox.Show("ファイル出力中です。処理を中断してフォームを閉じますか？", getAssemblyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me._isAbrot = True
            Else
                Me._isPause = False
            End If
            e.Cancel = True
        End If
    End Sub

    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
        If Not Me._EnableEvent Then Return
        Dim rb As RadioButton = DirectCast(sender, RadioButton)
        If Not rb.Checked Then Return
        COMMON.Setting.FileNameMode = CType(rb.Tag, Integer)
        Me.MakePlayList()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If Not Me._EnableEvent Then Return
        Dim ck As CheckBox = DirectCast(sender, CheckBox)
        COMMON.Setting.DisablePlayTime = ck.Checked
        Me.MakePlayList()
    End Sub

    Private Sub CheckBox2CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If Not Me._EnableEvent Then Return
        Dim ck As CheckBox = DirectCast(sender, CheckBox)
        COMMON.Setting.RemoveTrickNumber = ck.Checked
        Me.MakePlayList()
    End Sub

    Private Sub TextBox_PlayListName_Validated(sender As Object, e As EventArgs) Handles TextBox_PlayListName.Validated
        If Not Me._EnableEvent Then Return
        Me.MakePlayList()
    End Sub

    Private Sub TextBox_PlayListName_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_PlayListName.KeyDown
        If Not Me._EnableEvent Then Return
        If e.KeyCode = Keys.Enter Then Me.MakePlayList()
    End Sub

    Private Sub Button_OpenPath_Click(sender As Object, e As EventArgs) Handles Button_OpenPath.Click

        Using fbd As New FolderBrowserDialog
            With fbd
                .Description = "ファイルの出力先を指定してください。"
                .RootFolder = Environment.SpecialFolder.Desktop
                .SelectedPath = Me.TextBox_OutputPath.Text
                .ShowNewFolderButton = True
                If .ShowDialog(Me) = DialogResult.OK Then
                    Me.TextBox_OutputPath.Text = .SelectedPath
                    COMMON.Setting.OutputPath = .SelectedPath
                End If
            End With
        End Using

    End Sub

    Private Sub Button_Stop_Click(sender As Object, e As EventArgs) Handles Button_Stop.Click

        Me._isPause = True
        If MessageBox.Show("ファイル出力を中断しますか？", getAssemblyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then Me._isStop = True
        Me._isPause = False

    End Sub

    Private Sub Button_ExecCopy_Click(sender As Object, e As EventArgs) Handles Button_ExecCopy.Click
        If Not Me._EnableEvent Then Return
        If MessageBox.Show("プレイリスト内のファイルをコピーします。よろしいですか？", getAssemblyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Me._EnableEvent = False

        Me._isFileCopying = False
        Me._isPause = False
        Me._isAbrot = False
        Me._isStop = False

        Me.Button_ExecCopy.Enabled = False
        Me.GroupBox_Option.Enabled = False
        Me.TextBox_Src.Enabled = False
        Me.TextBox_OutputPath.Enabled = False
        Me.TextBox_PlayListName.Enabled = False
        Me.Button_OpenPath.Enabled = False

        Dim isExec As Boolean = True
        Dim OutDirName As String = $"{Me.TextBox_OutputPath.Text}\{System.IO.Path.GetFileNameWithoutExtension(Me.TextBox_PlayListName.Text)}"

        '* 出力フォルダ作成
        If System.IO.Directory.Exists(OutDirName) Then
            If MessageBox.Show($"出力ディレクトリが既に存在します。全て削除してファイルコピーを行います。{vbCrLf}処理を続行しますか？", getAssemblyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                isExec = False
            Else
                Try
                    System.IO.Directory.Delete(OutDirName, True)
                Catch ex As Exception
                    MessageBox.Show($"ディレクトリを削除できません。処理を中止します。", getAssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    isExec = False
                End Try
            End If
        End If

        If isExec Then
            Try
                System.IO.Directory.CreateDirectory(OutDirName)
            Catch ex As Exception
                MessageBox.Show($"出力ディレクトリを作成できません。処理を中止します。", getAssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                isExec = False
            End Try
        End If

        '* ファイルコピー
        If isExec Then
            Dim PlayFileList As New List(Of String())
            Dim PlayListText As String = Me.MakePlayList(False, PlayFileList)

            With Me.ToolStripProgressBar_CopyFile
                .Minimum = 0
                .Maximum = PlayFileList.Count
                .Visible = True
            End With

            With Me.ToolStripStatusLabel_Info
                .Text = $"0 / {PlayFileList.Count}"
                .Visible = True
            End With

            Me.Button_Stop.Enabled = True
            Me._isFileCopying = True
            Dim FileCount As Integer = 0
            For Each s As String() In PlayFileList
                Do
                    Application.DoEvents()
                Loop While Me._isPause AndAlso Not (Me._isAbrot OrElse Me._isStop)
                If Me._isStop OrElse Me._isAbrot Then Exit For

                FileCount += 1
                Me.ToolStripProgressBar_CopyFile.Value = FileCount
                Me.ToolStripStatusLabel_Info.Text = $"{FileCount} / {PlayFileList.Count}"

                Dim srcFileName As String = s(0)
                Dim dstFileName As String = $"{OutDirName}\{s(1)}"
                Try
                    System.IO.File.Copy(srcFileName, dstFileName, True)

                Catch ex As Exception
                    MessageBox.Show($"{ex.Message}", getAssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me._isStop = True
                    Exit For
                End Try
            Next

            If Me._isAbrot Then
                Me._isFileCopying = False
                Me.Close()
                Return
            End If

            Me.ToolStripProgressBar_CopyFile.Visible = False
            Me.ToolStripStatusLabel_Info.Visible = False

            If Me._isAbrot OrElse Me._isStop Then
                MessageBox.Show("ファイル出力を中断しました。", getAssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Try
                    Using sw As New System.IO.StreamWriter($"{Me.TextBox_OutputPath.Text}\{Me.TextBox_PlayListName.Text}", False, System.Text.Encoding.UTF8)
                        sw.Write(PlayListText)
                        sw.Close()
                    End Using
                    MessageBox.Show("ファイル出力が完了しました。", getAssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    System.Diagnostics.Process.Start(Me.TextBox_OutputPath.Text)

                Catch ex As Exception
                    MessageBox.Show($"{ex.Message}", getAssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End If
        End If

        Me._isFileCopying = False
        Me._isPause = False
        Me._isAbrot = False
        Me._isStop = False

        Me.Button_ExecCopy.Enabled = True
        Me.GroupBox_Option.Enabled = True
        Me.TextBox_Src.Enabled = True
        Me.TextBox_OutputPath.Enabled = True
        Me.TextBox_PlayListName.Enabled = True
        Me.Button_OpenPath.Enabled = True

        Me._EnableEvent = True
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CopyTextBox"></param>
    ''' <returns></returns>
    Private Function MakePlayList(Optional CopyTextBox As Boolean = True, Optional FileList As List(Of String()) = Nothing) As String
        Dim tbl As DataTable = DirectCast(Me.TextBox_Src.Tag, DataTable)

        If FileList IsNot Nothing Then FileList.Clear()

        Dim PlayListName As String = System.IO.Path.GetFileNameWithoutExtension(Me.TextBox_PlayListName.Text)
        Const DefaultPlayListName As String = "LIST"

        Dim invalidChars As Char() = System.IO.Path.GetInvalidFileNameChars()
        If PlayListName.Length <= 0 Then
            MessageBox.Show("プレイリスト名が指定されていません。規定値を適用します", getAssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            PlayListName = DefaultPlayListName

        ElseIf PlayListName.IndexOfAny(invalidChars) >= 0 Then
            MessageBox.Show("プレイリスト名にファイル名として使用できない文字が含まれています。規定値を適用します", getAssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            PlayListName = DefaultPlayListName

        End If
        Me.TextBox_PlayListName.Text = $"{PlayListName}.m3u"

        Dim sbPlayList As New Text.StringBuilder
        sbPlayList.AppendLine("#EXTM3U")

        Dim FileIndex As Integer = 0
        For Each row As DataRow In tbl.Rows
            Dim tim As Integer = If(COMMON.Setting.DisablePlayTime, -1, row("TotalTime") \ 1000)
            sbPlayList.AppendLine($"#EXTINF:{tim},{row("Name")} - {row("Artist")}")

            FileIndex += 1
            Dim FileName As String = System.IO.Path.GetFileName(row("Location"))

            If COMMON.Setting.RemoveTrickNumber Then    '* iTunesが付与したトラック番号をファイル名から除去
                If FileName.Length >= 4 Then
                    If "0123456789".IndexOf(FileName.Substring(0, 1)) >= 0 AndAlso "0123456789".IndexOf(FileName.Substring(1, 1)) >= 0 AndAlso FileName.Substring(2, 1).Equals(" ") Then
                        FileName = FileName.Substring(3)
                    End If
                End If
            End If

            Select Case COMMON.Setting.FileNameMode
                Case 0
                    FileName = FileName
                Case 1
                    FileName = $"{FileIndex.ToString("0000")}_{FileName}"
                Case 2
                    FileName = $"{FileIndex.ToString("0000")}{StrConv(System.IO.Path.GetExtension(FileName), VbStrConv.Lowercase)}"
            End Select

            sbPlayList.AppendLine($"{PlayListName}\{FileName}")

            If FileList IsNot Nothing Then FileList.Add(New String() {row("Location"), FileName})
        Next

        Dim PlayListText As String = sbPlayList.ToString
        If CopyTextBox Then Me.TextBox_Information.Text = sbPlayList.ToString

        Return sbPlayList.ToString
    End Function

End Class