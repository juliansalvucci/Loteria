Public Class ReporteApuesta
    Private Sub ReporteApuesta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'LoteriaDataSetLote.Reporte_Apuesta' Puede moverla o quitarla según sea necesario.
        Me.Reporte_ApuestaTableAdapter.Fill(Me.LoteriaDataSetLote.Reporte_Apuesta)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class