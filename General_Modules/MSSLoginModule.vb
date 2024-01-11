Imports System.Text.RegularExpressions
Imports MSSLogin_Plugin
Module MSSLoginModule
    Public MSTlogin As New MSS_Login

    Public Class LoginInfo
        Public UserName As String
        Public Password As String
        Public SkillList As ArrayList
        Public LoginValid As Boolean
        Public IsAdmin As Boolean

    End Class
    Public Function MSSLoginByUser(ByRef ChkUser As LoginInfo, Optional SkillChk As ArrayList = Nothing) As String
        Dim result As String = ""

        If MSTlogin.MSSUserLogin(ChkUser.UserName, ChkUser.Password) Then
            ChkUser.SkillList = MSTlogin.UserInfo.SkillList

            'Check For Adminsitrator skill
            If ChkUser.SkillList.Count > 0 Then
                For Each sk In ChkUser.SkillList
                    If Regex.IsMatch(sk, "admin", RegexOptions.IgnoreCase) Then
                        ChkUser.IsAdmin = True
                        Exit For
                    End If
                Next
            End If

            If SkillChk IsNot Nothing Then
                If ChkUser.SkillList IsNot Nothing AndAlso ChkUser.SkillList.Count > 0 Then
                    For Each sk In SkillChk
                        For Each item In ChkUser.SkillList
                            If Regex.IsMatch(sk, item, RegexOptions.IgnoreCase) Then
                                ChkUser.LoginValid = True
                                Exit For
                            End If
                        Next

                        If ChkUser.LoginValid Then
                            Exit For
                        End If
                    Next
                Else
                    ChkUser.LoginValid = False
                End If
            Else
                'No Input skill for checking
                ChkUser.LoginValid = True
            End If
        Else
            result = "Username or Password is Invalid."
        End If

        Return result
    End Function

    Public Function CheckForUserSkill(ByVal ChkUser As LoginInfo, ByVal ChkSkill As String) As Boolean
        Dim result As Boolean
        Dim ChkItem As String
        Try
            If ChkUser.SkillList IsNot Nothing AndAlso ChkUser.SkillList.Count > 0 Then
                ChkSkill = ChkSkill.ToLower
                For Each item In ChkUser.SkillList
                    ChkItem = item.ToString.ToLower
                    If "admin" = ChkItem Then
                        result = True
                        Exit For
                    ElseIf ChkSkill = ChkItem Then
                        result = True
                        Exit For
                    End If
                Next
            Else
                result = False
            End If
        Catch
            result = False
        End Try

        Return result
    End Function
End Module
