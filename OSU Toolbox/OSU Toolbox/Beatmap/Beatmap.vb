Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Text
Imports System.IO
Imports OSU_Toolbox.Core
Public Class Beatmap
    Public location As String
    Public name As String
    Public path As String
    Public Structure Timing
        Public offset As Integer
        Public bpm As Double
        Public meter As Integer
        Public sample As CSample
        Public volume As Integer
        Public type As Integer
        Public kiai As Integer
    End Structure
    Public Structure note
        Public x, y As Integer
    End Structure
    Public Structure HitObject
        Public x, y, starttime As Integer
        Public type As ObjectFlag
        Public allhitsound As Integer
        Public EndTime As Integer
        Public T_sample As CSample
        Public A_sample As CSample
        Public slidertype As Char
        Public slidernodes() As note
        Public repeatcount As Integer
        Public length As Double
        Public Hitsounds() As Integer
        Public T_samples() As CSample
        Public A_samples() As CSample
    End Structure
    Public Enum modes
        All
        Taiko
        CTB
        Mania
    End Enum
    'TODO:get rid of dictionary
    'General
    Public song As New Audiofiles
    Public previewtime As Integer = 0
    Public SampleSet As String = "Normal"
    Public mode As modes = modes.All
    'Metadata
    Public title As String
    Public titleRomanized As String = "<unknown title>"
    Public artist As String
    Public artistRomanized As String = "<unknown artist>"
    Public creator As String
    Public version As String
    Public source As String = "<unknown source>"
    Public tags As String
    Public tagList As List(Of String)
    Public beatmapId As Integer = 0
    Public beatmapsetId As Integer = -1
    'Difficulty
    Public HPDrainRate As Integer = 5
    Public CircleSize As Integer = 5
    Public OverallDifficulty As Integer = 5
    Public ApproachRate As Integer = 5
    Public SliderMultiplier As Double = 1
    Public SliderTickRate As Double = 1
    'Events
    Public background As String = ""
    Public video As Videofiles
    'diff-wide storyboard
    Public SB As StoryBoard
    'TimingPoints
    Public timingpoints As New List(Of Timing)
    'HitObjects
    Public HitObjects As New List(Of HitObject)
    Public haveSB As Boolean = False
    Public haveVideo As Boolean = False
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

        Dim position As New osuFileScanStatus
        Try
            Dim b As New Dictionary(Of String, String)
            position = osuFileScanStatus.FORMAT_UNKNOWN

            For Each row In File.ReadAllLines(osuFile)
                If row.Trim = "" Then Continue For
                If row.StartsWith("//") Or row.Length = 0 Then
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
                        If row.StartsWith("0,0,") Then
                            Dim str As String = row.Substring(5, row.Length - 6)
                            If str.Contains("""") Then
                                Dim tmp As String
                                tmp = str.Substring(str.IndexOf("""") + 2)
                                str = str.Substring(0, str.IndexOf(""""))
                                If Not b.ContainsKey("BackgroundX") Then
                                    b.Add("BackgroundX", tmp.Split(New Char() {","}, 2)(0))
                                    b.Add("BackgoundY", tmp.Split(New Char() {","}, 2)(1))
                                Else
                                    b("BackgroundX") = tmp.Split(New Char() {","}, 2)(0)
                                    b("BackgoundY") = tmp.Split(New Char() {","}, 2)(1)
                                End If
                            End If
                            If Not b.ContainsKey("Background") Then
                                b.Add("Background", str)
                            Else
                                b("Background") = str
                            End If
                        ElseIf row.StartsWith("1,") Or row.StartsWith("Video") Then
                            If Not b.ContainsKey("Video") Then
                                haveVideo = True
                                Dim vdata As String() = row.Split(",")
                                b.Add("VideoOffset", vdata(1))
                                b.Add("Video", vdata(2).Substring(1, vdata(2).Length - 2))
                            Else
                                Dim vdata As String() = row.Split(",")
                                b("VideoOffset") = vdata(1)
                                b("Video") = vdata(2).Substring(1, vdata(2).Length - 2)
                            End If
                        ElseIf row.StartsWith("3,") Or row.StartsWith("2,") Then
                            Exit Select
                            Else
                                Dim r As String = row.Trim()
                                tmpSB.Add(r)
                                haveSB = True
                            End If
                    Case osuFileScanStatus.TIMINGPOINTS

                    Case osuFileScanStatus.HITOBJECTS

                End Select
            Next
            If haveSB Then b.Add("SB", "TRUE")
            Return b
        Catch e As SystemException
            Console.WriteLine(e.StackTrace)
            Throw New FormatException("Failed to read .osu file", e)
        End Try
    End Function
    Public Sub New(location_F As String, name_F As String, osb As String)
        Dim rawBeatmapData As Dictionary(Of String, String)
        location = location_F
        name = name_F
        path = System.IO.Path.Combine(location, name)
        rawBeatmapData = Read(path)
        song.path = System.IO.Path.Combine(location, rawBeatmapData("AudioFilename"))
        If rawBeatmapData.ContainsKey("PreviewTime") Then previewtime = Convert.ToInt32(rawBeatmapData("PreviewTime"))
        If rawBeatmapData.ContainsKey("SampleSet") Then SampleSet = rawBeatmapData("SampleSet")
        If rawBeatmapData.ContainsKey("Mode") Then mode = CType(rawBeatmapData("Mode"), modes)
        If rawBeatmapData.ContainsKey("Artist") Then artistRomanized = rawBeatmapData("Artist")
        If rawBeatmapData.ContainsKey("Title") Then titleRomanized = rawBeatmapData("Title")
        If rawBeatmapData.ContainsKey("ArtistUnicode") And rawBeatmapData.ContainsKey("TitleUnicode") Then
            artist = rawBeatmapData("ArtistUnicode")
            title = rawBeatmapData("TitleUnicode")
        Else
            artist = artistRomanized
            title = titleRomanized
        End If
        If rawBeatmapData.ContainsKey("Creator") Then creator = rawBeatmapData("Creator")
        If rawBeatmapData.ContainsKey("Version") Then version = rawBeatmapData("Version")
        If rawBeatmapData.ContainsKey("Source") Then source = rawBeatmapData("Source")
        tagList = New List(Of String)()
        If rawBeatmapData.ContainsKey("Tags") Then
            tags = rawBeatmapData("Tags")
            For Each s As String In rawBeatmapData("Tags").Split("=")
                tagList.Add(s)
            Next
        Else
            tags = ""
        End If
        If rawBeatmapData.ContainsKey("BeatmapID") Then beatmapId = Convert.ToInt32(rawBeatmapData("BeatmapID"))
        If rawBeatmapData.ContainsKey("BeatmapSetID") Then beatmapsetId = Convert.ToInt32(rawBeatmapData("BeatmapSetID"))
        If rawBeatmapData.ContainsKey("HPDrainRate") Then HPDrainRate = Convert.ToInt32(rawBeatmapData("HPDrainRate"))
        If rawBeatmapData.ContainsKey("CircleSize") Then CircleSize = Convert.ToInt32(rawBeatmapData("CircleSize"))
        If rawBeatmapData.ContainsKey("OverallDifficulty") Then OverallDifficulty = Convert.ToInt32(rawBeatmapData("OverallDifficulty"))
        If rawBeatmapData.ContainsKey("ApproachRate") Then ApproachRate = Convert.ToInt32(rawBeatmapData("ApproachRate")) Else ApproachRate = OverallDifficulty
        If rawBeatmapData.ContainsKey("SliderMultiplier") Then SliderMultiplier = Convert.ToDouble(rawBeatmapData("SliderMultiplier"))
        If rawBeatmapData.ContainsKey("SliderTickRate") Then SliderTickRate = Convert.ToDouble(rawBeatmapData("SliderTickRate"))
        If rawBeatmapData.ContainsKey("Background") Then background = System.IO.Path.Combine(location, rawBeatmapData("Background"))
        If rawBeatmapData.ContainsKey("Video") Then
            video = New Videofiles
            video.path = System.IO.Path.Combine(location, rawBeatmapData("Video"))
            video.offset = Convert.ToInt32(rawBeatmapData("VideoOffset"))
        End If
        If rawBeatmapData.ContainsKey("SB") Then
            SB = New StoryBoard(tmpSB)
        Else
            If osb <> "" Then
                tmpSB.Clear()
                Dim tmp() As String = IO.File.ReadAllLines(IO.Path.Combine(location, osb))
                For i As Integer = 0 To tmp.Length - 1
                    tmpSB.Add(tmp(i))
                Next
                SB = New StoryBoard(tmpSB)
            End If
        End If

    End Sub
    Public Overrides Function ToString() As String
        Return artistRomanized & " - " & titleRomanized & " (" & creator & " ) [" & version & "]"
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
            Return Me.ToString.Equals(b.ToString) And Me.creator.Equals(b.creator)
        Else
            Return False
        End If
    End Function
    Public Function difftostring() As String
        Return version
    End Function
End Class