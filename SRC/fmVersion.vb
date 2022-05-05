Public Class fmVersion

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub fmVersion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = getAssemblyName()
        Me.TextBox_SettingFile.Text = clsSetting.getSettingFileNameFullPath()
        Me.Label_Build.Text = $"Build: {My.Application.buildTimeStamp()}"
    End Sub

End Class