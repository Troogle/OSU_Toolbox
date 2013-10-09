Imports OSU_Toolbox.QQ
Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim q_List As New List(Of String)
        Dim qq As New QQ
        q_List = qq.GetQQList()
        For i = 0 To q_List.Count
            ListBox1.Items.Add(q_List.Item(i))
        Next
    End Sub
End Class