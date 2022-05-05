Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MessageBox))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel_bottom = New System.Windows.Forms.Panel()
        Me.PictureBox_Icon = New System.Windows.Forms.PictureBox()
        Me.Label_Message = New System.Windows.Forms.Label()
        Me.PictureBox_Exclamation = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Error = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Question = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Information = New System.Windows.Forms.PictureBox()
        Me.Panel_bottom.SuspendLayout()
        CType(Me.PictureBox_Icon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Exclamation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Error, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Question, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Information, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button1.Location = New System.Drawing.Point(236, 5)
        Me.Button1.Margin = New System.Windows.Forms.Padding(8, 3, 8, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 31)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button2.Location = New System.Drawing.Point(135, 5)
        Me.Button2.Margin = New System.Windows.Forms.Padding(8, 3, 8, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 31)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button3.Location = New System.Drawing.Point(34, 5)
        Me.Button3.Margin = New System.Windows.Forms.Padding(8, 3, 8, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 31)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Panel_bottom
        '
        Me.Panel_bottom.BackColor = System.Drawing.SystemColors.Control
        Me.Panel_bottom.Controls.Add(Me.Button3)
        Me.Panel_bottom.Controls.Add(Me.Button1)
        Me.Panel_bottom.Controls.Add(Me.Button2)
        Me.Panel_bottom.Location = New System.Drawing.Point(0, 59)
        Me.Panel_bottom.Name = "Panel_bottom"
        Me.Panel_bottom.Size = New System.Drawing.Size(334, 41)
        Me.Panel_bottom.TabIndex = 4
        '
        'PictureBox_Icon
        '
        Me.PictureBox_Icon.Location = New System.Drawing.Point(17, 12)
        Me.PictureBox_Icon.Name = "PictureBox_Icon"
        Me.PictureBox_Icon.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox_Icon.TabIndex = 5
        Me.PictureBox_Icon.TabStop = False
        '
        'Label_Message
        '
        Me.Label_Message.Location = New System.Drawing.Point(65, 19)
        Me.Label_Message.Name = "Label_Message"
        Me.Label_Message.Size = New System.Drawing.Size(99, 18)
        Me.Label_Message.TabIndex = 6
        Me.Label_Message.Text = "Message"
        '
        'PictureBox_Exclamation
        '
        Me.PictureBox_Exclamation.Image = CType(resources.GetObject("PictureBox_Exclamation.Image"), System.Drawing.Image)
        Me.PictureBox_Exclamation.Location = New System.Drawing.Point(204, 12)
        Me.PictureBox_Exclamation.Name = "PictureBox_Exclamation"
        Me.PictureBox_Exclamation.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox_Exclamation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox_Exclamation.TabIndex = 7
        Me.PictureBox_Exclamation.TabStop = False
        Me.PictureBox_Exclamation.Visible = False
        '
        'PictureBox_Error
        '
        Me.PictureBox_Error.Image = CType(resources.GetObject("PictureBox_Error.Image"), System.Drawing.Image)
        Me.PictureBox_Error.Location = New System.Drawing.Point(238, 12)
        Me.PictureBox_Error.Name = "PictureBox_Error"
        Me.PictureBox_Error.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox_Error.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox_Error.TabIndex = 8
        Me.PictureBox_Error.TabStop = False
        Me.PictureBox_Error.Visible = False
        '
        'PictureBox_Question
        '
        Me.PictureBox_Question.Image = CType(resources.GetObject("PictureBox_Question.Image"), System.Drawing.Image)
        Me.PictureBox_Question.Location = New System.Drawing.Point(272, 12)
        Me.PictureBox_Question.Name = "PictureBox_Question"
        Me.PictureBox_Question.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox_Question.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox_Question.TabIndex = 9
        Me.PictureBox_Question.TabStop = False
        Me.PictureBox_Question.Visible = False
        '
        'PictureBox_Information
        '
        Me.PictureBox_Information.Image = CType(resources.GetObject("PictureBox_Information.Image"), System.Drawing.Image)
        Me.PictureBox_Information.Location = New System.Drawing.Point(170, 12)
        Me.PictureBox_Information.Name = "PictureBox_Information"
        Me.PictureBox_Information.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox_Information.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox_Information.TabIndex = 10
        Me.PictureBox_Information.TabStop = False
        Me.PictureBox_Information.Visible = False
        '
        'MessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(335, 100)
        Me.Controls.Add(Me.PictureBox_Information)
        Me.Controls.Add(Me.PictureBox_Question)
        Me.Controls.Add(Me.PictureBox_Error)
        Me.Controls.Add(Me.PictureBox_Exclamation)
        Me.Controls.Add(Me.Label_Message)
        Me.Controls.Add(Me.PictureBox_Icon)
        Me.Controls.Add(Me.Panel_bottom)
        Me.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MessageBox"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "MessageBox"
        Me.TopMost = True
        Me.Panel_bottom.ResumeLayout(False)
        CType(Me.PictureBox_Icon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Exclamation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Error, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Question, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Information, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Panel_bottom As Panel
    Friend WithEvents PictureBox_Icon As PictureBox
    Friend WithEvents Label_Message As Label
    Friend WithEvents PictureBox_Exclamation As PictureBox
    Friend WithEvents PictureBox_Error As PictureBox
    Friend WithEvents PictureBox_Question As PictureBox
    Friend WithEvents PictureBox_Information As PictureBox
End Class
