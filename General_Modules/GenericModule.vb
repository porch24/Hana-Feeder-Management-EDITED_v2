Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports SHDocVw
Imports Shell32
Imports System.Diagnostics

Module GenericModule

    Public DB_Type As String = "MsSql"
    Public DB_ConnStr As String
    Public DB_MDM_ConStr As String     'Used for collecting ValorMDM DB connection string
    Public DB_QM_ConStr As String   'Used for collecting ValorQM DB connection string
    Public DB_IM71_ConStr As String   'Used for collecting im_online DB connection string
    Public DB_SALE_ConStr As String   'Used for collecting SAP_SALE_ORDER DB connection string
    Public MDMSrv As String = ""     ' Used to store the MDM server name (for REST commands).
    Public MDMPort As String = ""     ' Used to store the MDM server port (for REST commands).
    Public RESTPrefix As String = ""     ' Used to store the REST prefix used for command calls.
    Public LogPath As String = ""  'Used with Log File functions
    Public LogFile As String = ""  'Used with Log File functions
    Public NumLogs As Integer = 5  'Used with Log File functions
    Public CodePage As Int32 = System.Text.Encoding.Default.CodePage
    Public McID As Integer = -1
    Public CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
    Public MST_LocalPath As String = ""

    Public Structure ConfigInfo
        Dim ConfigName As String
        Dim ConfigValue As String
    End Structure
    Public ConfigList As ConfigInfo()

    '### MUST CALL THIS FUNCTION AT STARTING OF THE PROGRAM
    Public Function ModuleStartup() As String
        Dim result As String = ""

        Try
#Region "Getting MCID"
            'Get McID From CommandLineArgs
            If (CommandLineArgs.Count > 0) Then
                McID = CInt(CommandLineArgs(0))
            End If
#End Region

#Region "Setup Log File"
            ' Check that the "ValorMSS_HOME" environment variable has been set (check this is running on a Valor client PC).
            If (Environment.GetEnvironmentVariable("ValorMSS_HOME") = "") Then
                Dim MsgBoxMsg As String
                MsgBoxMsg = "ไม่พบข้อมูล ValorMSS_HOME" & vbCrLf &
                    "โปรแกรมไม่สามารถเริ่มการทำงานได้" & vbCrLf &
                    "กรุณาติดต่อ Valor Team #420 เพื่อตรวจสอบ"
                result = MsgBoxMsg
                Exit Function
            Else
                ' Define the log file path.
                LogPath = Environment.GetEnvironmentVariable("ValorMSS_HOME") & "\Logs\Hana"

                ' Check that a "Hana" log folder exists.
                If (Dir(LogPath) = "") Then
                    ' Create the required log folder.
                    Directory.CreateDirectory(LogPath)
                End If
            End If

            ' Set the log file name.
            LogFile = LogPath & "\" & LogNameTimeStr() & "-" & McID & "-" & My.Application.Info.Description.Trim & ".log"

            ' Reduce the number of log files according to the log file quantity specified.
            CleanLogs()
#End Region

