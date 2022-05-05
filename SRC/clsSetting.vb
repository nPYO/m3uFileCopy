'##############################################################################
'#                       システム設定値保存クラス
'##############################################################################

'*
'* BinaryFormatterが非推奨になった為の代替えとしてDataContractSerializerをシリアライズに利用
'* 参照設定で System.Runtime.Serialization を選択しておく必要有り
'*
'* 2022.04.13
'*        プログラム部(clsSetting.vb)とデータ部(clsSettingData.vb)に分離
'*

<Serializable>
Public Class clsSetting

    '* Setting.txt ファイルを保存するフォルダ選択
    '*   0: 実行ファイルの有るフォルダ
    '*   1: 全ユーザー対象のフォルダ C:\ProgramData\nPYO
    '*   2: ユーザー毎のデータフォルダ C:\Users\UserName\AppData\Local\nPYO
    Private Shared _SettinFileLocation As Integer = 2

    '* セマフォ対応用
    Private Shared _lockObj As New Object()

    '*
    '* このクラスのファイル保存・復元
    Public Shared Function loadFile() As clsSetting
        SyncLock clsSetting._lockObj
            Dim obj As clsSetting = Nothing
            Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(clsSetting))
            Try
                Dim fileName As String = clsSetting.getSettingFileNameFullPath()
                Using stream As New System.IO.StreamReader(fileName, New System.Text.UTF8Encoding(False))
                    obj = DirectCast(serializer.Deserialize(stream), clsSetting)
                    stream.Close()
                End Using
            Catch ex1 As System.IO.FileNotFoundException '* ファイルが存在しない時の例外
                obj = Nothing
            Catch ex2 As System.IO.DirectoryNotFoundException '* ディレクトリが存在しない時の例外
                obj = Nothing
            Catch ex As Exception '* その他の例外
                Throw
            Finally
                serializer = Nothing
            End Try
            Return If(obj Is Nothing, New clsSetting, obj)
        End SyncLock
    End Function

    Public Shared Sub saveFile(obj As clsSetting)
        SyncLock clsSetting._lockObj
            Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(clsSetting))
            Try
                Dim fileName As String = clsSetting.getSettingFileNameFullPath()
                Dim di As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(fileName))
                di.Create()
                Using stream As New System.IO.StreamWriter(fileName, False, New System.Text.UTF8Encoding(False))
                    serializer.Serialize(stream, obj)
                    stream.Close()
                End Using
            Catch ex As Exception
                Throw
            Finally
                serializer = Nothing
            End Try
        End SyncLock
    End Sub

    '*
    '* 設定ファイルのフルパス名を取得
    Public Shared Function getSettingFileNameFullPath() As String
        Dim ret As String = ""

        Dim fname As String = $"{clsSetting.getExecFileName(True)}.ini"
        Select Case clsSetting._SettinFileLocation
            Case 0  '* 実行ファイルの有るフォルダ
                ret = $"{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\{fname}"

            Case 1  '* 全ユーザー対象のフォルダ C:\ProgramData
                ret = $"{System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\nPYO\{fname}"

            Case 2  '* ユーザー毎のデータフォルダ C:\Users\UserName\AppData\Local
                ret = $"{System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\nPYO\{fname}"

            Case Else
                ret = $"{fname}"
        End Select

        Return ret
    End Function

    '*
    '* 本実行ファイルのファイル名を取得
    Private Shared Function getExecFileName(Optional ExtensionExclusion As Boolean = False) As String '* Trueを指定すると拡張子無し
        Dim fileName As String = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location)
        Return If(ExtensionExclusion = True, System.IO.Path.GetFileNameWithoutExtension(fileName), fileName)
    End Function

    '*
    '* 比較用オペレータ設定
    Shared Operator =(a As clsSetting, b As clsSetting) As Boolean
        Return a._ToBinary().SequenceEqual(b._ToBinary())
    End Operator

    Shared Operator <>(a As clsSetting, b As clsSetting) As Boolean
        Return Not a._ToBinary().SequenceEqual(b._ToBinary())
    End Operator

    '*
    '* DeepClone / シリアライザ実装
    Public Function DeepClone() As clsSetting
        Return DirectCast(Me._toObject(Me._ToBinary()), clsSetting)
    End Function

    Public Shadows ReadOnly Property toString() As String
        Get
            Return System.Text.Encoding.UTF8.GetString(Me._ToBinary())
        End Get
    End Property

    Private Function _ToBinary() As Byte()
        SyncLock _lockObj
            Dim serializer As New System.Runtime.Serialization.DataContractSerializer(Me.GetType())
            Using stream As New System.IO.MemoryStream
                serializer.WriteObject(stream, Me)
                Return stream.ToArray()
            End Using
        End SyncLock
    End Function

    Private Function _toObject(bytes As Byte()) As Object
        SyncLock _lockObj
            Try
                Dim serializer As New System.Runtime.Serialization.DataContractSerializer(Me.GetType())
                Using stream As New System.IO.MemoryStream
                    stream.Write(bytes, 0, bytes.Length)
                    stream.Position = 0
                    Return serializer.ReadObject(stream)
                End Using
            Catch ex As Exception
                Throw
            End Try
        End SyncLock
    End Function

End Class
