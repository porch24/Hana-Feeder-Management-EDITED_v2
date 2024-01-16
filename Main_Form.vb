Imports System.ComponentModel
Imports System.IO
Imports System.Text.RegularExpressions
Imports Hana_Feeder_Management
Imports System.Windows.Forms
Imports System.Windows.Forms.Timer
Imports System.Data.SqlClient ' Import the necessary namespace for SQL Server
Imports System.Text
Imports System.Net
Imports System.Diagnostics
Imports System.Reflection
Public Class Main_Form
    ' ประกาศตัวแปรแบบ Public สำหรับใช้ในทั้ง Class
    Public Property Txt_FeederList As Object
    Public Property Txt_ScannedStatus As Object
    Public Property CurIdx As Integer
    Public Property YourMessageBox As Object
    Public Property Txt_FeedNo As Object
    Public Property Txt_FeedType As Object
    Public Property Txt_McNo As Object
    Public Property Txt_McName As Object
    Public Property UpdateNote As Object
    ' เปลี่ยน PalletInfo เป็น FeederInfo
    Private SetFeeder As FeederInfo
    Private FeederSet_FM As Object
    Private loggedIn As Boolean = False
    Private txtFeederInfo As TextBox ' ตัวแปร TextBox ที่ใช้แสดงข้อมูล Feeder

    ' ประกาศตัวแปร SkillRequired สำหรับใช้กำหนดความสามารถที่ต้องการ
    Dim SkillRequired As String = ""
    Dim LoadDone As Boolean = False
    Dim LoadingErr As String = ""
    Dim Fx_ExlTempPath As String = "\DLL_Hana Feeder Management Templates\Default_FeederTemplate.xlsx"
    Dim Fx_BtwFilePath As String = "\DLL_Hana Feeder Management Templates"
    Dim TemplatePath As String
    Dim SkillReqNewPal As String = "Feeder Management"
    Dim CurrUser As LoginInfo

    ' ประกาศ Structure สำหรับเก็บข้อมูล Warning
#Region "Must Defined Variables"
    Public DB_Type As String = "MsSQL"
    Public DB_ConStr_Vmn As String
    Public DB_ConStr_Inv As String
    Public MST_DbConn As DBConnect

#End Region
    Public Structure GlobalWarnInfo
        Dim ShowWarn As Boolean
        Dim BackColor As String
        Dim ForeColor As String
        Dim WarnMsg As String
        Dim CheckInterval As Long

    End Structure
    Public Structure WarningInfo
        Dim ShowWarn As Boolean
        Dim WarnStr As String       'Define Warning Message
        Dim WarnVis As Integer      'Define how long warning need to show up as a second
        Dim WarnCol As Integer      'Define color of Warning Label
    End Structure
    Public Class LoginInfo
        Public UserName As String
        Public SkillList As ArrayList
        Public LoginValid As Boolean
        Public IsAdmin As Boolean

    End Class
    Public Class YourDataStructure
        Public Property FeederID As String
        Public Property FeederType As String
        Public Property McID As String
        Public Property McName As String
    End Class

    Public Class FeederInfo
        Public FeederInfo As FeederInfo
        Public FeederRead As Boolean
    End Class
    Public WarnData As New WarningInfo
    Dim GlobalObj As GlobalWarnInfo
    ' ประกาศ Label แบบ WithEvents สำหรับใช้ใน Form
    Dim WithEvents LabAdmin As New Label
    ' Used to hold the scanner data strings if multiple strings need to arrive from the scanner to complete the sequence (typically longer than 8 data bits).
    Dim ScanStrTxt As String = ""     ' Stores the scanner strings coming from the scanner and updates the scan string textbox (removes the need to multi-thread on scanner data recieved).
    Dim ScanStrDB As String = ""     ' Stores the database search string taken from the full scanner string.
    Dim ScanStrUpd As Integer = -1     ' Stores the link to the text box requiring an update; 1 = inspector, 2 = defect update, 3 = PUID (removes the need to multi-thread on scanner data recieved).
    Dim WarnCntDown As Integer = 0
    Dim MST_BgwSetup As BgwInfo
    Private Structure BgwInfo
        Dim BgwWorkMode As Integer
        '   Used to defnied which mode that bgwMain will process
        '   1 = Check New Feeder Scanned
        '   2 = Feeder Saving
        '   3 = Load Feeder Info
        '   4 = Close Feeder
        '   5 = Save Feeder + McID Info
        '   6 = Reset Feeder
        '   7 = Reset McID
        '   8 = Save Setup Feeder
        '   ......

        Dim ReloadScanned As Boolean
        Dim ReportMsg As String
        Dim BgwError As Boolean
        Dim ErrMsg As String
    End Structure

