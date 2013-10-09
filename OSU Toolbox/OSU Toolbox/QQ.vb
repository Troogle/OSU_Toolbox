Imports SSOAxCtrlForPTLoginLib
Public Class QQ
    Public Class QQInfo
        Public uin As UInteger
        Public name As String
        Public face As UShort
        Public nick As String
        Public gender As Byte
    End Class
    Public Sub Send2QQ(id As UInteger, Str As String)
        Shell("QSetinfo " + id.ToString + " " + Str)
    End Sub
    Public Function GetQQList() As List(Of String)
        GetQQList = New List(Of String)
        Dim Q_list As List(Of QQInfo)
        Q_list = GetQQinfoList()
        Dim tmp As String
        For i = 0 To Q_list.Count
            tmp = Q_list.Item(i).uin.ToString + Q_list.Item(i).nick
            GetQQList.Add(tmp)
        Next
    End Function
    Private Function GetQQinfoList() As List(Of QQInfo)
        GetQQinfoList = New List(Of QQInfo)
        Dim AutoQQLogin As SSOForPTLoginClass = New SSOAxCtrlForPTLoginLib.SSOForPTLoginClass()
        Dim AA As ITXSSOData = AutoQQLogin.CreateTXSSOData()
        AutoQQLogin.InitSSOFPTCtrl(0, AA)
        Dim g_vOptData As ITXSSOData = AutoQQLogin.CreateTXSSOData()
        Dim Q As ITXSSOData = AutoQQLogin.DoOperation(1, g_vOptData)
        Dim N As ITXSSOArray = Q.GetArray("PTALIST")
        Dim U As UInteger = N.GetSize()
        Dim v As UInteger
        For v = 0 To U
            Dim C As ITXSSOData = N.GetData(v)
            Dim S As UInteger = C.GetDWord("dwSSO_Account_dwAccountUin")
            Dim G As ITXSSOArray = C.GetArray("SSO_Account_AccountValueList")
            Dim T As String = G.GetStr(0)
            Dim L As UShort = 0
            Try
                L = C.GetWord("wSSO_Account_wFaceIndex")
            Catch
                L = 0
            End Try
            Dim m As String = ""
            Try
                m = C.GetStr("strSSO_Account_strNickName")
            Catch
                m = ""
            End Try
            Dim J As Byte = 0
            Try

                J = C.GetByte("cSSO_Account_cGender")
            Catch
                J = 0
            End Try
            Dim NewInfo As New QQInfo()
            NewInfo.uin = S
            NewInfo.name = T
            NewInfo.face = L
            NewInfo.gender = J
            NewInfo.nick = m
            GetQQinfoList.Add(NewInfo)
        Next
    End Function
End Class
