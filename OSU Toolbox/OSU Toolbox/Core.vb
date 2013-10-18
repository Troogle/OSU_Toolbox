Imports System.IO
Public Class Core
    Public Shared osupath As String
    Public Shared allsets As New List(Of BeatmapSet)
    Public Shared defaultBG As String
    Public Shared Sub Getpath()
        Dim str As String
        Try
            Dim rk As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("osu!\shell\open\command")
            str = rk.GetValue("")
            str = Strings.Mid(str, 2, InStr(2, str, """") - 10)
            osupath = str
        Catch ex As Exception
            MessageBox.Show("读取游戏目录出错! 请手动指定", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            osupath = ""
        End Try
    End Sub
    Public Shared Function getsong() As String
        Return ""
    End Function
    Public Shared Sub scanforset(path As String)
        Dim osufiles As String() = Directory.GetFiles(path, "*.osu")
        If osufiles.Length <> 0 Then
            Dim tmp As New BeatmapSet(path)
            allsets.Add(tmp)
            Form1.ListView1.Items.Add(tmp.name)
        Else
            Dim subfolder As String() = Directory.GetDirectories(path)
            For i As Integer = 0 To subfolder.Length - 1
                scanforset(IO.Path.Combine(path, subfolder(i)))
            Next
        End If
    End Sub
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
    End Structure

End Class
Class DoubleBufferListView
    Inherits ListView
    Public Sub New()
        SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        UpdateStyles()
    End Sub
End Class
