<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QualityControl
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tanggal Produksi"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(168, 39)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(151, 28)
        Me.ComboBox1.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(168, 109)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 29
        Me.DataGridView1.Size = New System.Drawing.Size(488, 188)
        Me.DataGridView1.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(55, 348)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 29)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'QualityControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "QualityControl"
        Me.Text = "QualityControl"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
End Class
