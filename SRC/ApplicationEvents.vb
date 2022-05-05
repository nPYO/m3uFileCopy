Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices

'*
'*　ビルドタイムスタンプ取得機能の前準備  ver 2022.04.11
'*
'*　　プロジェクトに新規で TimeStamp.txt を追加（空のファイルが出来る）
'*    　　                 TimeStamp.txt のプロパティ「ビルドアクション」を「埋め込みリソース」「常にコピーする」に設定
'*
'*　　プロジェクト プロパティの　[コンパイル]-[ビルド イベント]-「ビルド前イベント」に、以下のコマンドを1行追加
'*　　ECHO %DATE% %TIME% > "$(ProjectDir)TimeStamp.txt"
'*
'*　　これで My.Application.buildTimeStamp からタイムスタンプが取得できるようになる
'*

Public Module NamespaceModule_MyApplication
    Public Function getNamespace() As String
        Return GetType(NamespaceModule_MyApplication).Namespace()
    End Function

    Public Function getAssemblyName() As String
        Return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
    End Function
End Module

Namespace My
    Partial Friend Class MyApplication

        Private gBuildTimeStamp As String = ""
        Private gWindowsKey As clsWindowsKey = Nothing

        '* プロパティ
        '* 　ビルドタイムスタンプ取得
        Public ReadOnly Property buildTimeStamp() As String
            Get
                Return Me.gBuildTimeStamp
            End Get
        End Property

        '* プロパティ
        '* 　Windowsキー有効無効
        Public Property enableWindowsKey() As Boolean
            Get
                Return Me.gWindowsKey.enableWindowsKey
            End Get
            Set(value As Boolean)
                Me.gWindowsKey.enableWindowsKey = value
            End Set
        End Property

        '* イベント
        '* 　アプリケーション開始時
        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

            '* ビルド日時を取得
            Dim timeStamp As String = ""
            Try
                Dim resName As String = $"{NamespaceModule_MyApplication.getNamespace()}.TimeStamp.txt"
                Using sr As New StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(resName))
                    timeStamp = sr.ReadToEnd()
                End Using

                Dim cut(,) As Integer = {{0, 4}, {5, 2}, {8, 2}, {11, 2}, {14, 2}, {17, 2}, {20, 2}}
                Dim s(6) As String
                For i As Integer = 0 To 6
                    s(i) = timeStamp.Substring(cut(i, 0), cut(i, 1)).Replace(" ", "0")
                Next
                timeStamp = $"{s(0)}{s(1)}{s(2)}-{s(3)}{s(4)}{s(5)}.{s(6)}"

            Catch ex As Exception
                timeStamp = "Unknown"

            End Try
            Me.gBuildTimeStamp = timeStamp

            '* WindowsKey無効化クラスインスタンス作成
            Me.gWindowsKey = New clsWindowsKey
            Me.gWindowsKey.enableWindowsKey = True

        End Sub

        '* イベント
        '* 　アプリケーション終了時
        Private Sub MyApplication_Shutdown(sender As Object, e As System.EventArgs) Handles Me.Shutdown

            '* WindowsKey有効化
            Me.gWindowsKey.enableWindowsKey = True

        End Sub

    End Class
End Namespace

'*
'* Windowsキー無効化クラス
'*  参考：https://ameblo.jp/ussr1917jp/entry-12553102177.html
'*
Public Class clsWindowsKey
    Implements IDisposable
    Private disposedValue As Boolean = False

    Private Const WH_KEYBOARD_LL = 13
    Shared _hHook As Integer = -1
    Public Delegate Function CallBack(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As Integer
    Private _hookproc As CallBack
    Private _Enable As Boolean = False

    '* -- Windows API 定義
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Private Overloads Shared Function SetWindowsHookEx(idHook As Integer, HookProc As CallBack, hInstance As IntPtr, wParam As Integer) As Integer
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Private Overloads Shared Function GetModuleHandle(lpModuleName As String) As IntPtr
    End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Private Overloads Shared Function CallNextHookEx(idHook As Integer, nCode As Integer, wParam As IntPtr, lParam As IntPtr) As Integer
    End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Private Overloads Shared Function UnhookWindowsHookEx(idHook As Integer) As Boolean
    End Function

    <StructLayout(LayoutKind.Sequential)> Public Structure KeyboardLLHookStruct
        Public vkCode As Integer
        Public scanCode As Integer
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure

    '*　コントラクタ
    '*
    Public Sub New()
        Me.enableWindowsKey = True
    End Sub

    '*　プロパティ :  Windowsキーを有効・無効
    '*
    Public Property enableWindowsKey() As Boolean
        Get
            Return Me._Enable
        End Get
        Set(value As Boolean)
            If value Then
                If Me._Enable Then
                    UnhookWindowsHookEx(_hHook)
                End If
            Else
                If Not Me._Enable Then
                    Me._hookproc = AddressOf KeybordHookProc
                    _hHook = SetWindowsHookEx(WH_KEYBOARD_LL, Me._hookproc, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0)
                End If
            End If
            Me._Enable = value
        End Set

    End Property

    '* メッセージプロシジャ
    '*
    Private Shared Function KeybordHookProc(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As Integer

        If (nCode < 0) Then Return CallNextHookEx(_hHook, nCode, wParam, lParam)

        Dim hookStruct As KeyboardLLHookStruct = DirectCast(Marshal.PtrToStructure(lParam, hookStruct.GetType()), KeyboardLLHookStruct)
        Select Case hookStruct.vkCode
            Case Keys.LWin, Keys.RWin
                Return 1
        End Select

        Return CallNextHookEx(_hHook, nCode, wParam, lParam)

    End Function

    '------------ Dispos実装
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: マネージ状態を破棄します (マネージ オブジェクト)。
                Me.enableWindowsKey = True
            End If
            ' TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、
            ' 下の Finalize() をオーバーライドします。
            ' TODO: 大きなフィールドを null に設定します。
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: 上の Dispose( disposing As Boolean) にアンマネージ リソース
    ' を解放するコードがある場合にのみ、
    ' Finalize() をオーバーライドします。
    ' Protected Overrides Sub Finalize()
    ' このコードを変更しないでください。クリーンアップ コードを上の
    ' Dispose( disposing As Boolean) に記述します。
    ' Dispose(False)
    ' MyBase.Finalize()
    ' End Sub

    ' このコードは、破棄可能なパターンを正しく実装できるように
    ' Visual Basic によって追加されました。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' このコードを変更しないでください。クリーンアップ コードを
        ' 上の Dispose(disposing As Boolean) に記述します。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

End Class