#Region "Getting DB Connection"
            'Check for DB Connection from XML file
            Dim TmpConnStr As String
            Dim MSSConfigFle As XDocument
            Try
                'program will try to load MSSconfig file from M:\, if cannot access will try to load on local instead
                Try
                    MSSConfigFle = XDocument.Load("M:\Components\MSSConfig.xml")
                Catch ex As Exception
                    MSSConfigFle = XDocument.Load(Application.StartupPath & "\MSSConfig.xml")
                End Try

                Dim FleNs As XNamespace = MSSConfigFle.Root.Name.NamespaceName
                For Each FileElem As XElement In MSSConfigFle.Descendants(FleNs + "Application")
                    ' Check for the MDM server section.
                    If (FileElem.Attribute("name").Value = "MDM") Then
                        MDMSrv = FileElem.Attribute("RestServerAddress").Value
                        MDMPort = FileElem.Attribute("RestPort").Value
                        RESTPrefix = "http://" & MDMSrv & ":" & MDMPort & "/"
                        ' Build the database connection string using the MDM database connection data.
                        TmpConnStr = FileElem.Attribute("DBConnectionString").Value
                        DB_MDM_ConStr = "User ID=" & Trim(TmpConnStr.Split(";")(2).Split("=")(1)) & ";" & "Password=" & Trim(TmpConnStr.Split(";")(3).Split("=")(1)) & ";" & "DATABASE=" & Trim(TmpConnStr.Split(";")(1).Split("=")(1)) & ";" & "Server=" & Trim(TmpConnStr.Split(";")(0).Split("=")(1))
                    End If

                    ' Check for the SFP appliction section.
                    If (FileElem.Attribute("name").Value = "SFP") Then
                        ' Work through the elements in the SFP application section.
                        For Each XElem As XElement In FileElem.Elements
                            ' Work through the internal attribute elements.
                            For Each IntAtrElem As XElement In XElem.Elements
                                ' Locate the SFP database connection string.
                                If (IntAtrElem.Name = "Attribute" And IntAtrElem.Attribute("Name").Value = "url") Then
                                    ' Build the database connection string using the SFP database connection data.
                                    TmpConnStr = IntAtrElem.Attribute("Value").Value
                                    DB_ConnStr = "User ID=" & TmpConnStr.Split(":")(6) & ";" & "Password=" & TmpConnStr.Split(":")(7) & ";" & "DATABASE=" & TmpConnStr.Split(":")(5) & ";" & "Server=" & TmpConnStr.Split(":")(3)
                                End If
                                ' Locate the umber of log files to retain.
                                If (IntAtrElem.Name = "Attribute" And IntAtrElem.Attribute("Name").Value = "numberoflogfiles") Then
                                    ' Define the number of log files to maintain.
                                    NumLogs = CInt(IntAtrElem.Attribute("Value").Value)
                                    WriteLog("Configuration parameter NumLogs = " & NumLogs)
                                End If
                            Next
                        Next
                    End If

                    ' Check for the QM application section.
                    If (FileElem.Attribute("name").Value = "QM") Then
                        ' Build the database connection string using the vQM database connection data.
                        TmpConnStr = FileElem.Attribute("DBConnectionString").Value
                        DB_QM_ConStr = "User ID=" & Trim(TmpConnStr.Split(";")(3).Split("=")(1)) & ";" & "Password=" & Trim(TmpConnStr.Split(";")(1).Split("=")(1)) & ";" & "DATABASE=" & Trim(TmpConnStr.Split(";")(4).Split("=")(1)) & ";" & "Server=" & Trim(TmpConnStr.Split(";")(5).Split("=")(1))

                    End If

                    'check for IM online connection
                    If (FileElem.Attribute("name").Value = "IM_71") Then
                        TmpConnStr = FileElem.Attribute("DBConnectionString").Value
                        DB_IM71_ConStr = "User ID=" & Trim(TmpConnStr.Split(";")(2).Split("=")(1)) & ";" & "Password=" & Trim(TmpConnStr.Split(";")(3).Split("=")(1)) & ";" & "DATABASE=" & Trim(TmpConnStr.Split(";")(1).Split("=")(1)) & ";" & "Server=" & Trim(TmpConnStr.Split(";")(0).Split("=")(1))
                    End If

                    'Check for .59 SAP_Sale_Order
                    If (FileElem.Attribute("name").Value = "SAPSALE") Then
                        TmpConnStr = FileElem.Attribute("DBConnectionString").Value
                        DB_SALE_ConStr = "User ID=" & Trim(TmpConnStr.Split(";")(2).Split("=")(1)) & ";" & "Password=" & Trim(TmpConnStr.Split(";")(3).Split("=")(1)) & ";" & "DATABASE=" & Trim(TmpConnStr.Split(";")(1).Split("=")(1)) & ";" & "Server=" & Trim(TmpConnStr.Split(";")(0).Split("=")(1))
                    End If
                Next
            Catch Ex As Exception
                WriteLog("Error when reading the MSSConfig.xml file. Error message is " & Ex.Message)
                Dim MsgBoxMsg As String
                MsgBoxMsg = "โปรแกรมไม่สามารถเริ่มการทำงานได้" & vbCrLf &
                    "เนื่องจากไม่สามารถเข้าถึงไฟล์การเชื่อมต่อฐานขช้อมูล" & vbCrLf &
                    "กรุณาติดต่อ Valor Team #420 เพื่อตรวจสอบ" & GetExErrorLine(Ex)
                result = MsgBoxMsg
                Return result
            End Try
