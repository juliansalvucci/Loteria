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
                dts.pLogin = txtLogin.Text
                dts.pPassword = txtPassword.Text
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



    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If btnModificar.Text = "Cancelar" Then
            modopantalla = ModoPantalla.ModoCONSULTA
            inicia_pantalla()
            btnAgregar.Text = "Agregar"
            btnModificar.Text = "Modificar"
            btnCerrar.Enabled = True
            dataUsuario.Enabled = True
            ErrProvUsuario.SetError(txtNombre, "")
        Else
            modopantalla = ModoPantalla.ModoMODIFICACION
            HabilitarTextos(Me)
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            btnCerrar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            dataUsuario.Enabled = False
            btnAgregar.Text = "Confirmar"
            btnModificar.Text = "Cancelar"
            txtNombre.Focus()
        End If
    End Sub

    Private Sub dataUsuario_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataUsuario.CellContentClick
        txtID.Text = dataUsuario.SelectedCells.Item(0).Value
        txtNombre.Text = dataUsuario.SelectedCells.Item(1).Value
        txtLogin.Text = dataUsuario.SelectedCells.Item(2).Value
        txtPassword.Text = dataUsuario.SelectedCells.Item(3).Value
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Respuesta As Integer = MessageBox.Show("Atención: ha seleccionado eliminar un usuario. " & Environment.NewLine & "¿Confirma la eliminación?", "Eliminación de usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If Respuesta = MsgBoxResult.Yes Then
            Try
                Dim dts As New logUsuario
                Dim FuncionInsertar As New fUsuario
                dts.pID = txtID.Text
                If FuncionInsertar.Eliminar_Usuario(dts) Then
                    mostrar_datos()
                    LimpiarTextos(Me)
                    inicia_pantalla()
                Else
                    MessageBox.Show("El usuario no se ha eliminado. Vuelva a intentarlo.",
                    "Eliminar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Atención: se ha generado un error tratando de eliminar el usuario." & Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class