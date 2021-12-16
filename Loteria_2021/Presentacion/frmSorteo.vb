Public Class frmSorteo
    Private Sub frmSorteo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar_Datos()
        Inicia_Pantalla()
    End Sub

    Private dt, dt2 As New DataTable

    Dim ModoPantalla As ModoPantalla
    Private Sub Mostrar_Datos()
        Try
            Dim FuncionMostrar As New fSorteo
            dt = FuncionMostrar.Mostrar_Sorteo

            If dt.Rows.Count <> 0 Then
                dataSorteo.DataSource = dt
            Else
                dataSorteo.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de mostrar los tipos de 
            sorteo." & Environment.NewLine & "Descripción del error: " & Environment.NewLine &
            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'del mostrar tipo sorteo tomo el nombre para mostrar en el combo
        'y por detras mando el id como valor.
        Try
            Dim FuncionMostrar As New fTipoSorteo
            dt2 = FuncionMostrar.Mostrar_TipoSorteo
            If dt2.Rows.Count <> 0 Then
                cboSorteo.DataSource = dt2
                cboSorteo.DisplayMember = "NOMBRE"
                cboSorteo.ValueMember = "ID"
            Else
                cboSorteo.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de mostrar los Sorteos." &
        Environment.NewLine & "Descripción del error: " & Environment.NewLine &
        ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub Inicia_Pantalla()
        modFuncionesForm.DeshabilitarTextos(Me)
        modFuncionesForm.DeshabilitarCombos(Me)
        If dt.Rows.Count = 0 Then
            'Al no encontrar datos en la tabla [Sorteo]
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            btnModificar.Image = My.Resources.Editar
            btnAgregar.Focus()
        Else
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnEliminar.Show()
            btnBuscar.Enabled = True
            cboBuscar.Enabled = True : cboBuscar.SelectedIndex = 0
            txtBuscar.Enabled = True
            btnModificar.Image = My.Resources.Editar
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
            If cboBuscar.SelectedItem = "ID" Then
                dv.RowFilter = cboBuscar.Text & " = " & txtBuscar.Text

            ElseIf cboBuscar.SelectedItem = "TIPOSORTEO" Then
                dv.RowFilter = cboBuscar.Text & " like '%" & txtBuscar.Text & "%'"
            End If

            If txtBuscar.Text = "" Then
                Mostrar_Datos()
            End If

            If dv.Count <> 0 Then 'si la cantidad de registros de la consulta es distinta de 0
                dataSorteo.DataSource = dv
            Else
                dataSorteo.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de buscar los sorteos." &
                            Environment.NewLine & "Descripción del error: " &
                            Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If btnAgregar.Text = "Agregar" Then
            ModoPantalla = ModoPantalla.ModoALTA

            modFuncionesForm.LimpiarTextos(Me)
            modFuncionesForm.HabilitarTextos(Me)

            btnEliminar.Enabled = False
            btnEliminar.Hide() 'Se oculta el boton eliminar

            btnBuscar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            txtID.Enabled = False
            dataSorteo.Enabled = False
            btnModificar.Image = My.Resources.Quitar_Todo

            btnAgregar.Text = "Confirmar" 'El botón Agregar pasa a ser Confirmar.

            btnModificar.Text = "Cancelar" 'El botón Modificar pasa a ser Cancelar.
            btnModificar.Enabled = True
            cboSorteo.Enabled = True

            cboSorteo.Focus()
        Else

            'Validamos los controles.
            If cboSorteo.Text = "" Then
                ErrProvSorteo.SetError(cboSorteo, "Debe ingresar una fecha para el Sorteo")
                cboSorteo.Focus()
                Exit Sub
            Else
                ErrProvSorteo.SetError(cboSorteo, "")
            End If

            If ModoPantalla = ModoPantalla.ModoALTA Then
                Try
                    Dim dts As New logSorteo
                    Dim FuncionInsertar As New fSorteo


                    dts.pIDTipoSorteo = cboSorteo.SelectedValue

                    If FuncionInsertar.Insertar_Sorteo(dts) Then
                        Mostrar_Datos()
                        LimpiarTextos(Me)
                        Inicia_Pantalla()

                        btnAgregar.Text = "Agregar"
                        btnModificar.Text = "Modificar"
                        dataSorteo.Enabled = True
                    Else
                        MessageBox.Show("El sorteo no se ha registrado. Vuelva a intentarlo.",
                                    "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Atención: se ha generado un error tratando de registrar el sorteo." &
                                Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                                ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            ElseIf ModoPantalla = ModoPantalla.ModoMODIFICACION Then
                Try
                    Dim dts As New logSorteo
                    Dim FuncionInsertar As New fSorteo

                    dts.pID = txtID.Text
                    dts.pIDTipoSorteo = cboSorteo.SelectedValue

                    If FuncionInsertar.Modificar_Sorteo(dts) Then
                        Mostrar_Datos()
                        LimpiarTextos(Me)
                        Inicia_Pantalla()

                        btnAgregar.Text = "Agregar"
                        btnModificar.Text = "Modificar"
                        dataSorteo.Enabled = True
                    Else
                        MessageBox.Show("El sorteo no se ha modificado. Vuelva a intentarlo.",
                                        "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Atención: se ha generado un error tratando de modificar el sorteo." &
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
            dataSorteo.Enabled = True
            btnModificar.Image = My.Resources.Editar
            btnEliminar.Show()
        Else
            ModoPantalla = modFuncionesForm.ModoPantalla.ModoMODIFICACION
            HabilitarTextos(Me)
            btnEliminar.Enabled = False
            txtID.Enabled = False
            btnBuscar.Enabled = False
            cboBuscar.Enabled = False
            cboSorteo.Enabled = True
            txtID.Enabled = False
            txtBuscar.Enabled = False
            dataSorteo.Enabled = False
            btnAgregar.Text = "Confirmar"
            btnModificar.Text = "Cancelar"
            btnModificar.Enabled = True
            btnEliminar.Hide()
            btnModificar.Image = My.Resources.Quitar_Todo


        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Respuesta As Integer = MessageBox.Show("Atención: ha seleccionado eliminar el sorteo. " &
                                                   Environment.NewLine & "¿Confirma la eliminación?",
                                                   "Eliminación del sorteo",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If Respuesta = MsgBoxResult.Yes Then
            Try
                Dim dts As New logSorteo
                Dim FuncionInsertar As New fSorteo

                dts.pID = txtID.Text

                If FuncionInsertar.Eliminar_Sorteo(dts) Then
                    Mostrar_Datos()
                    LimpiarTextos(Me)
                    Inicia_Pantalla()
                Else
                    MessageBox.Show("El sorteo no se ha eliminado. Vuelva a intentarlo.",
                                    "Eliminar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Atención: se ha generado un error tratando de eliminar el sorteo." &
                                Environment.NewLine & "Descripción del error: " &
                                Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Buscar_Datos()
    End Sub

    Private Sub btncerrar_click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close() 'El formulario se referencia a si mismo y se cierra.
    End Sub

    Private Sub dataTipoSorteo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataSorteo.CellClick
        txtID.Text = dataSorteo.CurrentRow.Cells("ID").Value
        cboSorteo.Text = dataSorteo.CurrentRow.Cells("TIPOSORTEO").Value

        btnModificar.Enabled = True
        btnEliminar.Enabled = True
    End Sub
End Class