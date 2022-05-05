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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TextBox_Information = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel_LibraryFile = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem_File = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_FileCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_OpenITunes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Help = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_AppInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.WMP = New AxWMPLib.AxWindowsMediaPlayer()
        Me.DataGridView_TrackList = New System.Windows.Forms.DataGridView()
        Me.DataGridView_PlayList = New System.Windows.Forms.DataGridView()
        Me.GroupBox_PlayList = New System.Windows.Forms.GroupBox()
        Me.GroupBox_PlayListItem = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button_ReLoad = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.WMP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView_TrackList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView_PlayList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_PlayList.SuspendLayout()
        Me.GroupBox_PlayListItem.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox_Information
        '
        Me.TextBox_Information.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Information.BackColor = System.Drawing.Color.White
        Me.TextBox_Information.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_Information.ForeColor = System.Drawing.Color.DimGray
        Me.TextBox_Information.Location = New System.Drawing.Point(4, 15)
        Me.TextBox_Information.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Information.Multiline = True
        Me.TextBox_Information.Name = "TextBox_Information"
        Me.TextBox_Information.ReadOnly = True
        Me.TextBox_Information.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox_Information.Size = New System.Drawing.Size(995, 142)
        Me.TextBox_Information.TabIndex = 1
        Me.TextBox_Information.TabStop = False
        Me.TextBox_Information.WordWrap = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel_LibraryFile})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 683)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1274, 23)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel_LibraryFile
        '
        Me.ToolStripStatusLabel_LibraryFile.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel_LibraryFile.ForeColor = System.Drawing.Color.DimGray
        Me.ToolStripStatusLabel_LibraryFile.Name = "ToolStripStatusLabel_LibraryFile"
        Me.ToolStripStatusLabel_LibraryFile.Size = New System.Drawing.Size(28, 18)
        Me.ToolStripStatusLabel_LibraryFile.Text = "....."
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_File, Me.ToolStripMenuItem_Help})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1274, 28)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem_File
        '
        Me.ToolStripMenuItem_File.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_FileCopy, Me.ToolStripMenuItem_OpenITunes})
        Me.ToolStripMenuItem_File.Name = "ToolStripMenuItem_File"
        Me.ToolStripMenuItem_File.Size = New System.Drawing.Size(73, 24)
        Me.ToolStripMenuItem_File.Text = "ファイル"
        '
        'ToolStripMenuItem_FileCopy
        '
        Me.ToolStripMenuItem_FileCopy.Name = "ToolStripMenuItem_FileCopy"
        Me.ToolStripMenuItem_FileCopy.Size = New System.Drawing.Size(274, 24)
        Me.ToolStripMenuItem_FileCopy.Text = "プレイリストファイル出力"
        '
        'ToolStripMenuItem_OpenITunes
        '
        Me.ToolStripMenuItem_OpenITunes.Name = "ToolStripMenuItem_OpenITunes"
        Me.ToolStripMenuItem_OpenITunes.Size = New System.Drawing.Size(274, 24)
        Me.ToolStripMenuItem_OpenITunes.Text = "iTunesライブラリファイルを開く"
        '
        'ToolStripMenuItem_Help
        '
        Me.ToolStripMenuItem_Help.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_AppInfo})
        Me.ToolStripMenuItem_Help.Name = "ToolStripMenuItem_Help"
        Me.ToolStripMenuItem_Help.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripMenuItem_Help.Text = "ヘルプ"
        '
        'ToolStripMenuItem_AppInfo
        '
        Me.ToolStripMenuItem_AppInfo.Name = "ToolStripMenuItem_AppInfo"
        Me.ToolStripMenuItem_AppInfo.Size = New System.Drawing.Size(208, 24)
        Me.ToolStripMenuItem_AppInfo.Text = "アプリケーション情報"
        '
        'WMP
        '
        Me.WMP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WMP.Enabled = True
        Me.WMP.Location = New System.Drawing.Point(1023, 524)
        Me.WMP.Name = "WMP"
        Me.WMP.OcxState = CType(resources.GetObject("WMP.OcxState"), System.Windows.Forms.AxHost.State)
        Me.WMP.Size = New System.Drawing.Size(239, 152)
        Me.WMP.TabIndex = 3
        Me.WMP.TabStop = False
        '
        'DataGridView_TrackList
        '
        Me.DataGridView_TrackList.AllowUserToAddRows = False
        Me.DataGridView_TrackList.AllowUserToDeleteRows = False
        Me.DataGridView_TrackList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.DataGridView_TrackList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView_TrackList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView_TrackList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_TrackList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView_TrackList.ColumnHeadersHeight = 28
        Me.DataGridView_TrackList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView_TrackList.ColumnHeadersVisible = False
        Me.DataGridView_TrackList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView_TrackList.EnableHeadersVisualStyles = False
        Me.DataGridView_TrackList.Location = New System.Drawing.Point(7, 31)
        Me.DataGridView_TrackList.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView_TrackList.MultiSelect = False
        Me.DataGridView_TrackList.Name = "DataGridView_TrackList"
        Me.DataGridView_TrackList.ReadOnly = True
        Me.DataGridView_TrackList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_TrackList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView_TrackList.RowHeadersVisible = False
        Me.DataGridView_TrackList.RowHeadersWidth = 64
        Me.DataGridView_TrackList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(231, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridView_TrackList.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView_TrackList.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGridView_TrackList.RowTemplate.Height = 24
        Me.DataGridView_TrackList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView_TrackList.Size = New System.Drawing.Size(858, 440)
        Me.DataGridView_TrackList.TabIndex = 2
        '
        'DataGridView_PlayList
        '
        Me.DataGridView_PlayList.AllowUserToAddRows = False
        Me.DataGridView_PlayList.AllowUserToDeleteRows = False
        Me.DataGridView_PlayList.AllowUserToResizeRows = False
        Me.DataGridView_PlayList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridView_PlayList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_PlayList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView_PlayList.ColumnHeadersHeight = 28
        Me.DataGridView_PlayList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView_PlayList.ColumnHeadersVisible = False
        Me.DataGridView_PlayList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView_PlayList.EnableHeadersVisualStyles = False
        Me.DataGridView_PlayList.Location = New System.Drawing.Point(7, 31)
        Me.DataGridView_PlayList.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView_PlayList.MultiSelect = False
        Me.DataGridView_PlayList.Name = "DataGridView_PlayList"
        Me.DataGridView_PlayList.ReadOnly = True
        Me.DataGridView_PlayList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_PlayList.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView_PlayList.RowHeadersVisible = False
        Me.DataGridView_PlayList.RowHeadersWidth = 64
        Me.DataGridView_PlayList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(231, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridView_PlayList.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView_PlayList.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGridView_PlayList.RowTemplate.Height = 24
        Me.DataGridView_PlayList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView_PlayList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView_PlayList.Size = New System.Drawing.Size(355, 438)
        Me.DataGridView_PlayList.TabIndex = 8
        '
        'GroupBox_PlayList
        '
        Me.GroupBox_PlayList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_PlayList.Controls.Add(Me.DataGridView_PlayList)
        Me.GroupBox_PlayList.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox_PlayList.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox_PlayList.Location = New System.Drawing.Point(15, 43)
        Me.GroupBox_PlayList.Name = "GroupBox_PlayList"
        Me.GroupBox_PlayList.Size = New System.Drawing.Size(369, 476)
        Me.GroupBox_PlayList.TabIndex = 9
        Me.GroupBox_PlayList.TabStop = False
        Me.GroupBox_PlayList.Text = "全てのプレイリスト"
        '
        'GroupBox_PlayListItem
        '
        Me.GroupBox_PlayListItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_PlayListItem.Controls.Add(Me.DataGridView_TrackList)
        Me.GroupBox_PlayListItem.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox_PlayListItem.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox_PlayListItem.Location = New System.Drawing.Point(390, 41)
        Me.GroupBox_PlayListItem.Name = "GroupBox_PlayListItem"
        Me.GroupBox_PlayListItem.Size = New System.Drawing.Size(872, 478)
        Me.GroupBox_PlayListItem.TabIndex = 10
        Me.GroupBox_PlayListItem.TabStop = False
        Me.GroupBox_PlayListItem.Text = "プレイリスト"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Button_ReLoad)
        Me.GroupBox1.Controls.Add(Me.TextBox_Information)
        Me.GroupBox1.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(15, 514)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1002, 163)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'Button_ReLoad
        '
        Me.Button_ReLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_ReLoad.Location = New System.Drawing.Point(906, 125)
        Me.Button_ReLoad.Name = "Button_ReLoad"
        Me.Button_ReLoad.Size = New System.Drawing.Size(74, 30)
        Me.Button_ReLoad.TabIndex = 2
        Me.Button_ReLoad.TabStop = False
        Me.Button_ReLoad.Text = "再読込"
        Me.Button_ReLoad.UseVisualStyleBackColor = True
        '
        'fmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1274, 706)
        Me.Controls.Add(Me.GroupBox_PlayListItem)
        Me.Controls.Add(Me.GroupBox_PlayList)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.WMP)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "fmMain"
        Me.Text = "m3uFileCopy"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.WMP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView_TrackList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView_PlayList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_PlayList.ResumeLayout(False)
        Me.GroupBox_PlayListItem.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox_Information As TextBox
    Friend WithEvents WMP As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem_File As ToolStripMenuItem
    Friend WithEvents DataGridView_TrackList As DataGridView
    Friend WithEvents DataGridView_PlayList As DataGridView
    Friend WithEvents GroupBox_PlayList As GroupBox
    Friend WithEvents GroupBox_PlayListItem As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ToolStripStatusLabel_LibraryFile As ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem_OpenITunes As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Help As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_AppInfo As ToolStripMenuItem
    Friend WithEvents Button_ReLoad As Button
    Friend WithEvents ToolStripMenuItem_FileCopy As ToolStripMenuItem
End Class
