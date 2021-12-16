Imports System.Data.SqlClient
Public Class fSorteo
    Inherits clsConexion 'La clase o interfaz actual hereda los atributos, variables, propiedades, procedimientos y eventos de otra clase o conjunto de interfaces.
    Dim cmd As SqlCommand 'nos da interfaces, atributos, procedimientos, variables, propiedades, todos los eventos que necesitamos para establecer la conexion con una base de datos de tipo sql server'

    Public Function Mostrar_Sorteo() As DataTable
        'Función que cargará en memoria la tabla Sorteo'
        Try
            funcConectarDB()
            cmd = New SqlCommand("procMostrar_Sorteo") 'Se hace una unueva instancia de cmd y ejecuta el comando ("procMostrar_Sorteo") en la base de datos'
            'tambien podria poner SELECT ID,NOMBRE,DESCRIPCION FROM TIPOSORTEO ORDER BY NOMBRE'
            cmd.CommandType = CommandType.StoredProcedure 'Se inica que se va ejecutar un procedimiento almacenado'

            cmd.Connection = CNN 'Se indica cual es la conexion activa a la base de datos'

            If cmd.ExecuteNonQuery Then 'ejecuta el comando antes definido'
                Dim dt As New DataTable 'Representa una tabla de datos relaciones en memoria'
                Dim da As New SqlDataAdapter(cmd) 'Representa un conjunto de comandos de datos y una conexion a una base de datos que se usan para rellenar DataSet y actualizar una DB de SQL Server'

                da.Fill(dt)

                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de mostrar los sorteos." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            funcCerrarConnDB()
        End Try
    End Function

    Public Function Insertar_Sorteo(ByVal dts As logSorteo) As Boolean
        'La función retornará VERDADERO si se inserta ok el registro.
        'Sino, devolverá FALSO.

        Try
            funcConectarDB()
            cmd = New SqlCommand("INSERTAR_Sorteo") 'Se setea el comando de sql y tiene que ejecutar un objeto en la DB "Insertar_TipoSorteo"
            cmd.CommandType = CommandType.StoredProcedure 'Ese objeto almacenado en la base de datos es de tipo StoredProcedure
            cmd.Connection = CNN ' La informacion para abrir la conexion esta en la variable CNN que es una variable SqlConnection

            'el procedimiento almacenado tiene 2 parametro por lo tanto se deben indicar 
            'tomando ese valor de las propiedades creadas en la funcion logica 
            cmd.Parameters.AddWithValue("@Fecha", DateTime.Today)
            cmd.Parameters.AddWithValue("@IDTipoSorteo", dts.pIDTipoSorteo)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de registrar el sorteo." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            funcCerrarConnDB()
        End Try
    End Function

    Public Function Modificar_Sorteo(ByVal dts As logSorteo) As Boolean
        'La función retornará VERDADERO si se actualiza ok el registro.
        'Sino, devolverá FALSO.

        Try
            funcConectarDB()
            cmd = New SqlCommand("EDITAR_Sorteo")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = CNN

            cmd.Parameters.AddWithValue("@ID", dts.pID)
            cmd.Parameters.AddWithValue("@IDTipoSorteo", dts.pIDTipoSorteo)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de registrar el sorteo." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            funcCerrarConnDB()
        End Try
    End Function

    Public Function Eliminar_Sorteo(ByVal dts As logSorteo) As Boolean
        'La función retornará VERDADERO si se elimina ok el registro.
        'Sino, devolverá FALSO.
        Try
            funcConectarDB()
            cmd = New SqlCommand("ELIMINAR_Sorteo")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = CNN
            cmd.Parameters.AddWithValue("@ID", dts.pID)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de eliminar el sorteo." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            funcCerrarConnDB()
        End Try
    End Function

    Public Function Mostrar_Reporte_Sorteo() As DataTable
        'Función que cargará en memoria la tabla Sorteo'
        Try
            funcConectarDB()
            cmd = New SqlCommand("Reporte_Sorteo") 'Se hace una unueva instancia de cmd y ejecuta el comando ("procMostrar_Sorteo") en la base de datos'
            'tambien podria poner SELECT ID,NOMBRE,DESCRIPCION FROM TIPOSORTEO ORDER BY NOMBRE'
            cmd.CommandType = CommandType.StoredProcedure 'Se inica que se va ejecutar un procedimiento almacenado'

            cmd.Connection = CNN 'Se indica cual es la conexion activa a la base de datos'

            If cmd.ExecuteNonQuery Then 'ejecuta el comando antes definido'
                Dim dt As New DataTable 'Representa una tabla de datos relaciones en memoria'
                Dim da As New SqlDataAdapter(cmd) 'Representa un conjunto de comandos de datos y una conexion a una base de datos que se usan para rellenar DataSet y actualizar una DB de SQL Server'

                da.Fill(dt)

                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de mostrar los sorteos." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            funcCerrarConnDB()
        End Try
    End Function

End Class
