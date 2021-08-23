﻿Public Class frmUsuario

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
        If btnAgregar.Text = "agregar" Then
            modopantalla = modFuncionesForm.ModoPantalla.ModoALTA

            LimpiarTextos(Me)
            HabilitarTextos(Me)
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            btnCerrar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            txtID.Enabled = False
            dataUsuario.Enabled = False
            cboHabilitar.Enabled = True
            'el botón agregar pasa a ser confirmar.
            'el botón modificar pasa a ser cancelar.
            btnAgregar.Text = "confirmar"
            btnModificar.Text = "cancelar"
            txtNombre.Focus()
        Else

            'validamos los controles.
            If txtNombre.Text = "" Then
                errprovusuario.seterror(txtNombre, "debe ingresar un nombre para el usuario")
                txtNombre.Focus()
                Exit Sub
            Else
                errprovusuario.seterror(txtNombre, "")
            End If
            If modopantalla = modFuncionesForm.ModoPantalla.ModoALTA Then
                Try
                    Dim dts As New logUsuario
                    Dim FuncionInsertar As New fUsuario

                    dts.pNombreUsu = txtNombre.Text
                    dts.pLogin = txtLogin.Text
                    dts.pPassword = txtPassword.Text
                    dts.pPassword = txtPassValidator.Text
                    dts.pHabilitado = cboHabilitar.SelectedItem

                    If FuncionInsertar.Alta_Usuario(dts) Then
                        mostrar_datos()
                        LimpiarTextos(Me)
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

                    dts.pID = txtID.Text
                    dts.pNombreUsu = txtNombre.Text
                    dts.pLogin = txtLogin.Text
                    dts.pPassword = txtPassword.Text
                    dts.pPassword = txtPassValidator.Text
                    dts.pHabilitado = cboHabilitar.SelectedItem

                    If FuncionInsertar.Modificar_Usuario(dts) Then
                        mostrar_datos()
                        LimpiarTextos(Me)
                        inicia_pantalla()

                        btnAgregar.Text = "Agregar"
                        btnModificar.Text = "Modificar"
                        btnCerrar.Enabled = True
                        dataUsuario.Enabled = True
                    Else
                        MessageBox.Show("El tipo de sorteo no se ha modificado. Vuelva a intentarlo.", "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Atención: se ha generado un error tratando de modificar el tipo de sorteo." &
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
            HabilitarTextos(Me)
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            btnCerrar.Enabled = False
            cboBuscar.Enabled = False
            cboHabilitar.Enabled = True
            txtBuscar.Enabled = False
            txtID.Enabled = False
            dataUsuario.Enabled = False
            btnAgregar.Text = "Confirmar"
            btnModificar.Text = "Cancelar"
            txtNombre.Focus()
        End If
    End Sub

    Private Sub dataUsuario_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataUsuario.CellContentClick
        Dim aux As New Integer
        txtID.Text = dataUsuario.CurrentRow.Cells("ID").Value
        txtNombre.Text = dataUsuario.CurrentRow.Cells("Empleado").Value
        txtLogin.Text = dataUsuario.CurrentRow.Cells("Login").Value
        aux = dataUsuario.CurrentRow.Cells("Habilitado").Value
        If aux = 1 Then
            cboHabilitar.Text = "Si"
        Else
            cboHabilitar.Text = "No"
        End If
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
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