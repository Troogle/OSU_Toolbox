Public Class Core
    Public Function Getpath() As String
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
End Class

