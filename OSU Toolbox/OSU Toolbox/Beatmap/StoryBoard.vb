Public Class StoryBoard
    Public elements As New List(Of SBelement)
    'TODO:单独抽取trigger并作索引
    Public Variables As New List(Of SBvar)
    Public trigger As New Dictionary(Of Triggertype, TriggerEvent)
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
        F
        M
        S
        V
        R
        C
        L
        T
        P
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
        Public Type As EventType
        Public easing As Integer
        '0 - none【没有缓冲】
        '1 - start fast and slow down【开始快结束慢】
        '2 - start slow and speed up【开始慢结束快】
        Public startT, endT As UInteger
        Public startxF, startyF, endyF, endxF As Double 'F,S(只用x),V 'F stands for float-option
        Public startx, starty, endx, endy As Integer 'R(只用x),MX,MY（只用x/y),M
        'P只用startx H - 水平翻转(0) V - 垂直翻转(1) A - additive-blend colour (2)
        Public r1, g1, b1, r2, g2, b2 As Integer 'C
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
        Public frameCount, framedealy As Integer
        Public Looptype As ElementLoopType '默认LoopForever【一直循环】
        'Sample only
        Public time, volume As Integer
        Public SBevents As New List(Of SBEvent)
        '事件触发循环可以被游戏时间事件触发. 虽然叫做循环, 事件触发循环循环时只执行一次
        '触发器循环和普通循环一样是从零计数. 如果两个重叠, 第一个将会被停止且被一个从头开始的循环替代.
        '如果他们和任何存在的故事版事件重叠,他们将不会循环直到那些故事版事件不在生效
    End Class
    Public Sub New(content As List(Of String))
        'initlazation from pieces of files(lines w/t bg/video/break/etc.)
        Dim Position As String
        Dim tmp() As String
        Try
            Position = "Unknown"
            For Each row In content
                If row.Trim = "" Then Continue For
                If row.StartsWith("//") Or row.Length = 0 Then Continue For
                If row.StartsWith("[") Then
                    Position = row.Substring(1, row.Length - 2)
                    Continue For
                End If
                Select Case Position
                    Case "Variables"
                        Dim tmpvar As SBvar
                        tmpvar.name = row.Split(New Char() {"="}, 2)(0)
                        tmpvar.replace = row.Split(New Char() {"="}, 2)(1)
                        tmpvar.name.Substring(1, tmpvar.name.Length - 1)
                        Variables.Add(tmpvar)
                    Case "Events"
                        For Each tmpvar In Variables
                            If row.Contains(tmpvar.name) Then row.Replace(tmpvar.name, tmpvar.replace)
                        Next
                        tmp = row.Split(New Char() {","}, 2)
                        Select Case tmp(0)
                            Case "Sprite"

                            Case "Animation"

                        End Select
                End Select
            Next
        Catch ex As Exception

        End Try
        'content is fulfilled by Beatmap
        'do variables change first
        '注意点：
        '①_event,easing,starttime,endtime,val1,val2,val3,...,valN
        '_event, easing, starttime, endtime, val1, val2
        '_event, easing, starttime + duration, endtime + duration, val2, val3
        '_event,easing,starttime + 2duration,endtime + 2duration,val3,val4
        '②_M,0,1000,1000,320,240,320,240-->_M,0,1000,,320,240,320,240(开始结束时间相同）
        '③_M,0,1000,,320,240,320,240-->_M,0,1000,,320,240 (开始结束值相同）
        '④对于L的处理：直接复制_L,time difference,loopcount
        'time difference : 循环开始的时间和此系列SB事件第一次生效的最初时间之间的时间差, 单位是毫秒
    End Sub
End Class
