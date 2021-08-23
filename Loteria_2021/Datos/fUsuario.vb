Imports System.Data.SqlClient
Public Class fUsuario
    Inherits clsConexion
    Dim cmd As SqlCommand
    Public Function Validar_Usuario(dts As logUsuario) As Boolean
        Try
            funcConectarDB()
            cmd = New SqlCommand("Validar_Usuario")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = CNN
            cmd.Parameters.AddWithValue("@Login", dts.pLogin)
            cmd.Parameters.AddWithValue("@Password", dts.pPassword)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de validar los datos del usuario." & Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            funcCerrarConnDB()
        End Try
    End Function

    Public Function Consultar_Usuario() As DataTable 'tipodatatable, crea en memoria una tabla cargada con info que genera desde el comando que ejecutemos'

        'Función que cargará en memoria la tabla TipoSorteo

        Try
            funcConectarDB()  'abrir conexión con base de datos'
            cmd = New SqlCommand("procMostrar_Usuarios") 'procedimiento almacenado que consulta y muestra los tipos de sorteos y los ordena por nombre, se llama procMostrar_TipoSorteo' 
            cmd.CommandType = CommandType.StoredProcedure 'string que contiene el comando de la base de datos'

            cmd.Connection = CNN

            If cmd.ExecuteNonQuery Then 'ejecuta comando en base de datos, devuelve true o false'

                Dim dt As New DataTable   'la conexión se abre'
                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                Return dt

            Else

                Return Nothing

            End If

        Catch ex As Exception 'error y detalle de error'

            MessageBox.Show("Atención: se ha generado un error tratando de mostrar los usuarios." & Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing
        Finally

            funcCerrarConnDB() 'la conexión se cierra y el finally permite que se cierre haya ocurrido un error o no'

        End Try
    End Function

    Public Function Alta_Usuario(ByVal dts As logUsuario) As Boolean
        'La función retornará VERDADERO si se inserta ok el registro.
        'Sino, devolverá FALSO.
        Try
            funcConectarDB()
            cmd = New SqlCommand("INSERTAR_Usuarios")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = CNN
            cmd.Parameters.AddWithValue("@NombreUsu", dts.pNombreUsu)
            cmd.Parameters.AddWithValue("@Login", dts.pLogin)
            cmd.Parameters.AddWithValue("@Password", dts.pPassword)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de registrar el usuario." & Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            funcCerrarConnDB()
        End Try
    End Function

    Public Function Modificar_Usuario(ByVal dts As logUsuario) As Boolean
        'La función retornará VERDADERO si se actualiza ok el registro.
        'Sino, devolverá FALSO.
        Try
            funcConectarDB()
            cmd = New SqlCommand("EDITAR_Usuarios")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = CNN
            cmd.Parameters.AddWithValue("@NombreUsu", dts.pNombreUsu)
            cmd.Parameters.AddWithValue("@Login", dts.pLogin)
            cmd.Parameters.AddWithValue("@Password", dts.pPassword)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de registrar el usuario." & Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            funcCerrarConnDB()
        End Try
    End Function

    Public Function Baja_Usuario(ByVal dts As logUsuario) As Boolean
        'La función retornará VERDADERO si se elimina ok el registro.
        'Sino, devolverá FALSO.
        Try
            funcConectarDB()
            cmd = New SqlCommand("ELIMINAR_Usuarios")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = CNN
            cmd.Parameters.AddWithValue("@ID", dts.pID)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de eliminar el usuario." & Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            funcCerrarConnDB()
        End Try
    End Function

End Class
