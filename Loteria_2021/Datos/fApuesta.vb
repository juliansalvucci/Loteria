Imports System.Data.SqlClient
Public Class fApuesta
    Inherits clsConexion 'La clase o interfaz actual hereda los atributos, variables, propiedades, procedimientos y eventos de otra clase o conjunto de interfaces.
    Dim cmd As SqlCommand 'nos da interfaces, atributos, procedimientos, variables, propiedades, todos los eventos que necesitamos para establecer la conexion con una base de datos de tipo sql server'

    Public Function Mostrar_Apuesta() As DataTable
        'Función que cargará en memoria la tabla TipoSorteo
        Try
            funcConectarDB()
            cmd = New SqlCommand("procMostrar_Apuesta") 'se hace una unueva instancia de cmd y ejecuta el comando ("procMostrar_Apuesta") en la base de datos'
            'tambien podria poner SELECT * FROM Apuesta ORDER BY ID'
            cmd.CommandType = CommandType.StoredProcedure 'le indico que va ejecutar un procedimiento almacenado'

            cmd.Connection = CNN 'le indico cual es la conexion activa a la base de datos'

            If cmd.ExecuteNonQuery Then 'ejecuta el comando antes definido'
                Dim dt As New DataTable 'representa una tabla de datos relaciones en memoria'
                Dim da As New SqlDataAdapter(cmd) 'representa un conjunto de comandos de datos y una conexion a una base de datos que se usan para rellenar DataSet y actualizar una DB de SQL Server'

                da.Fill(dt)

                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de mostrar las Apuestas." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            funcCerrarConnDB()
        End Try
    End Function

    Public Function Insertar_Apuesta(ByVal dts As logApuesta) As Boolean
        'La función retornará VERDADERO si se inserta ok el registro.
        'Sino, devolverá FALSO.

        Try
            funcConectarDB()
            cmd = New SqlCommand("Insertar_Apuesta") 'seto el comando de sql y tiene que ejecutar un objeto en la DB "Insertar_Apuesta"
            cmd.CommandType = CommandType.StoredProcedure 'ese objeto almacenado en la base de datos es de tipo StoredProcedure
            cmd.Connection = CNN ' y la informacion para abrir la conexion esta en la variable CNN que es una variable SqlConnection

            'el procedimiento almacenado tiene 2 parametro por lo tanto se deben indicar 
            'tomando eso valor de las propiedades creadas en la funcion logica 
            cmd.Parameters.AddWithValue("@Numero", dts.pNumero)

            'DEBO ALMACENAR EL MONTO, PERO TENGO QUE EXTRAERLO DESDE EL COMBOBOX
            cmd.Parameters.AddWithValue("@Monto", dts.pMonto)
            cmd.Parameters.AddWithValue("@Agencia", dts.pAgencia)
            cmd.Parameters.AddWithValue("@Sorteo", dts.pSorteo)


            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de registrar la Apuesta." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            funcCerrarConnDB()
        End Try
    End Function

    Public Function Modificar_Apuesta(ByVal dts As logApuesta) As Boolean
        'La función retornará VERDADERO si se actualiza ok el registro.
        'Sino, devolverá FALSO.

        Try
            funcConectarDB()
            cmd = New SqlCommand("EDITAR_Apuesta")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = CNN

            cmd.Parameters.AddWithValue("@ID", dts.pID)
            cmd.Parameters.AddWithValue("@Numero", dts.pNumero)
            cmd.Parameters.AddWithValue("@Monto", dts.pMonto)
            cmd.Parameters.AddWithValue("@Agencia", dts.pAgencia)
            cmd.Parameters.AddWithValue("@Sorteo", dts.pSorteo)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de registrar la Apuesta." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            funcCerrarConnDB()
        End Try
    End Function

    Public Function Eliminar_Apuesta(ByVal dts As logApuesta) As Boolean
        'La función retornará VERDADERO si se elimina ok el registro.
        'Sino, devolverá FALSO.
        Try
            funcConectarDB()
            cmd = New SqlCommand("ELIMINAR_Apuesta")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = CNN
            cmd.Parameters.AddWithValue("@ID", dts.pID)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de eliminar la Apuesta" &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            funcCerrarConnDB()
        End Try
    End Function

    Public Function Mostrar_ReporteApuesta() As DataTable
        'Función que cargará en memoria la tabla TipoSorteo
        Try
            funcConectarDB()
            cmd = New SqlCommand("procMostrarReporte_Apuesta") 'se hace una unueva instancia de cmd y ejecuta el comando ("procMostrar_Apuesta") en la base de datos'
            'tambien podria poner SELECT * FROM Apuesta ORDER BY ID'
            cmd.CommandType = CommandType.StoredProcedure 'le indico que va ejecutar un procedimiento almacenado'

            cmd.Connection = CNN 'le indico cual es la conexion activa a la base de datos'

            If cmd.ExecuteNonQuery Then 'ejecuta el comando antes definido'
                Dim dt As New DataTable 'representa una tabla de datos relaciones en memoria'
                Dim da As New SqlDataAdapter(cmd) 'representa un conjunto de comandos de datos y una conexion a una base de datos que se usan para rellenar DataSet y actualizar una DB de SQL Server'

                da.Fill(dt)

                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de mostrar el Reporte de Apuestas." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            funcCerrarConnDB()
        End Try
    End Function
End Class
