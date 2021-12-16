<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ABMCTipoSorteoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipoSorteroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuarioToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgenciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApuestaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SorteoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrosEn24hsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeshabilitadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgenciaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApuestaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SorteoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ABMCTipoSorteoToolStripMenuItem, Me.ReportesToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'ABMCTipoSorteoToolStripMenuItem
        '
        Me.ABMCTipoSorteoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TipoSorteroToolStripMenuItem, Me.UsuarioToolStripMenuItem1, Me.AgenciaToolStripMenuItem, Me.ApuestaToolStripMenuItem, Me.SorteoToolStripMenuItem})
        Me.ABMCTipoSorteoToolStripMenuItem.Name = "ABMCTipoSorteoToolStripMenuItem"
        Me.ABMCTipoSorteoToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.ABMCTipoSorteoToolStripMenuItem.Text = "ABMC "
        '
        'TipoSorteroToolStripMenuItem
        '
        Me.TipoSorteroToolStripMenuItem.Name = "TipoSorteroToolStripMenuItem"
        Me.TipoSorteroToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.TipoSorteroToolStripMenuItem.Text = "Tipo Sortero"
        '
        'UsuarioToolStripMenuItem1
        '
        Me.UsuarioToolStripMenuItem1.Name = "UsuarioToolStripMenuItem1"
        Me.UsuarioToolStripMenuItem1.Size = New System.Drawing.Size(138, 22)
        Me.UsuarioToolStripMenuItem1.Text = "Usuario"
        '
        'AgenciaToolStripMenuItem
        '
        Me.AgenciaToolStripMenuItem.Name = "AgenciaToolStripMenuItem"
        Me.AgenciaToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.AgenciaToolStripMenuItem.Text = "Agencia"
        '
        'ApuestaToolStripMenuItem
        '
        Me.ApuestaToolStripMenuItem.Name = "ApuestaToolStripMenuItem"
        Me.ApuestaToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.ApuestaToolStripMenuItem.Text = "Apuesta"
        '
        'SorteoToolStripMenuItem
        '
        Me.SorteoToolStripMenuItem.Name = "SorteoToolStripMenuItem"
        Me.SorteoToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.SorteoToolStripMenuItem.Text = "Sorteo"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsuariosToolStripMenuItem, Me.AgenciaToolStripMenuItem1, Me.ApuestaToolStripMenuItem1, Me.SorteoToolStripMenuItem1})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrosEn24hsToolStripMenuItem, Me.DeshabilitadosToolStripMenuItem})
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.UsuariosToolStripMenuItem.Text = "Usuarios"
        '
        'RegistrosEn24hsToolStripMenuItem
        '
        Me.RegistrosEn24hsToolStripMenuItem.Name = "RegistrosEn24hsToolStripMenuItem"
        Me.RegistrosEn24hsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RegistrosEn24hsToolStripMenuItem.Text = "Registros en 24hs"
        '
        'DeshabilitadosToolStripMenuItem
        '
        Me.DeshabilitadosToolStripMenuItem.Name = "DeshabilitadosToolStripMenuItem"
        Me.DeshabilitadosToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DeshabilitadosToolStripMenuItem.Text = "Deshabilitados"
        '
        'AgenciaToolStripMenuItem1
        '
        Me.AgenciaToolStripMenuItem1.Name = "AgenciaToolStripMenuItem1"
        Me.AgenciaToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.AgenciaToolStripMenuItem1.Text = "Agencia"
        '
        'ApuestaToolStripMenuItem1
        '
        Me.ApuestaToolStripMenuItem1.Name = "ApuestaToolStripMenuItem1"
        Me.ApuestaToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.ApuestaToolStripMenuItem1.Text = "Apuesta"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(632, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel.Text = "Estado"
        '
        'SorteoToolStripMenuItem1
        '
        Me.SorteoToolStripMenuItem1.Name = "SorteoToolStripMenuItem1"
        Me.SorteoToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.SorteoToolStripMenuItem1.Text = "Sorteo"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Loteria_2021.My.Resources.Resources.bingo
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrincipal"
        Me.Text = "Inicio"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ABMCTipoSorteoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TipoSorteroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsuarioToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AgenciaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AgenciaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ApuestaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SorteoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ApuestaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RegistrosEn24hsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeshabilitadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SorteoToolStripMenuItem1 As ToolStripMenuItem
End Class
