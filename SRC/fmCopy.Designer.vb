<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmCopy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmCopy))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_OutputPath = New System.Windows.Forms.TextBox()
        Me.Button_OpenPath = New System.Windows.Forms.Button()
        Me.GroupBox_Option = New System.Windows.Forms.GroupBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Button_ExecCopy = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.TextBox_Information = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar_CopyFile = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel_Info = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TextBox_Src = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_PlayListName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button_Stop = New System.Windows.Forms.Button()
        Me.GroupBox_Option.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "出力先"
        '
        'TextBox_OutputPath
        '
        Me.TextBox_OutputPath.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox_OutputPath.Location = New System.Drawing.Point(110, 41)
        Me.TextBox_OutputPath.Name = "TextBox_OutputPath"
        Me.TextBox_OutputPath.ReadOnly = True
        Me.TextBox_OutputPath.Size = New System.Drawing.Size(646, 25)
        Me.TextBox_OutputPath.TabIndex = 1
        Me.TextBox_OutputPath.TabStop = False
        '
        'Button_OpenPath
        '
        Me.Button_OpenPath.Image = CType(resources.GetObject("Button_OpenPath.Image"), System.Drawing.Image)
        Me.Button_OpenPath.Location = New System.Drawing.Point(762, 40)
        Me.Button_OpenPath.Name = "Button_OpenPath"
        Me.Button_OpenPath.Size = New System.Drawing.Size(47, 27)
        Me.Button_OpenPath.TabIndex = 3
        Me.Button_OpenPath.TabStop = False
        Me.Button_OpenPath.UseVisualStyleBackColor = True
        '
        'GroupBox_Option
        '
        Me.GroupBox_Option.Controls.Add(Me.CheckBox2)
        Me.GroupBox_Option.Controls.Add(Me.CheckBox1)
        Me.GroupBox_Option.Controls.Add(Me.RadioButton3)
        Me.GroupBox_Option.Controls.Add(Me.RadioButton2)
        Me.GroupBox_Option.Controls.Add(Me.RadioButton1)
        Me.GroupBox_Option.Location = New System.Drawing.Point(15, 105)
        Me.GroupBox_Option.Name = "GroupBox_Option"
        Me.GroupBox_Option.Size = New System.Drawing.Size(625, 109)
        Me.GroupBox_Option.TabIndex = 6
        Me.GroupBox_Option.TabStop = False
        Me.GroupBox_Option.Text = "出力ファイル名"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(323, 51)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(291, 22)
        Me.CheckBox2.TabIndex = 4
        Me.CheckBox2.TabStop = False
        Me.CheckBox2.Text = "ファイル名の前に付与されたトラック番号を削除"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Button_ExecCopy
        '
        Me.Button_ExecCopy.Location = New System.Drawing.Point(668, 129)
        Me.Button_ExecCopy.Name = "Button_ExecCopy"
        Me.Button_ExecCopy.Size = New System.Drawing.Size(144, 37)
        Me.Button_ExecCopy.TabIndex = 8
        Me.Button_ExecCopy.Text = "ファイル出力実行"
        Me.Button_ExecCopy.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(323, 77)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(243, 22)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.TabStop = False
        Me.CheckBox1.Text = "プレイリスト内の再生時間情報を無効化"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(22, 78)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(213, 22)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.Tag = "2"
        Me.RadioButton3.Text = "ファイル名を数字4桁の連番とする"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(22, 50)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(249, 22)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Tag = "1"
        Me.RadioButton2.Text = "元のファイル名の先頭に4桁の連番を付与"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(22, 24)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(146, 22)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Tag = "0"
        Me.RadioButton1.Text = "元のファイル名を使用"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'TextBox_Information
        '
        Me.TextBox_Information.BackColor = System.Drawing.Color.White
        Me.TextBox_Information.ForeColor = System.Drawing.Color.DimGray
        Me.TextBox_Information.Location = New System.Drawing.Point(4, 12)
        Me.TextBox_Information.MaxLength = 0
        Me.TextBox_Information.Multiline = True
        Me.TextBox_Information.Name = "TextBox_Information"
        Me.TextBox_Information.ReadOnly = True
        Me.TextBox_Information.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox_Information.Size = New System.Drawing.Size(789, 261)
        Me.TextBox_Information.TabIndex = 7
        Me.TextBox_Information.TabStop = False
        Me.TextBox_Information.WordWrap = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar_CopyFile, Me.ToolStripStatusLabel_Info})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 496)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(822, 23)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 9
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(10, 18)
        '
        'ToolStripProgressBar_CopyFile
        '
        Me.ToolStripProgressBar_CopyFile.AutoSize = False
        Me.ToolStripProgressBar_CopyFile.Name = "ToolStripProgressBar_CopyFile"
        Me.ToolStripProgressBar_CopyFile.Size = New System.Drawing.Size(640, 17)
        '
        'ToolStripStatusLabel_Info
        '
        Me.ToolStripStatusLabel_Info.AutoSize = False
        Me.ToolStripStatusLabel_Info.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel_Info.Name = "ToolStripStatusLabel_Info"
        Me.ToolStripStatusLabel_Info.Size = New System.Drawing.Size(136, 18)
        Me.ToolStripStatusLabel_Info.Text = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel_Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox_Src
        '
        Me.TextBox_Src.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox_Src.Location = New System.Drawing.Point(110, 10)
        Me.TextBox_Src.Name = "TextBox_Src"
        Me.TextBox_Src.ReadOnly = True
        Me.TextBox_Src.Size = New System.Drawing.Size(646, 25)
        Me.TextBox_Src.TabIndex = 11
        Me.TextBox_Src.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(60, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 18)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "ソース"
        '
        'TextBox_PlayListName
        '
        Me.TextBox_PlayListName.BackColor = System.Drawing.Color.White
        Me.TextBox_PlayListName.Location = New System.Drawing.Point(110, 72)
        Me.TextBox_PlayListName.MaxLength = 128
        Me.TextBox_PlayListName.Name = "TextBox_PlayListName"
        Me.TextBox_PlayListName.Size = New System.Drawing.Size(646, 25)
        Me.TextBox_PlayListName.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 18)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "プレイリスト名"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox_Information)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 212)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(797, 278)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'Button_Stop
        '
        Me.Button_Stop.Enabled = False
        Me.Button_Stop.Location = New System.Drawing.Point(668, 177)
        Me.Button_Stop.Name = "Button_Stop"
        Me.Button_Stop.Size = New System.Drawing.Size(144, 37)
        Me.Button_Stop.TabIndex = 9
        Me.Button_Stop.Text = "ファイル出力中断"
        Me.Button_Stop.UseVisualStyleBackColor = True
        '
        'fmCopy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(822, 519)
        Me.Controls.Add(Me.Button_ExecCopy)
        Me.Controls.Add(Me.Button_Stop)
        Me.Controls.Add(Me.TextBox_PlayListName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox_Src)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox_Option)
        Me.Controls.Add(Me.Button_OpenPath)
        Me.Controls.Add(Me.TextBox_OutputPath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "fmCopy"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "fmCopy"
        Me.GroupBox_Option.ResumeLayout(False)
        Me.GroupBox_Option.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_OutputPath As TextBox
    Friend WithEvents Button_OpenPath As Button
    Friend WithEvents GroupBox_Option As GroupBox
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents TextBox_Information As TextBox
    Friend WithEvents Button_ExecCopy As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents TextBox_Src As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TextBox_PlayListName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar_CopyFile As ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel_Info As ToolStripStatusLabel
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Button_Stop As Button
End Class
