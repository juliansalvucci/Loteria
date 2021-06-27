Public Class frmPrincipal
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmTipoSorteo.MdiParent = Me
        frmTipoSorteo.Show()
    End Sub
End Class