#End Region

        Catch ex As Exception
            result = "Catch Error: " & vbCr & vbCr & ex.Message
        End Try

        Return result

    End Function

#Region "Utilities Functions"
    Public Function GetMcIDConfig(Optional ChkMcID As Integer = -1) As String
        'return "" if no error occurs or return error message
        Dim result As String = ""
        Dim SQLstr As String
        Dim DBconn As DBConnect
        Dim tmpCnf As ConfigInfo
        Dim CurIdx As Integer = 0

        If ChkMcID < 0 And McID > 0 Then
            ChkMcID = McID
        ElseIf ChkMcID < 0 Then
            result = "Catch Error: " & vbCr & vbCr & "Cannot Get McID For Checking"
            Return result
        End If

        Try
            DBconn = New DBConnect
            DBconn.ConnectionString = DB_ConnStr
            DBconn.ConnectionType = DB_Type

            'test connection
            DBconn.ExecuteSql("SELECT GETDATE()")

            SQLstr = "EXEC HANA_SP_GetAllMcIDConfig '" & ChkMcID & "'"
            For Each conf In DBconn.DataSet(SQLstr).Tables(0).Select
                tmpCnf = New ConfigInfo
                tmpCnf.ConfigName = conf("ConfigName")
                tmpCnf.ConfigValue = conf("ConfigValue")

                ReDim Preserve ConfigList(CurIdx)
                ConfigList(CurIdx) = tmpCnf
                CurIdx += 1
            Next
        Catch ex As Exception
            result = "Catch Error: " & vbCr & vbCr & ex.Message
            Return result
        End Try

        Return result
    End Function

    Public Function GenerateID(Optional ByVal CurDBTime As String = "") As Integer
        ' Function to create an ID number for boards, material trace and parameter trace lists.
        ' This is the number of seconds since Jan 1, 2000.
        Dim RetInt As Integer
        Dim StDate As Date = "2000-01-01 00:00"
        Dim DBServTime As String = ""

        ' Collect the database server time.
        If CurDBTime <> "" Then
            DBServTime = CurDBTime
        Else
            DBServTime = DBServerTime()
        End If

        If (DBServTime = "ERROR") Then
            WriteLog("Error with database server time collection")
            WriteLog("DEBUG - False PCB ID entered into database")
            Return ("DateTimeErrPCB")
            Exit Function
        Else
            RetInt = DateDiff(DateInterval.Second, StDate, CDate(DBServTime))
            Return (RetInt)
        End If
    End Function

    Public Function DBServerTime() As String
        ' Define the database connections.
        Dim DBConn As New DBConnect
        DBConn.ConnectionString = DB_ConnStr
        DBConn.ConnectionType = DB_Type

        ' Set database server datestamp string.
        Try
            Return CnvDBDateTime(0, DBConn.GetDBServerTime(DB_Type))
        Catch Ex As Exception
            ' Error when getting database server time.
            WriteLog("Error when getting database server time")
            WriteLog("Error Message is: - " & Ex.Message)
            Return ("ERROR")
            Exit Function
        End Try

    End Function

    Public Function CnvDBDateTime(ByVal AddMS As Integer, ByVal DBStr As String) As String
        ' Function to convert a datetime string to be SQL compatible.
        ' If AddMS = 0 the return will not include milliseconds.
        Dim Sec As String
        Dim Min As String
        Dim Hr As String
        Dim Day As String
        Dim Mth As String
        Dim Yr As String
        Dim MSecs As Integer

        ' Set datestamp string.
        Sec = Microsoft.VisualBasic.DateAndTime.Second(DBStr)
        Min = Microsoft.VisualBasic.DateAndTime.Minute(DBStr)
        Hr = Microsoft.VisualBasic.DateAndTime.Hour(DBStr)
        Day = Microsoft.VisualBasic.DateAndTime.Day(DBStr)
        Mth = Microsoft.VisualBasic.DateAndTime.Month(DBStr)
        Yr = Microsoft.VisualBasic.DateAndTime.Year(DBStr)
        MSecs = Now.Millisecond

        Sec = Microsoft.VisualBasic.Right("00" & Sec, 2)
        Min = Microsoft.VisualBasic.Right("00" & Min, 2)
        Hr = Microsoft.VisualBasic.Right("00" & Hr, 2)
        Day = Microsoft.VisualBasic.Right("00" & Day, 2)
        Mth = Microsoft.VisualBasic.Right("00" & Mth, 2)

        If (AddMS = 0) Then
            Return (Yr & "-" & Mth & "-" & Day & " " & Hr & ":" & Min & ":" & Sec)
        Else
            Return (Yr & "-" & Mth & "-" & Day & " " & Hr & ":" & Min & ":" & Sec & "." & MSecs)
        End If
    End Function

    Public Function UpdateOpTrace(ByVal CurrOP As String, ByVal PUID As String, ByVal CurMcID As Integer, ByVal ActionID As Integer, ByVal User As String, ByVal Desc As String) As Integer
        ' Function to update the operatortrace table.
        ' If an error occurs "-1" is returned.
        Dim SQL_Command As String = ""
        Dim RetInt As Integer = 0

        ' Define the database connections.
        Dim DBConn As New DBConnect
        DBConn.ConnectionString = DB_ConnStr
        DBConn.ConnectionType = DB_Type

        Try
            SQL_Command = "INSERT INTO operatortrace (TimeStamp, OperatorID, ActionID, McID, Station, Slot, FeederID, CompID, SubSlot, Description) 
                        VALUES (GETDATE(), '" & CurrOP & "', " & ActionID & ", " & CurMcID & ", 0, 0, 0, '" & PUID & "', 0, '" & Desc & "')"
            DBConn.ExecuteSql(SQL_Command)
        Catch Ex As Exception
            ' Error when updating the operatortrace table.
            WriteLog("Error when updating the operatortrace table. Error message is " & Ex.Message)
            ' Set the return object to show an error.
            RetInt = -1
        End Try

        Return (RetInt)
    End Function

    Public Function GetExErrorLine(ByVal ex As Exception) As String
        Dim ErrLine As String
        If Regex.Split(ex.StackTrace, ":line").Count > 1 Then
            ErrLine = " (#" & Regex.Split(ex.StackTrace, ":line")(1).Trim & ")"
        Else
            ErrLine = ""
        End If

        Return ErrLine
    End Function

    Public Sub CriticalErrWarn(ByVal ex As Exception)
        Dim WarnMsg, ErrLine As String

        WarnMsg = "ระบบเกิดความผิดพลาดขณะประมวลผล" & vbCrLf & "กรุณาส่งภาพหน้าจอนี้แจ้งทีม Valor ก่อนดำเนินการต่อ" & vbCrLf & vbCrLf
        WarnMsg &= ex.Message

        ErrLine = GetExErrorLine(ex)
        If ErrLine.Trim <> "" Then
            WarnMsg &= vbCrLf & ErrLine
        End If

        MessageBox.Show(WarnMsg, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Function IsInteger(ByVal Num As String) As Boolean
        ' Function to check if number (supplied as string) can be interpreted as an integer.
        Dim Ret As Boolean = False
        If (IsNumeric(Num) = True) Then
            If (Num.Split(".").Length = 1) Then
                Ret = True
            End If
        End If

        Return (Ret)
    End Function

    Public Function GetMcName(ByVal ChkMcID As Integer) As String
        Dim result As String = "Unknown Station"

        Dim SQLstr As String
        Dim DBconn As New DBConnect
        DBconn.ConnectionString = DB_ConnStr
        DBconn.ConnectionType = DB_Type
        Try
            SQLstr = "SELECT McName FROM Hana_VW_MDM_FactoryLayout WHERE McID = " & ChkMcID
            For Each row In DBconn.DataSet(SQLstr).Tables(0).Select
                result = row("McName").ToString.Trim
                Exit For
            Next
        Catch
            result = "Error Checking Station Name"
        End Try

        Return result
    End Function

    Public Function CreateDTByGridView(ByVal SetGv As DataGridView, Optional ByVal NeedVal As Boolean = False) As DataTable
        Dim result As DataTable = New DataTable
        Try
            For Each row As DataGridViewColumn In SetGv.Columns
                If row.HeaderText.Trim = "" Then
                    result.Columns.Add("Col_" & row.Index.ToString)
                Else
                    result.Columns.Add(row.HeaderText.Trim)
                End If
            Next

            If NeedVal Then
                Dim ArrList As New ArrayList
                For Each row As DataGridViewRow In SetGv.Rows
                    ArrList.Clear()
                    For i = 0 To row.Cells.Count - 1
                        ArrList.Add(row.Cells(i).Value)
                    Next

                    result.Rows.Add(ArrList.ToArray)
                Next
            End If
        Catch ex As Exception
            WriteLog("Catch Error On CreateDTByGridView ErrMsg=" & ex.Message)
            result = Nothing
        End Try

        Return result
    End Function

    Public Function GetSelectedFromGrid(ByVal SetGv As DataGridView) As DataTable
        Dim result As DataTable = New DataTable
        Try
            result = CreateDTByGridView(SetGv)

            If result IsNot Nothing Then
                Dim ArrList As New ArrayList
                For Each sel As DataGridViewRow In SetGv.SelectedRows
                    ArrList.Clear()
                    For i = 0 To sel.Cells.Count - 1
                        ArrList.Add(sel.Cells(i).Value)
                    Next

                    result.Rows.Add(ArrList.ToArray)
                Next
            End If
        Catch ex As Exception
            WriteLog("Catch Error On CreateDTByGridView ErrMsg=" & ex.Message)
            result = Nothing
        End Try

        Return result
    End Function

    Public Function AddTableToGridRow(ByVal SetGv As DataGridView, ByVal SetDT As DataTable) As Boolean
        'return false if error
        Try
            For Each row As DataRow In SetDT.Rows
                SetGv.Rows.Add(row.ItemArray)
            Next
            Return True
        Catch ex As Exception
            WriteLog("Catch Error On AddTableToGridRow ErrMsg=" & ex.Message)
            Return False
        End Try
    End Function

    Public Sub SetFocusOnGridRow(ByRef SetGv As DataGridView, ByVal CellName As String, ByVal ChkVal As String)
        Try
            If SetGv.RowCount > 0 Then
                For Each row As DataGridViewRow In SetGv.Rows
                    If Regex.IsMatch(row.Cells(CellName).Value, ChkVal, RegexOptions.IgnoreCase) Then
                        row.Cells(0).Selected = True
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            WriteLog("Catch Error On SetFocusOnGridRow ErrMsg=" & ex.Message)
        End Try
    End Sub

    Public Function CreateTxLogFolder(Optional ByVal SetPath As String = "") As String
        'return "" if no error or return error message
        Dim result As String = ""

        If SetPath = "" Then
            If My.Application.Info.Description.Trim <> "" Then
                SetPath = "C:\TXlog\Hana_" & My.Application.Info.Description.Trim
            Else
                Return "No Application Description Found"
            End If
        End If

        MST_LocalPath = SetPath
        Try
            If MST_LocalPath <> "" Then
                If Not Directory.Exists(MST_LocalPath) Then
                    Directory.CreateDirectory(MST_LocalPath)
                End If
            End If
        Catch ex As Exception
            result = "CATCH ERROR: " & ex.Message
        End Try

        Return result
    End Function

    Public Function SetupNewDBConnect(ByVal ConnectStr As String) As DBConnect
        Dim result As DBConnect

        Try
            result = New DBConnect
            result.ConnectionType = DB_Type
            result.ConnectionString = ConnectStr
        Catch
            result = Nothing
        End Try

        Return result
    End Function

    Public Function DeleteTableRow(ByVal ChkTable As DataTable, ByVal WhereCond As String) As DataTable
        Dim result As DataTable

        Try
            For Each row As DataRow In ChkTable.Select(WhereCond)
                ChkTable.Rows.Remove(row)
            Next
            result = ChkTable.Copy
        Catch ex As Exception
            WriteLog("DeleteTableRow() CATCH ERROR=" & ex.Message)
            result = Nothing
        End Try

        Return result
    End Function

    ' Declare the API functions
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Function FindWindow(
ByVal lpClassName As String,
ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Public Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Public Sub ActivateExplorerWindow(ByVal title As String)
        ' Find the window handle by its title
        Dim hWnd As IntPtr = FindWindow(Nothing, title)
        If hWnd <> IntPtr.Zero Then
            ' Activate the window
            SetForegroundWindow(hWnd)
        Else
            ' Window not found
            MessageBox.Show("File Explorer window not found.")
        End If
    End Sub

    Public Function IsExplorerOpened(ByVal ChkPath As String) As Boolean
        Dim result As Boolean
        Dim hWnd As IntPtr = FindWindow(Nothing, Path.GetDirectoryName(ChkPath).Replace(Path.DirectorySeparatorChar, ""))
        If hWnd <> IntPtr.Zero Then
            ' Activate the window
            result = True
        Else
            ' Window not found
            result = False
        End If
        Return result
    End Function

    'Public Function GetAllExplorerPath() As ArrayList
    '    Dim exShell As New Shell()
    '    Dim SFV As ShellFolderView
    '    Dim expPath As String
    '    Dim PathList As New ArrayList

    '    For Each w As ShellBrowserWindow In DirectCast(exShell.Windows, IShellWindows)

    '        ' try to cast to an explorer folder
    '        If TryCast(w.Document, IShellFolderViewDual) IsNot Nothing Then
    '            expPath = DirectCast(w.Document, IShellFolderViewDual).FocusedItem.Path
    '            ' remove the GetDirectoryName method when you 
    '            ' want to return the selected file rather than folder
    '            PathList.Add(Path.GetDirectoryName(expPath))
    '            'Return Path.GetDirectoryName(expPath)
    '        ElseIf TryCast(w.Document, ShellFolderView) IsNot Nothing Then
    '            expPath = DirectCast(w.Document, ShellFolderView).FocusedItem.Path
    '            PathList.Add(Path.GetDirectoryName(expPath))
    '            'Return Path.GetDirectoryName(expPath)
    '        End If
    '    Next

    '    Return PathList
    'End Function

    <DllImport("user32.dll")>
    Public Function ShowWindow(ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
    End Function

    Public Sub ShowProcessWindowByID(ByVal ProcID As Integer)
        ' Create a Process object
        Dim p As New Process()
        ' Get the process by its name
        p = Process.GetProcessById(ProcID)
        If p IsNot Nothing Then
            ' Get the main window handle
            Dim hWnd As IntPtr = p.MainWindowHandle
            ' Show the window
            ShowWindow(hWnd, 1) ' 1 means SW_SHOWNORMAL
        Else
            ' Process not found
            MessageBox.Show("Process not found.")
        End If
    End Sub

#End Region

#Region "LogFile_Functions"
    Public Sub WriteLog(ByVal LogStr As String)
        ' Routine to add a string to the defined log file.
        Dim LogFileWrite As StreamWriter
        Dim DateTime As String
        Dim LogSize As Long
        Dim LogName As String

        ' Check the log file size.
        If (Dir(LogFile) <> "") Then
            LogSize = FileLen(LogFile)
            If (LogSize > 2000000) Then
                ' Update old log file and start new.
                DateTime = LogDateTimeStr()

                ' Set the log file name.
                LogName = LogNameTimeStr() & "-" & McID & "-" & My.Application.Info.Description.Trim & ".log"

                Try
                    ' Add the string to the log file.
                    LogFileWrite = New StreamWriter(LogFile, True, System.Text.Encoding.GetEncoding(CodePage))
                    LogFileWrite.WriteLine(DateTime & " : Continuing logging in file " & LogName)
                Catch Ex As Exception
                    ' Error when trying to write to the log file. 
                Finally
                    LogFileWrite.Close()
                End Try

                ' Update the general logfile full path.
                LogFile = LogPath & "\" & LogName

                Try
                    ' Add the string to the log file.
                    LogFileWrite = New StreamWriter(LogFile, True, System.Text.Encoding.GetEncoding(CodePage))

                    ' Initialise continuation log file.
                    LogFileWrite.WriteLine(Application.ProductName & " Application")
                    LogFileWrite.WriteLine("Continuing logging from previous log file")
                    LogFileWrite.WriteLine("Application version number " & Application.ProductVersion)
                Catch Ex As Exception
                    ' Error when trying to write to the log file.
                Finally
                    LogFileWrite.Close()
                End Try

                ' Clean up extra log files.
                CleanLogs()
            End If
        End If

        ' Set the log file entry date/time.
        DateTime = LogDateTimeStr()
        Try
            ' Add the string to the log file.
            LogFileWrite = New StreamWriter(LogFile, True, System.Text.Encoding.GetEncoding(CodePage))
            LogFileWrite.WriteLine(DateTime & " : " & LogStr)
        Catch Ex As Exception
            ' Error when trying to write to the log file.
        Finally
            LogFileWrite.Close()
        End Try
    End Sub

    Private Function LogDateTimeStr() As String
        ' Set the formatted timestamp string.
        Return DateAndTime.Now.ToString("HH:mm:ss dd-MM-yyyy")
    End Function

    Private Function LogNameTimeStr() As String
        ' Set the formatted timestamp string.
        Return DateAndTime.Now.ToString("yyyyMMddHHmm")
    End Function

    Private Function CleanLogs() As Integer
        ' Function to delete excess log files. The function will return the number of log files deleted.
        Dim FndFile As String = ""
        Dim FleList As String() = {""}
        Dim Elem As Integer = 0
        Dim DelNum As Integer = 0

        ' Create a list of all the log files.
        FndFile = Dir(LogPath & "\*-" & McID & "-" & My.Application.Info.Description.Trim & ".log", FileAttribute.Normal)
        Do While (FndFile <> "")
            ReDim Preserve FleList(Elem)
            FleList(Elem) = FndFile
            Elem = Elem + 1
            FndFile = Dir()
        Loop

        ' Check if too many log files exist.
        If (NumLogs > 0) Then
            If (FleList.Count > NumLogs) Then
                For Indx As Integer = 0 To ((FleList.Count - NumLogs) - 1)
                    Try
                        File.Delete(LogPath & "\" & FleList(Indx))
                    Catch Ex As Exception
                        WriteLog("WARNING - Unable to clean up log file " & FleList(Indx) & ". Error message in log file")
                        WriteLog("Error message is:- " & Ex.Message)
                    End Try
                Next
            End If
        End If

        Return DelNum
    End Function
#End Region

End Module
