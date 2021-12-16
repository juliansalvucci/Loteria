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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dataApuesta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ErrProvApuesta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboApuesta)
        Me.GroupBox1.Controls.Add(Me.cboSorteo)
        Me.GroupBox1.Controls.Add(Me.cboAgencia)
        Me.GroupBox1.Controls.Add(Me.txtNumero)
        Me.GroupBox1.Controls.Add(Me.IDAGENCIA)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 151)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(246, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Número"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(246, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Apuesta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Sorteo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Agencia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "ID Agencia"
        '
        'cboApuesta
        '
        Me.cboApuesta.FormattingEnabled = True
        Me.cboApuesta.Items.AddRange(New Object() {"10,0000", "20,0000", "30,0000", "40,0000", "50,0000", "60,0000", "70,0000", "80,0000", "90,0000", "100,0000"})
        Me.cboApuesta.Location = New System.Drawing.Point(305, 18)
        Me.cboApuesta.Name = "cboApuesta"
        Me.cboApuesta.Size = New System.Drawing.Size(110, 21)
        Me.cboApuesta.TabIndex = 4
        '
        'cboSorteo
        '
        Me.cboSorteo.FormattingEnabled = True
        Me.cboSorteo.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboSorteo.Location = New System.Drawing.Point(97, 72)
        Me.cboSorteo.Name = "cboSorteo"
        Me.cboSorteo.Size = New System.Drawing.Size(110, 21)
        Me.cboSorteo.TabIndex = 3
        '
        'cboAgencia
        '
        Me.cboAgencia.FormattingEnabled = True
        Me.cboAgencia.Location = New System.Drawing.Point(97, 45)
        Me.cboAgencia.Name = "cboAgencia"
        Me.cboAgencia.Size = New System.Drawing.Size(110, 21)
        Me.cboAgencia.TabIndex = 2
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(305, 45)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(110, 20)
        Me.txtNumero.TabIndex = 1
        '
        'IDAGENCIA
        '
        Me.IDAGENCIA.Enabled = False
        Me.IDAGENCIA.Location = New System.Drawing.Point(97, 19)
        Me.IDAGENCIA.Name = "IDAGENCIA"
        Me.IDAGENCIA.Size = New System.Drawing.Size(110, 20)
        Me.IDAGENCIA.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dataApuesta)
        Me.GroupBox2.Controls.Add(Me.txtBuscar)
        Me.GroupBox2.Controls.Add(Me.cboBuscar)
        Me.GroupBox2.Controls.Add(Me.btnBuscar)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 213)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(563, 197)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'dataApuesta
        '
        Me.dataApuesta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataApuesta.Location = New System.Drawing.Point(14, 61)
        Me.dataApuesta.Name = "dataApuesta"
        Me.dataApuesta.Size = New System.Drawing.Size(536, 125)
        Me.dataApuesta.TabIndex = 6
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(140, 27)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(315, 20)
        Me.txtBuscar.TabIndex = 5
        '
        'cboBuscar
        '
        Me.cboBuscar.FormattingEnabled = True
        Me.cboBuscar.Items.AddRange(New Object() {"ID", "NUMERO"})
        Me.cboBuscar.Location = New System.Drawing.Point(14, 26)
        Me.cboBuscar.Name = "cboBuscar"
        Me.cboBuscar.Size = New System.Drawing.Size(121, 21)
        Me.cboBuscar.TabIndex = 5
        '
        'btnBuscar
        '
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Image = Global.Loteria_2021.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.Location = New System.Drawing.Point(461, 17)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(89, 38)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnEliminar)
        Me.GroupBox3.Controls.Add(Me.btnModificar)
        Me.GroupBox3.Controls.Add(Me.btnAgregar)
        Me.GroupBox3.Location = New System.Drawing.Point(444, 56)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(122, 151)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'btnEliminar
        '
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Image = Global.Loteria_2021.My.Resources.Resources.Quitar_Todo
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.Location = New System.Drawing.Point(20, 105)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(89, 38)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModificar.Image = Global.Loteria_2021.My.Resources.Resources.Editar
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModificar.Location = New System.Drawing.Point(20, 59)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(89, 38)
        Me.btnModificar.TabIndex = 1
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Image = Global.Loteria_2021.My.Resources.Resources.Agregar_Todo
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregar.Location = New System.Drawing.Point(20, 15)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(89, 38)
        Me.btnAgregar.TabIndex = 0
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'ErrProvApuesta
        '
        Me.ErrProvApuesta.ContainerControl = Me
        '
        'btnCerrar
        '
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Location = New System.Drawing.Point(466, 416)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(89, 38)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(563, 47)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(43, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(445, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Formulario para realizar Alta, Modificación y Consulta sobre Apuestas"
        '
        'frmApuesta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 466)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmApuesta"
        Me.Text = "ABMC Apuestas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dataApuesta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.ErrProvApuesta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
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
    Friend WithEvents btnCerrar As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
