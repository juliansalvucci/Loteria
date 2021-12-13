Public Class frmTipoSorteo
    Private dt As New DataTable
    Dim ModoPantalla As ModoPantalla

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmTipoSorteo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar_Datos()
        Inicia_Pantalla()
    End Sub

    Private Sub Mostrar_Datos()
        Try
            Dim FuncionMostrar As New fTipoSorteo
            dt = FuncionMostrar.Mostrar_TipoSorteo

            If dt.Rows.Count <> 0 Then
                dataTipoSorteo.DataSource = dt
            Else
                dataTipoSorteo.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de mostrar los tipos de sorteo." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Inicia_Pantalla()
        DeshabilitarTextos(Me)
        DeshabilitarCombos(Me)

        If dt.Rows.Count = 0 Then
            'Al no encontrar datos en la tabla [TipoSorteo]
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
            cboBuscar.Enabled = True : cboBuscar.SelectedIndex = 0
            txtBuscar.Enabled = True
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub Buscar_Datos()
        Try
            Dim ds As New DataSet 'Representa una memoria caché de datos en memoria.
            ds.Tables.Add(dt.Copy) 'Se realiza una copia de la tabla en memoria.

            Dim dv As New DataView(ds.Tables(0))
            'DataView representa una vista personalizada que puede enlazar datos de un DataTable para ordenación, filtrado, búsqueda, edición y navegación. 
            'El DataView no almacena datos, sino que representa una vista conectada al DataTable correspondiente. Los cambios en los datos de DataView afectarán a DataTable. 
            'Los cambios en los datos de DataTable afectarán a toda los DataView asociados a él.

            If cboBuscar.SelectedItem = "Nombre" Then
                dv.RowFilter = cboBuscar.Text & " LIKE '%" & txtBuscar.Text & "%'"
            Else
                dv.RowFilter = cboBuscar.Text & " = " & txtBuscar.Text
            End If

            If dv.Count <> 0 Then
                dataTipoSorteo.DataSource = dv
            Else
                dataTipoSorteo.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de buscar los tipos de sorteo." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If btnAgregar.Text = "Agregar" Then
            ModoPantalla = modFuncionesForm.ModoPantalla.ModoALTA

            LimpiarTextos(Me)
            HabilitarTextos(Me)

            'Deshabilitamos los objetos que no pueden ser utilizados mientras el form está en estado ALTA.
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            btnCerrar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            dataTipoSorteo.Enabled = False
            txtID.Enabled = False

            'El botón Agregar pasa a ser Confirmar.
            'El botón Modificar pasa a ser Cancelar.
            btnAgregar.Text = "Confirmar"
            btnModificar.Text = "Cancelar"

            txtNombre.Focus()
        Else

            'Validamos los controles.
            If txtNombre.Text = "" Then
                ErrProvTipoSorteo.SetError(txtNombre, " Debe ingresar un nombre para el Tipo de Sorteo ")
                txtNombre.Focus()
                Exit Sub
            Else
                ErrProvTipoSorteo.SetError(txtNombre, "")
            End If

            If ModoPantalla = modFuncionesForm.ModoPantalla.ModoALTA Then
                Try
                    Dim dts As New logTipoSorteo
                    Dim FuncionInsertar As New fTipoSorteo

                    dts.pNombre = txtNombre.Text
                    dts.pDescripcion = txtDescripcion.Text

                    If FuncionInsertar.Insertar_TipoSorteo(dts) Then
                        Mostrar_Datos()
                        LimpiarTextos(Me)
                        Inicia_Pantalla()

                        btnAgregar.Text = "Agregar"
                        btnModificar.Text = "Modificar"
                        btnCerrar.Enabled = True
                        dataTipoSorteo.Enabled = True
                    Else
                        MessageBox.Show("El tipo de sorteo no se ha registrado. Vuelva a intentarlo.", "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Atención: se ha generado un error tratando de registrar el tipo de sorteo." &
                                Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            ElseIf ModoPantalla = modFuncionesForm.ModoPantalla.ModoMODIFICACION Then
                Try
                    Dim dts As New logTipoSorteo
                    Dim FuncionInsertar As New fTipoSorteo

                    dts.pID = txtID.Text
                    dts.pNombre = txtNombre.Text
                    dts.pDescripcion = txtDescripcion.Text

                    If FuncionInsertar.Modificar_TipoSorteo(dts) Then
                        Mostrar_Datos()
                        LimpiarTextos(Me)
                        Inicia_Pantalla()

                        btnAgregar.Text = "Agregar"
                        btnModificar.Text = "Modificar"
                        btnCerrar.Enabled = True
                        dataTipoSorteo.Enabled = True
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
            ModoPantalla = modFuncionesForm.ModoPantalla.ModoCONSULTA

            Inicia_Pantalla()

            btnAgregar.Text = "Agregar"
            btnModificar.Text = "Modificar"

            btnCerrar.Enabled = True
            dataTipoSorteo.Enabled = True

            ErrProvTipoSorteo.SetError(txtNombre, "")
        Else
            ModoPantalla = modFuncionesForm.ModoPantalla.ModoMODIFICACION

            HabilitarTextos(Me)

            'Deshabilitamos los objetos que no pueden ser utilizados mientras el form está en estado ALTA.
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            btnCerrar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            txtID.Enabled = False
            dataTipoSorteo.Enabled = False

            'El botón Agregar pasa a ser Confirmar.
            'El botón Modificar pasa a ser Cancelar.
            btnAgregar.Text = "Confirmar"
            btnModificar.Text = "Cancelar"

            txtNombre.Focus()
        End If
    End Sub

    'Procedimiento que establece el comportamiento del botón buscar.
    Private Sub btnbuscar_click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Buscar_Datos()
    End Sub

    Private Sub dataTipoSorteo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataTipoSorteo.CellClick
        txtID.Text = dataTipoSorteo.CurrentRow.Cells("ID").Value
        txtNombre.Text = dataTipoSorteo.CurrentRow.Cells("NOMBRE").Value
        txtDescripcion.Text = dataTipoSorteo.CurrentRow.Cells("DESCRIPCION").Value

        btnModificar.Enabled = True
        btnEliminar.Enabled = True
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Respuesta As Integer = MessageBox.Show("Atención: ha seleccionado eliminar un tipo de sorteo. " &
                                                   Environment.NewLine &
                                                   "¿Confirma la eliminación?", "Eliminación de tipos de sorteo",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Error)

        If Respuesta = MsgBoxResult.Yes Then
            Try
                Dim dts As New logTipoSorteo
                Dim FuncionInsertar As New fTipoSorteo

                dts.pID = txtID.Text

                If FuncionInsertar.Eliminar_TipoSorteo(dts) Then
                    Mostrar_Datos()
                    LimpiarTextos(Me)
                    Inicia_Pantalla()

                Else
                    MessageBox.Show("El tipo de sorteo no se ha eliminado. Vuelva a intentarlo.",
                                    "Eliminar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Atención: se ha generado un error tratando de eliminar el tipo de sorteo." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


End Class