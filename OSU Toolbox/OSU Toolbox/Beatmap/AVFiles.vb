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
    Private _stream As Integer = 0
    Private _fileName As String = [String].Empty
    Private _sync As SYNCPROC = Nothing
    Private _updateInterval As Integer = 1
    ' 1ms
    Private _updateTimer As Un4seen.Bass.BASSTimer = Nothing
    Private _isPaused As Boolean = False
    Public Shared Sub CreateDevice()
        Un4seen.Bass.BassNet.Registration("dgsrz2@gmail.com", "2X9151216152222")
        Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_3D, IntPtr.Zero)
    End Sub
    Public Sub New(fileName As String)
        _fileName = fileName
        _updateTimer = New Un4seen.Bass.BASSTimer(_updateInterval)
        _sync = New SYNCPROC(AddressOf EndPosition)

        Bass.BASS_StreamFree(_stream)
        If _fileName <> [String].Empty Then
            Dim flag As BASSFlag = BASSFlag.BASS_SAMPLE_FLOAT Or BASSFlag.BASS_STREAM_PRESCAN
            _stream = Bass.BASS_StreamCreateFile(_fileName, 0, 0, flag)
        End If
        If _stream = 0 Then

        End If
    End Sub

    Public Sub Play(Optional volume__1 As Single = 1.0F)
        _updateTimer.[Stop]()
        If _stream <> 0 AndAlso Bass.BASS_ChannelPlay(_stream, True) Then
            _updateTimer.Start()
        Else
            Throw New Exception("Internal Error! " & Bass.BASS_ErrorGetCode())
        End If
        Volume = volume__1
    End Sub

    Public Sub SeekSamplePosition(position As Double)
        If IsPlaying() Then
            Bass.BASS_ChannelSetPosition(_stream, Bass.BASS_ChannelSeconds2Bytes(_stream, position))
        End If
    End Sub

    Public Sub PauseOrResume()
        If _isPaused Then
            _updateTimer.Start()
            Bass.BASS_ChannelPlay(_stream, False)
        Else
            _updateTimer.[Stop]()
            Bass.BASS_ChannelPause(_stream)
        End If
        _isPaused = Not _isPaused
    End Sub

    Public Function IsPlaying() As Boolean
        Return Bass.BASS_ChannelIsActive(_stream) = BASSActive.BASS_ACTIVE_PLAYING
    End Function

    Public Sub [Stop](release As Boolean)
        _updateTimer.[Stop]()

        If release Then
            Bass.BASS_StreamFree(_stream)
            _stream = 0
        Else
            Bass.BASS_ChannelStop(_stream)
        End If
    End Sub

    Private Sub EndPosition(handle As Integer, channel As Integer, data As Integer, user As IntPtr)
        Bass.BASS_ChannelStop(channel)
    End Sub

    Public ReadOnly Property ChannelGetLength() As Long
        Get
            Return Bass.BASS_ChannelGetLength(_stream)
        End Get
    End Property

    Public ReadOnly Property ChannelGetPosition() As Long
        Get
            Return Bass.BASS_ChannelGetPosition(_stream)
        End Get
    End Property

    Public Function Bytes2Second(pos As Long) As Double
        Return Bass.BASS_ChannelBytes2Seconds(_stream, pos)
    End Function

    Public Sub Dispose()
        Release()
    End Sub

    Public Shared Sub Release()
        Bass.BASS_Stop()
        ' close bass
        Bass.BASS_Free()
    End Sub

    Public Property Volume() As Single
        Get
            Dim vol As Single = 1.0F
            Bass.BASS_ChannelGetAttribute(_stream, BASSAttribute.BASS_ATTRIB_VOL, vol)
            Return vol
        End Get
        Set(value As Single)
            Bass.BASS_ChannelSetAttribute(_stream, BASSAttribute.BASS_ATTRIB_VOL, value)
        End Set
    End Property

    Public ReadOnly Property IsPaused() As Boolean
        Get
            Return _isPaused
        End Get
    End Property
    Public Property UpdateTimer() As Un4seen.Bass.BASSTimer
        Get
            Return _updateTimer
        End Get
        Set(value As Un4seen.Bass.BASSTimer)
            _updateTimer = value
        End Set
    End Property
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
        videofile.SeekCurrentPosition(time, SeekPositionFlags.IncrementalPositioning)
    End Sub
End Class