Public Class frmRegister
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

        Try
            Dim dts As New logUsuario
            Dim FuncionAlta As New fUsuario

            dts.pNombreUsu = txtNombre.Text
            dts.pLogin = txtLogin.Text
            dts.pPassword = txtPassword.Text
            dts.pPassword = txtPassValidator.Text

            If txtPassword.Text = txtPassValidator.Text Then
                If FuncionAlta.Alta_Usuario(dts) Then
                    MessageBox.Show("Usuario registrado en éxito", "Confirmar registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("El Usuario no se ha registrado. Vuelva a intentarlo.", "Confirmar registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha generado un error tratando de registrar el Usuario." &
                        Environment.NewLine & "Descripción del error: " & Environment.NewLine & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class