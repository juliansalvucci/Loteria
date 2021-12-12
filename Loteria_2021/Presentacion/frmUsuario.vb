Public Class frmUsuario

    'Ctrl-K Ctrl-C comentario multilínea
    'Ctrl-K Ctrl-U decomentar

    Private dt As New DataTable
    Dim modopantalla As ModoPantalla

    Private Sub mostrar_datos()
        Try
            Dim funcionmostrar As New fUsuario
            dt = funcionmostrar.Consultar_Usuario
            If dt.Rows.Count <> 0 Then
                dataUsuario.DataSource = dt
            Else
                dataUsuario.DataSource = Nothing
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
            btnAgregar.Enabled = True
            CheckHabilitado.Enabled = False
            btnAgregar.Focus()
        Else
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnBuscar.Enabled = True
            cboBuscar.Enabled = True : cboBuscar.SelectedIndex = 1
            txtBuscar.Enabled = True
            CheckHabilitado.Enabled = False
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub buscar_datos()
        Try
            Dim ds As New DataSet 'representa una memoria caché de datos en memoria.
            ds.Tables.Add(dt.Copy) 'se realiza una copia de la tabla en memoria.
            Dim dv As New DataView(ds.Tables(0))
            If cboBuscar.SelectedItem = "USUARIO" Then
                dv.RowFilter = cboBuscar.Text & " like '%" & txtBuscar.Text & "%'"
            ElseIf cboBuscar.SelectedItem = "LOGIN" Then
                dv.RowFilter = cboBuscar.Text & " like '%" & txtBuscar.Text & "%'"
            Else
                '--Si lo ingresado en la caja de texto es un numero entonces
                If IsNumeric(txtBuscar.Text) Then
                    '--Se realizara una busqueda por filtrando por el campo codigo en el campo codigo el mismo numero que txtBuscar.Text
                    dv.RowFilter = cboBuscar.Text & " = " & txtBuscar.Text
                End If
            End If
            If dv.Count <> 0 Then
                dataUsuario.DataSource = dv
            Else
                dataUsuario.DataSource = Nothing
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
        If btnAgregar.Text = "Agregar" Then

            modopantalla = modFuncionesForm.ModoPantalla.ModoALTA
            modFuncionesForm.LimpiarTextos(Me)
            modFuncionesForm.HabilitarTextos(Me)
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            btnCerrar.Enabled = False
            btnModificar.Enabled = True
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            txtID.Enabled = False
            txtID.Text = "0"
            dataUsuario.Enabled = False
            CheckHabilitado.Enabled = True
            CheckHabilitado.Checked = False
            'el botón agregar pasa a ser confirmar.
            'el botón modificar pasa a ser cancelar.
            btnAgregar.Text = "Confirmar"
            btnModificar.Text = "Cancelar"
            txtNombre.Focus()
        Else

            'validamos los controles.
            If txtNombre.Text = "" Then
                ErrProvUsuario.SetError(txtNombre, "debe ingresar un nombre para el usuario")
                txtNombre.Focus()
                Exit Sub
            Else
                errprovusuario.seterror(txtNombre, "")
            End If
            If txtLogin.Text = "" Then
                ErrProvUsuario.SetError(txtLogin, "debe ingresar un login para el usuario")
                txtLogin.Focus()
                Exit Sub
            Else
                ErrProvUsuario.SetError(txtLogin, "")
            End If
            If txtPassword.Text = "" Then
                ErrProvUsuario.SetError(txtPassword, "debe ingresar una contraseña para el usuario")
                txtPassword.Focus()
                Exit Sub
            Else
                ErrProvUsuario.SetError(txtPassword, "")
            End If
            If txtPassValidator.Text = "" Then
                ErrProvUsuario.SetError(txtPassValidator, "debe validar la contraseña para el usuario")
                txtPassValidator.Focus()
                Exit Sub
            Else
                ErrProvUsuario.SetError(txtPassword, "")
            End If
            If modopantalla = modFuncionesForm.ModoPantalla.ModoALTA Then
                Try
                    Dim dts As New logUsuario
                    Dim FuncionInsertar As New fUsuario
                    Dim habilitado As Integer
                    Dim pass As String


                    If txtPassValidator.Text = txtPassword.Text Then
                        pass = txtPassword.Text
                    Else
                        pass = Nothing
                        If pass = Nothing Then
                            MessageBox.Show("Contraseñas incorrectas", "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If


                    If CheckHabilitado.Checked = True Then
                        habilitado = 1
                    Else
                        habilitado = 0
                    End If

                    dts.pNombreUsu = txtNombre.Text
                    dts.pLogin = txtLogin.Text
                    dts.pPassword = pass
                    dts.pHabilitado = habilitado

                    If FuncionInsertar.Alta_Usuario(dts) Then
                        mostrar_datos()
                        modFuncionesForm.LimpiarTextos(Me)
                        inicia_pantalla()

                        btnAgregar.Text = "Agregar"
                        btnModificar.Text = "Modificar"
                        btnCerrar.Enabled = True
                        dataUsuario.Enabled = True
                    Else
                        MessageBox.Show("El usuario no se ha registrado. Vuelva a intentarlo.", "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Atención: se ha generado un error tratando de registrar el usuario." &
                                Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            ElseIf modopantalla = modFuncionesForm.ModoPantalla.ModoMODIFICACION Then
                Try
                    Dim dts As New logUsuario
                    Dim FuncionInsertar As New fUsuario
                    Dim habilitado As Integer
                    Dim pass As String

                    If txtPassValidator.Text = txtPassword.Text Then
                        pass = txtPassword.Text
                    Else
                        pass = Nothing
                        If pass = Nothing Then
                            MessageBox.Show("Contraseñas incorrectas", "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                    If CheckHabilitado.Checked = True Then
                        habilitado = 1
                    Else
                        habilitado = 0
                    End If

                    dts.pID = txtID.Text
                    dts.pNombreUsu = txtNombre.Text
                    dts.pLogin = txtLogin.Text
                    dts.pPassword = pass
                    dts.pHabilitado = habilitado

                    If FuncionInsertar.Modificar_Usuario(dts) Then
                        mostrar_datos()
                        modFuncionesForm.LimpiarTextos(Me)
                        inicia_pantalla()

                        btnAgregar.Text = "Agregar"
                        btnModificar.Text = "Modificar"
                        btnCerrar.Enabled = True
                        dataUsuario.Enabled = True
                        txtID.Text = "0"
                        CheckHabilitado.Checked = False
                    Else
                        MessageBox.Show("El usuario no se ha modificado. Vuelva a intentarlo.", "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Atención: se ha generado un error tratando de modificar el usuario." &
                                Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If btnModificar.Text = "Cancelar" Then
            modopantalla = modFuncionesForm.ModoPantalla.ModoCONSULTA
            inicia_pantalla()
            btnAgregar.Text = "Agregar"
            btnModificar.Text = "Modificar"
            btnCerrar.Enabled = True
            dataUsuario.Enabled = True
            ErrProvUsuario.SetError(txtNombre, "")
        Else
            modopantalla = ModoPantalla.ModoMODIFICACION
            modFuncionesForm.HabilitarTextos(Me)
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            btnCerrar.Enabled = False
            cboBuscar.Enabled = False
            btnAgregar.Enabled = True
            CheckHabilitado.Enabled = True
            txtBuscar.Enabled = False
            txtID.Enabled = False
            txtLogin.Enabled = True
            dataUsuario.Enabled = False
            btnAgregar.Text = "Confirmar"
            btnModificar.Text = "Cancelar"
            txtNombre.Focus()
        End If
    End Sub

    Private Sub dataUsuario_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataUsuario.CellClick
        Dim aux As New Integer
        dataUsuario.ReadOnly = True
        txtID.Text = Convert.ToString(dataUsuario.CurrentRow.Cells("ID").Value)
        txtNombre.Text = Convert.ToString(dataUsuario.CurrentRow.Cells("Usuario").Value)
        txtLogin.Text = Convert.ToString(dataUsuario.CurrentRow.Cells("Login").Value)
        txtPassword.Text = Convert.ToString(dataUsuario.CurrentRow.Cells("Password").Value)
        txtPassValidator.Text = Convert.ToString(dataUsuario.CurrentRow.Cells("Password").Value)

        If txtID.Text <> "" Then
            aux = dataUsuario.CurrentRow.Cells("Habilitado").Value
        End If


        If aux = 1 Then
            CheckHabilitado.Checked = True
        Else
            CheckHabilitado.Checked = False
        End If
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        btnAgregar.Enabled = True

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Respuesta As Integer = MessageBox.Show("Atención: ha seleccionado eliminar un usuario. " & Environment.NewLine & "¿Confirma la eliminación?", "Eliminación de usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If Respuesta = MsgBoxResult.Yes Then
            Try
                Dim dts As New logUsuario
                Dim FuncionInsertar As New fUsuario
                dts.pID = txtID.Text
                If FuncionInsertar.Baja_Usuario(dts) Then
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