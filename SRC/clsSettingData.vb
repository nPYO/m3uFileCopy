
'*
'*　アプリで保存するパラーメータを Publicメンバで定義します
'*
Partial Public Class clsSetting

    Public iTuneLibraryFilePath As String = $"{System.Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)}\iTunes\iTunes Library.xml"
    Public OutputPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)
    Public FileNameMode As Integer = 1
    Public DisablePlayTime As Boolean = True
    Public RemoveTrickNumber As Boolean = False

End Class
