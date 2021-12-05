<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Logistik
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tanggal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Estimasi"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Customer"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 186)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Invoice"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(152, 35)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(125, 27)
        Me.TextBox1.TabIndex = 4
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(152, 87)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(125, 27)
        Me.TextBox2.TabIndex = 5
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(152, 137)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(151, 28)
        Me.ComboBox1.TabIndex = 6
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(152, 186)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(151, 28)
        Me.ComboBox2.TabIndex = 7
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(152, 233)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 29
        Me.DataGridView1.Size = New System.Drawing.Size(495, 188)
        Me.DataGridView1.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(34, 445)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 29)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Logistik
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 532)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Logistik"
        Me.Text = "Logistik"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
End Class
