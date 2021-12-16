Public Class ReporteSorteo
    Private Sub ReporteSorteo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'LoteriaDataSet.Reporte_Sorteo' Puede moverla o quitarla según sea necesario.
        Me.Reporte_SorteoTableAdapter.Fill(Me.LoteriaDataSet.Reporte_Sorteo)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class