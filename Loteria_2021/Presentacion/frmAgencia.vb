Public Class frmAgencia
    Private dt As New DataTable
    Dim ModoPantalla As ModoPantalla

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmAgencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar_Datos()
        Inicia_Pantalla()
    End Sub

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
            cboBuscar.Enabled = True : cboBuscar.SelectedIndex = 1
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
                dataAgencia.DataSource = dv
            Else
                dataAgencia.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de buscar los tipos de sorteo." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Buscar_Datos()
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
            dataAgencia.Enabled = False
            txtID.Enabled = False

            'El botón Agregar pasa a ser Confirmar.
            'El botón Modificar pasa a ser Cancelar.
            btnAgregar.Text = "Confirmar"
            btnModificar.Text = "Cancelar"

            txtNombre.Focus()
        Else

            'Validamos los controles.
            If txtNombre.Text = "" Then
                ErrorProvAgencia.SetError(txtNombre, " Debe ingresar un nombre para el Tipo de Sorteo ")
                txtNombre.Focus()
                Exit Sub
            Else
                ErrorProvAgencia.SetError(txtNombre, "")
            End If

            If ModoPantalla = modFuncionesForm.ModoPantalla.ModoALTA Then
                Try
                    Dim dts As New logAgencia
                    Dim FuncionInsertar As New fAgencia

                    dts.pNombre = txtNombre.Text
                    dts.pPorc_ganancia = txtPorcGanancia.Text

                    If FuncionInsertar.Insertar_Agencia(dts) Then
                        Mostrar_Datos()
                        LimpiarTextos(Me)
                        Inicia_Pantalla()

                        btnAgregar.Text = "Agregar"
                        btnModificar.Text = "Modificar"
                        btnCerrar.Enabled = True
                        dataAgencia.Enabled = True
                    Else
                        MessageBox.Show("La agencia no se ha registrado. Vuelva a intentarlo.", "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Atención: se ha generado un error tratando de registrar la Agencia." &
                                Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            ElseIf ModoPantalla = modFuncionesForm.ModoPantalla.ModoMODIFICACION Then
                Try
                    Dim dts As New logAgencia
                    Dim FuncionInsertar As New fAgencia

                    dts.pID = txtID.Text
                    dts.pNombre = txtNombre.Text
                    dts.pPorc_ganancia = txtPorcGanancia.Text

                    If FuncionInsertar.Modificar_Agencia(dts) Then
                        Mostrar_Datos()
                        LimpiarTextos(Me)
                        Inicia_Pantalla()

                        btnAgregar.Text = "Agregar"
                        btnModificar.Text = "Modificar"
                        btnCerrar.Enabled = True
                        dataAgencia.Enabled = True
                    Else
                        MessageBox.Show("La agencia no se ha modificado. Vuelva a intentarlo.", "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Atención: se ha generado un error tratando de modificar la agencia." &
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
            dataAgencia.Enabled = True

            ErrorProvAgencia.SetError(txtNombre, "")
        Else
            ModoPantalla = modFuncionesForm.ModoPantalla.ModoMODIFICACION

            HabilitarTextos(Me)

            'Deshabilitamos los objetos que no pueden ser utilizados mientras el form está en estado ALTA.
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            btnCerrar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            dataAgencia.Enabled = False

            'El botón Agregar pasa a ser Confirmar.
            'El botón Modificar pasa a ser Cancelar.
            btnAgregar.Text = "Confirmar"
            btnModificar.Text = "Cancelar"

            txtNombre.Focus()
        End If
    End Sub

    Private Sub dataAgencia_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataAgencia.CellClick
        txtID.Text = dataAgencia.SelectedCells.Item(0).Value
        txtNombre.Text = dataAgencia.SelectedCells.Item(1).Value
        txtPorcGanancia.Text = dataAgencia.SelectedCells.Item(2).Value
    End Sub

    Private Sub dataTipoSorteo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataAgencia.CellContentClick

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Respuesta As Integer = MessageBox.Show("Atención: ha seleccionado eliminar una Agencia. " &
                                                   Environment.NewLine &
                                                   "¿Confirma la eliminación?", "Eliminación de tipos de sorteo",
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
                    MessageBox.Show("La agencia no se ha eliminado. Vuelva a intentarlo.",
                                    "Eliminar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Atención: se ha generado un error tratando de eliminar la agencia." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class