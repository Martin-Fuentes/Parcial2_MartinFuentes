<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarCompra
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
        Me.imgAuto = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCant = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnSigui = New System.Windows.Forms.Button()
        Me.btnAnte = New System.Windows.Forms.Button()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTot = New System.Windows.Forms.Label()
        Me.lblCant = New System.Windows.Forms.Label()
        CType(Me.imgAuto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imgAuto
        '
        Me.imgAuto.Location = New System.Drawing.Point(19, 244)
        Me.imgAuto.Name = "imgAuto"
        Me.imgAuto.Size = New System.Drawing.Size(373, 221)
        Me.imgAuto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgAuto.TabIndex = 14
        Me.imgAuto.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Marca"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(70, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Modelo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Cantidad disponible"
        '
        'txtCant
        '
        Me.txtCant.Location = New System.Drawing.Point(132, 130)
        Me.txtCant.Name = "txtCant"
        Me.txtCant.ReadOnly = True
        Me.txtCant.Size = New System.Drawing.Size(229, 20)
        Me.txtCant.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(75, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Precio"
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(132, 179)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.ReadOnly = True
        Me.txtPrecio.Size = New System.Drawing.Size(229, 20)
        Me.txtPrecio.TabIndex = 22
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(424, 283)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(116, 34)
        Me.btnAgregar.TabIndex = 26
        Me.btnAgregar.Text = "Agregar a mi compra"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(424, 386)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 34)
        Me.Button2.TabIndex = 27
        Me.Button2.Text = "Comprar todo"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnSigui
        '
        Me.btnSigui.Location = New System.Drawing.Point(341, 582)
        Me.btnSigui.Name = "btnSigui"
        Me.btnSigui.Size = New System.Drawing.Size(116, 34)
        Me.btnSigui.TabIndex = 28
        Me.btnSigui.Text = "Siguiente >>"
        Me.btnSigui.UseVisualStyleBackColor = True
        '
        'btnAnte
        '
        Me.btnAnte.Location = New System.Drawing.Point(73, 582)
        Me.btnAnte.Name = "btnAnte"
        Me.btnAnte.Size = New System.Drawing.Size(116, 34)
        Me.btnAnte.TabIndex = 29
        Me.btnAnte.Text = "<< Anterior"
        Me.btnAnte.UseVisualStyleBackColor = True
        '
        'txtModelo
        '
        Me.txtModelo.Location = New System.Drawing.Point(132, 77)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.ReadOnly = True
        Me.txtModelo.Size = New System.Drawing.Size(229, 20)
        Me.txtModelo.TabIndex = 30
        '
        'txtMarca
        '
        Me.txtMarca.Location = New System.Drawing.Point(132, 35)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(229, 20)
        Me.txtMarca.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(258, 511)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Precio"
        '
        'lblTot
        '
        Me.lblTot.AutoSize = True
        Me.lblTot.Location = New System.Drawing.Point(394, 94)
        Me.lblTot.Name = "lblTot"
        Me.lblTot.Size = New System.Drawing.Size(0, 13)
        Me.lblTot.TabIndex = 33
        '
        'lblCant
        '
        Me.lblCant.AutoSize = True
        Me.lblCant.Location = New System.Drawing.Point(394, 130)
        Me.lblCant.Name = "lblCant"
        Me.lblCant.Size = New System.Drawing.Size(0, 13)
        Me.lblCant.TabIndex = 34
        '
        'AgregarCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 628)
        Me.Controls.Add(Me.lblCant)
        Me.Controls.Add(Me.lblTot)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtMarca)
        Me.Controls.Add(Me.txtModelo)
        Me.Controls.Add(Me.btnAnte)
        Me.Controls.Add(Me.btnSigui)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCant)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.imgAuto)
        Me.Name = "AgregarCompra"
        Me.Text = "AgregarCompra"
        CType(Me.imgAuto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents imgAuto As Windows.Forms.PictureBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents txtCant As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents txtPrecio As Windows.Forms.TextBox
    Friend WithEvents btnAgregar As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents btnSigui As Windows.Forms.Button
    Friend WithEvents btnAnte As Windows.Forms.Button
    Friend WithEvents txtModelo As Windows.Forms.TextBox
    Friend WithEvents txtMarca As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents lblTot As Windows.Forms.Label
    Friend WithEvents lblCant As Windows.Forms.Label
End Class
