Public Class Core
    Public Shared Function Getpath() As String
        Dim str As String
        Try
            Dim rk As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("osu!\shell\open\command")
            str = rk.GetValue("")
            str = Strings.Mid(str, 2, InStr(2, str, """") - 10)
            Getpath = str
        Catch ex As Exception
            MessageBox.Show("读取游戏目录出错! 请手动指定", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Getpath = ""
        End Try
    End Function
    Public Shared Function getsong() As String
        Return ""
    End Function
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

