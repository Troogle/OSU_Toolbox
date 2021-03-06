﻿Imports OSU_Toolbox.Selfupdate
Imports OSU_Toolbox.Core
Imports OSU_Toolbox.OsuDB
Public Class Form1
    Public uin As String
    Public uni_Video As New Videofiles
    'Public uni_Audio As New Audiofiles
    Public uni_timer As New Stopwatch
    Public first_P As Boolean = True
    Dim tmp As BeatmapSet
    Dim tmpbm As Beatmap
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Un4seen.Bass.BassNet.Registration("sqh1994@163.com", "2X280331512622")
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
    Private Sub setbg()
        Dim tmpimg As System.Drawing.Image
        Dim bgpath As String
        If tmpbm.background = "" Then bgpath = defaultBG Else bgpath = IO.Path.Combine(tmpbm.location, tmpbm.background)
        tmpimg = Image.FromFile(bgpath)
        Dim myCallback As New Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
        Panel1.BackgroundImage = tmpimg.GetThumbnailImage(Panel1.Width, Panel1.Height, myCallback, IntPtr.Zero)
        tmpimg.Dispose()
    End Sub
    Private Sub Play()
        uni_timer.Start()
        If tmpbm.haveVideo Then
            uni_Video.init(IO.Path.Combine(tmpbm.location, tmpbm.Video))
            uni_Video.Play(Me.Panel1)
            uni_Video.Pause()
            uni_Video.Pause()
        End If
        TrackBar1.Enabled = True
        first_P = False
    End Sub
    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        If PlayButton.Text = "播放" Then
            If first_P Then Play() Else uni_Video.Pause()
            PlayButton.Text = "暂停"
        Else
            'uni_Video.Pause()
            'uni_timer.Stop()
            PlayButton.Text = "播放"
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click
        Form2.Show()
    End Sub
    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        Try
            Superscanforset()
        Catch ex As SystemException
            Console.WriteLine(ex.StackTrace)
            Throw New FormatException("Failed to read song path", ex)
        End Try
    End Sub
    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Play()
        PlayButton.Text = "暂停"
    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedIndices.Count = 0 Then Exit Sub
        ListBox1.Items.Clear()
        ListDetail.Items.Clear()
        tmp = allsets.Item(ListView1.SelectedIndices(0))
        If Not tmp.detailed Then tmp.GetDetail()
        For Each s In tmp.diffstr
            ListBox1.Items.Add(s)
        Next
        tmpbm = tmp.Diffs(0)
        For i As OSUfile = OSUfile.FileVersion To OSUfile.SliderTickRate
            Dim tmpl As New ListViewItem(i.ToString)
            tmpl.SubItems.Add(tmpbm.Rawdata(i))
            ListDetail.Items.Add(tmpl)
        Next
        Try
            uni_Video.dispose()
            TrackBar1.Enabled = False
        Catch ex As Exception

        End Try

        setbg()
    End Sub
    Public Function ThumbnailCallback() As Boolean
        Return False
    End Function
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If (ListBox1.SelectedIndices.Count = 0) Or (ListView1.SelectedIndices.Count = 0) Then Exit Sub
        tmpbm = tmp.Diffs(ListBox1.SelectedIndex)
        setbg()
        first_P = True
        PlayButton.Text = "播放"
    End Sub

    Private Sub TrackBar1_MouseDown(sender As Object, e As MouseEventArgs) Handles TrackBar1.MouseDown

    End Sub

    Private Sub TrackBar1_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackBar1.MouseUp
        uni_Video.seek(TrackBar1.Value / 100 * uni_Video.durnation)
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs)
        Dim ts As TimeSpan = uni_timer.Elapsed
        TrackBar1.Value = CInt(uni_Video.current / uni_Video.durnation * 100)
    End Sub
End Class
