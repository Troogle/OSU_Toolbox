Public Class QQ
    Public Class QQInfo
        Public uin As Integer
        Public nick As String
    End Class
    Public web As WebBrowser = New WebBrowser()
    Public Sub New()
        Dim url As String = "http://xui.ptlogin2.qq.com/cgi-bin/qlogin"
        Web.Url = New Uri(url)
    End Sub
    Public Sub Send2QQ(id As UInteger, Str As String)
        Shell("QSetinfo " + id.ToString + " " + Str)
    End Sub
    Public Function GetQQList() As List(Of QQInfo)
        Dim ref As New List(Of QQInfo)
        Try
            If web.ReadyState = WebBrowserReadyState.Complete Then
                Dim doc As HtmlDocument = web.Document
                Dim uinList As HtmlElement = doc.GetElementById("list_uin")
                If uinList <> Nothing Then
                    For i = 0 To uinList.Children.Count - 1
                        Dim str As String = uinList.Children(i).InnerText.Trim()
                        Dim temp() As String = str.Split(New Char() {" "c})
                        Dim nick As String = temp(0)
                        Dim uin As String = temp(1)
                        uin = uin.Replace("(", "").Replace(")", "")
                        Dim NInfo As New QQInfo()
                        NInfo.nick = nick
                        NInfo.uin = Convert.ToInt32(uin)
                        ref.Add(NInfo)
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox("获取当前在线QQ出错！")
        End Try
        Return ref

    End Function
End Class
