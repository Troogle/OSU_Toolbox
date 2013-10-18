Imports Microsoft.DirectX.AudioVideoPlayback
Imports Un4seen.Bass
Public Class Audiofiles
    Public path As String
    Public name As String
    Public Sub init()
        Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_3D, IntPtr.Zero)
    End Sub

    Public Sub Play(volume As Integer)

    End Sub
End Class
Public Class Videofiles
    Public offset As Integer
    Private videofile As Video
    Public ReadOnly Property durnation As Double
        Get
            Return videofile.Duration
        End Get
    End Property
    Public ReadOnly Property current As Double
        Get
            Return videofile.CurrentPosition
        End Get
    End Property
    Public Sub init(path As String)
        videofile = New Video(path)
    End Sub
    Public Sub dispose()
        videofile.Dispose()
    End Sub
    Public Sub Play(panel As Windows.Forms.Panel)
        Dim height As Integer = panel.Height
        Dim width As Integer = panel.Width
        videofile.Owner = panel
        panel.Width = width
        panel.Height = height
        videofile.Size = panel.Size
        videofile.Play()
    End Sub
    Public Sub Pause()
        If videofile.Paused Then videofile.Play() Else videofile.Pause()
    End Sub
    Public Sub seek(time As Double)
        videofile.SeekCurrentPosition(time, SeekPositionFlags.AbsolutePositioning)
    End Sub
End Class