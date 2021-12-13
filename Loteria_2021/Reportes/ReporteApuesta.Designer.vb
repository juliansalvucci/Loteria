<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteApuesta
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
        Me.LoteriaDataSetLote = New Loteria_2021.LoteriaDataSetLote()
        Me.Reporte_ApuestaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Reporte_ApuestaTableAdapter = New Loteria_2021.LoteriaDataSetLoteTableAdapters.Reporte_ApuestaTableAdapter()
        CType(Me.LoteriaDataSetLote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Reporte_ApuestaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSetLot2"
        ReportDataSource1.Value = Me.Reporte_ApuestaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Loteria_2021.ReporteApuesta.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 0
        '
        'LoteriaDataSetLote
        '
        Me.LoteriaDataSetLote.DataSetName = "LoteriaDataSetLote"
        Me.LoteriaDataSetLote.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Reporte_ApuestaBindingSource
        '
        Me.Reporte_ApuestaBindingSource.DataMember = "Reporte_Apuesta"
        Me.Reporte_ApuestaBindingSource.DataSource = Me.LoteriaDataSetLote
        '
        'Reporte_ApuestaTableAdapter
        '
        Me.Reporte_ApuestaTableAdapter.ClearBeforeFill = True
        '
        'ReporteApuesta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "ReporteApuesta"
        Me.Text = "ReporteApuesta"
        CType(Me.LoteriaDataSetLote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Reporte_ApuestaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Reporte_ApuestaBindingSource As BindingSource
    Friend WithEvents LoteriaDataSetLote As LoteriaDataSetLote
    Friend WithEvents Reporte_ApuestaTableAdapter As LoteriaDataSetLoteTableAdapters.Reporte_ApuestaTableAdapter
End Class
