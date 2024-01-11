Imports System.IO.Ports
Imports System.Text.RegularExpressions

Module ScanningModule

    Public Structure PatternInfo
        Public PatternName As String
        Public PatternString As String
        Public Priority As Integer
    End Structure

    Public PatternList As PatternInfo()
    Dim DT_PattList As DataTable

#Region "Internal Funcs"
    Private Sub AddPattListDT(ByVal SetPatt As PatternInfo)
        If DT_PattList Is Nothing Then
            DT_PattList = New DataTable
            DT_PattList.Columns.Add("PatternName", GetType(String))
            DT_PattList.Columns.Add("PatternString", GetType(String))
            DT_PattList.Columns.Add("Priority", GetType(Integer))
        End If

        Dim NxtPrior As Integer = IIf(SetPatt.Priority < 0, DT_PattList.Rows.Count + 1, SetPatt.Priority)
        DT_PattList.Rows.Add(SetPatt.PatternName, SetPatt.PatternString, NxtPrior)
    End Sub

#End Region

    Public Sub SetupNewPattern(ByVal PattName As String, ByVal PattString As String, Optional ByVal Prior As Integer = -1)
        Dim LastIdx As Integer
        If PatternList Is Nothing Then
            LastIdx = 0
        Else
            LastIdx = PatternList.Length
        End If

        Try
            ReDim Preserve PatternList(LastIdx)
            PatternList(LastIdx) = New PatternInfo
            PatternList(LastIdx).PatternName = PattName
            PatternList(LastIdx).PatternString = PattString
            PatternList(LastIdx).Priority = Prior

            AddPattListDT(PatternList(LastIdx))
        Catch ex As Exception

        End Try
    End Sub

    Public Function CheckForPatternExist(ByVal PatName As String) As Boolean
        Dim result As Boolean = False

        If PatternList IsNot Nothing Then
            For Each patt In PatternList
                If Regex.IsMatch(patt.PatternName, PatName, RegexOptions.IgnoreCase) Then
                    result = True
                    Exit For
                End If
            Next
        End If

        Return result
    End Function

    Public Function CheckForScanMatch(ByVal PatName As String, ByVal ScanStr As String) As String
        'Return "" if no Pattern Match or return checking pattern
        Dim PattFnd As String = ""
        Dim QryChk As String = "PatternName = '" & PatName & "'"

        If DT_PattList.Select(QryChk).Length > 0 Then
            For Each pat In DT_PattList.Select(QryChk, "Priority")
                If ScanStr Like StripArrows(pat("PatternString")) Then
                    PattFnd = pat("PatternString")
                    Exit For
                End If
            Next
        End If

        Return PattFnd
    End Function

    Public Function StripCRLF(ByVal StripStr As String) As String
        ' Function to remove CR and LF characters from a string.
        Dim Indx As Integer
        Dim RetStr As String
        Dim CharC As Char

        RetStr = ""
        For Indx = 1 To Len(StripStr)
            CharC = Mid(StripStr, Indx, 1)
            If (CharC <> Chr(13) And CharC <> Chr(10) And CharC <> Chr(0)) Then
                RetStr = RetStr & CharC
            End If
        Next

        Return (RetStr)
    End Function

    Public Function StripArrows(ByVal StripStr As String)
        Dim Indx As Integer
        Dim RetStr As String
        Dim CharC As Char

        RetStr = ""
        For Indx = 1 To Len(StripStr)
            CharC = Mid(StripStr, Indx, 1)
            If (CharC <> Chr(60) And CharC <> Chr(62)) Then
                RetStr = RetStr & CharC
            End If
        Next

        Return (RetStr)
    End Function

    Public Function GetDBStrFromScanStr(ByVal ScanStr As String, ByVal PattrnStr As String) As String
        ' Funtion to convert the scanned string into the database string using the "<" and ">" string start and end characters (use only <???>).
        Dim StArwFnd As Integer = 0
        Dim NdArwFnd As Integer = 0
        Dim InUseStr As Boolean = False
        Dim InUseLen As Integer = 0
        Dim StartPatt As String = ""
        Dim EndPatt As String = ""
        Dim UsePatt As String = ""
        Dim StartStr As String = ""
        Dim EndStr As String = ""
        Dim UseStr As String = ""
        Dim ChkChr As Char
        Dim StrMatchList As New List(Of String)
        Dim BlkChrList As New List(Of Integer)({33, 34, 39, 40, 41, 42, 44, 58, 59, 60, 62, 91, 93, 96, 123})

        ' Check that the pattern being used is structured correctly.
        If (Not PattrnStr Like "*<*>*") Then
            ' Pattern is missing start or end string markers.
            Throw New Exception("Start and / or end of use string markers missing")
        End If
        For PattIdx As Integer = 1 To Len(PattrnStr)
            ChkChr = Mid(PattrnStr, PattIdx, 1)
            If (ChkChr = Chr(62)) Then
                ' Found ending arrow.
                InUseStr = False
                NdArwFnd = PattIdx - 1
                Exit For
            End If
            If (InUseStr = True) Then
                If (ChkChr = Chr(42)) Then
                    ' Found string wildcard inside use string section. This is not supported.
                    Throw New Exception("String wildcard used in use string selection pattern")
                End If
                If (Asc(ChkChr) < 32 And Asc(ChkChr) > 125) Then
                    ' Found unsupported character inside use string section.
                    Throw New Exception("Unsupported character ( " & ChkChr & ") used in use string selection pattern")
                Else
                    If (BlkChrList.Contains(Asc(ChkChr)) = True) Then
                        ' Found unsupported character inside use string section.
                        Throw New Exception("Unsupported character ( " & ChkChr & ") used in use string selection pattern")
                    End If
                End If
            End If
            If (ChkChr = Chr(60)) Then
                ' Found starting arrow.
                InUseStr = True
                StArwFnd = PattIdx
            End If
        Next

        ' Define the expected length of the use string section and the separate checking patterns.
        Try
            InUseLen = (NdArwFnd - StArwFnd)
            StartPatt = Mid(PattrnStr, 1, StArwFnd - 1)
            EndPatt = Mid(PattrnStr, NdArwFnd + 2)
            UsePatt = Mid(PattrnStr, StArwFnd + 1, InUseLen)

            For StrIdx As Integer = 1 To Len(ScanStr)
                If (StrIdx <= (Len(ScanStr) - (InUseLen - 1))) Then
                    UseStr = Mid(ScanStr, StrIdx, InUseLen)
                    If (StrIdx = 1) Then
                        StartStr = ""
                    Else
                        StartStr = Mid(ScanStr, 1, (StrIdx - 1))
                    End If
                    EndStr = Mid(ScanStr, StrIdx + InUseLen, (Len(ScanStr) - StrIdx))
                    If (UseStr Like UsePatt) Then
                        ' Possible use match found.
                        If (StartStr & UseStr Like StartPatt & UsePatt And UseStr & EndStr Like UsePatt & EndPatt) Then
                            ' Confirmed match found.
                            StrMatchList.Add(UseStr)
                        End If
                    End If
                Else
                    Exit For
                End If
            Next
        Catch Ex As Exception
            ' Error detected when processing the scanner string.
            Throw New Exception("Error when extracting scan use string. Error is " & Ex.Message)
        End Try

        If (StrMatchList.Count = 0) Then
            ' No matching string can be found.
            Throw New Exception("No use data string extracted")
        ElseIf (StrMatchList.Count > 1) Then
            ' Mulitple potential use strings have been found.
            Throw New Exception("Multiple use data strings detected. Pattern is not explicit enough")
        Else
            Return (StrMatchList(0))
        End If
    End Function

    Private Function OpenPort(ByVal PortName As SerialPort, ByVal COM As String) As Boolean
        Try
            ' Define the RS232 connection parameters.
            PortName.PortName = COM
            PortName.BaudRate = 9600
            PortName.Parity = IO.Ports.Parity.None
            PortName.StopBits = IO.Ports.StopBits.One
            PortName.DataBits = 8

            'Open the defined serial port
            PortName.Open()
            Return (True)
        Catch Ex As Exception
            Return (False)
        End Try
    End Function

    Public Function ClosePort(ByVal PortName As SerialPort) As Boolean
        ' Close the defined serial port.
        Try
            PortName.Close()
            Return (True)
        Catch Ex As Exception
            Return (False)
        End Try
    End Function

End Module
