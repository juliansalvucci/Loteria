<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteUsuarios
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.obtener_usuariosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LoteriaDataSet = New Loteria_2021.LoteriaDataSet()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.obtener_usuariosTableAdapter = New Loteria_2021.LoteriaDataSetTableAdapters.obtener_usuariosTableAdapter()
        CType(Me.obtener_usuariosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoteriaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'obtener_usuariosBindingSource
        '
        Me.obtener_usuariosBindingSource.DataMember = "obtener_usuarios"
        Me.obtener_usuariosBindingSource.DataSource = Me.LoteriaDataSet
        '
        'LoteriaDataSet
        '
        Me.LoteriaDataSet.DataSetName = "LoteriaDataSet"
        Me.LoteriaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSetUsuario"
        ReportDataSource1.Value = Me.obtener_usuariosBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Loteria_2021.ReporteUsuarios.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 0
        '
        'obtener_usuariosTableAdapter
        '
        Me.obtener_usuariosTableAdapter.ClearBeforeFill = True
        '
        'ReporteUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "ReporteUsuarios"
        Me.Text = "ReporteUsuarios"
        CType(Me.obtener_usuariosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoteriaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents obtener_usuariosBindingSource As BindingSource
    Friend WithEvents LoteriaDataSet As LoteriaDataSet
    Friend WithEvents obtener_usuariosTableAdapter As LoteriaDataSetTableAdapters.obtener_usuariosTableAdapter
End Class
