
Public Class iTuneLibrary

    Public Class LibraryInformation
        Public HeaderLineCount As Integer = -1
        Public PlayListVersion As String = ""
        Public MajorVersion As Integer = -1
        Public MinorVersion As Integer = -1
        Public ApplicationVersion As String = ""
        Public DateString As String = ""
        Public Features As Integer = -1
        Public ShowContentRatings As Boolean = False
        Public LibraryPersistentID As String = ""
    End Class

    Public Class TrackInfo
        Public TrackID As Integer = -1
        Public Size As Integer = -1
        Public TotalTime As Integer = -1
        Public DiscNumber As Integer = -1
        Public DiscCount As Integer = -1
        Public TrackNumber As Integer = -1
        Public TrackCount As Integer = -1
        Public Year As Integer = 1900
        Public DateModified As String = ""
        Public DateAdded As String = ""
        Public BitRate As Integer = -1
        Public SampleRate As Integer
        Public ReleaseDate As String = ""
        Public PersistentID As String = ""
        Public TrackType As String = ""
        Public Purchased As Boolean = -1
        Public FileFolderCount As Integer = -1
        Public LibraryFolderCount As Integer = -1
        Public Name As String = ""
        Public Artist As String = ""
        Public AlbumArtist As String = ""
        Public Composer As String = ""
        Public Album As String = ""
        Public Genre As String = ""
        Public Kind As String = ""
        Public SortName As String = ""
        Public SortAlbum As String = ""
        Public SortArtist As String = ""
        Public Location As String = ""
    End Class

    Public Class PlayListInfo
        Public Visible As Boolean = True
        Public PlayListID As Integer = -1
        Public PlayListName As String = ""
        Public PlaylistPersistentID As String = ""
        Public DistinguishedKind As Integer = -1
        Public AllItems As Boolean = False
        Public SmartInfo As New List(Of String)
        Public SmartCriteria As New List(Of String)
        Public TrackIdList As New List(Of Integer)
        Public TableData As DataTable = Nothing
    End Class

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property GetLastError() As String
        Get
            Return Me._LastError
        End Get
    End Property

    ''' <summary>
    ''' トラックデータリスト取得
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property TrackDatas() As TrackInfo()
        Get
            Return Me._TrackList.Values.ToArray
        End Get
    End Property

    ''' <summary>
    ''' トラックデータ取得
    ''' </summary>
    ''' <param name="TrackID"></param>
    ''' <returns></returns>
    Public ReadOnly Property TrackDatas(TrackID As Integer) As TrackInfo
        Get
            Return If(Me._TrackList.ContainsKey(TrackID), Me._TrackList(TrackID), Nothing)
        End Get
    End Property

    ''' <summary>
    ''' プレイリスト一覧をデータテーブルとして取得
    ''' </summary>
    ''' <returns>DataTable</returns>
    Public Function GetPlayListTable() As DataTable

        Dim tbl As New DataTable("PlayList")
        tbl.Columns.Add("Name", GetType(String))
        tbl.Columns.Add("Playlist ID", GetType(Integer))

        For Each pl As iTuneLibrary.PlayListInfo In Me._PlayList.Values
            If pl.Visible AndAlso pl.TrackIdList.Count > 0 Then
                Dim row As DataRow = tbl.NewRow()
                row("Name") = pl.PlayListName
                row("Playlist ID") = pl.PlayListID
                tbl.Rows.Add(row)
            End If
        Next

        Return tbl
    End Function

    ''' <summary>
    ''' 指定プレイリスト番号に該当するプレイリスト内トラックデータ一覧をDataTableで取得
    ''' </summary>
    ''' <param name="PlayListId">-1:全てのトラック情報</param>
    ''' <returns></returns>
    Public Function GetPlayListItemTable(PlayListId As Integer) As DataTable

        If PlayListId >= 0 Then
            If Me._PlayList.ContainsKey(PlayListId) Then
                Dim plList As PlayListInfo = Me._PlayList(PlayListId)
                If plList.TableData Is Nothing Then
                    Dim tbl As New DataTable(plList.PlayListName)
                    Me.CreateColumns(tbl)
                    For Each trkID As Integer In plList.TrackIdList
                        If Not Me._TrackList.ContainsKey(trkID) Then
                            Me._LastError = $"トラックID {trkID.ToString } が存在しません"
                            Return Nothing
                        End If
                        Dim trk As TrackInfo = Me._TrackList(trkID)
                        Me.AddTableRow(tbl, trk)
                    Next
                    plList.TableData = tbl
                End If
                Return plList.TableData
            End If
        End If

        Dim tb As New DataTable("-")
        Me.CreateColumns(tb)
        If PlayListId = -1 Then
            For Each trk As TrackInfo In Me._TrackList.Values
                Me.AddTableRow(tb, trk)
            Next
        End If

        Return tb
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="tbl"></param>
    Private Sub CreateColumns(tbl As DataTable)
        tbl.Columns.Add("Name", GetType(String))
        tbl.Columns.Add("Artist", GetType(String))
        tbl.Columns.Add("Album", GetType(String))
        tbl.Columns.Add("Year", GetType(Integer))
        tbl.Columns.Add("Genre", GetType(String))
        tbl.Columns.Add("Time", GetType(String))

        tbl.Columns.Add("TotalTime", GetType(Integer))
        tbl.Columns.Add("Track Type", GetType(String))
        tbl.Columns.Add("Track ID", GetType(Integer))
        tbl.Columns.Add("Size", GetType(Integer))
        tbl.Columns.Add("Disc Number", GetType(Integer))
        tbl.Columns.Add("Disc Count", GetType(Integer))
        tbl.Columns.Add("Track Number", GetType(Integer))
        tbl.Columns.Add("Track Count", GetType(Integer))
        tbl.Columns.Add("Date Modified", GetType(String))
        tbl.Columns.Add("Date Added", GetType(String))
        tbl.Columns.Add("Bit Rate", GetType(Integer))
        tbl.Columns.Add("Sample Rate", GetType(Integer))
        tbl.Columns.Add("Release Date", GetType(String))
        tbl.Columns.Add("Persistent ID", GetType(String))
        tbl.Columns.Add("Purchased", GetType(Integer))
        tbl.Columns.Add("File Folder Count", GetType(Integer))
        tbl.Columns.Add("Library Folder Count", GetType(Integer))
        tbl.Columns.Add("Album Artist", GetType(String))
        tbl.Columns.Add("Composer", GetType(String))
        tbl.Columns.Add("Kind", GetType(String))
        tbl.Columns.Add("Sort Name", GetType(String))
        tbl.Columns.Add("Sort Album", GetType(String))
        tbl.Columns.Add("Sort Artist", GetType(String))
        tbl.Columns.Add("Location", GetType(String))
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="tbl"></param>
    ''' <param name="trk"></param>
    Private Sub AddTableRow(tbl As DataTable, trk As TrackInfo)
        Dim row As DataRow = tbl.NewRow()
        row("Name") = trk.Name
        row("Time") = (trk.TotalTime \ 60000).ToString("00") & ":" & ((trk.TotalTime / 1000) Mod 60).ToString("00")
        row("TotalTime") = trk.TotalTime
        row("Artist") = trk.Artist
        row("Album") = trk.Album
        row("Genre") = trk.Genre
        row("Track Type") = trk.TrackType
        row("Track ID") = trk.TrackID
        row("Size") = trk.Size
        row("Disc Number") = trk.DiscNumber
        row("Disc Count") = trk.DiscCount
        row("Track Number") = trk.TrackNumber
        row("Track Count") = trk.TrackCount
        row("Year") = trk.Year
        row("Date Modified") = trk.DateModified
        row("Date Added") = trk.DateAdded
        row("Bit Rate") = trk.BitRate
        row("Release Date") = trk.ReleaseDate
        row("Persistent ID") = trk.PersistentID
        row("Purchased") = trk.Purchased
        row("File Folder Count") = trk.FileFolderCount
        row("Album Artist") = trk.AlbumArtist
        row("Composer") = trk.Composer
        row("Kind") = trk.Kind
        row("Sort Name") = StrConv(trk.Name, vbKatakana Or vbNarrow Or vbUpperCase).Replace(" ", "")
        row("Sort Album") = StrConv(trk.Album, vbKatakana Or vbNarrow Or vbUpperCase).Replace(" ", "")
        row("Sort Artist") = StrConv(trk.Artist, vbKatakana Or vbNarrow Or vbUpperCase).Replace(" ", "")
        row("Location") = trk.Location
        tbl.Rows.Add(row)
    End Sub

    Private _FileName As String
    Private _Src As String()
    Private _Header As LibraryInformation
    Private _TrackList As Dictionary(Of Integer, TrackInfo)
    Private _PlayList As Dictionary(Of Integer, PlayListInfo)
    Private _LastError As String = ""

    ''' <summary>
    ''' ライブラリのヘッダ情報
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property GetHeader() As LibraryInformation
        Get
            Return Me._Header
        End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="FileName"></param>
    Sub New(FileName As String)
        Me._FileName = FileName
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Function Begin() As Boolean

        Me.Free()
        If Not Me.LoadFile() Then
            Me._LastError = $"ファイル {Me._FileName} の読み込みが出来ません。"
            Return False
        End If

        Me._Header = Me.GetLibraryInformation()
        If Me._Header Is Nothing Then
            Return False
        End If

        If Not Me._Header.PlayListVersion.Equals("1.0") OrElse Me._Header.MajorVersion <> 1 Then
            Me._LastError = $"このライブラリのバージョンは対応しません。{vbCrLf}Library version: {Me._Header.MajorVersion.ToString}.{Me._Header.MinorVersion.ToString}{vbCrLf}Playlist version: {Me._Header.PlayListVersion}"
            Return False
        End If

        Me._TrackList = New Dictionary(Of Integer, TrackInfo)
        Me._PlayList = New Dictionary(Of Integer, PlayListInfo)

        Dim stk As New Stack(Of String)()
        Dim stkLevel As Integer = 0
        Dim CurrentBlockName As String = ""

        Dim rKeyName As String = ""

        Dim isTracksSection As Boolean = False
        Dim isTrackItemSection As Boolean = False
        Dim trkInfo As TrackInfo = Nothing

        Dim isPlaylistsSection As Boolean = False
        Dim isPlaylistItemsSection As Boolean = False
        Dim isSmartInfoSection As Boolean = False
        Dim isSmartCriteriaSection As Boolean = False
        Dim plList As PlayListInfo = Nothing

        Dim LineNumber As Integer = 0
        For Each line In Me._Src
            Dim txt As String = line.Trim()
            LineNumber += 1

            '* ブロックネスト処理( iTunes Library.xml version "1.0" )
            Select Case txt
                Case "<dict>", "<array>", "<data>"
                    Select Case rKeyName
                        Case "Tracks"
                            If isTracksSection OrElse isPlaylistsSection OrElse isPlaylistItemsSection Then
                                Me._LastError = $"ファイル構造エラー({LineNumber.ToString})"
                                Return False
                            End If
                            isTracksSection = True

                        Case "Playlists"
                            If isTracksSection OrElse isPlaylistsSection OrElse isPlaylistItemsSection Then
                                Me._LastError = $"ファイル構造エラー({LineNumber.ToString})"
                                Return False
                            End If
                            isPlaylistsSection = True

                        Case "Smart Info"
                            If Not isPlaylistItemsSection Then
                                Me._LastError = $"ファイル構造エラー({LineNumber.ToString})"
                                Return False
                            End If
                            isSmartInfoSection = True

                        Case "Smart Criteria"
                            If Not isPlaylistItemsSection Then
                                Me._LastError = $"ファイル構造エラー({LineNumber.ToString})"
                                Return False
                            End If
                            isSmartCriteriaSection = True

                    End Select

                    stk.Push(CurrentBlockName)
                    stkLevel = stk.Count
                    CurrentBlockName = txt
                    rKeyName = ""

                    If stkLevel = 3 AndAlso isPlaylistsSection Then
                        'Debug.Print($"({LineNumber.ToString}) Playlist Item start.")
                        isPlaylistItemsSection = True
                        plList = New PlayListInfo

                    ElseIf stkLevel = 3 AndAlso isTracksSection Then
                        'Debug.Print($"({LineNumber.ToString}) Track item start.")
                        isTrackItemSection = True
                        trkInfo = New TrackInfo

                    End If

                    Continue For

                Case "</dict>", "</array>", "</data>"
                    If (stk.Count <= 0) OrElse (Not CurrentBlockName.Equals(txt.Replace("/", ""))) Then
                        Me._LastError = $"ファイル構造エラー({LineNumber.ToString})"
                        Return False
                    End If

                    CurrentBlockName = stk.Pop()
                    stkLevel = stk.Count

                    If stkLevel = 1 AndAlso txt.Equals("</dict>") AndAlso isTracksSection Then
                        isTracksSection = False

                    ElseIf stkLevel = 2 AndAlso txt.Equals("</dict>") AndAlso isTracksSection Then
                        'Debug.Print($"Track ID: {trkInfo.TrackID} Name: {trkInfo.Name}")
                        'Debug.Print($"({LineNumber.ToString}) Track item end.")
                        If trkInfo Is Nothing OrElse trkInfo.TrackID < 0 OrElse trkInfo.Name.Length <= 0 OrElse Me._TrackList.ContainsKey(trkInfo.TrackID) Then
                            Me._LastError = $"({LineNumber}) トラック情報が無効です。"
                            Return False
                        End If
                        Me._TrackList.Add(trkInfo.TrackID, trkInfo)
                        isTrackItemSection = False
                        trkInfo = Nothing

                    ElseIf stkLevel = 2 AndAlso txt.Equals("</dict>") AndAlso isPlaylistItemsSection Then
                        'Debug.Print($"Playlist ID: {plList.PlayListID}")
                        'Debug.Print($"Playlist name: {plList.PlayListName}")
                        'Debug.Print($"Playlist count: {plList.TrackIdList.Count}")
                        'Debug.Print($"Visible: {plList.Visible}")
                        'Debug.Print($"Smart Info:")
                        'For Each s As String In plList.SmartInfo
                        'Debug.Print($"    {s}")
                        'Next
                        'Debug.Print($"Smart Criteria:")
                        'For Each s As String In plList.SmartCriteria
                        'Debug.Print($"    {s}")
                        'Next
                        'Debug.Print($"({LineNumber.ToString}) Playlist Item end.")

                        If plList Is Nothing OrElse plList.PlayListID < 0 OrElse plList.PlayListName.Length <= 0 OrElse Me._PlayList.ContainsKey(plList.PlayListID) Then
                            Me._LastError = $"({LineNumber}) プレイリスト情報が無効です。"
                            Return False
                        End If
                        Me._PlayList.Add(plList.PlayListID, plList)

                        isSmartCriteriaSection = False
                        plList = Nothing

                    ElseIf stkLevel = 1 AndAlso txt.Equals("</array>") AndAlso isPlaylistsSection Then
                        isPlaylistsSection = False

                    ElseIf stkLevel = 3 AndAlso txt.Equals("</data>") AndAlso isSmartInfoSection Then
                        isSmartInfoSection = False

                    ElseIf stkLevel = 3 AndAlso txt.Equals("</data>") AndAlso isSmartCriteriaSection Then
                        isSmartCriteriaSection = False

                    End If

                    Continue For
            End Select

            If txt.Length > 11 Then                                       '* <key>で始まる行の場合は値を取得
                Dim kpos As Integer = txt.IndexOf("</key>")
                If kpos > 0 AndAlso (txt.IndexOf("<key>") = 0) Then rKeyName = txt.Substring(5, kpos - 5)
            End If

            If LineNumber <= Me._Header.HeaderLineCount Then Continue For '* ヘッダ部を無視

            '* トラック情報処理
            If isTrackItemSection Then
                If Not Me.SetTrackItemValue(trkInfo, rKeyName, txt) Then
                    Me._LastError = $"({LineNumber}) {rKeyName}: トラック情報の取得に失敗しました。"
                    Return False
                End If
                Continue For
            End If

            '* プレイリスト情報処理
            If isPlaylistItemsSection Then
                If isSmartInfoSection Then
                    plList.SmartInfo.Add(txt)

                ElseIf isSmartCriteriaSection Then
                    plList.SmartCriteria.Add(txt)

                Else
                    If Not Me.SetPlayListItemValue(plList, rKeyName, txt) Then
                        Me._LastError = $"({LineNumber}) {rKeyName}: プレイリスト情報の取得に失敗しました。"
                        Return False
                    End If
                    Continue For
                End If
            End If

        Next

        Return True
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub Free()
        Me._Src = Nothing
        Me._Header = Nothing
        Me._TrackList = Nothing
        Me._PlayList = Nothing
        Me._LastError = ""
    End Sub

    ''' <summary>
    ''' テキストファイルを読み込む
    ''' </summary>
    ''' <returns></returns>
    Private Function LoadFile() As Boolean

        Me._Src = Nothing
        Try
            Using sr As New System.IO.StreamReader(Me._FileName, System.Text.Encoding.UTF8)
                Dim src As String = sr.ReadToEnd()
                sr.Close()
                Me._Src = src.Split(vbCrLf)
            End Using
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function


    ''' <summary>
    ''' プレイリスト情報をセット
    ''' </summary>
    ''' <param name="plList"></param>
    ''' <param name="key">項目名</param>
    ''' <param name="txt">入力文字列</param>
    ''' <returns></returns>
    Private Function SetPlayListItemValue(plList As PlayListInfo, key As String, txt As String) As Boolean

        Try
            Select Case key
                Case "Playlist ID"
                    plList.PlayListID = Integer.Parse(Me.getKeyValue(txt, "integer"))

                Case "Playlist Persistent ID"
                    plList.PlaylistPersistentID = Me.getKeyValue(txt, "string")

                Case "Distinguished Kind"
                    plList.DistinguishedKind = Integer.Parse(Me.getKeyValue(txt, "integer"))

                Case "All Items"
                    plList.AllItems = Boolean.Parse(Me.getKeyValue(txt, "bool"))

                Case "Name"
                    plList.PlayListName = Me.getKeyValue(txt, "string")

                Case "Visible"
                    plList.Visible = Boolean.Parse(Me.getKeyValue(txt, "bool"))

                Case "Track ID"
                    plList.TrackIdList.Add(Integer.Parse(Me.getKeyValue(txt, "integer")))

            End Select

        Catch ex As Exception
            Return False

        End Try
        Return True
    End Function

    ''' <summary>
    ''' トラック情報をセット
    ''' </summary>
    ''' <param name="trkInfo"></param>
    ''' <param name="key">項目名</param>
    ''' <param name="txt">入力文字列</param>
    ''' <returns></returns>
    Private Function SetTrackItemValue(trkInfo As TrackInfo, key As String, txt As String) As Boolean

        Try
            Select Case key
                Case "Track ID"
                    trkInfo.TrackID = Integer.Parse(Me.getKeyValue(txt, "integer"))

                Case "Size"
                    trkInfo.Size = Integer.Parse(Me.getKeyValue(txt, "integer"))

                Case "Total Time"
                    trkInfo.TotalTime = Integer.Parse(Me.getKeyValue(txt, "integer"))

                Case "Disc Number"
                    trkInfo.DiscNumber = Integer.Parse(Me.getKeyValue(txt, "integer"))

                Case "Disc Count"
                    trkInfo.DiscCount = Integer.Parse(Me.getKeyValue(txt, "integer"))

                Case "Track Number"
                    trkInfo.TrackNumber = Integer.Parse(Me.getKeyValue(txt, "integer"))

                Case "Track Count"
                    trkInfo.TrackCount = Integer.Parse(Me.getKeyValue(txt, "integer"))

                Case "Year"
                    trkInfo.Year = Integer.Parse(Me.getKeyValue(txt, "integer"))

                Case "Bit Rate"
                    trkInfo.BitRate = Integer.Parse(Me.getKeyValue(txt, "integer"))

                Case "Sample Rate"
                    trkInfo.SampleRate = Integer.Parse(Me.getKeyValue(txt, "integer"))

                Case "File Folder Count"
                    trkInfo.FileFolderCount = Integer.Parse(Me.getKeyValue(txt, "integer"))

                Case "Library Folder Count"
                    trkInfo.LibraryFolderCount = Integer.Parse(Me.getKeyValue(txt, "integer"))

                Case "Date Modified"
                    trkInfo.DateModified = Me.getKeyValue(txt, "date")

                Case "Date Added"
                    trkInfo.DateAdded = Me.getKeyValue(txt, "date")

                Case "Release Date"
                    trkInfo.ReleaseDate = Me.getKeyValue(txt, "date")

                Case "Purchased"
                    trkInfo.Purchased = Boolean.Parse(Me.getKeyValue(txt, "bool"))

                Case "PersistentID"
                    trkInfo.PersistentID = Me.getKeyValue(txt, "string")

                Case "Track Type"
                    trkInfo.TrackType = Me.getKeyValue(txt, "string")

                Case "Name"
                    trkInfo.Name = Me.getKeyValue(txt, "string")

                Case "Artist"
                    trkInfo.Artist = Me.getKeyValue(txt, "string")

                Case "Album Artist"
                    trkInfo.AlbumArtist = Me.getKeyValue(txt, "string")

                Case "Composer"
                    trkInfo.Composer = Me.getKeyValue(txt, "string")

                Case "Album"
                    trkInfo.Album = Me.getKeyValue(txt, "string")

                Case "Genre"
                    trkInfo.Genre = Me.getKeyValue(txt, "string")

                Case "Kind"
                    trkInfo.Kind = Me.getKeyValue(txt, "string")

                Case "Sort Name"
                    trkInfo.SortName = Me.getKeyValue(txt, "string")

                Case "Sort Album"
                    trkInfo.SortAlbum = Me.getKeyValue(txt, "string")

                Case "Sort Artist"
                    trkInfo.SortArtist = Me.getKeyValue(txt, "string")

                Case "Location"
                    trkInfo.Location = Me.getKeyValue(txt, "uri")

            End Select

        Catch ex As Exception
            Return False

        End Try
        Return True
    End Function

    ''' <summary>
    ''' ライブラリのヘッダ部を取得
    ''' </summary>
    ''' <returns></returns>
    Private Function GetLibraryInformation() As LibraryInformation

        Dim inf As New LibraryInformation
        Dim LineCount As Integer = 0

        Try
            Dim dicKey As New Dictionary(Of String, String)
            Dim key As String = ""
            Dim dictCount As Integer = 0

            For Each line In Me._Src
                Dim txt As String = line.Trim()
                LineCount += 1

                If txt.Equals("<dict>") OrElse LineCount > 16 Then    '* 2つめの<dict>出現又は16行処理で終了
                    dictCount += 1
                    If dictCount >= 2 Then Exit For
                End If

                key = "<plist version="
                If txt.IndexOf(key) = 0 Then
                    Dim ver As String = txt.Substring(key.Length + 1)
                    Dim lastPos As Integer = ver.LastIndexOf(">")
                    If lastPos > 0 Then
                        If dicKey.ContainsKey(key) Then Throw New Exception($"ヘッダ要素 {key} が複数存在します")
                        inf.PlayListVersion = ver.Substring(0, lastPos - 1)
                        dicKey.Add(key, "")
                    End If
                    Continue For
                End If

                key = "<key>Major Version</key>"
                If txt.IndexOf(key) = 0 Then
                    If dicKey.ContainsKey(key) Then Throw New Exception($"ヘッダ要素 {key} が複数存在します")
                    inf.MajorVersion = Integer.Parse(Me.getKeyValue(txt, "integer"))
                    dicKey.Add(key, "")
                    Continue For
                End If

                key = "<key>Minor Version</key>"
                If txt.IndexOf(key) = 0 Then
                    If dicKey.ContainsKey(key) Then Throw New Exception($"ヘッダ要素 {key} が複数存在します")
                    inf.MinorVersion = Integer.Parse(Me.getKeyValue(txt, "integer"))
                    dicKey.Add(key, "")
                    Continue For
                End If

                key = "<key>Application Version</key>"
                If txt.IndexOf(key) = 0 Then
                    If dicKey.ContainsKey(key) Then Throw New Exception($"ヘッダ要素 {key} が複数存在します")
                    inf.ApplicationVersion = Me.getKeyValue(txt, "string")
                    dicKey.Add(key, "")
                    Continue For
                End If

                key = "<key>Date</key>"
                If txt.IndexOf(key) = 0 Then
                    If dicKey.ContainsKey(key) Then Throw New Exception($"ヘッダ要素 {key} が複数存在します")
                    inf.DateString = Me.getKeyValue(txt, "date")
                    dicKey.Add(key, "")
                    Continue For
                End If

                key = "<key>Features</key>"
                If txt.IndexOf(key) = 0 Then
                    If dicKey.ContainsKey(key) Then Throw New Exception($"ヘッダ要素 {key} が複数存在します")
                    inf.Features = Integer.Parse(Me.getKeyValue(txt, "integer"))
                    dicKey.Add(key, "")
                    Continue For
                End If

                key = "<key>Show Content Ratings</key>"
                If txt.IndexOf(key) = 0 Then
                    If dicKey.ContainsKey(key) Then Throw New Exception($"ヘッダ要素 {key} が複数存在します")
                    inf.ShowContentRatings = Boolean.Parse(Me.getKeyValue(txt, "bool"))
                    dicKey.Add(key, "")
                    Continue For
                End If

                key = "<key>Library Persistent ID</key>"
                If txt.IndexOf(key) = 0 Then
                    If dicKey.ContainsKey(key) Then Throw New Exception($"ヘッダ要素 {key} が複数存在します")
                    inf.LibraryPersistentID = Me.getKeyValue(txt, "string")
                    dicKey.Add(key, "")
                    Continue For
                End If

            Next

        Catch ex As Exception
            Me._LastError = ex.Message
            Return Nothing

        End Try

        inf.HeaderLineCount = LineCount - 1
        Return inf
    End Function

    ''' <summary>
    ''' <key></key><xxx></xxx>形式のテキストから値を文字列として取得
    ''' </summary>
    ''' <param name="txt">入力文字列</param>
    ''' <param name="typ">値の種別(特殊タイプ：'bool','uri')</param>
    ''' <returns></returns>
    Private Function getKeyValue(txt As String, typ As String) As String

        Dim ret As String = Nothing

        If typ.Equals("bool") Then
            If txt.LastIndexOf("<true/>") >= 0 Then
                ret = "true"
            ElseIf txt.LastIndexOf("<false/>") >= 0 Then
                ret = "false"
            End If
        Else
            Dim isUri As Boolean = False
            Dim isString As Boolean = False
            If typ.Equals("uri") Then
                isString = True
                isUri = True
                typ = "string"
            ElseIf typ.Equals("string") Then
                isString = True
            End If

            Dim key As String = $"<{typ}>"
            Dim spos As Integer = txt.IndexOf($"<{typ}>")
            Dim epos As Integer = txt.LastIndexOf($"</{typ}>")
            If spos >= 0 AndAlso epos >= 0 Then
                spos += (typ.Length + 2)
                Dim len As Integer = epos - spos
                If len >= 0 Then
                    Dim val As String = txt.Substring(spos, len)
                    If isString Then val = Me.StringDecode(val, isUri)
                    ret = val
                End If
            End If
        End If

        Return ret

    End Function

    ''' <summary>
    ''' 入力文字列を正規化（iTuneの文字列に '＆＃９９９' の表記が含まれると.netのUirクラスでは失敗する)
    ''' </summary>
    ''' <param name="txt">入力文字列</param>
    ''' <param name="isUri">Trueにするとファイル名として変換</param>
    ''' <returns></returns>
    Private Function StringDecode(txt As String, isUri As Boolean) As String

        Dim filename As String = ""
        Try
            Dim rp As Integer = 0
            Dim wp As Integer = 0
            Dim src As Byte() = System.Text.Encoding.UTF8.GetBytes(txt)
            Dim dst(src.Length) As Byte
            Do While rp < src.Length
                Dim c As Byte = src(rp)
                If c = &H25 Then        '* '%'
                    Dim h As UInt16 = (Me.h2d(src(rp + 1)) << 4) + Me.h2d(src(rp + 2))
                    dst(wp) = CType(h, Byte)
                    rp += 3

                ElseIf c = &H2F AndAlso isUri Then '* &h2F = '/' --> &h5c '\'
                    dst(wp) = &H5C
                    rp += 1

                ElseIf c = &H26 AndAlso src(rp + 1) = &H23 Then '* 26h = '&' / 23h = '#'
                    rp += 2
                    Dim n As Integer = 0
                    Do While src(rp) <> &H3B '* 3Bh = ';'
                        c = src(rp)
                        n *= 10
                        n += Me.d2d(c)
                        rp += 1
                    Loop
                    dst(wp) = n
                    rp += 1
                Else
                    dst(wp) = c
                    rp += 1
                End If
                wp += 1
            Loop

            dst(wp) = 0
            ReDim Preserve dst(wp - 1)
            filename = System.Text.Encoding.UTF8.GetString(dst)
            If isUri Then filename = filename.Replace("file:\\localhost\", "")

        Catch ex As Exception
            filename = Nothing
            Me._LastError = $"文字列のデコードに失敗しました。{vbCrLf}{txt}"

        End Try

        Return filename

    End Function
    ''' <summary>
    ''' 16進数文字(1文字)を数値に変換
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Private Function h2d(c As Byte) As Integer
        If (c >= &H30) AndAlso (c <= &H39) Then Return c - &H30
        c = c Or &H20
        Return If((c >= &H61) AndAlso (c <= &H66), (c - &H61) + 10, -1)
    End Function

    ''' <summary>
    ''' 10進数文字(1文字)を数値に変換
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Private Function d2d(c As Byte) As Integer
        Return If((c >= &H30) AndAlso (c <= &H39), c - &H30, -1)
    End Function

End Class
