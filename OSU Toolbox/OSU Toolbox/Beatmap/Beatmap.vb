Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Text
Imports System.IO
Imports OSU_Toolbox.Core
Public Class Beatmap
    Public location As String
    Public name As String
    Public path As String
    Private osb As String
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
        Public sample As CSample
        Public A_sample As CSample
        Public slidertype As Char
        Public slidernodes() As note
        Public repeatcount As Integer
        Public length As Double
        Public Hitsounds As List(Of Integer)
        Public samples As List(Of CSample)
        Public A_samples As List(Of CSample)
    End Structure
    Public Enum modes
        All = 0
        Taiko = 1
        CTB = 2
        Mania = 3
    End Enum
    Public Rawdata(45) As String
    Public ReadOnly Property FileVersion() As String
        Get
            Return Rawdata(OSUfile.FileVersion)
        End Get
    End Property
    Public ReadOnly Property Audio() As String
        Get
            Return Rawdata(OSUfile.AudioFilename)
        End Get
    End Property
    Public ReadOnly Property Previewtime() As Integer
        Get
            If Rawdata(OSUfile.PreviewTime) <> "" Then
                Return Convert.ToInt32(Rawdata(OSUfile.PreviewTime))
            Else : Return 0
            End If
        End Get
    End Property
    Public ReadOnly Property SampleSet() As String
        Get
            If Rawdata(OSUfile.SampleSet) <> "" Then
                Return Rawdata(OSUfile.ArtistUnicode)
            Else
                Return "Normal"
            End If
        End Get
    End Property
    Public ReadOnly Property Mode() As modes
        Get
            If Rawdata(OSUfile.Mode) <> "" Then
                Return CType(Rawdata(OSUfile.Mode), modes)
            Else
                Return modes.All
            End If
        End Get
    End Property
    Public ReadOnly Property Artist() As String
        Get
            If Rawdata(OSUfile.ArtistUnicode) <> "" Then
                Return Rawdata(OSUfile.ArtistUnicode)
            Else
                Return (Rawdata(OSUfile.Artist))
            End If
        End Get
    End Property
    Public ReadOnly Property ArtistRomanized() As String
        Get
            If Rawdata(OSUfile.Artist) <> "" Then
                Return Rawdata(OSUfile.Artist)
            Else
                Return "<unknown artist>"
            End If
        End Get
    End Property
    Public ReadOnly Property Title() As String
        Get
            If Rawdata(OSUfile.TitleUnicode) <> "" Then
                Return Rawdata(OSUfile.TitleUnicode)
            Else
                Return (Rawdata(OSUfile.Title))
            End If
        End Get
    End Property
    Public ReadOnly Property TitleRomanized() As String
        Get
            If Rawdata(OSUfile.Title) <> "" Then
                Return Rawdata(OSUfile.Title)
            Else
                Return "<unknown title>"
            End If
        End Get
    End Property
    Public ReadOnly Property Creator() As String
        Get
            Return Rawdata(OSUfile.Creator)
        End Get
    End Property
    Public ReadOnly Property Version() As String
        Get
            Return Rawdata(OSUfile.Version)
        End Get
    End Property
    Public ReadOnly Property Source() As String
        Get
            If Rawdata(OSUfile.Source) <> "" Then
                Return Rawdata(OSUfile.Source)
            Else
                Return "<unknown source>"
            End If
        End Get
    End Property
    Private tags As String
    Private I_tagList As New List(Of String)
    Public ReadOnly Property Taglist() As List(Of String)
        Get
            Return I_tagList
        End Get
    End Property
    Public ReadOnly Property beatmapId() As Integer
        Get
            If Rawdata(OSUfile.BeatmapID) <> "" Then
                Return Convert.ToInt32(Rawdata(OSUfile.BeatmapID))
            Else : Return 0
            End If
        End Get
    End Property
    Public ReadOnly Property beatmapsetId() As Integer
        Get
            If Rawdata(OSUfile.BeatmapSetID) <> "" Then
                Return Convert.ToInt32(Rawdata(OSUfile.BeatmapSetID))
            Else : Return -1
            End If
        End Get
    End Property
    Public ReadOnly Property HPDrainRate() As Integer
        Get
            If Rawdata(OSUfile.HPDrainRate) <> "" Then
                Return Convert.ToInt32(Rawdata(OSUfile.HPDrainRate))
            Else : Return 5
            End If
        End Get
    End Property
    Public ReadOnly Property CircleSize() As Integer
        Get
            If Rawdata(OSUfile.CircleSize) <> "" Then
                Return Convert.ToInt32(Rawdata(OSUfile.CircleSize))
            Else : Return 5
            End If
        End Get
    End Property
    Public ReadOnly Property OverallDifficulty() As Integer
        Get
            If Rawdata(OSUfile.OverallDifficulty) <> "" Then
                Return Convert.ToInt32(Rawdata(OSUfile.OverallDifficulty))
            Else : Return 5
            End If
        End Get
    End Property
    Public ReadOnly Property ApproachRate() As Integer
        Get
            If Rawdata(OSUfile.ApproachRate) <> "" Then
                Return Convert.ToInt32(Rawdata(OSUfile.ApproachRate))
            Else : Return Convert.ToInt32(Rawdata(OSUfile.OverallDifficulty))
            End If
        End Get
    End Property
    Public ReadOnly Property SliderMultiplier() As Double
        Get
            If Rawdata(OSUfile.SliderMultiplier) <> "" Then
                Return Convert.ToDouble(Rawdata(OSUfile.SliderMultiplier))
            Else : Return 1
            End If
        End Get
    End Property
    Public ReadOnly Property SliderTickRate() As Double
        Get
            If Rawdata(OSUfile.SliderTickRate) <> "" Then
                Return Convert.ToDouble(Rawdata(OSUfile.SliderTickRate))
            Else : Return 1
            End If
        End Get
    End Property
    Public background As String = ""
    Public backgroundOffset As String = ""
    Public Video As String
    Public VideoOffset As Integer
    'diff-wide storyboard
    Public SB As StoryBoard
    'TimingPoints
    Public timingpoints As New List(Of Timing)
    'HitObjects
    Public HitObjects As New List(Of HitObject)
    Public haveSB As Boolean = False
    Public haveVideo As Boolean = False
    Private tmpSB As New List(Of String)
    Private Function picknext(ByRef str As String) As String
        Dim ref As String
        If Not str.Contains(",") Then
            ref = str
            str = ""
        Else
            ref = str.Substring(0, str.IndexOf(","))
            str = str.Substring(str.IndexOf(",") + 1)
        End If
        Return ref
    End Function
    Private Function check(op As String) As ObjectFlag
        Dim tmp As Integer = Convert.ToInt32(op)
        If ((tmp >> 0) And 1) Then Return ObjectFlag.Normal
        If ((tmp >> 1) And 1) Then Return ObjectFlag.Slider
        If ((tmp >> 3) And 1) Then Return ObjectFlag.Spinner
        Return ObjectFlag.ColourHax
    End Function
    Enum osuFileScanStatus
        FORMAT_UNKNOWN
        GENERAL
        EDITOR
        METADATA
        DIFFICULTY
        VARIABLES
        EVENTS
        TIMINGPOINTS
        COLOURS
        HITOBJECTS
    End Enum
    Public Sub GetDetail()
        path = System.IO.Path.Combine(location, name)
        Dim content As New List(Of String)
        content.AddRange(File.ReadAllLines(path))
        If osb <> "" Then
            content.AddRange(File.ReadAllLines(IO.Path.Combine(location, osb)))
        End If
        Dim position As New osuFileScanStatus
        Try
            position = osuFileScanStatus.FORMAT_UNKNOWN
            For Each row In content
                If row.Trim = "" Then Continue For
                If row.StartsWith("//") Or row.Length = 0 Then
                    Continue For
                End If
                If row.StartsWith("[") Then
                    position = CType(System.Enum.Parse(GetType(osuFileScanStatus), row.Substring(1, row.Length - 2).ToUpper()), osuFileScanStatus)
                    If position = osuFileScanStatus.EVENTS Then tmpSB.Add("[Events]")
                    If position = osuFileScanStatus.VARIABLES Then tmpSB.Add("[Variables]")
                    Continue For
                End If
                Select Case position
                    Case osuFileScanStatus.FORMAT_UNKNOWN
                        Rawdata(OSUfile.FileVersion) = row.Substring(17)
                        Exit Select
                    Case osuFileScanStatus.GENERAL, osuFileScanStatus.METADATA, osuFileScanStatus.EDITOR, osuFileScanStatus.DIFFICULTY
                        Dim s As String() = row.Split(New Char() {":"}, 2)
                        Rawdata(System.Enum.Parse(GetType(OSUfile), s(0).Trim)) = s(1).Trim
                        Exit Select
                    Case osuFileScanStatus.EVENTS
                        If row.StartsWith("0,0,") Then
                            Dim str As String = row.Substring(5, row.Length - 6)
                            If str.Contains("""") Then
                                backgroundOffset = str.Substring(str.IndexOf("""") + 2)
                                str = str.Substring(0, str.IndexOf(""""))
                            End If
                            background = str
                        ElseIf row.StartsWith("1,") Or row.StartsWith("Video") Then
                            haveVideo = True
                            Dim vdata As String() = row.Split(",")
                            VideoOffset = Convert.ToInt32(vdata(1))
                            Video = vdata(2).Substring(1, vdata(2).Length - 2)
                        ElseIf row.StartsWith("3,") Or row.StartsWith("2,") Then
                            Exit Select
                        Else
                            tmpSB.Add(row)
                            haveSB = True
                        End If
                    Case osuFileScanStatus.VARIABLES
                        tmpSB.Add(row)
                    Case osuFileScanStatus.TIMINGPOINTS
                        Dim tmp As New Timing
                        Dim tmpop As String
                        tmp.offset = Int(Convert.ToDouble(picknext(row)))
                        tmp.bpm = Convert.ToDouble(picknext(row))
                        tmpop = picknext(row)
                        If tmpop = "" Then tmp.meter = 4 Else tmp.meter = Convert.ToInt32(tmpop)
                        tmpop = picknext(row)
                        If tmpop = "" Then
                            tmp.sample = New CSample(TSample.Normal, 0)
                        Else
                            tmp.sample = New CSample(System.Enum.Parse(GetType(TSample), tmpop), Convert.ToInt32(picknext(row)))
                        End If
                        tmpop = picknext(row)
                        If tmpop = "" Then tmp.volume = 100 Else tmp.volume = Convert.ToInt32(tmpop)
                        tmpop = picknext(row)
                        If tmpop = "" Then tmp.type = 1 Else tmp.type = Convert.ToInt32(tmpop)
                        tmpop = picknext(row)
                        If tmpop = "" Then tmp.kiai = 0 Else tmp.kiai = Convert.ToInt32(tmpop)
                        If tmp.type = 1 Then
                            tmp.bpm = 60000 / tmp.bpm
                        Else
                            tmp.bpm = -100 / tmp.bpm
                        End If
                        timingpoints.Add(tmp)
                    Case osuFileScanStatus.HITOBJECTS
                        Dim tmp As New HitObject
                        Dim tmpop As String
                        Dim tmpspilt() As String
                        tmp.x = Convert.ToInt32(picknext(row))
                        tmp.y = Convert.ToInt32(picknext(row))
                        tmp.starttime = Convert.ToInt32(picknext(row))
                        Select Case check(picknext(row))
                            Case ObjectFlag.Normal
                                tmp.allhitsound = Convert.ToInt32(picknext(row))
                                tmpop = picknext(row)
                                If tmpop <> "" Then
                                    If tmpop.Length > 3 Then
                                        tmp.sample = New CSample(Convert.ToInt32(tmpop(0)), Convert.ToInt32(tmpop(4)))
                                        If tmpop.Length < 7 Then tmpop = tmpop & ":0:"
                                        tmp.A_sample = New CSample(Convert.ToInt32(tmpop(2)), Convert.ToInt32(tmpop(6)))
                                    Else
                                        tmp.sample = New CSample(Convert.ToInt32(tmpop(0)), Convert.ToInt32(tmpop(2)))
                                        tmp.A_sample = New CSample(TSample.Normal, 0)
                                    End If
                                Else
                                    tmp.sample = New CSample(TSample.Normal, 0)
                                    tmp.A_sample = New CSample(TSample.Normal, 0)
                                End If
                                Exit Select
                            Case ObjectFlag.Spinner
                                tmp.allhitsound = Convert.ToInt32(picknext(row))
                                tmp.EndTime = Convert.ToInt32(picknext(row))
                                tmpop = picknext(row)
                                If tmpop <> "" Then
                                    If tmpop.Length > 3 Then
                                        tmp.sample = New CSample(Convert.ToInt32(tmpop(0)), Convert.ToInt32(tmpop(4)))
                                        If tmpop.Length < 7 Then tmpop = tmpop & ":0:"
                                        tmp.A_sample = New CSample(Convert.ToInt32(tmpop(2)), Convert.ToInt32(tmpop(6)))
                                    Else
                                        tmp.sample = New CSample(Convert.ToInt32(tmpop(0)), Convert.ToInt32(tmpop(2)))
                                        tmp.A_sample = New CSample(TSample.Normal, 0)
                                    End If
                                Else
                                    tmp.sample = New CSample(TSample.Normal, 0)
                                    tmp.A_sample = New CSample(TSample.Normal, 0)
                                End If
                                Exit Select
                            Case ObjectFlag.Slider
                                tmp.allhitsound = Convert.ToInt32(picknext(row))
                                tmpop = picknext(row)
                                'ignore all anthor
                                tmpop = picknext(row)
                                If tmpop <> "" Then tmp.repeatcount = Convert.ToInt32(tmpop) Else tmp.repeatcount = 0
                                tmpop = picknext(row)
                                If tmpop <> "" Then tmp.length = Convert.ToDouble(tmpop) Else tmp.length = 0
                                tmpop = picknext(row)
                                tmp.Hitsounds = New List(Of Integer)
                                tmp.samples = New List(Of CSample)
                                tmp.A_samples = New List(Of CSample)
                                If tmpop <> "" Then
                                    tmpspilt = tmpop.Split(New Char() {"|"})
                                    For Each s In tmpspilt
                                        tmp.Hitsounds.Add(Convert.ToInt32(s))
                                    Next
                                End If
                                tmpop = picknext(row)
                                If tmpop <> "" Then
                                    tmpspilt = tmpop.Split(New Char() {"|"})
                                    For Each s In tmpspilt
                                        tmp.samples.Add(New CSample(System.Enum.Parse(GetType(TSample), s(0)), 0))
                                        tmp.A_samples.Add(New CSample(System.Enum.Parse(GetType(TSample), s(2)), 0))
                                    Next
                                End If
                                tmpop = picknext(row)
                                If tmpop <> "" Then
                                    If tmpop.Length > 3 Then
                                        tmp.sample = New CSample(Convert.ToInt32(tmpop(0)), Convert.ToInt32(tmpop(4)))
                                        If tmpop.Length < 7 Then tmpop = tmpop & ":0:"
                                        tmp.A_sample = New CSample(Convert.ToInt32(tmpop(2)), Convert.ToInt32(tmpop(6)))
                                    Else
                                        tmp.sample = New CSample(Convert.ToInt32(tmpop(0)), Convert.ToInt32(tmpop(2)))
                                        tmp.A_sample = New CSample(TSample.Normal, 0)
                                    End If
                                Else
                                    tmp.sample = New CSample(TSample.Normal, 0)
                                    tmp.A_sample = New CSample(TSample.Normal, 0)
                                End If
                                Exit Select
                                'HitSound,(SampleSet&Addition|SampleSet&Addition),(All SampleSet&Addition)
                                'SampleSet&Addition 只有sample没有setcount
                                'All SampleSet&Addition 啥都有
                                '数值1为不反复
                                'Length=长度（乘以每小节时间60000/BPM再乘以滑条速度SliderMultiplier为滑条时间长度）
                                'HitSound S1|S2|S3|S4......Sn 计算公式n=RepeatCount+1
                            Case Else
                                'Throw New FormatException("Failed to read .osu file")
                                'this is for mania
                        End Select

                End Select
            Next
        Catch e As SystemException
            Console.WriteLine(e.StackTrace)
            Throw New FormatException("Failed to read .osu file", e)
        End Try
        tags = Rawdata(OSUfile.Tags)
        If tags <> "" Then
            For Each s As String In tags.Split(" ")
                I_tagList.Add(s)
            Next
        End If
        If haveSB Then SB = New StoryBoard(tmpSB)
    End Sub
    Public Sub New(location_F As String, name_F As String, osb_F As String)
        location = location_F
        name = name_F
        osb = osb_F
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