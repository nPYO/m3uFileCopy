'*
'*　.net 標準より大きい MessageBox クラス  2022.04.11 - PM
'*
'*　他のプロジェクトに流用する方法
'*　　・MessageBox.Designer.vb
'*    ・MessageBox.resx
'*    ・MessageBox.vb
'*  上の3つのファイルをプロジェクトフォルダにコピー
'*  プロジェクトに「追加」→「既存の項目」をクリックして、「MessageBox.vb」だけを追加すると暫くしてフォームとして登録される
'*
'* .net 標準の MessageBox と同じ使い方ができる
'*
Imports System.Windows.Forms
Imports System.Drawing

Public Class MessageBox
    Private Shared _SoundMute As Boolean = True
    Private Shared _OwnerForm As Form = Nothing

    '*
    '* 親フォームの Load イベントから一度呼んでおくと親フォームの中央に表示されるようになる（デフォルトでは画面中央）
    Public Shared Sub Begin(OwnerForm As Form, Optional SoundMute As Boolean = False)
        _SoundMute = SoundMute
        _OwnerForm = OwnerForm
    End Sub

    Public Shared Shadows Function Show(message As String, Optional caption As String = "Information", Optional buttons As MessageBoxButtons = MessageBoxButtons.OK, Optional icon As MessageBoxIcon = MessageBoxIcon.Information, Optional defaultBtn As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult

        If (_OwnerForm IsNot Nothing) AndAlso (_OwnerForm.IsDisposed) Then _OwnerForm = Nothing
        Using fm As New MessageBox
            fm._Text = message
            fm._Caption = caption
            fm._buttons = buttons
            fm._icon = icon
            fm._defaultBtn = defaultBtn
            fm.StartPosition = If(_OwnerForm IsNot Nothing, FormStartPosition.CenterParent, FormStartPosition.CenterScreen)

            If _OwnerForm Is Nothing Then
                fm.ShowDialog()
            Else
                fm.ShowDialog(_OwnerForm)
            End If

            Return fm._ret
        End Using

    End Function

    Private _Caption As String = ""
    Private _Text As String = ""
    Private _buttons As MessageBoxButtons = MessageBoxButtons.OK
    Private _icon As MessageBoxIcon = MessageBoxIcon.Information
    Private _defaultBtn As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1
    Private _ret As DialogResult = DialogResult.Cancel

    Private Sub MessageBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = Me._Caption            '* キャプションをセット

        If Me._Text.Split(vbCrLf).Count > 1 Then Me.Label_Message.Top -= 7 '* 複数行の場合はラベルの位置を微調整
        If Me._icon = MessageBoxIcon.None Then Me.Label_Message.Left = Me.PictureBox_Icon.Left

        '* 自動サイズモードでラベルに文字列を描画してラベルのサイズを取得する
        Me.Label_Message.AutoSize = True            '* ラベルの自動サイズをオン
        Me.Label_Message.Text = Me._Text            '* ラベルに文字列をセット（ラベルのサイズが変わる）
        Dim lbSize As Size = Me.Label_Message.Size
        Me.Label_Message.AutoSize = False           '* ラベル自動サイズをオフにする
        Me.Label_Message.Size = lbSize              '* ラベルのサイズを再設定

        '* フォームとボトムパネルの位置・サイズ調整
        Me.Panel_bottom.Top = Me.PictureBox_Icon.Top + (Me.Label_Message.Height + Me.Label_Message.Top) '* PictureBox_Iconを基準として縦位置を計算
        Me.Height = Me.Panel_bottom.Top + Me.Panel_bottom.Height + (Me.Height - Me.ClientSize.Height)
        Me.Width = Me.PictureBox_Icon.Left + (Me.Label_Message.Left + Label_Message.Width) + (Me.Width - Me.ClientSize.Width) '* PictureBox_Iconを基準として横幅を計算
        If Me.Width <= 350 Then Me.Width = 350
        Me.Panel_bottom.Width = Me.ClientSize.Width

        '* ボタン表示設定
        Dim buttonCount As Integer = 0
        Select Case Me._buttons
            Case MessageBoxButtons.AbortRetryIgnore
                Me.Button3.Text = "中止" : Me.Button3.Visible = True : Me.Button3.Tag = DialogResult.Abort
                Me.Button2.Text = "再試行" : Me.Button2.Visible = True : Me.Button2.Tag = DialogResult.Retry
                Me.Button1.Text = "無視" : Me.Button1.Visible = True : Me.Button1.Tag = DialogResult.Ignore
                buttonCount = 3

            Case MessageBoxButtons.OK
                Me.Button3.Text = "" : Me.Button3.Visible = False
                Me.Button2.Text = "" : Me.Button2.Visible = False
                Me.Button1.Text = "OK" : Me.Button1.Visible = True : Me.Button1.Tag = DialogResult.OK
                buttonCount = 1

            Case MessageBoxButtons.OKCancel
                Me.Button3.Text = "" : Me.Button3.Visible = False
                Me.Button2.Text = "OK" : Me.Button2.Visible = True : Me.Button2.Tag = DialogResult.Abort
                Me.Button1.Text = "キャンセル" : Me.Button1.Visible = True : Me.Button1.Tag = DialogResult.Cancel
                buttonCount = 2

            Case MessageBoxButtons.RetryCancel
                Me.Button3.Text = "" : Me.Button3.Visible = False
                Me.Button2.Text = "再試行" : Me.Button2.Visible = True : Me.Button2.Tag = DialogResult.Retry
                Me.Button1.Text = "キャンセル" : Me.Button1.Visible = True : Me.Button1.Tag = DialogResult.Cancel
                buttonCount = 2

            Case MessageBoxButtons.YesNo
                Me.Button3.Text = "" : Me.Button3.Visible = False
                Me.Button2.Text = "はい" : Me.Button2.Visible = True : Me.Button2.Tag = DialogResult.Yes
                Me.Button1.Text = "いいえ" : Me.Button1.Visible = True : Me.Button1.Tag = DialogResult.No
                buttonCount = 2

            Case MessageBoxButtons.YesNoCancel
                Me.Button3.Text = "はい" : Me.Button3.Visible = True : Me.Button3.Tag = DialogResult.Yes
                Me.Button2.Text = "いいえ" : Me.Button2.Visible = True : Me.Button2.Tag = DialogResult.No
                Me.Button1.Text = "キャンセル" : Me.Button1.Visible = True : Me.Button1.Tag = DialogResult.Cancel
                buttonCount = 3

            Case Else
                Throw New Exception("パラメータが無効")

        End Select

        '* 表示アイコン画像設定
        Select Case Me._icon
            Case MessageBoxIcon.Asterisk, MessageBoxIcon.Information
                Me.PictureBox_Icon.Image = Me.PictureBox_Information.Image

            Case MessageBoxIcon.Error, MessageBoxIcon.Hand, MessageBoxIcon.Stop
                Me.PictureBox_Icon.Image = Me.PictureBox_Error.Image

            Case MessageBoxIcon.Exclamation, MessageBoxIcon.Warning
                Me.PictureBox_Icon.Image = Me.PictureBox_Exclamation.Image

            Case MessageBoxIcon.Question
                Me.PictureBox_Icon.Image = Me.PictureBox_Question.Image

            Case MessageBoxIcon.None
                Me.PictureBox_Icon.Image = Nothing

            Case Else
                Throw New Exception("パラメータが無効")
        End Select

        '* デフォルトボタンにフォーカスを設定
        Select Case Me._defaultBtn
            Case MessageBoxDefaultButton.Button1
                If buttonCount = 3 Then Me.ActiveControl = Me.Button3
                If buttonCount = 2 Then Me.ActiveControl = Me.Button2
                If buttonCount = 1 Then Me.ActiveControl = Me.Button1

            Case MessageBoxDefaultButton.Button2
                If buttonCount = 3 Then Me.ActiveControl = Me.Button2
                If buttonCount = 2 Then Me.ActiveControl = Me.Button1
                If buttonCount = 1 Then Me.ActiveControl = Me.Button1

            Case MessageBoxDefaultButton.Button3
                Me.ActiveControl = Me.Button1

            Case Else
                Throw New Exception("パラメータが無効")
        End Select

        If Not MessageBox._SoundMute Then System.Media.SystemSounds.Asterisk.Play()
    End Sub

    Private Sub MessageBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button3.Click, Button2.Click, Button1.Click
        Me._ret = DirectCast(sender, Button).Tag
        Me.Close()
    End Sub

End Class