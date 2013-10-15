Imports System.IO
Imports OSU_Toolbox.Core
Public Class BeatmapSet
    Public location As String
    Public Osbfilename As String
    Public Diffs As New List(Of Beatmap)
    Public count As Integer 'number of diffs
    Public beatmapsetId As Integer
    'no set-wide storyboard,fill it in per diffs
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
            soundtype = Int(soundtype / 2)
            If soundtype = 0 Then Return tmp
            If soundtype Mod 2 = 1 Then tmp.Add(all + "-hitwhistle.wav")
            soundtype = Int(soundtype / 2)
            If soundtype = 0 Then Return tmp
            If soundtype Mod 2 = 1 Then tmp.Add(all + "-finish.wav")
            soundtype = Int(soundtype / 2)
            If soundtype = 0 Then Return tmp
            If soundtype Mod 2 = 1 Then tmp.Add(all + "-hitclap.wav")
            soundtype = Int(soundtype / 2)
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
        soundtype = Int(soundtype / 2)
        If soundtype = 0 Then Return tmp
        If soundtype Mod 2 = 1 Then tmp.Add(check(first + "-hitwhistle" + last))
        soundtype = Int(soundtype / 2)
        If soundtype = 0 Then Return tmp
        If soundtype Mod 2 = 1 Then tmp.Add(check(first + "-finish" + last))
        soundtype = Int(soundtype / 2)
        If soundtype = 0 Then Return tmp
        If soundtype Mod 2 = 1 Then tmp.Add(check(first + "-hitclap" + last))
        soundtype = Int(soundtype / 2)
        Return tmp
    End Function
    Public Sub New(path As String)
        count = 0
        location = path
        Dim F As New DirectoryInfo(location)
        Dim file As FileInfo
        Dim osbfiles As String() = Directory.GetFiles(path, "*.osb")
        If osbfiles.Length <> 0 Then
            Osbfilename = osbfiles(0)
        End If
        'osb first
        For Each file In F.GetFiles
            Select Case file.Extension
                Case ".osu"
                    count += 1
                    Dim bm As Beatmap
                    Try
                        bm = New Beatmap(location, file.Name, Osbfilename)
                        Diffs.Add(bm)
                    Catch generatedExceptionName As SystemException
                        Console.WriteLine("Failed to read beatmap: " & file.FullName)
                    End Try
                    '.mp3 .wav .png .jpg who cares?
            End Select
        Next
        'beatmapsetId = Diffs(0).beatmapsetId
    End Sub
    Public Overrides Function ToString() As String
        Return Diffs(0).artistRomanized & " - " & Diffs(0).titleRomanized
    End Function
End Class
