Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Text
Imports OSU_Toolbox.OSUGeneral
Public Class Beatmap
    Public location As String
    Public name As String
    Public path As String
    Public Class Osufile
        'location is defined in beatmapfiles
        'metadata/set ID is defined in beatmapfiles
        'diff-wide storyboard
    End Class
    Public SB As StoryBoard
    Public video As Videofiles
    Public song As Audiofiles
    Public samples As Dictionary(Of String, Audiofiles)
    Public background As String
    Private rawBeatmapData As Dictionary(Of String, String)
    Public tagList As List(Of String)
    Public beatmapId As Integer
    Public artist As String
    Public artistRomanized As String
    Public title As String
    Public titleRomanized As String
    Public tags As String
    Public source As String
    Public Sub New(location_F As String, name_F As String)
        location = location_F
        name = name_F
        path = System.IO.Path.Combine(location, name)
        rawBeatmapData = osuFileFormatReader.Read(path)
        If rawBeatmapData.ContainsKey("BeatmapID") Then
            beatmapId = Convert.ToInt32(rawBeatmapData("BeatmapID"))
        Else
            beatmapId = 0
        End If
        If rawBeatmapData.ContainsKey("Artist") Then
            artistRomanized = rawBeatmapData("Artist")
        Else
            artistRomanized = "<unknown artist>"
        End If
        If rawBeatmapData.ContainsKey("Title") Then
            titleRomanized = rawBeatmapData("Title")
        Else
            titleRomanized = "<unknown title>"
        End If
        If rawBeatmapData.ContainsKey("Source") Then
            source = rawBeatmapData("Source")
        Else
            source = "<unknown source>"
        End If
        tagList = New List(Of String)()
        If rawBeatmapData.ContainsKey("Tags") Then
            tags = rawBeatmapData("Tags")
            For Each s As String In rawBeatmapData("Tags").Split("="c)
                tagList.Add(s)
            Next
        Else
            tags = ""
        End If
        If rawBeatmapData.ContainsKey("ArtistUnicode") And rawBeatmapData.ContainsKey("TitleUnicode") Then
            artist = rawBeatmapData("ArtistUnicode")
            title = rawBeatmapData("TitleUnicode")
        Else
            artist = artistRomanized
            title = titleRomanized
        End If
        If rawBeatmapData.ContainsKey("Video") Then
            video = New Videofiles
            video.path = System.IO.Path.Combine(location, rawBeatmapData("Video"))
            video.offset = Integer.Parse(rawBeatmapData("VideoOffset"))
        End If
        song.path = System.IO.Path.Combine(location, rawBeatmapData("AudioFilename"))
        background = System.IO.Path.Combine(location, rawBeatmapData("Background"))
    End Sub
    Public Overrides Function ToString() As String
        Return artistRomanized & " - " & titleRomanized
    End Function

    ''' <summary>
    ''' Compares this beatmap to another beatmap.
    ''' </summary>
    ''' <param name="other">The other beatmap.</param>
    ''' <returns>-1 if this beatmap's artist is before the other beatmap's artist<br />* 0 if this beatmap's artist AND the beatmap's title is before the other beatmap's artist/title<br />* 1 if this beatmap's artist is after the other beatmap's artist<br />* If the artists equal eachother, the title of the song is checked.</returns>
    Public Function CompareTo(other As Beatmap) As Integer
        Dim artist As Integer = Me.artistRomanized.CompareTo(other.artistRomanized)
        If artist = 0 Then
            Return Me.titleRomanized.CompareTo(other.titleRomanized)
        Else
            Return artist
        End If
    End Function

    ''' <summary>
    ''' Checks if this beatmap equals another beatmap.
    ''' </summary>
    ''' <param name="obj">The other beatmap.</param>
    ''' <returns>true if this beatmap's artist and title equal the other beatmap.</returns>
    Public Overrides Function Equals(obj As Object) As Boolean
        If TypeOf obj Is Beatmap Then
            Dim b As Beatmap = DirectCast(obj, Beatmap)
            Return Me.artistRomanized.Equals(b.artistRomanized) AndAlso Me.titleRomanized.Equals(b.titleRomanized)
        Else
            Return False
        End If
    End Function
    Public Sub readSB()

        SB.ReadSection(System.IO.File.ReadAllText(location))
    End Sub
End Class
