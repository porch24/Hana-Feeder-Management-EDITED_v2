Public Class frmUpdate
    Private Sub UpdateLog_Form_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        ButtonC.Focus()
    End Sub


    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles ButtonC.Click
        Me.Dispose()
    End Sub

    Private Sub frmUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUdtNote.Text = My.Resources.UpdateNote
    End Sub
End Class