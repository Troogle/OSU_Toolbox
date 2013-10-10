Imports System.Net
Imports System.IO
Public Class Selfupdate
    Shared AppPath As String = My.Application.Info.DirectoryPath & "\"
    Shared XmlFilePath As String = AppPath & "update.xml"
    Shared UpDateXml As New Xml.XmlDocument
    Shared url As String = ""
    Shared ver As String = ""
    Shared temp As String = Environment.GetEnvironmentVariable("Temp").ToString & "\"
    Shared WithEvents myWebclient As Net.WebClient
    Shared Sub download(ByVal url As String)
        Dim res As DialogResult
        Try
            My.Computer.Network.DownloadFile(url, My.Computer.FileSystem.CombinePath(temp, My.Computer.FileSystem.GetName(url)), "", "", False, 10000, True)
            UpDateXml.Load(temp & "update.xml")
            Dim newver As String
            newver = UpDateXml.SelectNodes("/Xml/Version").Item(0).InnerText
            If newver > ver Then
                res = MessageBox.Show("新版本" & newver & "发布了~", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                If res = Windows.Forms.DialogResult.OK Then Process.Start(UpDateXml.SelectNodes("/Xml/Link").Item(0).InnerText)
            End If
        Catch ex As Exception
            MessageBox.Show("更新配置文件出错!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Public Shared Sub check_update()
        Try
            UpDateXml.Load(XmlFilePath)
            url = UpDateXml.SelectNodes("/Xml/Url").Item(0).InnerText
            ver = UpDateXml.SelectNodes("/Xml/Version").Item(0).InnerText
        Catch ex As Exception
            MessageBox.Show("本地配置文件出错!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        download(url & "update.xml")
    End Sub
End Class
