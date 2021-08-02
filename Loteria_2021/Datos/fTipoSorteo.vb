Imports System.Data.SqlClient

Public Class fTipoSorteo
    Inherits clsConexion 'La clase o interfaz actual herede los atributos, variables, propiedades, procedimientos y eventos de otra clase o conjunto de interfaces.
    Dim cmd As SqlCommand 'Variable que representa un procedimiento almacenado o para ejecutar comandos o consultas en la base de datos.

    Public Function Mostrar_TipoSorteo() As DataTable
        'Función que cargará en memoria la tabla TipoSorteo

        Try
            funcConectarDB()
            cmd = New SqlCommand("procMostrar_TipoSorteo")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = CNN

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                Return dt

                'SqlDataAdapter: representa un conjunto de comandos de datos y una conexión de base de datos que se utilizan 
                'para rellenar un DataSet o DataTable y actualizar una base de datos de SQL Server
                'Se utiliza como un puente entre DataSet y SQL Server para recuperar y guardar datos.
                'SqlDataAdapter proporciona este puente mediante la asignación de Fill, que cambia los datos en DataSet para que 
                'coincidan con los datos del origen de datos; 
                'y Update, que cambia los datos en el origen de datos para que coincidan con los datos en DataSet utilizando 
                'las instrucciones de Transact-SQL en el origen de datos adecuado. 
                'SqlDataAdapter se utiliza junto con SqlConnection y SqlCommand para aumentar el rendimiento en la conexión 
                'con una base de datos de SQL Server.
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de mostrar los tipos de sorteo." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            funcCerrarConnDB()
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
            MessageBox.Show("Atención: se ha generado un error tratando de registrar el tipo de sorteo." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show("Atención: se ha generado un error tratando de registrar el tipo de sorteo." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show("Atención: se ha generado un error tratando de eliminar el tipo de sorteo." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            funcCerrarConnDB()
        End Try
    End Function
End Class
