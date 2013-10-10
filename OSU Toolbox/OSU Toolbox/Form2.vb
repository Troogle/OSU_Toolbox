Imports OSU_Toolbox.QQ
Public Class Form2
    Public qq As New QQ
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        qq.GetQQList()
        ListView1 = qq.ListofQQ
    End Sub
End Class