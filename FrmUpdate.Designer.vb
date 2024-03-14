<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUpdate
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
        Me.txtUdtNote = New System.Windows.Forms.TextBox()
        Me.ButtonC = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtUdtNote
        '
        Me.txtUdtNote.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUdtNote.BackColor = System.Drawing.SystemColors.Window
        Me.txtUdtNote.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtUdtNote.Location = New System.Drawing.Point(-3, -2)
        Me.txtUdtNote.Multiline = True
        Me.txtUdtNote.Name = "txtUdtNote"
        Me.txtUdtNote.ReadOnly = True
        Me.txtUdtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtUdtNote.Size = New System.Drawing.Size(550, 343)
        Me.txtUdtNote.TabIndex = 2
        Me.txtUdtNote.TabStop = False
        Me.txtUdtNote.Text = "UpdateNote.txt"
        '
        'ButtonC
        '
        Me.ButtonC.Location = New System.Drawing.Point(445, 308)
        Me.ButtonC.Name = "ButtonC"
        Me.ButtonC.Size = New System.Drawing.Size(75, 23)
        Me.ButtonC.TabIndex = 3
        Me.ButtonC.Text = "CLOSE"
        Me.ButtonC.UseVisualStyleBackColor = True
        '
        'frmUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 341)
        Me.Controls.Add(Me.ButtonC)
        Me.Controls.Add(Me.txtUdtNote)
        Me.Name = "frmUpdate"
        Me.Text = "FrmUpdate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtUdtNote As TextBox
    Friend WithEvents ButtonC As Button
End Class
