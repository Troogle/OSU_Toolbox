Public Class StoryBoard
    Public elements As New List(Of SBelement)
    'TODO:单独抽取trigger并作索引
    Public Variables As New List(Of SBvar)
    Public trigger As New Dictionary(Of Triggertype, TriggerEvent)
    Public events As New List(Of SBEvent)
    Public raw As List(Of String)
    '目录由beatmapfiles.location-->beatmap.location
    Public Enum ElementType
        Background
        Video
        Break
        Colour
        Sprite
        Sample
        Animation
    End Enum
    Public Enum ElementLayer
        Background
        Fail
        Pass
        Foreground
    End Enum
    Public Enum ElementOrigin
        TopLeft
        TopCentre
        TopRight
        CentreLeft
        Centre
        CentreRight
        BottomLeft
        BottomCentre
        BottomRight
    End Enum
    Public Enum ElementLoopType
        LoopOnce
        LoopForever
    End Enum
    Public Enum EventType
        'F - fade【隐藏(淡入淡出)】
        'M - move【移动】
        'S - scale【缩放】
        'V - vector scale (width and height separately)【矢量缩放(宽高分别变动)】
        'R - rotate【旋转】
        'C - colour【颜色】
        'L - loop【循环】
        'T - Event-triggered loop【事件触发循环】
        'P - Parameters【参数】
        'Play - 播放sample
        F
        M
        S
        V
        R
        C
        L
        T
        P
        Play
    End Enum
    Public Enum Triggertype
        HitSoundClap
        HitSoundFinish
        HitSoundWhistle
        Passing
        Failing
    End Enum
    Public Structure SBvar
        Public name As String
        Public replace As String
    End Structure
    Public Structure SBEvent
        Public elemnet As Integer
        Public Type As EventType
        Public easing As Integer
        '0 - none【没有缓冲】
        '1 - start fast and slow down【开始快结束慢】
        '2 - start slow and speed up【开始慢结束快】
        Public startT, endT As Integer
        Public startxF, startyF, endyF, endxF As Double 'F,S,R(只用x),V 'F stands for float-option
        Public startx, starty, endx, endy As Integer 'M,MX,MY（只用x/y)
        'P只用startx H - 水平翻转(0) V - 垂直翻转(1) A - additive-blend colour (2)
        Public r1, g1, b1, r2, g2, b2 As Integer 'C
        Public volume As Integer 'Play
    End Structure
    Public Structure TriggerEvent
        Public triggerstart, triggerend As Integer
        Public events() As SBEvent
        Public count As Integer
    End Structure
    Public Class SBelement
        Public Type As ElementType
        Public Layers As ElementLayer
        Public Origin As ElementOrigin 'sample时无
        Public path As String
        Public x, y As Integer 'sample时无时无
        'Animation only
        Public frameCount, framedelay As Integer
        Public Looptype As ElementLoopType '默认LoopForever【一直循环】
        '事件触发循环可以被游戏时间事件触发. 虽然叫做循环, 事件触发循环循环时只执行一次
        '触发器循环和普通循环一样是从零计数. 如果两个重叠, 第一个将会被停止且被一个从头开始的循环替代.
        '如果他们和任何存在的故事版事件重叠,他们将不会循环直到那些故事版事件不在生效
    End Class
    Private Function picknext(ByRef str As String) As String
        Dim ref As String
        If Not str.Contains(",") Then
            ref = str
            str = ""
        Else
            ref = str.Substring(0, str.IndexOf(","))
            str = str.Substring(str.IndexOf(",") + 1)
        End If
        Return ref
    End Function
    Private Sub dealevent(str As String, element As Integer, delta As Integer, ByRef currentrow As Integer)
        Try
            Dim tmpe As SBEvent
            Dim op As String
            Dim tmp As String
            op = picknext(str)
            If op = " T" Then
                currentrow += 1
                While currentrow < raw.Count AndAlso raw(currentrow).StartsWith("  ")
                    'For i As Integer = 0 To tmpe.startT
                    '    dealevent(raw(currentrow).Substring(1), element, i * tmpe.easing, currentrow)
                    '    currentrow -= 1
                    'Next
                    currentrow += 1
                End While
                Return
            End If
            tmpe.elemnet = element
            tmpe.easing = Convert.ToInt32(picknext(str))
            tmpe.startT = Convert.ToInt32(picknext(str)) + delta
            '②_M,0,1000,1000,320,240,320,240-->_M,0,1000,,320,240,320,240(开始结束时间相同）
            tmp = picknext(str)
            If tmp = "" Then tmpe.endT = tmpe.startT Else tmpe.endT = Convert.ToInt32(tmp) + delta
            Dim first As String = String.Concat(op, ",", tmpe.easing.ToString, ",", tmpe.startT.ToString, ",", tmpe.endT.ToString, ",")
            Select Case op
                Case " F"
                    tmpe.startxF = Convert.ToDouble(picknext(str))
                    tmp = picknext(str)
                    If tmp = "" Then tmpe.endxF = tmpe.startxF Else tmpe.endxF = Convert.ToDouble(tmp)
                    '③_M,0,1000,,320,240,320,240-->_M,0,1000,,320,240 (开始结束值相同）
                    events.Add(tmpe)
                Case " MX"
                    tmpe.startx = Convert.ToInt32(picknext(str))
                    tmp = picknext(str)
                    If tmp = "" Then tmpe.endx = tmpe.startx Else tmpe.endx = Convert.ToInt32(tmp)
                    events.Add(tmpe)
                Case " MY"
                    tmpe.starty = Convert.ToInt32(picknext(str))
                    tmp = picknext(str)
                    If tmp = "" Then tmpe.endy = tmpe.starty Else tmpe.endy = Convert.ToInt32(tmp)
                    events.Add(tmpe)
                Case " M"
                    tmpe.startx = Convert.ToInt32(picknext(str))
                    tmpe.starty = Convert.ToInt32(picknext(str))
                    tmp = picknext(str)
                    If tmp = "" Then tmpe.endx = tmpe.startx Else tmpe.endx = Convert.ToInt32(tmp)
                    tmp = picknext(str)
                    If tmp = "" Then tmpe.endy = tmpe.starty Else tmpe.endy = Convert.ToInt32(tmp)
                    events.Add(tmpe)
                Case " S"
                    tmpe.startxF = Convert.ToDouble(picknext(str))
                    tmp = picknext(str)
                    If tmp = "" Then tmpe.endxF = tmpe.startxF Else tmpe.endxF = Convert.ToDouble(tmp)
                    events.Add(tmpe)
                Case " V"
                    tmpe.startxF = Convert.ToDouble(picknext(str))
                    tmpe.startyF = Convert.ToDouble(picknext(str))
                    tmp = picknext(str)
                    If tmp = "" Then tmpe.endxF = tmpe.startxF Else tmpe.endxF = Convert.ToDouble(tmp)
                    tmp = picknext(str)
                    If tmp = "" Then tmpe.endyF = tmpe.startyF Else tmpe.endyF = Convert.ToDouble(tmp)
                    events.Add(tmpe)
                Case " R"
                    tmpe.startxF = Convert.ToDouble(picknext(str))
                    tmp = picknext(str)
                    If tmp = "" Then tmpe.endxF = tmpe.startxF Else tmpe.endxF = Convert.ToDouble(tmp)
                    events.Add(tmpe)
                Case " C"
                    tmpe.r1 = Convert.ToInt32(picknext(str))
                    tmpe.g1 = Convert.ToInt32(picknext(str))
                    tmpe.b1 = Convert.ToInt32(picknext(str))
                    tmp = picknext(str)
                    If tmp = "" Then tmpe.r2 = tmpe.r1 Else tmpe.r2 = Convert.ToInt32(tmp)
                    tmp = picknext(str)
                    If tmp = "" Then tmpe.g2 = tmpe.g1 Else tmpe.g2 = Convert.ToInt32(tmp)
                    tmp = picknext(str)
                    If tmp = "" Then tmpe.b2 = tmpe.b1 Else tmpe.b2 = Convert.ToInt32(tmp)
                    events.Add(tmpe)
                Case " P"
                    Select Case picknext(str)
                        Case "H" : tmpe.startx = 0
                        Case "V" : tmpe.startx = 1
                        Case "A" : tmpe.startx = 2
                    End Select
                Case " L"
                    '④对于L的处理：直接复制_L,time difference,loopcount
                    currentrow += 1
                    'tmpe.easing:time difference
                    'time difference : 循环开始的时间和此系列SB事件第一次生效的最初时间之间的时间差, 单位是毫秒
                    'tmpe.startT:loopcount
                    While currentrow < raw.Count AndAlso raw(currentrow).StartsWith("  ")
                        For i As Integer = 0 To tmpe.startT
                            dealevent(raw(currentrow).Substring(1), element, i * tmpe.easing, currentrow)
                            currentrow -= 1
                        Next
                        currentrow += 1
                    End While
                    Return
                Case Else
                    Throw New FormatException("Failed to read .osb file")
            End Select
            '_event,easing,starttime,endtime,val1,val2,val3,...,valN
            If str <> "" Then
                dealevent(first & str, element, tmpe.endT - tmpe.startT, currentrow)
            End If
            currentrow += 1
        Catch ex As Exception
            Throw New FormatException("Failed to read .osb file")
        End Try
    End Sub
    Public Sub New(content As List(Of String))
        'initlazation from pieces of files(lines w/t bg/video/break/etc.)
        'content is fulfilled by Beatmap
        Dim Position As String
        raw = content
        Try
            Position = "Unknown"
            Dim i As Integer = 0
            Dim row As String
            Dim currentelement As Integer = -1
            Dim tmp() As String
            Dim tmpe As SBelement
            While i < content.Count
                row = content(i)
                If row.Trim = "" Then i += 1 : Continue While
                If row.StartsWith("//") Or row.Length = 0 Then i += 1 : Continue While
                If row.StartsWith("[") Then
                    Position = row.Substring(1, row.Length - 2)
                    i += 1
                    Continue While
                End If
                Select Case Position
                    Case "Variables"
                        Dim tmpvar As SBvar
                        tmpvar.name = row.Split(New Char() {"="c}, 2)(0)
                        tmpvar.replace = row.Split(New Char() {"="c}, 2)(1)
                        tmpvar.name.Substring(1, tmpvar.name.Length - 1)
                        Variables.Add(tmpvar)
                    Case "Events"
                        'do variables change first
                        For Each tmpvar In Variables
                            If row.Contains(tmpvar.name) Then row.Replace(tmpvar.name, tmpvar.replace)
                        Next
                        If row.StartsWith("Sample") Or row.StartsWith("5,") Then
                            'Sample,time,layer,"filepath",volume
                            tmp = row.Split(New Char() {","c})
                            tmpe = New SBelement
                            tmpe.Type = ElementType.Sample
                            tmpe.Layers = CType(System.Enum.Parse(GetType(ElementLayer), tmp(2)), ElementLayer)
                            tmpe.path = tmp(3)
                            elements.Add(tmpe)
                            currentelement += 1
                            Dim tmpev As SBEvent
                            tmpev.startT = Convert.ToInt32(tmp(1))
                            tmpev.Type = EventType.Play
                            If tmp.Length < 5 Then tmpev.volume = 100 Else tmpev.volume = Convert.ToInt32(tmp(4))
                            tmpev.elemnet = currentelement
                            events.Add(tmpev)
                            i += 1
                        ElseIf row.StartsWith("Animation") Or row.StartsWith("6,") Then
                            'Animation,"layer","origin","filepath",x,y,frameCount,frameDelay,looptype
                            tmp = row.Split(New Char() {","c})
                            tmpe = New SBelement
                            tmpe.Type = ElementType.Animation
                            tmpe.Layers = CType(System.Enum.Parse(GetType(ElementLayer), tmp(1)), ElementLayer)
                            tmpe.Origin = CType(System.Enum.Parse(GetType(ElementOrigin), tmp(2)), ElementOrigin)
                            tmpe.path = tmp(3)
                            tmpe.x = Convert.ToInt32(tmp(4))
                            tmpe.y = Convert.ToInt32(tmp(5))
                            tmpe.frameCount = Convert.ToInt32(tmp(6))
                            tmpe.framedelay = CInt(Convert.ToDouble(tmp(7)))
                            tmpe.Looptype = CType(System.Enum.Parse(GetType(ElementLoopType), tmp(8)), ElementLoopType)
                            elements.Add(tmpe)
                            currentelement += 1
                            i += 1
                        ElseIf row.StartsWith("Sprite") Or row.StartsWith("4,") Then
                            'Sprite,"layer","origin","filepath",x,y
                            tmp = row.Split(New Char() {","c})
                            tmpe = New SBelement
                            tmpe.Type = ElementType.Sprite
                            tmpe.Layers = CType(System.Enum.Parse(GetType(ElementLayer), tmp(1)), ElementLayer)
                            tmpe.Origin = CType(System.Enum.Parse(GetType(ElementOrigin), tmp(2)), ElementOrigin)
                            tmpe.path = tmp(3)
                            tmpe.x = Convert.ToInt32(tmp(4))
                            tmpe.y = Convert.ToInt32(tmp(5))
                            elements.Add(tmpe)
                            currentelement += 1
                            i += 1
                        ElseIf row.StartsWith("0,") Then
                            tmp = row.Split(New Char() {","c})
                            tmpe = New SBelement
                            tmpe.Type = ElementType.Sprite
                            tmpe.Layers = ElementLayer.Background
                            tmpe.Origin = ElementOrigin.Centre
                            tmpe.path = tmp(2)
                            elements.Add(tmpe)
                            currentelement += 1
                            i += 1
                        Else : dealevent(row, currentelement, 0, i)
                        End If
                End Select
            End While
        Catch ex As Exception
            Throw New FormatException("Failed to read .osb file")
        End Try
    End Sub
End Class
