Imports System.Data.SqlClient
Public Class ClsConexion 'establece la conexión con bd.
    Protected CNN As New SqlConnection 'Representa una conexión a una base de datos SQL Server que va a usar el string de conexión strConexión.
    Const strConexion As String = "Data Source=DESKTOP-0836GCF;User ID=sa;Password=qwer*1234;Initial Catalog=Loteria;Integrated Security=True"
    'Data source, va lo que aparece en autenticación, si es true ingreso con windows autentication si es false es con sqlautentication.
    Protected Function funcConectarDB() As Boolean
        Try
            CNN = New SqlConnection(strConexion)
            CNN.Open() 'Abrimos la conexión.
            Return True
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de establecer la conexión con la base de datos." & Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Protected Function funcCerrarConnDB() As Boolean
        Try
            If CNN.State = ConnectionState.Open Then
                CNN.Close()
                Return True
            ElseIf CNN.State = ConnectionState.Closed Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de cerrar la conexión con la base de datos." & Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End Try
    End Function
End Class
