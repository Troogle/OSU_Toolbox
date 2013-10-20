Imports System.IO
Public Class Core
    Public Shared osupath As String
    Public Shared allsets As New List(Of BeatmapSet)
    Public Shared defaultBG As String = Path.Combine(Application.StartupPath, "default\") & "defaultBG.png"
    Public Shared Sub Getpath()
        Dim str As String
        Try
            Dim rk As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("osu!\shell\open\command")
            str = rk.GetValue("").ToString
            str = Strings.Mid(str, 2, InStr(2, str, """") - 10)
            osupath = str
        Catch ex As Exception
            MessageBox.Show("读取游戏目录出错! 请手动指定", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            osupath = ""
        End Try
    End Sub
    Private Declare Function GetDesktopWindow Lib "user32" () As Integer
    Private Declare Function GetForegroundWindow Lib "user32" () As Integer
    Private Declare Function GetWindow Lib "user32" (ByVal hwnd As Integer, ByVal wCmd As Integer) As Integer
    Private Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Integer, ByVal lpString As String, ByVal cch As Integer) As Integer
    Private Const GW_CHILD = 5
    Private Const GW_HWNDNEXT = 2
    Public Shared Function getsong() As String
        Dim hwnd As Integer
        Dim strTitle As String = ""
        hwnd = GetDesktopWindow()
        hwnd = GetWindow(hwnd, GW_CHILD)
        Do While hwnd <> 0
            GetWindowText(hwnd, strTitle, 255)
            If strTitle.Contains("osu!") Then
                Return strTitle
            End If
            hwnd = GetWindow(hwnd, GW_HWNDNEXT)
        Loop
        Return ""
    End Function
    Public Shared Sub Superscanforset()
        If IO.Directory.Exists(IO.Path.Combine(osupath, "Songs")) Then scanforset(IO.Path.Combine(osupath, "Songs\1108"))
    End Sub
    Public Shared Sub scanforset(path As String)
        Dim osufiles As String() = Directory.GetFiles(path, "*.osu")
        If osufiles.Length <> 0 Then
            Dim tmp As New BeatmapSet(path)
            'tmp.GetDetail()
            allsets.Add(tmp)
            Dim tmpl As New ListViewItem(tmp.name)
            Form1.ListView1.Items.Add(tmpl)
        Else
            Dim subfolder As String() = Directory.GetDirectories(path)
            For i As Integer = 0 To subfolder.Length - 1
                scanforset(IO.Path.Combine(path, subfolder(i)))
            Next
        End If
    End Sub
    Public Enum OSUfile
        FileVersion
        AudioFilename
        AudioHash
        AudioLeadIn
        PreviewTime
        Countdown
        SampleSet
        StackLeniency
        Mode
        LetterboxInBreaks
        StoryFireInFront
        EpilepsyWarning
        CountdownOffset
        WidescreenStoryboard
        EditorBookmarks
        EditorDistanceSpacing
        UseSkinSprites
        OverlayPosition
        SkinPreference
        SpecialStyle
        CustomSamples
        Bookmarks
        DistanceSpacing
        BeatDivisor
        GridSize
        CurrentTime
        Title
        TitleUnicode
        Artist
        ArtistUnicode
        Creator
        Version
        Source
        Tags
        BeatmapID
        BeatmapSetID
        HPDrainRate
        CircleSize
        OverallDifficulty
        ApproachRate
        SliderMultiplier
        SliderTickRate
    End Enum
    Public Enum ObjectFlag
        Normal = 1
        Slider = 2
        NewCombo = 4
        NormalNewCombo = 5
        SliderNewCombo = 6
        Spinner = 8
        SpinnerNewCombo = 12
        ColourHax = 112
        Hold = 128
        ManiaLong = 128
    End Enum
    Public Enum HitSound
        Normal = 0
        Whistle = 2
        Finish = 4
        Clap = 8
    End Enum
    Public Enum TSample
        Normal
        Soft
        Drum
    End Enum
    Public Structure CSample
        Public sample As TSample
        Public sampleset As Integer
        Public Sub New(sample As Integer, sampleset As Integer)
            Me.sampleset = sampleset
            Me.sample = CType(sample, TSample)
        End Sub
    End Structure

End Class
