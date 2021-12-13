<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmApuesta
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboApuesta = New System.Windows.Forms.ComboBox()
        Me.cboSorteo = New System.Windows.Forms.ComboBox()
        Me.cboAgencia = New System.Windows.Forms.ComboBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.IDAGENCIA = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dataApuesta = New System.Windows.Forms.DataGridView()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.cboBuscar = New System.Windows.Forms.ComboBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.ErrProvApuesta = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dataApuesta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ErrProvApuesta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboApuesta)
        Me.GroupBox1.Controls.Add(Me.cboSorteo)
        Me.GroupBox1.Controls.Add(Me.cboAgencia)
        Me.GroupBox1.Controls.Add(Me.txtNumero)
        Me.GroupBox1.Controls.Add(Me.IDAGENCIA)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(342, 179)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'cboApuesta
        '
        Me.cboApuesta.FormattingEnabled = True
        Me.cboApuesta.Items.AddRange(New Object() {"10,0000", "20,0000", "30,0000", "40,0000", "50,0000", "60,0000", "70,0000", "80,0000", "90,0000", "100,0000"})
        Me.cboApuesta.Location = New System.Drawing.Point(183, 52)
        Me.cboApuesta.Name = "cboApuesta"
        Me.cboApuesta.Size = New System.Drawing.Size(121, 21)
        Me.cboApuesta.TabIndex = 4
        '
        'cboSorteo
        '
        Me.cboSorteo.FormattingEnabled = True
        Me.cboSorteo.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboSorteo.Location = New System.Drawing.Point(8, 87)
        Me.cboSorteo.Name = "cboSorteo"
        Me.cboSorteo.Size = New System.Drawing.Size(121, 21)
        Me.cboSorteo.TabIndex = 3
        '
        'cboAgencia
        '
        Me.cboAgencia.FormattingEnabled = True
        Me.cboAgencia.Location = New System.Drawing.Point(8, 52)
        Me.cboAgencia.Name = "cboAgencia"
        Me.cboAgencia.Size = New System.Drawing.Size(121, 21)
        Me.cboAgencia.TabIndex = 2
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(183, 88)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(121, 20)
        Me.txtNumero.TabIndex = 1
        '
        'IDAGENCIA
        '
        Me.IDAGENCIA.Enabled = False
        Me.IDAGENCIA.Location = New System.Drawing.Point(8, 19)
        Me.IDAGENCIA.Name = "IDAGENCIA"
        Me.IDAGENCIA.Size = New System.Drawing.Size(100, 20)
        Me.IDAGENCIA.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dataApuesta)
        Me.GroupBox2.Controls.Add(Me.txtBuscar)
        Me.GroupBox2.Controls.Add(Me.cboBuscar)
        Me.GroupBox2.Controls.Add(Me.btnBuscar)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 197)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(548, 170)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        '
        'dataApuesta
        '
        Me.dataApuesta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataApuesta.Location = New System.Drawing.Point(19, 45)
        Me.dataApuesta.Name = "dataApuesta"
        Me.dataApuesta.Size = New System.Drawing.Size(479, 150)
        Me.dataApuesta.TabIndex = 6
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(183, 19)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(121, 20)
        Me.txtBuscar.TabIndex = 5
        '
        'cboBuscar
        '
        Me.cboBuscar.FormattingEnabled = True
        Me.cboBuscar.Items.AddRange(New Object() {"ID", "NUMERO"})
        Me.cboBuscar.Location = New System.Drawing.Point(19, 19)
        Me.cboBuscar.Name = "cboBuscar"
        Me.cboBuscar.Size = New System.Drawing.Size(121, 21)
        Me.cboBuscar.TabIndex = 5
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(417, 19)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnEliminar)
        Me.GroupBox3.Controls.Add(Me.btnModificar)
        Me.GroupBox3.Controls.Add(Me.btnAgregar)
        Me.GroupBox3.Location = New System.Drawing.Point(360, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 179)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "GroupBox3"
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(60, 139)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(60, 85)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 23)
        Me.btnModificar.TabIndex = 1
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(60, 28)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 0
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'ErrProvApuesta
        '
        Me.ErrProvApuesta.ContainerControl = Me
        '
        'frmApuesta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmApuesta"
        Me.Text = "frmApuesta"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dataApuesta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.ErrProvApuesta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboApuesta As ComboBox
    Friend WithEvents cboSorteo As ComboBox
    Friend WithEvents cboAgencia As ComboBox
    Friend WithEvents txtNumero As TextBox
    Friend WithEvents IDAGENCIA As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cboBuscar As ComboBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents dataApuesta As DataGridView
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents ErrProvApuesta As ErrorProvider
End Class
