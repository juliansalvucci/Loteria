Public Class frmTipoSorteo
    Private Sub frmTipoSorteo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar_Datos()
        Inicia_Pantalla()
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Buscar_Datos()
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If btnAgregar.Text = "Agregar" Then
            LimpiarTextos(Me)
            HabilitarTextos(Me)
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            btnCerrar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            dataTipoSorteo.Enabled = False
            'El botón Agregar pasa a ser Confirmar.
            'El botón Modificar pasa a ser Cancelar.
            btnAgregar.Text = "Confirmar"
            btnModificar.Text = "Cancelar"
            txtNombre.Focus()
        Else

            'Validamos los controles.
            If txtNombre.Text = "" Then
                ErrProvTipoSorteo.SetError(txtNombre, "Debe ingresar un nombre para el Tipo de Sorteo")
                txtNombre.Focus()
                Exit Sub
            Else
                ErrProvTipoSorteo.SetError(txtNombre, "")
            End If
            Try
                Dim dts As New logTipoSorteo
                Dim FuncionInsertar As New fTipoSorteo
                dts.pNombre = txtNombre.Text
                dts.pDescripcion = txtDescripcion.Text
                If FuncionInsertar.Insertar_TipoSorteo(dts) Then
                    Mostrar_Datos()
                    LimpiarTextos(Me)
                    Inicia_Pantalla()
                Else
                    MessageBox.Show("El tipo de sorteo no se ha registrado. Vuelva a intentarlo.",
                    "Confirmar registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Atención: se ha generado un error tratando de registrar el tipo de
 sorteo." & Environment.NewLine & "Descripción del error: " & Environment.NewLine &
                ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub dataTipoSorteo_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        txtID.Text = dataTipoSorteo.SelectedCells.Item(0).Value
        txtNombre.Text = dataTipoSorteo.SelectedCells.Item(1).Value
        txtDescripcion.Text = dataTipoSorteo.SelectedCells.Item(2).Value
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If btnModificar.Text = "Cancelar" Then
            ModoPantalla = ModoPantalla.ModoConsulta
            Inicia_Pantalla()
            btnAgregar.Text = "Agregar"
            btnModificar.Text = "Modificar"
            btnCerrar.Enabled = True
            dataTipoSorteo.Enabled = True
            ErrProvTipoSorteo.SetError(txtNombre, "")
        Else
            ModoPantalla = ModoPantalla.ModoMODIFICACION
            HabilitarTextos(Me)
            btnEliminar.Enabled = False
            btnBuscar.Enabled = False
            btnCerrar.Enabled = False
            cboBuscar.Enabled = False
            txtBuscar.Enabled = False
            dataTipoSorteo.Enabled = False
            btnAgregar.Text = "Confirmar"
            btnModificar.Text = "Cancelar"
            txtNombre.Focus()
        End If
    End Sub
End Class