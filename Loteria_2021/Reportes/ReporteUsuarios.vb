Public Class ReporteUsuarios
    Private Sub ReporteUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'LoteriaDataSet.obtener_usuarios' Puede moverla o quitarla según sea necesario.
        Me.obtener_usuariosTableAdapter.Fill(Me.LoteriaDataSet.obtener_usuarios)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class