Module COMMON

    Public Setting As clsSetting

End Module

Namespace My
    Partial Friend Class MyApplication

        Private Sub app_startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Setting = clsSetting.loadFile()
        End Sub

        Private Sub app_shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
            clsSetting.saveFile(Setting)
        End Sub

    End Class

End Namespace