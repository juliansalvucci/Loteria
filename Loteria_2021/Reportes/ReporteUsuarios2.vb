Public Class ReporteUsuarios2
    Private Sub ReporteUsuarios2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'LoteriaDataSetLote.Mostrar_Usuarios_Deshabilitados' Puede moverla o quitarla según sea necesario.
        Me.Mostrar_Usuarios_DeshabilitadosTableAdapter.Fill(Me.LoteriaDataSetLote.Mostrar_Usuarios_Deshabilitados)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class