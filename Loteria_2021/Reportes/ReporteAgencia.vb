Public Class ReporteAgencia
    Private Sub ReporteAgencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'LoteriaDataSetAgencia.Reporte_Agencia' Puede moverla o quitarla según sea necesario.
        Me.Reporte_AgenciaTableAdapter.Fill(Me.LoteriaDataSetAgencia.Reporte_Agencia)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class