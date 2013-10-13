Imports Microsoft.DirectX.AudioVideoPlayback
Imports Un4seen.Bass
Public Class Audiofiles
    Public path As String
    Public name As String
    Public Sub Play(volume As Integer)

    End Sub
End Class
Public Class Videofiles
    Public path As String
    Public offset As Integer
    Public Sub Play(panel As Windows.Forms.Panel)
        Dim videofile As Video = New Video(path)
        Dim height As Integer = panel.Height
        Dim width As Integer = panel.Width
        videofile.Owner = panel
        panel.Width = width
        panel.Height = height
        videofile.Size = panel.Size
        videofile.Play()
    End Sub
    Public Sub Pause()

    End Sub
End Class