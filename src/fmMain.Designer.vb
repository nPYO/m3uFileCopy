<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmMain
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmMain))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.Button_FileCopy = New System.Windows.Forms.Button()
        Me.Button_SelectFolder = New System.Windows.Forms.Button()
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label_PlayListFileName = New System.Windows.Forms.Label()
        Me.Label_FolderPath = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_PlayListData = New System.Windows.Forms.TextBox()
        Me.Label_DrogDrop = New System.Windows.Forms.Label()
        Me.CheckBox_MakePlayList = New System.Windows.Forms.CheckBox()
        Me.CheckBox_IndexNumber = New System.Windows.Forms.CheckBox()
        Me.CheckBox_UTF8 = New System.Windows.Forms.CheckBox()
        Me.ファイルToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.バージョンToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel, Me.ToolStripProgressBar})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 379)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(584, 22)
        Me.StatusStrip.TabIndex = 0
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.AutoSize = False
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.AutoSize = False
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(100, 16)
        '
        'Button_FileCopy
        '
        Me.Button_FileCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_FileCopy.Location = New System.Drawing.Point(473, 345)
        Me.Button_FileCopy.Name = "Button_FileCopy"
        Me.Button_FileCopy.Size = New System.Drawing.Size(99, 31)
        Me.Button_FileCopy.TabIndex = 1
        Me.Button_FileCopy.Text = "ファイルコピー開始"
        Me.Button_FileCopy.UseVisualStyleBackColor = True
        '
        'Button_SelectFolder
        '
        Me.Button_SelectFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_SelectFolder.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button_SelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_SelectFolder.Image = CType(resources.GetObject("Button_SelectFolder.Image"), System.Drawing.Image)
        Me.Button_SelectFolder.Location = New System.Drawing.Point(540, 82)
        Me.Button_SelectFolder.Name = "Button_SelectFolder"
        Me.Button_SelectFolder.Size = New System.Drawing.Size(32, 31)
        Me.Button_SelectFolder.TabIndex = 2
        Me.Button_SelectFolder.UseVisualStyleBackColor = True
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Cancel.Enabled = False
        Me.Button_Cancel.Location = New System.Drawing.Point(368, 345)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(99, 31)
        Me.Button_Cancel.TabIndex = 3
        Me.Button_Cancel.Text = "キャンセル"
        Me.Button_Cancel.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(584, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "プレイリストファイル名"
        '
        'Label_PlayListFileName
        '
        Me.Label_PlayListFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_PlayListFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_PlayListFileName.Location = New System.Drawing.Point(12, 42)
        Me.Label_PlayListFileName.Name = "Label_PlayListFileName"
        Me.Label_PlayListFileName.Size = New System.Drawing.Size(522, 21)
        Me.Label_PlayListFileName.TabIndex = 6
        Me.Label_PlayListFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_FolderPath
        '
        Me.Label_FolderPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_FolderPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_FolderPath.Location = New System.Drawing.Point(12, 87)
        Me.Label_FolderPath.Name = "Label_FolderPath"
        Me.Label_FolderPath.Size = New System.Drawing.Size(522, 21)
        Me.Label_FolderPath.TabIndex = 7
        Me.Label_FolderPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "ファイル出力フォルダ"
        '
        'TextBox_PlayListData
        '
        Me.TextBox_PlayListData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_PlayListData.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_PlayListData.Location = New System.Drawing.Point(12, 126)
        Me.TextBox_PlayListData.MaxLength = 0
        Me.TextBox_PlayListData.Multiline = True
        Me.TextBox_PlayListData.Name = "TextBox_PlayListData"
        Me.TextBox_PlayListData.ReadOnly = True
        Me.TextBox_PlayListData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox_PlayListData.Size = New System.Drawing.Size(560, 213)
        Me.TextBox_PlayListData.TabIndex = 9
        Me.TextBox_PlayListData.WordWrap = False
        '
        'Label_DrogDrop
        '
        Me.Label_DrogDrop.AutoSize = True
        Me.Label_DrogDrop.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_DrogDrop.ForeColor = System.Drawing.Color.Blue
        Me.Label_DrogDrop.Location = New System.Drawing.Point(23, 138)
        Me.Label_DrogDrop.Name = "Label_DrogDrop"
        Me.Label_DrogDrop.Size = New System.Drawing.Size(366, 16)
        Me.Label_DrogDrop.TabIndex = 10
        Me.Label_DrogDrop.Text = "ここにプレイリストファイルをドラッグ＆ドロップして下さい"
        '
        'CheckBox_MakePlayList
        '
        Me.CheckBox_MakePlayList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_MakePlayList.AutoSize = True
        Me.CheckBox_MakePlayList.Checked = True
        Me.CheckBox_MakePlayList.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_MakePlayList.Location = New System.Drawing.Point(12, 353)
        Me.CheckBox_MakePlayList.Name = "CheckBox_MakePlayList"
        Me.CheckBox_MakePlayList.Size = New System.Drawing.Size(108, 16)
        Me.CheckBox_MakePlayList.TabIndex = 11
        Me.CheckBox_MakePlayList.Text = "プレイリストを出力"
        Me.CheckBox_MakePlayList.UseVisualStyleBackColor = True
        '
        'CheckBox_IndexNumber
        '
        Me.CheckBox_IndexNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_IndexNumber.AutoSize = True
        Me.CheckBox_IndexNumber.Location = New System.Drawing.Point(184, 353)
        Me.CheckBox_IndexNumber.Name = "CheckBox_IndexNumber"
        Me.CheckBox_IndexNumber.Size = New System.Drawing.Size(177, 16)
        Me.CheckBox_IndexNumber.TabIndex = 12
        Me.CheckBox_IndexNumber.Text = "ファイル名の先頭に連番を付ける"
        Me.CheckBox_IndexNumber.UseVisualStyleBackColor = True
        '
        'CheckBox_UTF8
        '
        Me.CheckBox_UTF8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_UTF8.AutoSize = True
        Me.CheckBox_UTF8.Checked = True
        Me.CheckBox_UTF8.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_UTF8.Location = New System.Drawing.Point(126, 353)
        Me.CheckBox_UTF8.Name = "CheckBox_UTF8"
        Me.CheckBox_UTF8.Size = New System.Drawing.Size(52, 16)
        Me.CheckBox_UTF8.TabIndex = 13
        Me.CheckBox_UTF8.Text = "UTF8"
        Me.CheckBox_UTF8.UseVisualStyleBackColor = True
        '
        'ファイルToolStripMenuItem
        '
        Me.ファイルToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.バージョンToolStripMenuItem})
        Me.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem"
        Me.ファイルToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.ファイルToolStripMenuItem.Text = "ファイル"
        '
        'バージョンToolStripMenuItem
        '
        Me.バージョンToolStripMenuItem.Name = "バージョンToolStripMenuItem"
        Me.バージョンToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.バージョンToolStripMenuItem.Text = "バージョン"
        '
        'fmMain
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 401)
        Me.Controls.Add(Me.CheckBox_UTF8)
        Me.Controls.Add(Me.CheckBox_IndexNumber)
        Me.Controls.Add(Me.CheckBox_MakePlayList)
        Me.Controls.Add(Me.Label_DrogDrop)
        Me.Controls.Add(Me.TextBox_PlayListData)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label_FolderPath)
        Me.Controls.Add(Me.Label_PlayListFileName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button_Cancel)
        Me.Controls.Add(Me.Button_SelectFolder)
        Me.Controls.Add(Me.Button_FileCopy)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(600, 440)
        Me.Name = "fmMain"
        Me.Text = "m3u File copy"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents ToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar As ToolStripProgressBar
    Friend WithEvents Button_FileCopy As Button
    Friend WithEvents Button_SelectFolder As Button
    Friend WithEvents Button_Cancel As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Label1 As Label
    Friend WithEvents Label_PlayListFileName As Label
    Friend WithEvents Label_FolderPath As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox_PlayListData As TextBox
    Friend WithEvents Label_DrogDrop As Label
    Friend WithEvents CheckBox_MakePlayList As CheckBox
    Friend WithEvents CheckBox_IndexNumber As CheckBox
    Friend WithEvents CheckBox_UTF8 As CheckBox
    Friend WithEvents ファイルToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents バージョンToolStripMenuItem As ToolStripMenuItem
End Class