#Region "Station Config"
    Private tcCt_Main As Object
    Private btSave1 As Object
    Private btRefresh2 As Object
#End Region



#Region "Global_Warning Functions"
    ' Event Handler สำหรับ Load Form
    Private Sub Main_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '### MUST BE DEFINED TO AVOID CROSS THREAD ERROR
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        '###

        Me.Text = Application.ProductName & " (" & Application.ProductVersion & ")"
        MyBase.WindowState = FormWindowState.Minimized
        Pan_Tmr1.BackColor = Color.Red
        Pan_Tmr2.BackColor = Color.Yellow

        ' กำหนดระยะเวลาของ Timer เป็น 1000 มิลลิวินาที (1 วินาที)
        Dim timer As New System.Windows.Forms.Timer()
        timer.Interval = 1000
        AddHandler timer.Tick, AddressOf Timer_Tick
        timer.Start()
        LoadingErr = ModuleStartup()
        If LoadingErr.Trim = "" Then
            ' ทำตามข้อความที่ต้องการเมื่อ ModuleStartup สำเร็จ
        End If

        WriteLog("Getting McID Configuration")
        LoadingErr = GetMcIDConfig(GenericModule.McID)

        If ConfigList IsNot Nothing AndAlso CurIdx > 0 Then
            Dim FeedType, McName As String
            Dim FeedNo, McNO As Integer
            For Each Feeder In ConfigList
                FeedNo = Feeder.ConfigName.Trim()
                FeedType = Feeder.ConfigValue.Trim()
                ' Check Mc Pattern
                If Regex.IsMatch(FeedNo, "Mcidpattern", RegexOptions.IgnoreCase) Then
                    Dim McIDCounter As Integer = Integer.Parse(FeedType)
                    McIDCounter += 1
                    GenericModule.McID = McIDCounter
                    SetupNewPattern("McIDPattern", McNO, GenericModule.McID)
                    WriteLog("Config Found : McIDPattern =" & vbTab & GenericModule.McID)
                    Continue For
                End If
            Next

            ' Copy template files to local folder if not exist
            Dim FeederErr, McErr As String
            FeederErr = "FeederPattern" & vbTab & "- สำหรับการสแกน Feeder"
            McErr = "McPattern " & vbTab & "- สำหรับการสแกน McID"

            If PatternList IsNot Nothing AndAlso PatternList.Count > 0 Then
                If Not CheckForPatternExist("FeederPattern") Then
                    LoadingErr = FeederErr
                ElseIf Not CheckForPatternExist("McPattern") Then
                    LoadingErr = McErr
                End If

                'Copy template files to local folder if not exist
                If TemplatePath Is Nothing Then
                    CreateTxLogFolder()
                    TemplatePath = MST_LocalPath & Path.GetDirectoryName(Fx_ExlTempPath)
                ElseIf TemplatePath <> "" Then
                    CreateTxLogFolder(TemplatePath)
                    TemplatePath &= Path.GetDirectoryName(Fx_ExlTempPath)
                End If
                Try
                    For Each tmp In Directory.GetFiles(Application.StartupPath & Path.GetDirectoryName(Fx_ExlTempPath), "*.*")
                        If Not File.Exists(TemplatePath & Path.DirectorySeparatorChar & Path.GetFileName(tmp)) Then
                            If Not Directory.Exists(TemplatePath) Then
                                Directory.CreateDirectory(TemplatePath)
                            End If
                            FileCopy(tmp, TemplatePath & Path.DirectorySeparatorChar & Path.GetFileName(tmp))
                        End If
                    Next

                    Fx_BtwFilePath = MST_LocalPath & Fx_BtwFilePath
                Catch ex As Exception
                    LoadingErr = "Template File Transfer Error" & vbCr & ex.Message
                End Try
            Else
                LoadingErr = "No Configuration found (McID= " & GenericModule.McID & ")"
            End If
        End If

        ' Setup Form UI
        lbHStaName.Text = GetMcName(GenericModule.McID)
        Me.Text &= " - " & GenericModule.McID & "_" & lbHStaName.Text

        If LoadingErr = "" Then
            LoadDone = True
            ' ทำตามข้อความที่ต้องการเมื่อโปรแกรมโหลดเสร็จสมบูรณ์
        End If
    End Sub
