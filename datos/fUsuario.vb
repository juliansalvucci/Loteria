Imports System.Data.SqlClient
Public Class fUsuario
    Inherits ClsConexion
    Dim cmd As SqlCommand
    Public Function Validar_Usuario(dts As logUsuario) As Boolean
        Try
            funcConectarDB()
            cmd = New SqlCommand("Validar_Usuario")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = CNN
            cmd.Parameters.AddWithValue("@Login", dts.pLogin)
            cmd.Parameters.AddWithValue("@Passw", dts.pPassword)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de validar los datos del
 usuario." & Environment.NewLine & "Descripción del error: " & Environment.NewLine &
            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            funcCerrarConnDB()
        End Try
    End Function
End Class
