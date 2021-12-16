Public Class frmAgencia
    Private dt, dt1 As New DataTable
    Dim ModoPantalla As ModoPantalla
    Dim fila As String

    Private Sub Mostrar_Datos()
        Try
            Dim FuncionMostrar As New fAgencia
            dt = FuncionMostrar.Mostrar_Agencia

            If dt.Rows.Count <> 0 Then
                dataAgencia.DataSource = dt
            Else
                dataAgencia.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de mostrar las Agencias." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Inicia_Pantalla()
        modFuncionesForm.DeshabilitarTextos(Me)
        modFuncionesForm.DeshabilitarCombos(Me)

        If dt.Rows.Count = 0 Then
            'Al no encontrar datos en la tabla 
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            btnAgregar.Focus()
        Else
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnEliminar.Show()
            btnBuscar.Enabled = True
            cboBuscar.Enabled = True : cboBuscar.SelectedIndex = 1
            txtBuscar.Enabled = True
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub Buscar_Datos()
        Try
            Dim ds As New DataSet 'Representa una memoria caché de datos en memoria.'
            ds.Tables.Add(dt.Copy) 'Se realiza una copia de la tabla en memoria.'

            Dim dv As New DataView(ds.Tables(0))

            'DataView representa una vista personalizada que puede enlazar datos de una DataTable para
            'ordenacion, filtrado, busqueda, edicion y navegacion.
            'El DataView no almacen datos, sino que representa una vista conectada al DataTable correspondientes.
            'Los cambios en los datos de DataView afectan a DataTable.
            'Los cambios en los datos de DataTable afectaran a todos los DataView asociados a el.

            If cboBuscar.SelectedItem = "NOMBRE" Then
                dv.RowFilter = cboBuscar.Text & " LIKE '%" & txtBuscar.Text & "%'"
            Else
                dv.RowFilter = cboBuscar.Text & " = " & txtBuscar.Text
            End If

            If txtBuscar.Text = "" Then
                Mostrar_Datos()
            End If

            If dv.Count <> 0 Then 'si la cantidad de registros de la consulta es distinta de 0
                dataAgencia.DataSource = dv
            Else
                dataAgencia.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de buscar los tipos de sorteo." &
                            Environment.NewLine & "Descripción del error: " &
                            Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If btnAgregar.Text = "Agregar" Then
            ModoPantalla = modFuncionesForm.ModoPantalla.ModoALTA
            modFuncionesForm.LimpiarTextos(Me)
            modFuncionesForm.HabilitarTextos(Me)

            btnModificar.Enabled = True
            btnModificar.Text = "Cancelar" 'El botón Modificar pasa a ser Cancelar.
            txtID.Enabled = False
            btnBuscar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False




            dataAgencia.Enabled = False
            btnAgregar.Text = "Confirmar" 'El botón Agregar pasa a ser Confirmar.

            btnEliminar.Enabled = False
            btnEliminar.Hide() 'Se oculta el boton eliminar

            txtNombre.Focus()
        Else

            'Validamos los controles.
            If txtNombre.Text = "" Then
                ErrProvAgencia.SetError(txtNombre, "Debe ingresar un nombre para la Agencia")
                txtNombre.Focus()
                Exit Sub
            Else
                ErrProvAgencia.SetError(txtNombre, "")
            End If

            If txtGanancia.Text = "" Then
                ErrProvAgencia.SetError(txtGanancia, "Debe ingresar un valor para la ganancia")
                txtNombre.Focus()
                Exit Sub
            Else
                ErrProvAgencia.SetError(txtGanancia, "")
            End If

            If ModoPantalla = modFuncionesForm.ModoPantalla.ModoALTA Then
                Try
                    Dim dts As New logAgencia
                    Dim FuncionInsertar As New fAgencia

                    dts.pNombre = txtNombre.Text
                    dts.pGanancia = txtGanancia.Text

                    If FuncionInsertar.Insertar_Agencia(dts) Then
                        Mostrar_Datos()
                        LimpiarTextos(Me)
                        Inicia_Pantalla()

                        btnAgregar.Text = "Agregar"
                        btnModificar.Text = "Modificar"


                        dataAgencia.Enabled = True
                    Else
                        MessageBox.Show("La Agencia no se ha registrado. Vuelva a intentarlo.",
                                    "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Atención: se ha generado un error tratando de registrar la Agencia." &
                                Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                                ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            ElseIf ModoPantalla = modFuncionesForm.ModoPantalla.ModoMODIFICACION Then
                Try
                    Dim dts As New logAgencia
                    Dim FuncionInsertar As New fAgencia

                    dts.pID = txtID.Text
                    dts.pNombre = txtNombre.Text
                    dts.pGanancia = txtGanancia.Text

                    If FuncionInsertar.Modificar_Agencia(dts) Then
                        Mostrar_Datos()
                        LimpiarTextos(Me)
                        Inicia_Pantalla()

                        btnAgregar.Text = "Agregar"
                        btnModificar.Text = "Modificar"
                        dataAgencia.Enabled = True
                    Else
                        MessageBox.Show("La Afencia no se ha modificado. Vuelva a intentarlo.",
                                        "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Atención: se ha generado un error tratando de modificar la Agencia." &
                                    Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                                    ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If btnModificar.Text = "Cancelar" Then
            ModoPantalla = modFuncionesForm.ModoPantalla.ModoCONSULTA
            Inicia_Pantalla()
            btnAgregar.Text = "Agregar"
            btnModificar.Text = "Modificar"
            dataAgencia.Enabled = True
            btnEliminar.Show()
            btnModificar.Image = My.Resources.Quitar_Todo
            ErrProvAgencia.SetError(txtNombre, "")
        Else
            ModoPantalla = modFuncionesForm.ModoPantalla.ModoMODIFICACION
            'dataAgencia_CellClick()
            HabilitarTextos(Me)
            txtID.Enabled = False
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            dataAgencia.Enabled = False
            btnAgregar.Text = "Confirmar"
            btnModificar.Text = "Cancelar"
            btnModificar.Enabled = True
            btnEliminar.Hide()

            txtNombre.Focus()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Buscar_Datos()
    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        AbmEvents_KP(e)
    End Sub

    Private Sub txtGanancia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGanancia.KeyDown
        AbmEvents_KP(e)
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        AbmEvents_KP(e)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Respuesta As Integer = MessageBox.Show("Atención: ha seleccionado eliminar Agencia. " &
                                                   Environment.NewLine & "¿Confirma la eliminación?",
                                                   "Eliminación de Agencia",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If Respuesta = MsgBoxResult.Yes Then
            Try
                Dim dts As New logAgencia
                Dim FuncionInsertar As New fAgencia

                dts.pID = txtID.Text

                If FuncionInsertar.Eliminar_Agencia(dts) Then
                    Mostrar_Datos()
                    LimpiarTextos(Me)
                    Inicia_Pantalla()
                Else
                    MessageBox.Show("La Agencia no se ha eliminado. Vuelva a intentarlo.",
                                    "Eliminar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Atención: se ha generado un error tratando de eliminar la Agencia." &
                                Environment.NewLine & "Descripción del error: " &
                                Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub frmAgencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar_Datos()
        Inicia_Pantalla()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dataAgencia_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataAgencia.CellClick
        txtID.Text = dataAgencia.CurrentRow.Cells("ID").Value
        txtNombre.Text = dataAgencia.CurrentRow.Cells("NOMBRE").Value
        txtGanancia.Text = dataAgencia.CurrentRow.Cells("GANANCIA").Value

        btnModificar.Enabled = True
        btnEliminar.Enabled = True
    End Sub
End Class