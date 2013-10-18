Imports OSU_Toolbox.Selfupdate
Imports OSU_Toolbox.Core
Imports OSU_Toolbox.OsuDB
Public Class Form1
    Public uin As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'check_update()
        Getpath()
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
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        getsong()
    End Sub
    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        Try
            If IO.Directory.Exists(IO.Path.Combine(osupath, "Songs")) Then scanforset(IO.Path.Combine(osupath, "Songs"))
        Catch ex As SystemException
            Console.WriteLine(ex.StackTrace)
            Throw New FormatException("Failed to read song path", ex)
        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedIndices.Count = 0 Then Exit Sub
        Dim tmp As BeatmapSet
        ListBox1.Items.Clear()
        tmp = allsets.Item(ListView1.SelectedIndices(0))
        If Not tmp.detailed Then tmp.GetDetail()
        For Each s In tmp.diffstr
            ListBox1.Items.Add(s)
        Next
    End Sub
    Public Function ThumbnailCallback() As Boolean
        Return False
    End Function
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If (ListBox1.SelectedIndices.Count = 0) Or (ListView1.SelectedIndices.Count = 0) Then Exit Sub
        Dim tmp As BeatmapSet = allsets.Item(ListView1.SelectedIndices(0))
        Dim tmpbm As Beatmap = tmp.Diffs(ListBox1.SelectedIndex)
        If tmpbm.haveVideo Then
            Dim tempvideo As New Videofiles
            tempvideo.path = IO.Path.Combine(tmpbm.location, tmpbm.Video)
            tempvideo.Play(Me.Panel1)
        Else
            Dim tmpimg As System.Drawing.Image
            tmpimg = Image.FromFile(IO.Path.Combine(tmpbm.location, tmpbm.background))
            Dim myCallback As New Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
            Panel1.BackgroundImage = tmpimg.GetThumbnailImage(Panel1.Width, Panel1.Height, myCallback, IntPtr.Zero)
            tmpimg.Dispose()
        End If
    End Sub
End Class
