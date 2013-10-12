Imports System.Collections.Generic
Imports System.IO
Imports System.Text
Public Class OSUGeneral
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
    Public Class osuFileFormatReader

        Private Shared position As osuFileScanStatus

        Public Shared Function Read(osuFile As String) As Dictionary(Of String, String)
            Try
                Dim b As New Dictionary(Of String, String)()
                position = osuFileScanStatus.FORMAT_UNKNOWN
                For Each row In File.ReadAllLines(osuFile)
                    If row.StartsWith("//") OrElse row.Length = 0 Then
                        Continue For
                    End If
                    If row.StartsWith("[") Then
                        position = CType(System.[Enum].Parse(GetType(osuFileScanStatus), row.Substring(1, row.Length - 2).ToUpper()), osuFileScanStatus)
                        Continue For
                    End If
                    Select Case position
                        Case osuFileScanStatus.FORMAT_UNKNOWN
                            b.Add("FileFormat", row.Substring(17))
                            Exit Select
                        Case osuFileScanStatus.GENERAL, osuFileScanStatus.EDITOR, osuFileScanStatus.METADATA, osuFileScanStatus.DIFFICULTY
                            Dim s As String() = row.Split(New Char() {":"c}, 2)
                            b.Add(s(0).Trim(), s(1).Trim())
                            Exit Select
                        Case osuFileScanStatus.EVENTS
                            If row.StartsWith("//") Then
                                Exit Select
                            ElseIf row.StartsWith("0,0,""") Then
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
                                ' TODO: storyboards

                                If r.StartsWith("Animation") Then

                                ElseIf r.StartsWith("Sprite") Then

                                Else
                                End If
                            End If
                            Exit Select
                    End Select
                Next
                If Not b.ContainsKey("Background") Then
                    b.Add("Background", "none")
                End If
                Return b
            Catch e As SystemException
                Console.WriteLine(e.StackTrace)
                Throw New FormatException("Failed to read .osu file", e)
            End Try
        End Function
    End Class

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
End Class
