Public Class frmUsuario

    'Ctrl-K Ctrl-C comentario multilínea
    'Ctrl-K Ctrl-U decomentar


    Private dt As New DataTable 'Variable para obtener un registro y mostrarlo como tabla.
    Dim modopantalla As ModoPantalla 'Variable para establecer los modos de pantalla.

    'Procedimiento para asignar los registros obtenidos por la función 'Consulta_Usuario' a la variable dt.
    Private Sub mostrar_datos()
        Try
            Dim funcionmostrar As New fUsuario
            dt = funcionmostrar.Consulta_Usuario
            If dt.Rows.Count <> 0 Then  'Si dt posee filas, cargar el resultado en el DataGridView dataUsuario'
                dataUsuario.DataSource = dt
            Else
                dataUsuario.DataSource = Nothing 'De lo contrario asignar nada.
            End If
        Catch ex As Exception  'Si se produce un error en la conexión, capturarla y formatear el mensaje.
            MessageBox.Show("atención: se ha generado un error tratando de mostrar los usuarios." & Environment.NewLine & "descripción del error: " & Environment.NewLine & ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Procedimiento para definir el comportamiento inicial del formulario.
    Private Sub inicia_pantalla()

        'Por cada vez que invoquemos a un procedimiento del modFuncionesForm
        'se le deberá pasar por parámetro el formulario, para que el procedimiento
        'pueda accionar sobre el formulario.
        modFuncionesForm.DeshabilitarTextos(Me)
        modFuncionesForm.DeshabilitarCombos(Me)

        'Si no hay usuarios registrados
        If dt.Rows.Count = 0 Then

            'Desabilitar la posibilidad de eliminar, consultar y modificar.

            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            btnAgregar.Enabled = True
            CheckHabilitado.Enabled = False
            btnAgregar.Focus()
        Else

            'Caso contrario habilitar las posibilidades.

            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnBuscar.Enabled = True
            cboBuscar.Enabled = True : cboBuscar.SelectedIndex = 1
            txtBuscar.Enabled = True
            CheckHabilitado.Enabled = False
            txtBuscar.Focus()
        End If
    End Sub


    'Procedimiento para el filtrado de registros en el DataGridView.
    Private Sub buscar_datos()
        Try
            Dim ds As New DataSet 'representa una memoria caché de datos en memoria.
            ds.Tables.Add(dt.Copy) 'se realiza una copia de la tabla en memoria.
            Dim dv As New DataView(ds.Tables(0)) 'Regresa los registros filterados.

            'Si el elemento text en el combo de busqueda es iguak al nombre de la columna 
            'del DataGridView, permitir el filtrado para dicha columna.

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

            'Si el dataView dv retorna resultados, entonces asignarlos al DataGridView.
            'Caso contrario retornar nada.

            If dv.Count <> 0 Then
                dataUsuario.DataSource = dv
            Else
                dataUsuario.DataSource = Nothing
            End If

            'Si el procedimiento falla, entonces devilver una excepción.

        Catch ex As Exception
            MessageBox.Show("atención: se ha generado un error tratando de buscar los usuarios" & Environment.NewLine & "descripción del error: " & Environment.NewLine & ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Procedimiento que establece que métodos ejecutar apenas se ejecute el formulario. 
    Private Sub frmusuario_load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar_datos()
        inicia_pantalla()
    End Sub

    'Procedimiento que establece el comportamiento del botón buscar.
    Private Sub btnbuscar_click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        buscar_datos()
    End Sub

    'Procedimiento que establece el comportamiento del botón cerrar.
    Private Sub btncerrar_click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close() 'El formulario se referencia a si mismo y se cierra.
    End Sub

    'Procedimiento que establece el comportamiento del botón agregar.
    Private Sub btnagregar_click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        'Si la propiedad text del botón es "Agregar" entonces activar el modo para dar de alta.
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
            txtID.Text = "0" 'Defino un ID 0 como guarda y estética.
            dataUsuario.Enabled = False
            CheckHabilitado.Enabled = True
            CheckHabilitado.Checked = False
            'el botón agregar pasa a ser confirmar.
            'el botón modificar pasa a ser cancelar.
            btnAgregar.Text = "Confirmar"
            btnModificar.Text = "Cancelar"
            txtNombre.Focus() 'Focalizo el cursor en el campo txtNormbre.
        Else

            'Control para los campos requeridos.
            If txtNombre.Text = "" Then
                ErrProvUsuario.SetError(txtNombre, "debe ingresar un nombre para el usuario")
                txtNombre.Focus()
                Exit Sub
            Else
                ErrProvUsuario.SetError(txtNombre, "")
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

                'Si el formulario esta en modo alta, invocar a la función Alta_Usuario.

                Try
                    Dim dts As New logUsuario
                    Dim FuncionInsertar As New fUsuario
                    Dim habilitado As Integer
                    Dim pass As String

                    'Validación de contraseña.

                    If txtPassValidator.Text = txtPassword.Text Then
                        pass = txtPassword.Text
                    Else
                        pass = Nothing
                        If pass = Nothing Then
                            MessageBox.Show("Contraseñas incorrectas", "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                    'Control para checkbox "Habilitado"
                    'Si la casilla esta habilitada, se establece que el valor habilitado es 1
                    'De lo contrario es 0

                    If CheckHabilitado.Checked = True Then
                        habilitado = 1
                    Else
                        habilitado = 0
                    End If

                    'Asigno los datos al dts para enviarselos a la función.

                    dts.pNombreUsu = txtNombre.Text
                    dts.pLogin = txtLogin.Text
                    dts.pPassword = pass
                    dts.pHabilitado = habilitado

                    'Invocación de Alta_Usuario.

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

                'Si el formulario esta en modo alta, invocar a la función Modificacion_Usuario.

                Try
                    Dim dts As New logUsuario
                    Dim FuncionInsertar As New fUsuario
                    Dim habilitado As Integer
                    Dim pass As String

                    'Validación de contraseña.

                    If txtPassValidator.Text = txtPassword.Text Then
                        pass = txtPassword.Text
                    Else
                        pass = Nothing
                        If pass = Nothing Then
                            MessageBox.Show("Contraseñas incorrectas", "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                    'Control para checkbox "Habilitado"
                    'Si la casilla esta habilitada, se establece que el valor habilitado es 1
                    'De lo contrario es 0

                    If CheckHabilitado.Checked = True Then
                        habilitado = 1
                    Else
                        habilitado = 0
                    End If

                    'Asigno los datos al dts para enviarselos a la función.

                    dts.pID = txtID.Text
                    dts.pNombreUsu = txtNombre.Text
                    dts.pLogin = txtLogin.Text
                    dts.pPassword = pass
                    dts.pHabilitado = habilitado

                    'Invocación de Modificacion_Usuario.

                    If FuncionInsertar.Modificacion_Usuario(dts) Then
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

    'Procedimiento que establece el comportamiento del botón modificar.
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        'Si la propiedad Text del botón modificar es "Cancelar" se establecerá el modo consulta.

        If btnModificar.Text = "Cancelar" Then
            modopantalla = modFuncionesForm.ModoPantalla.ModoCONSULTA
            inicia_pantalla()
            btnAgregar.Text = "Agregar"
            btnModificar.Text = "Modificar"
            btnCerrar.Enabled = True
            dataUsuario.Enabled = True
            ErrProvUsuario.SetError(txtNombre, "")
        Else

            'Caso contrario habilitar el modo modificación.

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

    'Procedimiento que establece el comportamiento de una celta del DataGridView al hacer un click sobre ella.
    Private Sub dataUsuario_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataUsuario.CellClick
        Dim aux As New Integer

        'No permitir la edición de los datos en el DataGridView.
        dataUsuario.ReadOnly = True

        'Asignar cada valor a su campo correspondiente para luego permitir editarlos.
        txtID.Text = Convert.ToString(dataUsuario.CurrentRow.Cells("ID").Value)
        txtNombre.Text = Convert.ToString(dataUsuario.CurrentRow.Cells("Usuario").Value)
        txtLogin.Text = Convert.ToString(dataUsuario.CurrentRow.Cells("Login").Value)
        txtPassword.Text = Convert.ToString(dataUsuario.CurrentRow.Cells("Password").Value)
        txtPassValidator.Text = Convert.ToString(dataUsuario.CurrentRow.Cells("Password").Value)

        'Estructura para evitar el error "Return DBNULL"
        If txtID.Text <> "" Then
            aux = dataUsuario.CurrentRow.Cells("Habilitado").Value
        End If

        'Estructura con variable auxiliar para establecer el valor en el check habilitado.
        If aux = 1 Then
            CheckHabilitado.Checked = True
        Else
            CheckHabilitado.Checked = False
        End If

        'Comportamiento de botones
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        btnAgregar.Enabled = True

    End Sub

    'Procedimiento que establece el comportamiento del botón eliminar.
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        'Al presionar el botón, se desplegará un MessageBox para preguntarnos si 
        'estamos seguros de nuestra decisión .

        Dim Respuesta As Integer = MessageBox.Show("Atención: ha seleccionado eliminar un usuario. " & Environment.NewLine & "¿Confirma la eliminación?", "Eliminación de usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Error)

        'Si el usuario admite que si entonces se procede a la eliminación.

        If Respuesta = MsgBoxResult.Yes Then
            Try
                Dim dts As New logUsuario
                Dim FuncionInsertar As New fUsuario

                'Se toma el id  y se pasa por parámetro a la función Baja_Usuario.
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