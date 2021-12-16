<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteUsuarios2
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.LoteriaDataSet = New Loteria_2021.LoteriaDataSet()
        Me.Mostrar_Usuarios_DeshabilitadosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Mostrar_Usuarios_DeshabilitadosTableAdapter = New Loteria_2021.LoteriaDataSetTableAdapters.Mostrar_Usuarios_DeshabilitadosTableAdapter()
        CType(Me.LoteriaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mostrar_Usuarios_DeshabilitadosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSetU2"
        ReportDataSource1.Value = Me.Mostrar_Usuarios_DeshabilitadosBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Loteria_2021.ReporteUsuarios2.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 0
        '
        'LoteriaDataSet
        '
        Me.LoteriaDataSet.DataSetName = "LoteriaDataSet"
        Me.LoteriaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Mostrar_Usuarios_DeshabilitadosBindingSource
        '
        Me.Mostrar_Usuarios_DeshabilitadosBindingSource.DataMember = "Mostrar_Usuarios_Deshabilitados"
        Me.Mostrar_Usuarios_DeshabilitadosBindingSource.DataSource = Me.LoteriaDataSet
        '
        'Mostrar_Usuarios_DeshabilitadosTableAdapter
        '
        Me.Mostrar_Usuarios_DeshabilitadosTableAdapter.ClearBeforeFill = True
        '
        'ReporteUsuarios2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "ReporteUsuarios2"
        Me.Text = "ReporteUsuarios2"
        CType(Me.LoteriaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mostrar_Usuarios_DeshabilitadosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Mostrar_Usuarios_DeshabilitadosBindingSource As BindingSource
    Friend WithEvents LoteriaDataSet As LoteriaDataSet
    Friend WithEvents Mostrar_Usuarios_DeshabilitadosTableAdapter As LoteriaDataSetTableAdapters.Mostrar_Usuarios_DeshabilitadosTableAdapter
End Class
