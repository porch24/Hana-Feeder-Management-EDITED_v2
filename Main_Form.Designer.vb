<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main_Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_Form))
        Me.Pix_MSS = New System.Windows.Forms.PictureBox()
        Me.Pix_Hana = New System.Windows.Forms.PictureBox()
        Me.Lab_MainTitle = New System.Windows.Forms.Label()
        Me.lbHStaName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Grb_MSSuser = New System.Windows.Forms.GroupBox()
        Me.btnLogInOut = New System.Windows.Forms.Button()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.Pan_Tmr = New System.Windows.Forms.Panel()
        Me.Pan_Tmr1 = New System.Windows.Forms.RadioButton()
        Me.Pan_Tmr2 = New System.Windows.Forms.RadioButton()
        Me.Lab_AlertMsg = New System.Windows.Forms.Label()
        Me.Lab_Scan = New System.Windows.Forms.Label()
        Me.Txt_Scanner = New System.Windows.Forms.TextBox()
        Me.Btn_SendScan = New System.Windows.Forms.Button()
        Me.btUpdNote = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.McName = New System.Windows.Forms.TextBox()
        Me.McID = New System.Windows.Forms.TextBox()
        Me.FeederID = New System.Windows.Forms.TextBox()
        Me.FeederType = New System.Windows.Forms.TextBox()
        Me.FeederSH = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbCt_InvState = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btCt_Save = New System.Windows.Forms.Button()
        Me.IssueBox = New System.Windows.Forms.ComboBox()
        Me.IssueText = New System.Windows.Forms.TextBox()
        Me.btCtsend = New System.Windows.Forms.Button()
        Me.lbLoading = New System.Windows.Forms.Label()
        CType(Me.Pix_MSS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pix_Hana, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grb_MSSuser.SuspendLayout()
        Me.Pan_Tmr.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pix_MSS
        '
        Me.Pix_MSS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pix_MSS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pix_MSS.Image = CType(resources.GetObject("Pix_MSS.Image"), System.Drawing.Image)
        Me.Pix_MSS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Pix_MSS.Location = New System.Drawing.Point(742, 221)
        Me.Pix_MSS.Name = "Pix_MSS"
        Me.Pix_MSS.Size = New System.Drawing.Size(122, 56)
        Me.Pix_MSS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pix_MSS.TabIndex = 458
        Me.Pix_MSS.TabStop = False
        '
        'Pix_Hana
        '
        Me.Pix_Hana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pix_Hana.Image = CType(resources.GetObject("Pix_Hana.Image"), System.Drawing.Image)
        Me.Pix_Hana.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Pix_Hana.Location = New System.Drawing.Point(-162, 220)
        Me.Pix_Hana.Name = "Pix_Hana"
        Me.Pix_Hana.Size = New System.Drawing.Size(122, 56)
        Me.Pix_Hana.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pix_Hana.TabIndex = 457
        Me.Pix_Hana.TabStop = False
        '
        'Lab_MainTitle
        '
        Me.Lab_MainTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lab_MainTitle.BackColor = System.Drawing.Color.Transparent
        Me.Lab_MainTitle.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lab_MainTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Lab_MainTitle.Location = New System.Drawing.Point(128, 9)
        Me.Lab_MainTitle.Name = "Lab_MainTitle"
        Me.Lab_MainTitle.Size = New System.Drawing.Size(446, 28)
        Me.Lab_MainTitle.TabIndex = 459
        Me.Lab_MainTitle.Text = "Hana Feeder Management"
        Me.Lab_MainTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbHStaName
        '
        Me.lbHStaName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbHStaName.BackColor = System.Drawing.Color.Transparent
        Me.lbHStaName.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lbHStaName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbHStaName.Location = New System.Drawing.Point(128, 38)
        Me.lbHStaName.Name = "lbHStaName"
        Me.lbHStaName.Size = New System.Drawing.Size(446, 34)
        Me.lbHStaName.TabIndex = 460
        Me.lbHStaName.Text = "xStationName"
        Me.lbHStaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(579, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(122, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 464
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox2.Location = New System.Drawing.Point(1, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(122, 56)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 463
        Me.PictureBox2.TabStop = False
        '
        'Grb_MSSuser
        '
        Me.Grb_MSSuser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grb_MSSuser.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grb_MSSuser.Controls.Add(Me.btnLogInOut)
        Me.Grb_MSSuser.Controls.Add(Me.txtUsername)
        Me.Grb_MSSuser.Controls.Add(Me.UsernameLabel)
        Me.Grb_MSSuser.Controls.Add(Me.Pan_Tmr)
        Me.Grb_MSSuser.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grb_MSSuser.Location = New System.Drawing.Point(2, 108)
        Me.Grb_MSSuser.Name = "Grb_MSSuser"
        Me.Grb_MSSuser.Size = New System.Drawing.Size(697, 50)
        Me.Grb_MSSuser.TabIndex = 465
        Me.Grb_MSSuser.TabStop = False
        Me.Grb_MSSuser.Text = "MSS User Login"
        '
        'btnLogInOut
        '
        Me.btnLogInOut.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnLogInOut.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogInOut.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLogInOut.Location = New System.Drawing.Point(244, 17)
        Me.btnLogInOut.Name = "btnLogInOut"
        Me.btnLogInOut.Size = New System.Drawing.Size(81, 26)
        Me.btnLogInOut.TabIndex = 489
        Me.btnLogInOut.Text = "Login"
        Me.btnLogInOut.UseVisualStyleBackColor = False
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtUsername.Location = New System.Drawing.Point(101, 20)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(121, 22)
        Me.txtUsername.TabIndex = 488
        '
        'UsernameLabel
        '
        Me.UsernameLabel.BackColor = System.Drawing.Color.SandyBrown
        Me.UsernameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsernameLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UsernameLabel.ForeColor = System.Drawing.Color.Black
        Me.UsernameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.UsernameLabel.Location = New System.Drawing.Point(32, 21)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(73, 20)
        Me.UsernameLabel.TabIndex = 487
        Me.UsernameLabel.Text = "&Username:"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pan_Tmr
        '
        Me.Pan_Tmr.BackColor = System.Drawing.Color.Lime
        Me.Pan_Tmr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pan_Tmr.Controls.Add(Me.Pan_Tmr1)
        Me.Pan_Tmr.Controls.Add(Me.Pan_Tmr2)
        Me.Pan_Tmr.Location = New System.Drawing.Point(644, 19)
        Me.Pan_Tmr.Name = "Pan_Tmr"
        Me.Pan_Tmr.Size = New System.Drawing.Size(48, 24)
        Me.Pan_Tmr.TabIndex = 416
        '
        'Pan_Tmr1
        '
        Me.Pan_Tmr1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pan_Tmr1.Appearance = System.Windows.Forms.Appearance.Button
        Me.Pan_Tmr1.BackColor = System.Drawing.Color.Yellow
        Me.Pan_Tmr1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Pan_Tmr1.Location = New System.Drawing.Point(5, 3)
        Me.Pan_Tmr1.Name = "Pan_Tmr1"
        Me.Pan_Tmr1.Size = New System.Drawing.Size(14, 14)
        Me.Pan_Tmr1.TabIndex = 41
        Me.Pan_Tmr1.UseVisualStyleBackColor = False
        '
        'Pan_Tmr2
        '
        Me.Pan_Tmr2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pan_Tmr2.Appearance = System.Windows.Forms.Appearance.Button
        Me.Pan_Tmr2.BackColor = System.Drawing.Color.Red
        Me.Pan_Tmr2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Pan_Tmr2.Location = New System.Drawing.Point(25, 3)
        Me.Pan_Tmr2.Name = "Pan_Tmr2"
        Me.Pan_Tmr2.Size = New System.Drawing.Size(14, 14)
        Me.Pan_Tmr2.TabIndex = 42
        Me.Pan_Tmr2.UseVisualStyleBackColor = False
        '
        'Lab_AlertMsg
        '
        Me.Lab_AlertMsg.BackColor = System.Drawing.Color.LightGreen
        Me.Lab_AlertMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Lab_AlertMsg.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Lab_AlertMsg.ForeColor = System.Drawing.Color.Black
        Me.Lab_AlertMsg.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Lab_AlertMsg.Location = New System.Drawing.Point(0, 482)
        Me.Lab_AlertMsg.Name = "Lab_AlertMsg"
        Me.Lab_AlertMsg.Size = New System.Drawing.Size(701, 28)
        Me.Lab_AlertMsg.TabIndex = 466
        Me.Lab_AlertMsg.Text = "xLab_ShowWarning"
        Me.Lab_AlertMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lab_Scan
        '
        Me.Lab_Scan.BackColor = System.Drawing.Color.Cyan
        Me.Lab_Scan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lab_Scan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Lab_Scan.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Lab_Scan.Location = New System.Drawing.Point(0, 158)
        Me.Lab_Scan.Name = "Lab_Scan"
        Me.Lab_Scan.Size = New System.Drawing.Size(122, 24)
        Me.Lab_Scan.TabIndex = 477
        Me.Lab_Scan.Text = "SCAN HERE >>>"
        Me.Lab_Scan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Txt_Scanner
        '
        Me.Txt_Scanner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Scanner.BackColor = System.Drawing.Color.LightGreen
        Me.Txt_Scanner.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Scanner.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Txt_Scanner.Location = New System.Drawing.Point(121, 159)
        Me.Txt_Scanner.Name = "Txt_Scanner"
        Me.Txt_Scanner.Size = New System.Drawing.Size(546, 22)
        Me.Txt_Scanner.TabIndex = 478
        '
        'Btn_SendScan
        '
        Me.Btn_SendScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_SendScan.BackColor = System.Drawing.Color.LightYellow
        Me.Btn_SendScan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_SendScan.Location = New System.Drawing.Point(642, 158)
        Me.Btn_SendScan.Margin = New System.Windows.Forms.Padding(0)
        Me.Btn_SendScan.Name = "Btn_SendScan"
        Me.Btn_SendScan.Size = New System.Drawing.Size(60, 24)
        Me.Btn_SendScan.TabIndex = 479
        Me.Btn_SendScan.Text = "SEND"
        Me.Btn_SendScan.UseVisualStyleBackColor = False
        '
        'btUpdNote
        '
        Me.btUpdNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btUpdNote.BackColor = System.Drawing.Color.White
        Me.btUpdNote.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btUpdNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(254, Byte))
        Me.btUpdNote.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btUpdNote.Location = New System.Drawing.Point(597, 79)
        Me.btUpdNote.Name = "btUpdNote"
        Me.btUpdNote.Size = New System.Drawing.Size(98, 22)
        Me.btUpdNote.TabIndex = 488
        Me.btUpdNote.Text = "UPDATE NOTE"
        Me.btUpdNote.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Yellow
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(364, 300)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 14)
        Me.Label6.TabIndex = 505
        Me.Label6.Text = "Mc Name:"
        '
        'McName
        '
        Me.McName.BackColor = System.Drawing.SystemColors.Window
        Me.McName.Location = New System.Drawing.Point(440, 296)
        Me.McName.Name = "McName"
        Me.McName.ReadOnly = True
        Me.McName.Size = New System.Drawing.Size(134, 20)
        Me.McName.TabIndex = 504
        Me.McName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'McID
        '
        Me.McID.BackColor = System.Drawing.SystemColors.Window
        Me.McID.Location = New System.Drawing.Point(440, 257)
        Me.McID.Name = "McID"
        Me.McID.ReadOnly = True
        Me.McID.Size = New System.Drawing.Size(134, 20)
        Me.McID.TabIndex = 499
        Me.McID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FeederID
        '
        Me.FeederID.BackColor = System.Drawing.SystemColors.Window
        Me.FeederID.Location = New System.Drawing.Point(212, 258)
        Me.FeederID.Name = "FeederID"
        Me.FeederID.ReadOnly = True
        Me.FeederID.Size = New System.Drawing.Size(134, 20)
        Me.FeederID.TabIndex = 498
        Me.FeederID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FeederType
        '
        Me.FeederType.BackColor = System.Drawing.SystemColors.Window
        Me.FeederType.Location = New System.Drawing.Point(212, 296)
        Me.FeederType.Name = "FeederType"
        Me.FeederType.ReadOnly = True
        Me.FeederType.Size = New System.Drawing.Size(134, 20)
        Me.FeederType.TabIndex = 497
        Me.FeederType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FeederSH
        '
        Me.FeederSH.AutoSize = True
        Me.FeederSH.BackColor = System.Drawing.Color.Yellow
        Me.FeederSH.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FeederSH.ForeColor = System.Drawing.Color.Red
        Me.FeederSH.Location = New System.Drawing.Point(261, 201)
        Me.FeederSH.Name = "FeederSH"
        Me.FeederSH.Size = New System.Drawing.Size(96, 24)
        Me.FeederSH.TabIndex = 503
        Me.FeederSH.Text = "Feeder#"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Yellow
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(381, 262)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 14)
        Me.Label5.TabIndex = 502
        Me.Label5.Text = "Mc ID:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Yellow
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(122, 262)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 14)
        Me.Label4.TabIndex = 501
        Me.Label4.Text = "Feeder_ID:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Yellow
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(110, 300)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 14)
        Me.Label3.TabIndex = 500
        Me.Label3.Text = "Feeder_Type:"
        '
        'lbCt_InvState
        '
        Me.lbCt_InvState.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbCt_InvState.AutoEllipsis = True
        Me.lbCt_InvState.BackColor = System.Drawing.Color.Yellow
        Me.lbCt_InvState.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCt_InvState.ForeColor = System.Drawing.Color.Black
        Me.lbCt_InvState.Location = New System.Drawing.Point(138, 352)
        Me.lbCt_InvState.Name = "lbCt_InvState"
        Me.lbCt_InvState.Size = New System.Drawing.Size(208, 22)
        Me.lbCt_InvState.TabIndex = 491
        Me.lbCt_InvState.Text = "Report Issue (Optional)"
        Me.lbCt_InvState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Yellow
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(151, 431)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 14)
        Me.Label1.TabIndex = 494
        Me.Label1.Text = "Other:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Yellow
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(150, 390)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 14)
        Me.Label2.TabIndex = 493
        Me.Label2.Text = "Issue :"
        '
        'btCt_Save
        '
        Me.btCt_Save.BackColor = System.Drawing.Color.LightGreen
        Me.btCt_Save.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btCt_Save.Location = New System.Drawing.Point(451, 383)
        Me.btCt_Save.Name = "btCt_Save"
        Me.btCt_Save.Size = New System.Drawing.Size(114, 28)
        Me.btCt_Save.TabIndex = 506
        Me.btCt_Save.Text = "SAVE Feeder"
        Me.btCt_Save.UseVisualStyleBackColor = False
        '
        'IssueBox
        '
        Me.IssueBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.IssueBox.FormattingEnabled = True
        Me.IssueBox.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.IssueBox.Items.AddRange(New Object() {"Error1", "Error2", "Error3"})
        Me.IssueBox.Location = New System.Drawing.Point(212, 388)
        Me.IssueBox.Name = "IssueBox"
        Me.IssueBox.Size = New System.Drawing.Size(134, 21)
        Me.IssueBox.TabIndex = 507
        '
        'IssueText
        '
        Me.IssueText.Location = New System.Drawing.Point(212, 429)
        Me.IssueText.Name = "IssueText"
        Me.IssueText.Size = New System.Drawing.Size(134, 20)
        Me.IssueText.TabIndex = 508
        '
        'btCtsend
        '
        Me.btCtsend.BackColor = System.Drawing.Color.Salmon
        Me.btCtsend.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btCtsend.Location = New System.Drawing.Point(451, 421)
        Me.btCtsend.Name = "btCtsend"
        Me.btCtsend.Size = New System.Drawing.Size(114, 28)
        Me.btCtsend.TabIndex = 509
        Me.btCtsend.Text = "Send Massage"
        Me.btCtsend.UseVisualStyleBackColor = False
        '
        'lbLoading
        '
        Me.lbLoading.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbLoading.AutoSize = True
        Me.lbLoading.BackColor = System.Drawing.Color.Yellow
        Me.lbLoading.Font = New System.Drawing.Font("Tahoma", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lbLoading.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbLoading.Location = New System.Drawing.Point(261, 81)
        Me.lbLoading.Name = "lbLoading"
        Me.lbLoading.Size = New System.Drawing.Size(163, 19)
        Me.lbLoading.TabIndex = 462
        Me.lbLoading.Text = ". . . L o a d i n g . . ."
        Me.lbLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbLoading.Visible = False
        '
        'Main_Form
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(701, 510)
        Me.Controls.Add(Me.btCtsend)
        Me.Controls.Add(Me.IssueText)
        Me.Controls.Add(Me.IssueBox)
        Me.Controls.Add(Me.btCt_Save)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.McName)
        Me.Controls.Add(Me.McID)
        Me.Controls.Add(Me.FeederID)
        Me.Controls.Add(Me.FeederType)
        Me.Controls.Add(Me.FeederSH)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbCt_InvState)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btUpdNote)
        Me.Controls.Add(Me.Btn_SendScan)
        Me.Controls.Add(Me.Txt_Scanner)
        Me.Controls.Add(Me.Lab_Scan)
        Me.Controls.Add(Me.Lab_AlertMsg)
        Me.Controls.Add(Me.Grb_MSSuser)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lbLoading)
        Me.Controls.Add(Me.Pix_MSS)
        Me.Controls.Add(Me.Pix_Hana)
        Me.Controls.Add(Me.Lab_MainTitle)
        Me.Controls.Add(Me.lbHStaName)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "Main_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main_Form"
        CType(Me.Pix_MSS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pix_Hana, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grb_MSSuser.ResumeLayout(False)
        Me.Grb_MSSuser.PerformLayout()
        Me.Pan_Tmr.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TmrGlobalWarn As Timers.Timer
    Friend WithEvents bgwGlobalWarn As System.ComponentModel.BackgroundWorker
    Friend WithEvents lbGlobalWarn As Label
    Friend WithEvents Pix_MSS As PictureBox
    Friend WithEvents Pix_Hana As PictureBox
    Friend WithEvents Lab_MainTitle As Label
    Friend WithEvents lbHStaName As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Grb_MSSuser As GroupBox
    Friend WithEvents Pan_Tmr As Panel
    Friend WithEvents Pan_Tmr1 As RadioButton
    Friend WithEvents Pan_Tmr2 As RadioButton
    Public WithEvents Lab_AlertMsg As Label
    Friend WithEvents Lab_Scan As Label
    Friend WithEvents Txt_Scanner As TextBox
    Friend WithEvents Btn_SendScan As Button
    Friend WithEvents btnLogInOut As Button
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents UsernameLabel As Label
    Friend WithEvents btUpdNote As Button
    Friend WithEvents Tpg_CtnLabel As TabPage
    Friend WithEvents Tpg_PltLabel As TabPage
    Friend WithEvents bgwMain As System.ComponentModel.BackgroundWorker
    Friend WithEvents btPl_Refresh As Button
    Friend WithEvents btPl_Cancel As Button
    Friend WithEvents ChkU_Reprn As CheckBox
    Friend WithEvents ChkU_PalSetup As CheckBox
    Friend WithEvents ChkU_ForceCls As CheckBox
    Friend WithEvents numCt_BoxAmt As NumericUpDown
    Friend WithEvents Tmr_1Sec As Timer
    Friend WithEvents tsSlb_LastScan As ToolStripStatusLabel
    Friend WithEvents Tmr_Scan As Timers.Timer
    Friend WithEvents Label6 As Label
    Friend WithEvents McName As TextBox
    Friend WithEvents McID As TextBox
    Friend WithEvents FeederID As TextBox
    Friend WithEvents FeederType As TextBox
    Friend WithEvents FeederSH As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lbCt_InvState As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btCt_Save As Button
    Friend WithEvents IssueText As TextBox
    Friend WithEvents btCtsend As Button
    Friend WithEvents IssueBox As ComboBox
    Friend WithEvents lbLoading As Label
End Class
