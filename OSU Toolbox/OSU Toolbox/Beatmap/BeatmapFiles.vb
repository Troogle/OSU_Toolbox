Imports System.IO
Public Class BeatmapFiles
    Public location As String
    Public Osbfilename As String
    Public Diffs As New List(Of Beatmap)
    Public count As Integer 'number of diffs
    Public Structure Metadata
        'metadata/set ID
    End Structure
    'no set-wide storyboard,fill it in per diffs
    Public Sub New(path As String)
        count = 0
        location = path
        Dim F As New DirectoryInfo(location)
        Dim file As FileInfo
        'Dim files As String() = Directory.GetFiles(path, "*.osb", SearchOption.AllDirectories)
        'osb first
        For Each file In F.GetFiles
            Select Case file.Extension
                Case ".osu"
                    count += 1
                    Dim bm As Beatmap
                    Try
                        bm = New Beatmap(location, file.Name)
                        Diffs.Add(bm)
                    Catch generatedExceptionName As SystemException
                        Console.WriteLine("Failed to read beatmap: " & file.FullName)
                    End Try
                Case ".osb"

                Case ".mp3"

                Case ".ogg"

                Case ".wav"

                Case ".avi"

                Case ".flv"
            End Select
        Next
    End Sub

End Class
