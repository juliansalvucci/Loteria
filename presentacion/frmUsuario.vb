Public Class frmUsuario
    'Ctrl-K Ctrl-C comentario multilínea
    'Ctrl-K Ctrl-U decomentar

    Private dt As New DataTable
    Dim modopantalla As ModoPantalla

    Private Sub mostrar_datos()
        Try
            Dim funcionmostrar As New fUsuario
            dt = funcionmostrar.mostrar_usuario
            If dt.Rows.Count <> 0 Then
                datausuario.datasource = dt
            Else
                datausuario.datasource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("atención: se ha generado un error tratando de mostrar los usuarios." & Environment.NewLine & "descripción del error: " & Environment.NewLine & ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub inicia_pantalla()
        DeshabilitarTextos(Me)
        DeshabilitarCombos(Me)
        If dt.Rows.Count = 0 Then
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            btnAgregar.Focus()
        Else
            btnModificar.Enabled = True
            btnEliminar.Enabled = True
            btnBuscar.Enabled = True
            cboBuscar.Enabled = True : cboBuscar.SelectedIndex = 1
            txtBuscar.Enabled = True
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub buscar_datos()
        Try
            Dim ds As New DataSet 'representa una memoria caché de datos en memoria.
            ds.Tables.Add(dt.Copy) 'se realiza una copia de la tabla en memoria.
            Dim dv As New DataView(ds.Tables(0))
            If cboBuscar.SelectedItem = "nombre" Then
                dv.RowFilter = cboBuscar.Text & " like '%" & txtBuscar.Text & "%'"
            Else
                dv.RowFilter = cboBuscar.Text & " = " & txtBuscar.Text
            End If
            If dv.Count <> 0 Then
                datausuario.datasource = dv
            Else
                datausuario.datasource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("atención: se ha generado un error tratando de buscar los usuarios" & Environment.NewLine & "descripción del error: " & Environment.NewLine & ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmusuario_load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar_datos()
        inicia_pantalla()
    End Sub

    Private Sub btnbuscar_click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        buscar_datos()
    End Sub

    Private Sub btncerrar_click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnagregar_click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If btnAgregar.Text = "agregar" Then
            LimpiarTextos(Me)
            HabilitarTextos(Me)
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            btnCerrar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            dataUsuario.Enabled = False
            'el botón agregar pasa a ser confirmar.
            'el botón modificar pasa a ser cancelar.
            btnAgregar.Text = "confirmar"
            btnModificar.Text = "cancelar"
            txtnombre.focus()
        Else

            'validamos los controles.
            If txtnombre.text = "" Then
                errprovusuario.seterror(txtNombre, "debe ingresar un nombre para el usuario")
                txtNombre.focus()
                Exit Sub
            Else
                errprovusuario.seterror(txtNombre, "")
            End If
            Try
                Dim dts As New logUsuario
                Dim funcioninsertar As New fUsuario
                dts.pNombreUsu = txtNombre.Text
                'AGREGAR EL RESTO
                If funcioninsertar.Insertar_Usuario(dts) Then
                    mostrar_datos()
                    LimpiarTextos(Me)
                    inicia_pantalla()
                Else
                    MessageBox.Show("el usuario no esta registrado. vuelva a intentarlo.", "confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("atención: se ha generado un error tratando de registrar el usuario." & Environment.NewLine & "descripción del error: " & Environment.NewLine &
                ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class