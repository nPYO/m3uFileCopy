
'* 引用）
'* ICOOON MONO ソングリストアイコン1
'* https://icooon-mono.com/14735-%e3%82%bd%e3%83%b3%e3%82%b0%e3%83%aa%e3%82%b9%e3%83%88%e3%82%a2%e3%82%a4%e3%82%b3%e3%83%b31/

'* 引用）
'* dobon.net 文字コードを判別する
'* https://dobon.net/vb/dotnet/string/detectcode.html

Public Class fmMain

    Private cts As System.Threading.CancellationTokenSource '* タスクキャンセルコントロール用
    Private MusicFileList As New ArrayList

    '* イベント
    '* バージョン表示
    '*
    Private Sub バージョンToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles バージョンToolStripMenuItem.Click

        Using fm As New fmVersion
            fm.ShowDialog()
        End Using

    End Sub

    '* イベント
    '* フォーム初期化時
    '*
    Private Sub fmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.SetControls()

        '* ステータスバー表示設定
        With Me.ToolStripStatusLabel
            .Visible = True
        End With

        '* プログレスバー表示設定
        With Me.ToolStripProgressBar
            .Visible = False
        End With

        EnableControls(True)

    End Sub

    '*　イベント
    '*　フォームリサイズ時
    '*
    Private Sub fmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        Me.SetControls()

    End Sub

    '* イベント
    '* コントロール内にドラッグされたとき
    '*
    Private Sub fmMain_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            '* ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            e.Effect = DragDropEffects.Copy
        Else
            '* ファイル以外は受け付けない
            e.Effect = DragDropEffects.None
        End If
    End Sub

    '* イベント
    '* コントロール内にドロップされたとき
    '*
    Private Async Sub fmMain_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop

        Dim ret As Boolean = True
        Dim fs As System.IO.FileStream = Nothing

        '* ドロップされたすべてのファイル名を取得する
        Dim fileNames As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        If UBound(fileNames) > 0 Then
            MessageBox.Show("複数のファイルをドロップする事は出来ません。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        '* ファイル名を取得
        Dim FileName As String = fileNames(0)

        '* 各コントロール無効化
        Me.EnableControls(False)

        '* プレイリスト読込
        Me.cts = New System.Threading.CancellationTokenSource()
        Try
            Dim tsk As Task(Of Boolean) = Me.LoadPlayList(cts.Token, FileName)  '* タスクの実行
            Await tsk                                                           '* 非同期的に完了待ち
            ret = tsk.Result                                                    '* 戻り値取得

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Me.cts.Dispose() : Me.cts = Nothing

        End Try

        '* 各コントロール有効化
        Me.EnableControls(True)

    End Sub

    '* イベント
    '* コマンドボタン「キャンセル」クリック時
    '*
    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click

        CType(sender, Button).Enabled = False
        If Not Me.cts Is Nothing Then Me.cts.Cancel()

    End Sub

    '* イベント
    '* コマンドボタン「フォルダ選択」クリック時
    '*
    Private Sub Button_SelectFolder_Click(sender As Object, e As EventArgs) Handles Button_SelectFolder.Click

        '* FolderBrowserDialogクラスのインスタンスを作成
        Dim fbd As New FolderBrowserDialog

        '* 上部に表示する説明テキストを指定する
        fbd.Description = "音楽ファイルを出力するフォルダを指定してください。"

        '* ルートフォルダを指定する
        fbd.RootFolder = Environment.SpecialFolder.MyComputer

        '* 最初に選択するフォルダを指定する
        fbd.SelectedPath = Me.Label_FolderPath.Text

        '* ユーザーが新しいフォルダを作成できるようにする
        '* デフォルトでTrue
        fbd.ShowNewFolderButton = True

        '* ダイアログを表示する
        If fbd.ShowDialog(Me) = DialogResult.OK Then
            Me.Label_FolderPath.Text = fbd.SelectedPath
        End If

    End Sub

    '* イベント
    '* コマンドボタン「ファイルコピー」クリック時
    '*
    Private Async Sub Button_FileCopy_Click(sender As Object, e As EventArgs) Handles Button_FileCopy.Click

        Dim ret As Boolean = True
        Dim s As String

        If Me.MusicFileList.Count <= 0 Then
            MessageBox.Show("プレイリストが読み込まれていません。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Me.Label_FolderPath.Text.Length <= 0 Then
            MessageBox.Show("ファイル出力フォルダが選択されていません。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        '* 各コントロール無効化
        Me.EnableControls(False)
        s = Me.ToolStripStatusLabel.Text

        '* プレイリスト読込
        Me.cts = New System.Threading.CancellationTokenSource()
        Try
            Dim tsk As Task(Of Boolean) = Me.CopyFiles(cts.Token, Me.Label_FolderPath.Text, Me.Label_PlayListFileName.Text)  '* タスクの実行
            Await tsk                                                           '* 非同期的に完了待ち
            ret = tsk.Result                                                    '* 戻り値取得

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Me.cts.Dispose() : Me.cts = Nothing

        End Try

        '* 各コントロール有効化
        Me.ToolStripProgressBar.Visible = False
        Me.ToolStripStatusLabel.Text = s
        Me.EnableControls(True)

    End Sub

    '*　イベント
    '*　チェックボックス「プレイリストを作成する」
    '*
    Private Sub CheckBox_MakePlayList_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_MakePlayList.CheckedChanged

        Me.CheckBox_UTF8.Enabled = Me.CheckBox_MakePlayList.Checked

    End Sub

    '*
    '*　各種コントロール有効／無効
    '*
    Private Sub EnableControls(ByVal flag As Boolean)

        Me.Button_Cancel.Enabled = Not flag
        Me.Button_FileCopy.Enabled = flag
        Me.Button_SelectFolder.Enabled = flag
        Me.TextBox_PlayListData.Enabled = flag
        Me.CheckBox_IndexNumber.Enabled = flag
        Me.CheckBox_MakePlayList.Enabled = flag

        If flag Then
            Me.CheckBox_UTF8.Enabled = Me.CheckBox_MakePlayList.Checked
        Else
            Me.CheckBox_UTF8.Enabled = False
        End If
        Me.AllowDrop = flag

    End Sub

    '*
    '*　ウインドウサイズにコントロールを合わせる
    '*
    Private Sub SetControls()

        '* ステータスバー表示設定
        With Me.ToolStripStatusLabel
            .Width = Me.Width / 3
        End With

        '* プログレスバー表示設定
        With Me.ToolStripProgressBar
            .Width = Me.StatusStrip.Width - (Me.ToolStripStatusLabel.Width + 20)
        End With

        '* 「ここにドラッグ＆ドロップしてください」ラベルを中央に設定
        With Me.Label_DrogDrop
            .Top = Me.TextBox_PlayListData.Top + ((Me.TextBox_PlayListData.Height) / 2)
            .Left = (Me.Width - .Width) / 2
        End With

    End Sub

    '*
    '* プレイリスト読込
    '*
    Private Async Function LoadPlayList(token As System.Threading.CancellationToken, FileName As String) As Task(Of Boolean)

        Dim result As Boolean = Await Task.Run(
        Function() As Boolean
            Dim ret As Boolean = True

            Dim fs As System.IO.FileStream = Nothing
            Dim code As String = ""
            Dim txt As String = ""
            Dim fileSize As Integer = 0                             '* ファイルのサイズ
            Dim readSize As Integer                                 '* Readメソッドで読み込んだバイト数
            Dim bufPos As Integer = 0                               '* データ格納用配列内の追加位置
            Dim bytesData(1) As Byte                                '* データ格納用配列
            Dim i As Long
            Dim PlayList As String() = Nothing
            Dim PlayListItemCount = 0
            Dim sb As New System.Text.StringBuilder()
            Dim enc As System.Text.Encoding = Nothing
            Dim hasBOM As Boolean = False
            Dim lngBomLength As Integer = 0

            Me.MusicFileList.Clear()
            sb.Clear()

            Invoke(
            Sub()
                '* プログレスバー非表示
                With Me.ToolStripProgressBar
                    .Visible = False
                End With

                '* ステータス表示更新
                With Me.ToolStripStatusLabel
                    .Text = "ファイル読込中"
                End With
            End Sub)

            '* バイナリモードでファイルを取得し、文字コードを判別
            Try
                fs = New System.IO.FileStream(FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                fileSize = CInt(fs.Length)                          '* ファイルのサイズ
                ReDim bytesData(fileSize - 1)
                readSize = fs.Read(bytesData, bufPos, fileSize)

            Catch ex As Exception
                code = ex.Message
                ret = False
            End Try

            fs.Close() : fs.Dispose() : fs = Nothing

            '* 入力データの文字コードを判別
            If ret Then
                Invoke(
                Sub()
                    With Me.ToolStripStatusLabel
                        .Text = "文字コード識別中"
                    End With
                End Sub)

                Try
                    enc = mjJudgeCode.DetectEncodingFromBOM(bytesData, lngBomLength) '* BOMから文字コード判別を試す
                    If Not enc Is Nothing Then
                        hasBOM = True
                        txt = enc.GetString(bytesData, lngBomLength, bytesData.Length - lngBomLength) '* BOMの部分はデコードしない

                    Else '* BOMが無い場合は別の方法で文字コード判別を行う
                        enc = mjJudgeCode.GetCode(bytesData)
                        If enc Is Nothing Then
                            code = "文字コードの判別に失敗しました。"
                            ret = False
                        Else
                            txt = enc.GetString(bytesData)
                        End If
                    End If

                Catch ex As Exception
                    code = "文字コード判別エラーです。"
                    ret = False

                End Try
            End If

            '* 改行コードで分割する
            If ret Then
                PlayList = txt.Replace(vbCrLf, vbLf).Split({vbLf(0), vbCr(0)})
                PlayListItemCount = UBound(PlayList) + 1
                If PlayListItemCount <= 1 OrElse PlayList(0) <> "#EXTM3U" Then
                    code = "「m3u」ファイルとして認識されませんでした。"
                    ret = False
                End If
            End If

            If ret Then
                Invoke(
                Sub()
                    Me.Label_DrogDrop.Visible = False

                    '* ステータス表示更新
                    With Me.ToolStripStatusLabel
                        .Text = "ファイル読込中"
                    End With

                    '* プログレスバー初期設定
                    With Me.ToolStripProgressBar
                        .Value = 0
                        .Maximum = PlayListItemCount
                        .Visible = True
                    End With
                End Sub)

                Try
                    code = enc.EncodingName '* 文字コード名を取得

                    '* ストリングスビルダーに行追記
                    sb.Append("#EXTM3U")
                    sb.Append(vbCrLf)

                    i = 1
                    Do While i < PlayListItemCount
                        If Me.cts.IsCancellationRequested Then
                            ret = False
                            code = "ユーザー要求により処理を中断しました。"
                            Exit Do
                        End If

                        '* プログレスバー表示更新
                        Invoke(
                        Sub()
                            Me.ToolStripProgressBar.Value += 1
                        End Sub)

                        If PlayList(i).Length > 0 Then

                            '* アイテム登録
                            If PlayList(i).IndexOf("#EXTINF") < 0 Then Me.MusicFileList.Add(PlayList(i))

                            '* ストリングスビルダーに行追記
                            sb.Append(PlayList(i))
                            sb.Append(vbCrLf)
                        End If

                        i += 1
                    Loop

                Catch ex As Exception
                    ret = False
                    code = "エラーにより処理を中断しました。"
                End Try

            End If

            '* プログレスバー非表示
            Invoke(
            Sub()
                With Me.ToolStripProgressBar
                    .Visible = False
                End With
            End Sub)

            If ret Then
                Invoke(
                Sub()
                    Me.ToolStripStatusLabel.Text = code & " / " & PlayListItemCount.ToString & "lines / " & Me.MusicFileList.Count.ToString & "files"
                    Me.Label_PlayListFileName.Text = FileName
                    Me.TextBox_PlayListData.Text = sb.ToString
                End Sub)
                MessageBox.Show("プレイリストを読込みました。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                Invoke(
                Sub()
                    Me.TextBox_PlayListData.Text = ""
                    Me.Label_PlayListFileName.Text = ""
                    Me.ToolStripStatusLabel.Text = code
                    Me.ToolStripProgressBar.Value = 0
                    Me.Label_DrogDrop.Visible = True
                End Sub)
                Me.MusicFileList.Clear()
                MessageBox.Show(code, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Return ret
        End Function)

        Return result

    End Function

    '*
    '* ファイルコピー
    '*
    Private Async Function CopyFiles(token As System.Threading.CancellationToken, FolderPath As String, PlayFileName As String) As Task(Of Boolean)

        Dim result As Boolean = Await Task.Run(
            Function() As Boolean

                Dim ret As Boolean = True
                Dim dstPath As String
                Dim srcFileName As String, dstFileName As String, strFolderPath As String
                Dim dstFullPath As String
                Dim n As Long, fmt As String
                Dim addIndexNumber As Boolean, makePlayList As Boolean, CodeUtf8 As Boolean
                Dim sb As New System.Text.StringBuilder()

                sb.Clear()

                '* 出力フォルダ名の後ろに \ を付与
                strFolderPath = FolderPath
                If strFolderPath.LastIndexOf("\"c) <> (strFolderPath.Length - 1) Then strFolderPath &= "\"

                Invoke(
                Sub()
                    '* ステータス表示更新
                    With Me.ToolStripStatusLabel
                        .Text = "ファイルコピー中"
                    End With

                    '* プログレスバー初期化
                    With Me.ToolStripProgressBar
                        .Step = 1
                        .Value = 0
                        .Maximum = Me.MusicFileList.Count
                        .Visible = True
                    End With

                    '* チェックボックスフラグ取得
                    addIndexNumber = Me.CheckBox_IndexNumber.Checked
                    makePlayList = Me.CheckBox_MakePlayList.Checked
                    CodeUtf8 = Me.CheckBox_UTF8.Checked

                    '* テキストボックス内のプレイリスト文字列取得
                    sb.Append(Me.TextBox_PlayListData.Text)
                End Sub)

                '* コピー先フォルダ作成
                dstPath = strFolderPath & System.IO.Path.GetFileNameWithoutExtension(PlayFileName)

                '* 事前にコピー先フォルダを削除
                Try
                    My.Computer.FileSystem.DeleteDirectory(dstPath, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.ThrowException)
                Catch ex As Exception
                End Try
                dstPath &= "\"

                '* コピー先フォルダを作成
                Try
                    System.IO.Directory.CreateDirectory(dstPath)
                Catch ex As Exception
                    MessageBox.Show("フォルダの作成に失敗しました。" & vbCrLf & dstPath, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try

                '* ファイル番号作成時の桁数
                n = CStr(Me.MusicFileList.Count).Length
                fmt = New String("0"c, n)

                '* ファイルコピー実行
                Dim i As Long
                i = 0
                Do While i < Me.MusicFileList.Count
                    If cts.IsCancellationRequested Then
                        MessageBox.Show("ユーザー要求により処理を中断しました。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If

                    '* プログレスバー更新
                    Invoke(
                    Sub()
                        With Me.ToolStripProgressBar
                            .Value += 1
                        End With
                    End Sub)

                    '* ファイルコピー
                    srcFileName = Me.MusicFileList(i).ToString

                    If addIndexNumber Then
                        dstFileName = (i + 1).ToString(fmt) & "_" & System.IO.Path.GetFileName(srcFileName)
                    Else
                        dstFileName = System.IO.Path.GetFileName(srcFileName)
                    End If

                    Try
                        dstFullPath = dstPath & dstFileName
                        If Not System.IO.File.Exists(dstFullPath) Then
                            System.IO.File.Copy(srcFileName, dstFullPath, True)
                        End If
                    Catch ex As Exception
                        MessageBox.Show("ファイルをコピー中にエラーが発生しました。" & vbCrLf & "コピー元：" & srcFileName & vbCrLf & "コピー先：" & dstFileName & vbCrLf & Err.Description.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End Try

                    '* プレイリストテキスト置換
                    If makePlayList Then
                        Dim sb2 As New System.Text.StringBuilder()
                        sb2.Append(dstFullPath)
                        sb2.Replace(strFolderPath, "")
                        sb2.Replace("\", "/")
                        sb.Replace(srcFileName, sb2.ToString)
                    End If

                    i += 1
                Loop

                '* プレイリストファイルを作成
                If makePlayList Then

                    '* プレイリストファイル作成フォルダ名
                    dstPath = FolderPath
                    If dstPath.LastIndexOf("\"c) <> (dstPath.Length - 1) Then dstPath &= "\"

                    '* プレイリストファイル名作成
                    dstFileName = System.IO.Path.GetFileNameWithoutExtension(PlayFileName)
                    If CodeUtf8 Then
                        dstFileName &= ".m3u8"
                    Else
                        dstFileName &= ".m3u"
                    End If

                    dstFullPath = dstPath & dstFileName

                    '* ファイル書き込み
                    Try
                        If CodeUtf8 Then
                            Using sw As New System.IO.StreamWriter(dstFullPath, False, System.Text.Encoding.UTF8)
                                sw.Write(sb)
                                sw.Close()
                            End Using
                        Else
                            Using sw As New System.IO.StreamWriter(dstFullPath, False, System.Text.Encoding.GetEncoding(932))
                                sw.Write(sb)
                                sw.Close()
                            End Using
                        End If

                    Catch ex As Exception
                        MessageBox.Show("プレイファイルを作成中にエラーが発生しました。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ret = False
                    End Try
                End If

                Return ret
            End Function
        )

        Return result

    End Function

End Class
