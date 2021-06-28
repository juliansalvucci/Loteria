Imports System.Data.SqlClient

Public Class fTipoSorteo
    Inherits ClsConexion 'La clase o interfaz actual hereda los atributos, variables, propiedades,procedimientos y eventos de otra clase o conjunto de interfaces.
    Dim cmd As SqlCommand 'variable que permite ejecutar instrucciones de la base de datos'

    Public Function Mostrar_TipoSorteo() As DataTable 'tipodatatable, crea en memoria una tabla cargada con info que genera desde el comando que ejecutemos'

        'Función que cargará en memoria la tabla TipoSorteo

        Try
            funcConectarDB()  'abrir conexión con base de datos'
            cmd = New SqlCommand("procMostrar_TipoSorteo") 'procedimiento almacenado que consulta y muestra los tipos de sorteos y los ordena por nombre, se llama procMostrar_TipoSorteo' 
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

            MessageBox.Show("Atención: se ha generado un error tratando de mostrar los tipos de sorteo." & Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing
        Finally

            funcCerrarConnDB() 'la conexión se cierra y el finally permite que se cierre haya ocurrido un error o no'

        End Try
    End Function

    Public Function Insertar_TipoSorteo(ByVal dts As logTipoSorteo) As Boolean
        'La función retornará VERDADERO si se inserta ok el registro.
        'Sino, devolverá FALSO.
        Try
            funcConectarDB()
            cmd = New SqlCommand("Insertar_TipoSorteo")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = CNN
            cmd.Parameters.AddWithValue("@Nombre", dts.pNombre)
            cmd.Parameters.AddWithValue("@Descripcion", dts.pDescripcion)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de registrar el tipo de sorteo." & Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            funcCerrarConnDB()
        End Try
    End Function

    Public Function Modificar_TipoSorteo(ByVal dts As logTipoSorteo) As Boolean
        'La función retornará VERDADERO si se actualiza ok el registro.
        'Sino, devolverá FALSO.
        Try
            funcConectarDB()
            cmd = New SqlCommand("EDITAR_TipoSorteo")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = CNN
            cmd.Parameters.AddWithValue("@ID", dts.pID)
            cmd.Parameters.AddWithValue("@Nombre", dts.pNombre)
            cmd.Parameters.AddWithValue("@Descripcion", dts.pDescripcion)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de registrar el tipo de sorteo." & Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            funcCerrarConnDB()
        End Try
    End Function

    Public Function Eliminar_TipoSorteo(ByVal dts As logTipoSorteo) As Boolean
        'La función retornará VERDADERO si se elimina ok el registro.
        'Sino, devolverá FALSO.
        Try
            funcConectarDB()
            cmd = New SqlCommand("ELIMINAR_TipoSorteo")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = CNN
            cmd.Parameters.AddWithValue("@ID", dts.pID)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de eliminar el tipo de sorteo." & Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            funcCerrarConnDB()
        End Try
    End Function


End Class
