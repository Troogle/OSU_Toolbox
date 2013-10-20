Imports System.IO
Imports OSU_Toolbox.Core
Public Class BeatmapSet
    Public location As String
    Public Osbfilename As String
    Public count As Integer 'number of diffs
    Public name As String
    Public diffstr As New List(Of String)
    Public detailed As Boolean = False
    Public Diffs As New List(Of Beatmap)
    Private Function check(url As String) As String
        If File.Exists(Path.Combine(location, url + ".wav")) Then Return (url + ".wav") Else Return (url + ".mp3")
    End Function
    Public Function getsamplename(sample As CSample, soundtype As Integer, objecttype As Integer) As List(Of String)
        Dim tmp As New List(Of String)
        If objecttype = ObjectFlag.Spinner Or objecttype = ObjectFlag.SpinnerNewCombo Then Return tmp
        Dim last As String
        If sample.sampleset = 0 Then
            Dim all As String = Path.Combine(Application.StartupPath, "\defalut\") & [Enum].GetName(GetType(TSample), sample.sample)
            If soundtype Mod 2 = 0 Then tmp.Add(all + "-hitnormal.wav")
            soundtype = CInt(soundtype / 2)
            If soundtype = 0 Then Return tmp
            If soundtype Mod 2 = 1 Then tmp.Add(all + "-hitwhistle.wav")
            soundtype = CInt(soundtype / 2)
            If soundtype = 0 Then Return tmp
            If soundtype Mod 2 = 1 Then tmp.Add(all + "-finish.wav")
            soundtype = CInt(soundtype / 2)
            If soundtype = 0 Then Return tmp
            If soundtype Mod 2 = 1 Then tmp.Add(all + "-hitclap.wav")
            soundtype = CInt(soundtype / 2)
            Return tmp
        End If
        If sample.sampleset = 1 Then last = "" Else last = sample.sampleset.ToString
        'normal-sliderslide(loops)
        'normal-sliderwhistle(loops)
        'normal-slidertick
        '不考虑以上
        Dim first As String
        first = [Enum].GetName(GetType(TSample), sample.sample)
        If soundtype Mod 2 = 0 Then tmp.Add(check(first + "-hitnormal" + last))
        soundtype = CInt(soundtype / 2)
        If soundtype = 0 Then Return tmp
        If soundtype Mod 2 = 1 Then tmp.Add(check(first + "-hitwhistle" + last))
        soundtype = CInt(soundtype / 2)
        If soundtype = 0 Then Return tmp
        If soundtype Mod 2 = 1 Then tmp.Add(check(first + "-finish" + last))
        soundtype = CInt(soundtype / 2)
        If soundtype = 0 Then Return tmp
        If soundtype Mod 2 = 1 Then tmp.Add(check(first + "-hitclap" + last))
        soundtype = CInt(soundtype / 2)
        Return tmp
    End Function
    Public Sub New(path As String)
        count = 0
        location = path
        Dim F As New DirectoryInfo(location)
        Dim osbfiles As FileInfo() = F.GetFiles("*.osb")
        If osbfiles.Length <> 0 Then Osbfilename = osbfiles(0).Name
        'osb first
        Dim osufiles As FileInfo() = F.GetFiles("*.osu")
        name = osufiles(0).Name
        name = name.Substring(0, name.LastIndexOf("("))
        For Each s In osufiles
            count += 1
            Dim filename As String = s.Name
            Dim bm As New Beatmap(location, filename, Osbfilename)
            Diffs.Add(bm)
        Next
    End Sub
    Public Sub GetDetail()
        For Each bm In Diffs
            bm.GetDetail()
            diffstr.Add(bm.Version)
        Next
        detailed = True
    End Sub
    Public Overrides Function ToString() As String
        Return name
    End Function
End Class
