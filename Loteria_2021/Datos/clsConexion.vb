'Importamos la funcionalidad del espacio de nombres SqlCLient.
'El espacio de nombres System.Data.SqlClient es el proveedor de datos .NET Framework para SQL Server.
'El proveedor de datos .NET Framework para SQL Server describe una colección de clases que se utiliza para obtener acceso a una base de datos de SQL Server en el espacio administrado. Al utilizar SqlDataAdapter, se puede rellenar un objeto DataSet residente en memoria, que sirve para consultar y actualizar la base de datos.

Imports System.Data.SqlClient

Public Class clsConexion
    Protected CNN As New SqlConnection 'Representa una conexión a una base de datos SQL Server.
    Dim strConexion As String = "Data Source=DESKTOP-0836GCF;User ID=sa;Password=qwer*1234;Initial Catalog=Loteria;Integrated Security=True"
    '"Data Source=OBELIX-NB3\SQLExpress;User ID=sa;Password=qwer*1234;Initial Catalog=Loteria;Integrated Security=False"
    Protected Function funcConectarDB() As Boolean
        '**************************************************************************************************************************************************************
        '* Función que establece la conexión con la base de datos.                                                                                                    *
        '* Al conectarse devuelve VERDADERO. Si no se conecta, devuelve FALSO.                                                                                        *
        '*                                                                                                                                                            *
        '* Protected especifica que sólo se puede obtener acceso a uno o varios elementos de programación declarados desde su propia clase o desde una clase derivada.*
        '**************************************************************************************************************************************************************
        Try
            CNN = New SqlConnection(strConexion)
            CNN.Open() 'Abrimos la conexión.
            Return True
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de establecer la conexión con la base de datos." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Protected Function funcCerrarConnDB() As Boolean
        '*****************************************************************************************************************************************
        '* Función que cierra la conexión con la base de datos.                                                                                  *
        '* Al cerrar devuelve VERDADERO. Si no se cierra, devuelve FALSO.                                                                        *
        '*****************************************************************************************************************************************
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
            MessageBox.Show("Atención: se ha generado un error tratando de cerrar la conexión con la base de datos." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class
