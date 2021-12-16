Public Class ReporteSorteoFuncional
    Private Sub ReporteSorteoFuncional_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar_datos()
    End Sub
    Private dt As New DataTable
    Private Sub Mostrar_Datos()
        Try
            Dim FuncionMostrar As New fSorteo
            dt = FuncionMostrar.Mostrar_Reporte_Sorteo

            If dt.Rows.Count <> 0 Then
                dataSorteo.DataSource = dt
            Else
                dataSorteo.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de mostrar los tipos de 
            sorteo." & Environment.NewLine & "Descripción del error: " & Environment.NewLine &
            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class