#End Region

    ' Event Handler สำหรับ Form ที่ถูกแสดงขึ้น
    Private Sub Main_Form_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' This Sub will be called after MainForm Loaded
        If LoadDone Then
            ' Clear previous running excel execution
            MyBase.WindowState = FormWindowState.Normal
            WarnData = New WarningInfo
            WarnData.WarnCol = 2
            WarnData.WarnVis = 0
            ShowWarning()
            txtUsername.Focus()
        Else
            ' If loading is not done successfully
            Dim WarnStr As String = ""
            WarnStr = "ไม่สามารถเริ่มการทำงานของโปรแกรมได้เนื่องจาก" & vbCrLf & vbCrLf & LoadingErr
            MsgBox(WarnStr, MsgBoxStyle.Critical)
            Process.GetCurrentProcess.Kill()
            Application.Exit()
        End If
    End Sub
    ' Event Handler สำหรับปิด Form
    Private Sub Main_Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            My.Settings.Save()
        Catch
        End Try
    End Sub
    Private Sub btUpdNote_Click(sender As Object, e As EventArgs) Handles btUpdNote.Click
        Dim updateNotePath As String = "Resources\UpdateNote.txt" ' ระบุ path ของไฟล์ UpdateNote ที่ต้องการเปิด

        ' ตรวจสอบว่าไฟล์ UpdateNote มีอยู่หรือไม่
        If File.Exists(updateNotePath) Then
            ' ใช้ Process.Start เพื่อเปิดไฟล์ด้วยโปรแกรมที่เปิดได้ (เช่น Notepad)
            Process.Start(updateNotePath)
        Else
            ' แสดงคำเตือนหากไฟล์ UpdateNote ไม่มีอยู่
            MessageBox.Show("The UpdateNote file is not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Txt_Scan_Enter(sender As Object, e As EventArgs) Handles Txt_Scanner.Enter
        If Not Txt_Scanner.ReadOnly Then
            Txt_Scanner.BackColor = Color.LightGreen
        End If
    End Sub

    Private Sub Txt_Scan_Leave(sender As Object, e As EventArgs) Handles Txt_Scanner.Leave
        If Not Txt_Scanner.ReadOnly Then
            Txt_Scanner.BackColor = Color.Yellow
        End If
    End Sub
    ' Event Handler สำหรับเมื่อ Form ได้รับการ Activate
    Private Sub Main_Form_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If txtUsername.Text = "" Then
            txtUsername.Focus()
        Else
            Txt_Scanner.Focus()
        End If
    End Sub


    ' Event Handler สำหรับ KeyPress ของ txtUsername
    Private Sub txtUsername_keypass(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If e.KeyChar = Chr(13) And txtUsername.Text <> "" Then
            ' ทำงานเมื่อกด Enter
        End If
    End Sub

    ' ฟังก์ชันตรวจสอบการ Logout
    Private Function ValidateLogout() As Boolean
        Dim result, NeedWarn As Boolean

        NeedWarn = False

        If NeedWarn Then
            If MessageBox.Show(My.Resources.Warn_ConfirmLogout, "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                result = False
            Else
                result = True
            End If
        Else
            result = True
        End If

        Return result
    End Function

    ' ฟังก์ชันแสดง Warning
    Public Sub ShowWarning(ByVal WarnStr As String, ByVal WarnVis As Integer, ByVal WarnCol As Integer)
        Lab_AlertMsg.Visible = False
        Lab_AlertMsg.Text = WarnStr
        Select Case WarnCol
            Case 1
                Lab_AlertMsg.BackColor = Color.Red
                Lab_AlertMsg.ForeColor = Color.Yellow
            Case 2
                Lab_AlertMsg.BackColor = Color.Yellow
                Lab_AlertMsg.ForeColor = Color.Black
            Case 3
                Lab_AlertMsg.BackColor = Color.LightGreen
                Lab_AlertMsg.ForeColor = Color.Black
        End Select
        Lab_AlertMsg.Visible = True
    End Sub
    ' Event Handler สำหรับ Logout ผู้ใช้
    Private Sub UserLogout()
        'Clear Invoice Info.
        ResetForm()
        'Update User Control
        txtUsername.Text = ""
        txtUsername.Enabled = True
        btnLogInOut.Text = "Login"
        LabAdmin.Hide()
        WarnData.ShowWarn = True
        WarnData.WarnStr = "MSS User has logout."
        WarnData.WarnVis = 5
        WarnData.WarnCol = 2
        ShowWarning()
        'Reset application state
        txtUsername.Focus()
    End Sub

    ' ฟังก์ชันตรวจสอบการ Login
    ' ฟังก์ชันแสดง Warning
    Public Sub ShowWarning()
        If WarnData.WarnStr IsNot Nothing Then
            Lab_AlertMsg.Visible = False
            Lab_AlertMsg.Text = WarnData.WarnStr
            Select Case WarnData.WarnCol
                Case 1
                    Lab_AlertMsg.BackColor = Color.Red
                    Lab_AlertMsg.ForeColor = Color.Yellow
                Case 2
                    Lab_AlertMsg.BackColor = Color.Yellow
                    Lab_AlertMsg.ForeColor = Color.Black
                Case 3
                    Lab_AlertMsg.BackColor = Color.LightGreen
                    Lab_AlertMsg.ForeColor = Color.Black
            End Select
            Lab_AlertMsg.Visible = True
        Else
            Lab_AlertMsg.Visible = False
        End If
    End Sub

    ' ฟังก์ชัน Login ผู้ใช้
    Public Sub UserLogin()
        'Disable login controls
        txtUsername.Enabled = False
        btnLogInOut.Text = "Logout"

        Txt_Scanner.Enabled = True
        Txt_Scanner.Focus()
        ShowWarning("MSS User Login Successful", 5, 3)
    End Sub

    ' Event Handler สำหรับ Reset Form
    Private Sub ResetForm(Optional ByVal SetMode As Integer = 0)
        Dim PrevLoad As Boolean = LoadDone
        LoadDone = False
        Lab_AlertMsg.Visible = False

        Select Case SetMode
            Case 0
                ' สามารถเพิ่มการกำหนดค่าต่าง ๆ ในกรณีที่ SetMode = 0
            Case 1
                ' สามารถเพิ่มการกำหนดค่าต่าง ๆ ในกรณีที่ SetMode = 1 (Clear Invoice Carton info for new scanning)
        End Select

        LoadDone = PrevLoad
    End Sub

    Private Sub SetFormLoading(ByVal SetVal As Boolean)
        ' ถ้า SetVal เป็น True แสดงว่าฟอร์มกำลังโหลดหรือบันทึกข้อมูล
        lbLoading.Visible = SetVal
        ShowWarning()

        ' หยุดการทำงานของ Tmr_1Sec ถ้าฟอร์มกำลังโหลดหรือบันทึกข้อมูล
        If SetVal Then
            Tmr_1Sec.Stop()
        Else
            Tmr_1Sec.Start()
        End If
    End Sub

    ' ฟังก์ชันที่ใช้ในการอัปเดตสถานะการสแกนของ Feeder
    Private Sub UpdateFeederScanned(ByVal FeederID As String)
        ' ตรวจสอบว่ามีข้อมูล Feeder ใน ListBox (หรือ ListView) หรือไม่
        If Txt_FeederList.Items.Count > 0 Then
            ' วนลูปผ่าน Item ทุกตัวใน ListBox
            For Each item As Object In Txt_FeederList.Items
                ' ตรวจสอบว่าข้อมูล Feeder ที่ตรงกับ FeederNo หรือไม่
                If item.ToString().Contains(FeederID) Then
                    ' เพิ่มเครื่องหมายถูกสแกน (หรือข้อความอื่นๆ ตามต้องการ) ลงใน TextBox ของสถานะการสแกน
                    Txt_ScannedStatus.AppendText($"Feeder {FeederID} ถูกสแกนแล้ว" & Environment.NewLine)

                    ' ลบข้อมูล Feeder ที่ถูกสแกนออกจาก ListBox
                    Txt_FeederList.Items.Remove(item)
                    Exit For
                End If
            Next

            ' ตรวจสอบว่าทุก Feeder ในกลุ่มนี้ถูกสแกนหรือไม่
            If Txt_FeederList.Items.Count = 0 Then
                ' แสดงข้อความ Warning ที่เหลือ
                ShowWarning("Please input box quantity", 10, 2)
            Else
                ' แสดงข้อความ Warning สำหรับรอการสแกน Feeder ถัดไปในกลุ่ม
                ShowWarning("Wait for the next Feeder scan", 10, 3)
            End If

        End If
    End Sub

    ' เป็นเหตุการณ์ที่เกิดขึ้นเมื่อ TextBox ได้รับการ focus (ถูกคลิกเพื่อใส่ข้อความ)
    Private Sub Txt_Scanner_Enter(sender As Object, e As EventArgs) Handles Txt_Scanner.Enter
        ' ตรวจสอบว่า TextBox ไม่ใช่ระหว่างการอ่านอยู่
        If Not Txt_Scanner.ReadOnly Then
            ' กำหนดสีพื้นหลังของ TextBox เป็นสีเขียว
            Txt_Scanner.BackColor = Color.LightGreen
        End If
    End Sub

    ' เป็นเหตุการณ์ที่เกิดขึ้นเมื่อ TextBox ไม่ได้รับการ focus
    Private Sub Txt_Scanner_Leave(sender As Object, e As EventArgs) Handles Txt_Scanner.Leave
        ' ตรวจสอบว่า TextBox ไม่ใช่ระหว่างการอ่านอยู่
        If Not Txt_Scanner.ReadOnly Then
            ' กำหนดสีพื้นหลังของ TextBox เป็นสีเหลือง
            Txt_Scanner.BackColor = Color.Yellow
        End If
    End Sub


    Private Sub Txt_Scanner_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Scanner.KeyDown
        ' ตรวจสอบว่าปุ่มที่ถูกกดคือปุ่ม Enter
        If e.KeyCode = Keys.Enter Then
            ' แสดง MessageBox เพื่อยืนยันการเปลี่ยนหมายเลข Feeder
            If MessageBox.Show("ยืนยันการเปลี่ยนหมายเลข Feeder ?", "CONFIRM FEEDER CHANGE",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                ' ถ้าผู้ใช้ตอบ Yes ใน MessageBox ให้เรียกเมทอด PerformClick() ของปุ่ม Btn_SendScan
                Btn_SendScan.PerformClick()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            ' ถ้าเป็นปุ่ม Escape
            ' ตรวจสอบว่าปุ่มยกเลิก (btPl_Cancel) มีการแสดงผลและเปิดใช้งาน
            If btPl_Cancel.Visible AndAlso btPl_Cancel.Enabled Then
                ' แสดง MessageBox เพื่อยืนยันการเปลี่ยนหมายเลข Feeder & McID
                If MessageBox.Show("ยืนยันการเปลี่ยนหมายเลข Feeder & McID ไปยังหมายเลขอื่น ?" & vbCr & vbCr &
                               "(ข้อมูลปัจจุบันที่ปรากฏในโปรแกรม ได้ถูกบันทึกแล้วโดยอัตโนมัติ)", "CONFIRM CANCEL",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    ' ถ้าผู้ใช้ตอบ Yes ใน MessageBox ให้เรียกเมทอด PerformClick() ของปุ่ม btPl_Cancel
                    btPl_Cancel.PerformClick()
                End If
            End If
        End If
    End Sub

    ' ฟังก์ชันนี้ใช้สำหรับหยุดหรือเริ่มการสแกน โดยการปรับค่า Enabled ของ Txt_Scanner
    ' SetValue: True หมายถึงหยุดการสแกน, False หมายถึงเริ่มการสแกน
    Private Sub PauseScanning(ByVal SetValue As Boolean)
        Txt_Scanner.Enabled = Not SetValue
        If Txt_Scanner.Enabled Then
            Txt_Scanner.Focus()
        End If
    End Sub

    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If e.KeyChar = Chr(13) And txtUsername.Text <> "" Then

        End If
    End Sub

    Private Sub btnLogInOut_Click(sender As Object, e As EventArgs) Handles btnLogInOut.Click
        If btnLogInOut.Text = "Logout" Then
            If ValidateLogout() Then
                UserLogout()
            End If
        Else
            If (txtUsername.Text.Trim = "") Then
                WarnData.ShowWarn = True
                WarnData.WarnStr = "Please input Username first!!"
                WarnData.WarnVis = 5
                WarnData.WarnCol = 1
                ShowWarning()
                If txtUsername.Text = "" Then
                    txtUsername.Focus()
                End If
            Else
                Dim NewLogin As New LoginInfo
                NewLogin.UserName = txtUsername.Text.Trim

                ' Check for user skill
                If NewLogin.UserName = "089177" Then ' ตัวอย่างการตรวจสอบว่าเป็นตัวเลข 6 ตัว
                    WarnData.ShowWarn = True
                    WarnData.WarnStr = My.Resources.Warn_MSSUserNoSkillRequired & " [" & SkillRequired.ToUpper & "]"
                    WarnData.WarnVis = 5
                    WarnData.WarnCol = 1
                    ShowWarning()
                Else
                    WarnData.ShowWarn = True
                    WarnData.WarnStr = "Username Invalid!!!"
                    WarnData.WarnVis = 5
                    WarnData.WarnCol = 1
                    ShowWarning()
                    txtUsername.Text = ""
                End If
            End If
        End If
    End Sub

    Private Function ValidateLogin(ByVal ChkUser As LoginInfo) As Boolean
        Dim result, UserValid As Boolean


        CurrUser = New LoginInfo
        CurrUser.UserName = ChkUser.UserName
        CurrUser.SkillList = ChkUser.SkillList
        CurrUser.LoginValid = True

        result = True

        Return result
    End Function

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        ' สลับสีของ Pan_Tmr1 และ Pan_Tmr2
        Pan_Tmr1.BackColor = If(Pan_Tmr1.BackColor = Color.Red, Color.Yellow, Color.Red)
        Pan_Tmr2.BackColor = If(Pan_Tmr1.BackColor = Color.Red, Color.Yellow, Color.Red)
    End Sub

    Private Sub btCt_Save_Click(sender As Object, e As EventArgs)
        ' ดึงข้อมูลจาก TextBox แล้วเตรียมสำหรับการบันทึกลงในฐานข้อมูล
        Dim dataToSave As String = IssueText.Text ' เปลี่ยนเป็น TextBox ที่ต้องการเซฟข้อมูล

        ' เรียกฟังก์ชันหรือเมธอดที่ใช้ในการบันทึกข้อมูลลงในฐานข้อมูล
        btCt_Save.Enabled = True

        ' จากนั้นคุณสามารถทำอย่างอื่น ๆ ตามต้องการ
    End Sub
    Public Function TestFeeder(ByVal FdrID As Integer) As Object
        ' Return "" if no error or return error message
        Dim ResStr As String = ""
        Dim DBconn As DBConnect
        Dim SQLStr As String
        Dim TmpDS As DataSet
        Dim data As YourDataStructure = Nothing

        Try
            DBconn = New DBConnect
            DBconn.ConnectionString = DB_ConnStr
            DBconn.ConnectionType = DB_Type

            SQLStr = "EXECUTE [dbo].[HANA_SP_Feeder_GetInfo] @pramFdrID = " & FdrID.ToString
            TmpDS = DBconn.DataSet(SQLStr)

            If TmpDS.Tables IsNot Nothing AndAlso TmpDS.Tables.Count > 0 AndAlso TmpDS.Tables(0).Rows.Count > 0 Then
                If CBool(TmpDS.Tables(0).Rows(0)(0)) Then
                    ' Process data retrieval successfully
                    ResStr = TmpDS.Tables(0).Rows(0)(1).ToString.Trim

                    ' Retrieve data from the database
                    If TmpDS.Tables.Count > 1 AndAlso TmpDS.Tables(1).Rows.Count > 0 Then
                        data = New YourDataStructure()
                        data.FeederID = TmpDS.Tables(1).Rows(0)("FeederID").ToString()
                        data.FeederType = TmpDS.Tables(1).Rows(0)("FeederType").ToString()
                        data.McID = TmpDS.Tables(1).Rows(0)("McID").ToString()
                        data.McName = TmpDS.Tables(1).Rows(0)("McName").ToString()
                    Else
                        ' No data found for Feeder
                        ResStr = "Feeder not found in the database"
                        ' Log the message
                        WriteLog(ResStr)
                    End If
                Else
                    ' Data retrieval process failed
                    ResStr = TmpDS.Tables(0).Rows(0)(1).ToString.Trim
                    ' Log the message
                    WriteLog("Feeder not found in the database (" & ResStr & ")")
                End If
            Else
                ' No data from SQL query
                ResStr = "No Result Return from DB"
                ' Log the message
                WriteLog(" No Result Return from DB")
            End If
        Catch ex As Exception
            ResStr = My.Resources.Warn_CatchErrorContactValor & vbCr & vbCr & ex.Message
            ' Log the exception
            WriteLog("Catch Error on Feeder Management" & vbCr & "ErrMsg= " & ex.Message)
        End Try

        Return If(data IsNot Nothing, data, ResStr)
    End Function

    Private Sub Btn_SendScan_Click(sender As Object, e As EventArgs) Handles Btn_SendScan.Click
        Try
            Dim scannerValue As String = Txt_Scanner.Text.Trim

            ' Call the TestFeeder function to retrieve data
            Dim result As Object = TestFeeder(Convert.ToInt32(scannerValue))

            If TypeOf result Is YourDataStructure Then
                Dim data As YourDataStructure = DirectCast(result, YourDataStructure)

                ' Use Dictionary to map Column names to TextBoxes
                Dim textBoxDictionary As New Dictionary(Of String, TextBox) From
            {
                {"FeederID", FeederID},
                {"FeederType", FeederType},
                {"McID", McID},
                {"McName", McName}
            }

                ' Set values in TextBoxes based on Column names
                For Each propInfo As PropertyInfo In GetType(YourDataStructure).GetProperties()
                    Dim columnName As String = propInfo.Name
                    If textBoxDictionary.ContainsKey(columnName) Then
                        Dim textBox As TextBox = textBoxDictionary(columnName)

                        ' Check if the TextBox is found
                        If textBox IsNot Nothing Then
                            ' Set value in TextBox
                            Dim value As Object = propInfo.GetValue(data)
                            Dim valueString As String = If(value IsNot Nothing, value.ToString(), "")
                            textBox.Text = valueString
                        End If
                    End If
                Next

                ' Set value in FeederSH
                FeederSH.Text = $"Feeder# {data.FeederID}"
            Else
                ' If the result is not YourDataStructure, show a necessary error message
                MessageBox.Show($"Feeder not found in the database: {result}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            ' Focus on the TextBox used for scanning
            Txt_Scanner.Focus()
        Catch ex As Exception
            ' Show an error message if there is another error
            MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btCtsend_Click(sender As Object, e As EventArgs) Handles btCtsend.Click
        Try
            ' กำหนด Token ของ Line Notify ที่นี่
            Dim lineNotifyToken As String = "VuDC1CO0b7bULHMRHpakNnoN9Z0SY0mOzIwqNxdi9bq"

            WriteLog("Getting McID Configuration")
            LoadingErr = GetMcIDConfig(GenericModule.McID)

            Dim message1 As String = $"Report{vbCrLf}FeederID: {Txt_Scanner.Text}{vbCrLf}" & $"McID: {GenericModule.McID}{vbCrLf}{vbCrLf}" & $"Issue: {IssueBox.Text}{vbCrLf}" & $"Other: {IssueText.Text}"


            If String.IsNullOrEmpty(message1) Then
                MsgBox("กรุณาใส่ข้อความทั้งสองก่อนครับ")
                Return
            End If


            Dim startInfo As New ProcessStartInfo()
            startInfo.FileName = "curl"
            startInfo.Arguments = $"-X POST -H ""Authorization: Bearer {lineNotifyToken}"" -F ""message={message1}"" https://notify-api.line.me/api/notify"
            startInfo.RedirectStandardOutput = True
            startInfo.UseShellExecute = False
            startInfo.CreateNoWindow = True

            Using process As Process = Process.Start(startInfo)
                Using reader As StreamReader = process.StandardOutput
                    Dim result As String = reader.ReadToEnd()
                    Console.WriteLine($"Response from Line Notify API: {result}")
                End Using
            End Using

            MsgBox($"ส่งข้อความสำเร็จ")

            ' เคลียร์ข้อความในช่อง
            Txt_Scanner.Text = ""
            IssueBox.Text = ""
            IssueText.Text = ""
        Catch ex As Exception
            Console.WriteLine($"Error sending message to Line Notify: {ex.Message}")
            MsgBox("เกิดข้อผิดพลาด: " & ex.Message)
        End Try
    End Sub

    Private Sub btCt_Save_Click_1(sender As Object, e As EventArgs) Handles btCt_Save.Click
        Dim confirmationResult As DialogResult = MessageBox.Show("คุณต้องการบันทึกข้อมูลใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmationResult = DialogResult.Yes Then
            Try
                ' สร้าง Connection String
                Dim connectionString As String = "Data Source=NB-SPARE-13;Initial Catalog=FeederM1;Integrated Security=True"

                ' สร้าง SqlConnection โดยใช้ Connection String
                Using connection As New SqlConnection(connectionString)
                    connection.Open()

                    ' สร้าง SqlCommand โดยใช้ stored procedure ที่เซ็ตไว้ใน cmd.CommandText
                    Using cmd As New SqlCommand("INSERT * FROM FeederData WHERE FeedNo = @pramFdrID", connection)
                        cmd.CommandType = CommandType.StoredProcedure

                        ' เพิ่มพารามิเตอร์และค่าที่จะส่งไปยัง stored procedure
                        cmd.Parameters.AddWithValue("@FeedNo", Txt_FeedNo.Text)
                        cmd.Parameters.AddWithValue("@FeedType", Txt_FeedType.Text)
                        cmd.Parameters.AddWithValue("@McNo", Txt_McNo.Text)
                        cmd.Parameters.AddWithValue("@McName", Txt_McName.Text)

                        ' ประมวลผล stored procedure
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "สถานะ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                ' จัดการข้อผิดพลาดที่เกิดขึ้น
                MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล: " & ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub





End Class
