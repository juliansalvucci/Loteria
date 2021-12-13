Public Class frmApuesta
    Private dt, dtx, dt2 As New DataTable
    Dim ModoPantalla As ModoPantalla


    Private Sub FRMApuesta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar_Datos()
        Inicia_Pantalla()
    End Sub

    Private Sub Mostrar_Datos()
        Try
            Dim FuncionMostrar As New fApuesta
            dt = FuncionMostrar.Mostrar_Apuesta

            If dt.Rows.Count <> 0 Then
                dataApuesta.DataSource = dt
            Else
                dataApuesta.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de mostrar las Apuestas." &
                            Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Dim FuncionMostrar2 As New fAgencia
            dtx = FuncionMostrar2.Mostrar_Agencia

            If dtx.Rows.Count <> 0 Then
                cboAgencia.DataSource = dtx
                cboAgencia.DisplayMember = "NOMBRE"
                cboAgencia.ValueMember = "ID"
            Else
                cboAgencia.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de mostrar las Agencias." &
        Environment.NewLine & "Descripción del error: " & Environment.NewLine &
        ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        '-------------------------------------------'
        Try
            Dim FuncionMostrar As New fSorteo
            dt2 = FuncionMostrar.Mostrar_Sorteo

            If dt2.Rows.Count <> 0 Then
                cboSorteo.DataSource = dt2
                cboSorteo.DisplayMember = "FECHA"
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
        DeshabilitarTextos(Me)
        DeshabilitarCombos(Me)
        If dt.Rows.Count = 0 Then
            'Al no encontrar datos en la tabla [Apuesta]
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
            If IsNumeric(txtBuscar.Text) Then
                '--Se realizara una busqueda por filtrando por el campo codigo en el campo codigo el mismo numero que txtBuscar.Text
                dv.RowFilter = cboBuscar.Text & " = " & txtBuscar.Text
            End If

            If txtBuscar.Text = "" Then
                dataApuesta.DataSource = dv
            End If

            If dv.Count <> 0 Then 'si la cantidad de registros de la consulta es distinta de 0
                dataApuesta.DataSource = dv
            Else
                dataApuesta.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de buscar las Apuestas." &
                            Environment.NewLine & "Descripción del error: " &
                            Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub dataApuesta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataApuesta.CellClick
        IDAGENCIA.Text = dataApuesta.CurrentRow.Cells("ID").Value
        cboAgencia.Text = dataApuesta.CurrentRow.Cells("NOMBRE").Value
        cboSorteo.Text = dataApuesta.CurrentRow.Cells("FECHA").Value
        cboApuesta.Text = dataApuesta.CurrentRow.Cells("MONTO").Value
        txtNumero.Text = dataApuesta.CurrentRow.Cells("NUMERO").Value

        btnModificar.Enabled = True
        btnEliminar.Enabled = True
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Buscar_Datos()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Respuesta As Integer = MessageBox.Show("Atención: ha seleccionado eliminar APUESTA. " &
                                                   Environment.NewLine & "¿Confirma la eliminación?",
                                                   "Eliminación de APUESTA",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If Respuesta = MsgBoxResult.Yes Then
            Try
                Dim dts As New logApuesta
                Dim FuncionInsertar As New fApuesta

                dts.pID = IDAGENCIA.Text

                If FuncionInsertar.Eliminar_Apuesta(dts) Then
                    Mostrar_Datos()
                    LimpiarTextos(Me)
                    Inicia_Pantalla()
                Else
                    MessageBox.Show("La Apuesta no se ha eliminado. Vuelva a intentarlo.",
                                    "Eliminar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Atención: se ha generado un error tratando de eliminar la Agencia." &
                                Environment.NewLine & "Descripción del error: " &
                                Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btncerrar_click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close() 'El formulario se referencia a si mismo y se cierra.
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If btnAgregar.Text = "Agregar" Then
            ModoPantalla = ModoPantalla.ModoALTA
            modFuncionesForm.LimpiarTextos(Me)
            modFuncionesForm.HabilitarTextos(Me)

            btnModificar.Text = "Cancelar" 'El botón Modificar pasa a ser Cancelar.
            btnModificar.Enabled = True
            btnBuscar.Enabled = False
            txtBuscar.Enabled = False
            cboBuscar.Enabled = False
            dataApuesta.Enabled = False
            cboApuesta.Enabled = True
            cboAgencia.Enabled = True
            cboSorteo.Enabled = True
            IDAGENCIA.Enabled = False
            btnEliminar.Enabled = False
            btnEliminar.Hide() 'Se oculta el boton eliminar
            btnAgregar.Text = "Confirmar" 'El botón Agregar pasa a ser Confirmar.
            txtNumero.Focus()
            'cboApuesta.Focus()

        Else

            'Validamos los controles.
            If txtNumero.Text = "" Then
                ErrProvApuesta.SetError(txtNumero, "Debe ingresar un Número")
                txtNumero.Focus()
                Exit Sub


            Else
                'ErrProvApuesta.SetError(txtNumero, "")
            End If

            If txtNumero.Text > 999 Or txtNumero.Text < 0 Then
                ErrProvApuesta.SetError(txtNumero, "Debe ingresar un Número Válido de hasta 3 cifras")
                txtNumero.Focus()
                Exit Sub
            Else
                'ErrProvApuesta.SetError(txtNumero, "")
            End If

            If ModoPantalla = ModoPantalla.ModoALTA Then
                Try
                    Dim dts As New logApuesta
                    Dim FuncionInsertar As New fApuesta

                    dts.pNumero = Convert.ToInt32(txtNumero.Text)
                    dts.pMonto = cboApuesta.SelectedItem
                    dts.pAgencia = cboAgencia.SelectedValue
                    dts.pSorteo = cboSorteo.SelectedValue

                    If FuncionInsertar.Insertar_Apuesta(dts) Then
                        Mostrar_Datos()
                        LimpiarTextos(Me)
                        Inicia_Pantalla()

                        btnAgregar.Text = "Agregar"
                        btnModificar.Text = "Modificar"
                        dataApuesta.Enabled = True
                    Else
                        MessageBox.Show("La Apuesta no se ha registrado. Vuelva a intentarlo.",
                                    "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Atención: se ha generado un error tratando de registrar la Apuesta." &
                                Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                                ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            ElseIf ModoPantalla = ModoPantalla.ModoMODIFICACION Then
                Try
                    Dim dts As New logApuesta
                    Dim FuncionInsertar As New fApuesta

                    dts.pID = IDAGENCIA.Text
                    dts.pNumero = Convert.ToInt32(txtNumero.Text)
                    dts.pMonto = cboApuesta.SelectedItem
                    dts.pAgencia = cboAgencia.SelectedValue
                    dts.pSorteo = cboSorteo.SelectedValue

                    If FuncionInsertar.Modificar_Apuesta(dts) Then
                        Mostrar_Datos()
                        LimpiarTextos(Me)
                        Inicia_Pantalla()

                        btnAgregar.Text = "Agregar"
                        btnModificar.Text = "Modificar"
                        dataApuesta.Enabled = True
                    Else
                        MessageBox.Show("La Apuesta no se ha modificado. Vuelva a intentarlo.",
                                        "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Atención: se ha generado un error tratando de modificar la Apuesta." &
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
            dataApuesta.Enabled = True
            btnEliminar.Show()
        Else
            ModoPantalla = modFuncionesForm.ModoPantalla.ModoMODIFICACION
            HabilitarTextos(Me)
            IDAGENCIA.Enabled = False
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            dataApuesta.Enabled = False
            cboBuscar.Enabled = True
            cboAgencia.Enabled = True
            cboSorteo.Enabled = True
            btnAgregar.Text = "Confirmar"
            btnModificar.Text = "Cancelar"
            btnModificar.Enabled = True
            btnEliminar.Hide()
            txtNumero.Focus()
        End If
    End Sub
End Class