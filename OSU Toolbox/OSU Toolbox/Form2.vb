Imports OSU_Toolbox.QQ
Public Class Form2
    Public qq As New QQ
    Dim ref As New List(Of QQInfo)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ref = qq.GetQQList()
        ListView1.Clear()
        ListView1.Columns.Add("ID", 100)
        ListView1.Columns.Add("昵称", 100)
        Try
            For i = 0 To ref.Count - 1
                Dim Tmp As New ListViewItem
                Tmp.Text = ref.Item(i).uin.ToString
                Tmp.SubItems.Add(ref.Item(i).nick)
                ListView1.Items.Add(Tmp)
            Next
        Catch ex As Exception
            MsgBox("获取当前在线QQ出错！")
        End Try
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs)

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.LabelQQ.Text = "当前同步QQ：" + ListView1.SelectedItems(0).Text
        Me.Dispose()
    End Sub
End Class