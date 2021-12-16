<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteSorteo
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
        Me.Reporte_SorteoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LoteriaDataSet = New Loteria_2021.LoteriaDataSet()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Reporte_SorteoTableAdapter = New Loteria_2021.LoteriaDataSetTableAdapters.Reporte_SorteoTableAdapter()
        CType(Me.Reporte_SorteoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoteriaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Reporte_SorteoBindingSource
        '
        Me.Reporte_SorteoBindingSource.DataMember = "Reporte_Sorteo"
        Me.Reporte_SorteoBindingSource.DataSource = Me.LoteriaDataSet
        '
        'LoteriaDataSet
        '
        Me.LoteriaDataSet.DataSetName = "LoteriaDataSet"
        Me.LoteriaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSetSorteo"
        ReportDataSource1.Value = Me.Reporte_SorteoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Loteria_2021.ReporteSorteo.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 0
        '
        'Reporte_SorteoTableAdapter
        '
        Me.Reporte_SorteoTableAdapter.ClearBeforeFill = True
        '
        'ReporteSorteo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "ReporteSorteo"
        Me.Text = "ReporteSorteo"
        CType(Me.Reporte_SorteoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoteriaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Reporte_SorteoBindingSource As BindingSource
    Friend WithEvents LoteriaDataSet As LoteriaDataSet
    Friend WithEvents Reporte_SorteoTableAdapter As LoteriaDataSetTableAdapters.Reporte_SorteoTableAdapter
End Class
