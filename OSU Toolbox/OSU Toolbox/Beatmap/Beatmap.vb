Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Text
Imports System.IO
Imports OSU_Toolbox.Core
Public Class Beatmap
    Public location As String
    Public name As String
    Public path As String
    'location is defined in beatmapfiles
    'metadata/set ID is defined in beatmapfiles
    'diff-wide storyboard
    Public Structure Timing

    End Structure
    Public Structure HitObject

    End Structure
    Public Enum modes
        All
        Taiko
        CTB
        Mania
    End Enum
    Private rawBeatmapData As Dictionary(Of String, String)
    'General
    Public song As New Audiofiles
    Public previewtime As Integer = 0
    Public samples As Dictionary(Of String, Audiofiles)
    Public SampleSet As String = "Normal"
    Public mode As modes = modes.All
    'Metadata
    Public title As String
    Public titleRomanized As String
    Public artist As String
    Public artistRomanized As String
    Public creator As String
    Public version As String
    Public source As String
    Public tags As String
    Public tagList As List(Of String)
    Public beatmapId As Integer
    Public beatmapsetId As Integer
    'Difficulty
    Public HPDrainRate As Integer
    Public CircleSize As Integer
    Public OverallDifficulty As Integer
    Public ApproachRate As Integer
    Public SliderMultiplier As Integer
    Public SliderTickRate As Integer
    'Events
    Public background As String
    Public video As Videofiles
    Public SB As StoryBoard
    'TimingPoints
    Public timingpoints As New List(Of Timing)
    'HitObjects
    Public HitObjects As New List(Of HitObject)
    Private position As New osuFileScanStatus
    Private tmpSB As New List(Of String)
    Enum osuFileScanStatus
        FORMAT_UNKNOWN
        GENERAL
        EDITOR
        METADATA
        DIFFICULTY
        EVENTS
        TIMINGPOINTS
        COLOURS
        HITOBJECTS
    End Enum
    Private Function Read(osuFile As String) As Dictionary(Of String, String)
        Try
            Dim b As New Dictionary(Of String, String)
            position = osuFileScanStatus.FORMAT_UNKNOWN
            For Each row In File.ReadAllLines(osuFile)
                If row.StartsWith("//") OrElse row.Length = 0 Then
                    Continue For
                End If
                If row.StartsWith("[") Then
                    position = CType(System.Enum.Parse(GetType(osuFileScanStatus), row.Substring(1, row.Length - 2).ToUpper()), osuFileScanStatus)
                    Continue For
                End If
                Select Case position
                    Case osuFileScanStatus.FORMAT_UNKNOWN
                        b.Add("FormatVersion", row.Substring(17))
                        Exit Select
                    Case osuFileScanStatus.GENERAL, osuFileScanStatus.EDITOR, osuFileScanStatus.METADATA, osuFileScanStatus.DIFFICULTY, osuFileScanStatus.COLOURS
                        Dim s As String() = row.Split(New Char() {":"}, 2)
                        b.Add(s(0).Trim(), s(1).Trim())
                        Exit Select
                    Case osuFileScanStatus.EVENTS
                        If row.StartsWith("0,0,""") Then
                            Dim str As String = row.Substring(5, row.Length - 6)
                            If str.EndsWith(""",0,") Then
                                str = str.Substring(0, str.Length - 4)
                            End If
                            b.Add("Background", str)
                        ElseIf row.StartsWith("1,") OrElse row.StartsWith("Video") Then
                            Dim vdata As String() = row.Split(","c)
                            b.Add("VideoOffset", vdata(1))
                            b.Add("Video", vdata(2).Substring(1, vdata(2).Length - 2))
                        Else
                            Dim r As String = row.Trim()
                            tmpSB.Add(r)
                        End If
                    Case osuFileScanStatus.TIMINGPOINTS

                    Case osuFileScanStatus.HITOBJECTS

                End Select
            Next
            Return b
        Catch e As SystemException
            Console.WriteLine(e.StackTrace)
            Throw New FormatException("Failed to read .osu file", e)
        End Try
    End Function

    Public Sub New(location_F As String, name_F As String)
        location = location_F
        name = name_F
        path = System.IO.Path.Combine(location, name)
        rawBeatmapData = Read(path)
        song.path = System.IO.Path.Combine(location, rawBeatmapData("AudioFilename"))
        If rawBeatmapData.ContainsKey("PreviewTime") Then previewtime = CType(rawBeatmapData("PreviewTime"), Integer)
        If rawBeatmapData.ContainsKey("SampleSet") Then SampleSet = rawBeatmapData("SampleSet")
        If rawBeatmapData.ContainsKey("Mode") Then mode = CType(rawBeatmapData("Mode"), modes)

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
        If rawBeatmapData.ContainsKey("BeatmapID") Then
            beatmapId = Convert.ToInt32(rawBeatmapData("BeatmapID"))
        Else
            beatmapId = 0
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

        background = System.IO.Path.Combine(location, rawBeatmapData("Background"))
    End Sub
    Public Overrides Function ToString() As String
        Return artistRomanized & " - " & titleRomanized
    End Function
    '-1 if this beatmap's artist is before the other beatmap's artist
    '0 if this beatmap's artist AND the beatmap's title is before the other beatmap's artist/title
    '1 if this beatmap's artist is after the other beatmap's artist
    Public Function CompareTo(other As Beatmap) As Integer
        Dim artist As Integer = Me.artistRomanized.CompareTo(other.artistRomanized)
        If artist = 0 Then
            Return Me.titleRomanized.CompareTo(other.titleRomanized)
        Else
            Return artist
        End If
    End Function
    Public Overrides Function Equals(obj As Object) As Boolean
        If TypeOf obj Is Beatmap Then
            Dim b As Beatmap = DirectCast(obj, Beatmap)
            If (b.beatmapId = beatmapId) And (beatmapId <> 0) Then
                Return True
            End If
            Return Me.ToString.Equals(b.ToString) And Me.titleRomanized.Equals(b.titleRomanized)
        Else
            Return False
        End If
    End Function
End Class
