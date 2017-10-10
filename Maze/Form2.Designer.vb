<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nudSizeX = New System.Windows.Forms.NumericUpDown()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.nudWidth = New System.Windows.Forms.NumericUpDown()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudSizeX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nudSizeX)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 25)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.GroupBox1.Size = New System.Drawing.Size(168, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Square Size"
        Me.ToolTip1.SetToolTip(Me.GroupBox1, "Changes the actual size of the squares")
        '
        'nudSizeX
        '
        Me.nudSizeX.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nudSizeX.Location = New System.Drawing.Point(14, 38)
        Me.nudSizeX.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.nudSizeX.Maximum = New Decimal(New Integer() {41, 0, 0, 0})
        Me.nudSizeX.Minimum = New Decimal(New Integer() {11, 0, 0, 0})
        Me.nudSizeX.Name = "nudSizeX"
        Me.nudSizeX.Size = New System.Drawing.Size(134, 31)
        Me.nudSizeX.TabIndex = 0
        Me.nudSizeX.Value = New Decimal(New Integer() {31, 0, 0, 0})
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(24, 137)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(150, 44)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.nudWidth)
        Me.GroupBox2.Location = New System.Drawing.Point(214, 25)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.GroupBox2.Size = New System.Drawing.Size(168, 100)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Grid Size"
        Me.ToolTip1.SetToolTip(Me.GroupBox2, "Changes the size of the playing feild")
        '
        'nudWidth
        '
        Me.nudWidth.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nudWidth.Location = New System.Drawing.Point(14, 38)
        Me.nudWidth.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.nudWidth.Maximum = New Decimal(New Integer() {39, 0, 0, 0})
        Me.nudWidth.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudWidth.Name = "nudWidth"
        Me.nudWidth.Size = New System.Drawing.Size(134, 31)
        Me.nudWidth.TabIndex = 2
        Me.nudWidth.Value = New Decimal(New Integer() {9, 0, 0, 0})
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 192)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "Form2"
        Me.Text = "Advanced Options"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.nudSizeX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.nudWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents nudSizeX As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents nudWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
