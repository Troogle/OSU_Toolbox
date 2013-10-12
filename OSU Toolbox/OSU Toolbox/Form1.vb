Imports OSU_Toolbox.Selfupdate
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        check_update()
    End Sub
    Private Sub AskForExit(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim close As DialogResult
        close = MessageBox.Show("确认退出？", "提示", MessageBoxButtons.YesNo)
        If close = DialogResult.Yes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        If PlayButton.Text = "播放" Then PlayButton.Text = "暂停" Else PlayButton.Text = "播放"

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
    End Sub
End Class
