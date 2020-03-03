<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Me.components = New System.ComponentModel.Container
        Me.timeLabel = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.plusLeftLabel = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.plusRightLabel = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.sum = New System.Windows.Forms.NumericUpDown
        Me.difference = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.minusRightLabel = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.minusLeftLabel = New System.Windows.Forms.Label
        Me.product = New System.Windows.Forms.NumericUpDown
        Me.Label8 = New System.Windows.Forms.Label
        Me.timesRightLabel = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.timesLeftLabel = New System.Windows.Forms.Label
        Me.quotient = New System.Windows.Forms.NumericUpDown
        Me.Label12 = New System.Windows.Forms.Label
        Me.dividedRightLabel = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.dividedLeftLabel = New System.Windows.Forms.Label
        Me.startButton = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.sum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.difference, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.product, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.quotient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'timeLabel
        '
        Me.timeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.timeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timeLabel.Location = New System.Drawing.Point(280, 9)
        Me.timeLabel.Name = "timeLabel"
        Me.timeLabel.Size = New System.Drawing.Size(200, 30)
        Me.timeLabel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(173, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Time Left"
        '
        'plusLeftLabel
        '
        Me.plusLeftLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plusLeftLabel.Location = New System.Drawing.Point(75, 75)
        Me.plusLeftLabel.Name = "plusLeftLabel"
        Me.plusLeftLabel.Size = New System.Drawing.Size(60, 50)
        Me.plusLeftLabel.TabIndex = 2
        Me.plusLeftLabel.Text = "?"
        Me.plusLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(141, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 50)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "+"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'plusRightLabel
        '
        Me.plusRightLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plusRightLabel.Location = New System.Drawing.Point(207, 75)
        Me.plusRightLabel.Name = "plusRightLabel"
        Me.plusRightLabel.Size = New System.Drawing.Size(60, 50)
        Me.plusRightLabel.TabIndex = 4
        Me.plusRightLabel.Text = "?"
        Me.plusRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(273, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 50)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "="
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sum
        '
        Me.sum.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sum.Location = New System.Drawing.Point(339, 84)
        Me.sum.Name = "sum"
        Me.sum.Size = New System.Drawing.Size(100, 35)
        Me.sum.TabIndex = 2
        '
        'difference
        '
        Me.difference.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.difference.Location = New System.Drawing.Point(339, 125)
        Me.difference.Name = "difference"
        Me.difference.Size = New System.Drawing.Size(100, 35)
        Me.difference.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(273, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 50)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "="
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'minusRightLabel
        '
        Me.minusRightLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minusRightLabel.Location = New System.Drawing.Point(207, 116)
        Me.minusRightLabel.Name = "minusRightLabel"
        Me.minusRightLabel.Size = New System.Drawing.Size(60, 50)
        Me.minusRightLabel.TabIndex = 9
        Me.minusRightLabel.Text = "?"
        Me.minusRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(141, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 50)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "-"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'minusLeftLabel
        '
        Me.minusLeftLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minusLeftLabel.Location = New System.Drawing.Point(75, 116)
        Me.minusLeftLabel.Name = "minusLeftLabel"
        Me.minusLeftLabel.Size = New System.Drawing.Size(60, 50)
        Me.minusLeftLabel.TabIndex = 7
        Me.minusLeftLabel.Text = "?"
        Me.minusLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'product
        '
        Me.product.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.product.Location = New System.Drawing.Point(339, 166)
        Me.product.Name = "product"
        Me.product.Size = New System.Drawing.Size(100, 35)
        Me.product.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(273, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 50)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "="
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timesRightLabel
        '
        Me.timesRightLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timesRightLabel.Location = New System.Drawing.Point(207, 157)
        Me.timesRightLabel.Name = "timesRightLabel"
        Me.timesRightLabel.Size = New System.Drawing.Size(60, 50)
        Me.timesRightLabel.TabIndex = 14
        Me.timesRightLabel.Text = "?"
        Me.timesRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(141, 157)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 50)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "×"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timesLeftLabel
        '
        Me.timesLeftLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timesLeftLabel.Location = New System.Drawing.Point(75, 157)
        Me.timesLeftLabel.Name = "timesLeftLabel"
        Me.timesLeftLabel.Size = New System.Drawing.Size(60, 50)
        Me.timesLeftLabel.TabIndex = 12
        Me.timesLeftLabel.Text = "?"
        Me.timesLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'quotient
        '
        Me.quotient.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quotient.Location = New System.Drawing.Point(339, 207)
        Me.quotient.Name = "quotient"
        Me.quotient.Size = New System.Drawing.Size(100, 35)
        Me.quotient.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(273, 198)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 50)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "="
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dividedRightLabel
        '
        Me.dividedRightLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dividedRightLabel.Location = New System.Drawing.Point(207, 198)
        Me.dividedRightLabel.Name = "dividedRightLabel"
        Me.dividedRightLabel.Size = New System.Drawing.Size(60, 50)
        Me.dividedRightLabel.TabIndex = 19
        Me.dividedRightLabel.Text = "?"
        Me.dividedRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(141, 198)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 50)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "÷"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dividedLeftLabel
        '
        Me.dividedLeftLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dividedLeftLabel.Location = New System.Drawing.Point(75, 198)
        Me.dividedLeftLabel.Name = "dividedLeftLabel"
        Me.dividedLeftLabel.Size = New System.Drawing.Size(60, 50)
        Me.dividedLeftLabel.TabIndex = 17
        Me.dividedLeftLabel.Text = "?"
        Me.dividedLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'startButton
        '
        Me.startButton.AutoSize = True
        Me.startButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startButton.Location = New System.Drawing.Point(178, 320)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(132, 34)
        Me.startButton.TabIndex = 1
        Me.startButton.Text = "Start the quiz!"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 366)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.quotient)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.dividedRightLabel)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.dividedLeftLabel)
        Me.Controls.Add(Me.product)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.timesRightLabel)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.timesLeftLabel)
        Me.Controls.Add(Me.difference)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.minusRightLabel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.minusLeftLabel)
        Me.Controls.Add(Me.sum)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.plusRightLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.plusLeftLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.timeLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Math Quiz"
        CType(Me.sum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.difference, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.product, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.quotient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents timeLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents plusLeftLabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents plusRightLabel As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents sum As System.Windows.Forms.NumericUpDown
    Friend WithEvents difference As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents minusRightLabel As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents minusLeftLabel As System.Windows.Forms.Label
    Friend WithEvents product As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents timesRightLabel As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents timesLeftLabel As System.Windows.Forms.Label
    Friend WithEvents quotient As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dividedRightLabel As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dividedLeftLabel As System.Windows.Forms.Label
    Friend WithEvents startButton As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class


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
        Me.components = New System.ComponentModel.Container
        Me.timeLabel = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.plusLeftLabel = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.plusRightLabel = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.sum = New System.Windows.Forms.NumericUpDown
        Me.difference = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.minusRightLabel = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.minusLeftLabel = New System.Windows.Forms.Label
        Me.product = New System.Windows.Forms.NumericUpDown
        Me.Label8 = New System.Windows.Forms.Label
        Me.timesRightLabel = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.timesLeftLabel = New System.Windows.Forms.Label
        Me.quotient = New System.Windows.Forms.NumericUpDown
        Me.Label12 = New System.Windows.Forms.Label
        Me.dividedRightLabel = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.dividedLeftLabel = New System.Windows.Forms.Label
        Me.startButton = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.sum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.difference, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.product, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.quotient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'timeLabel
        '
        Me.timeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.timeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timeLabel.Location = New System.Drawing.Point(280, 9)
        Me.timeLabel.Name = "timeLabel"
        Me.timeLabel.Size = New System.Drawing.Size(200, 30)
        Me.timeLabel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(173, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Time Left"
        '
        'plusLeftLabel
        '
        Me.plusLeftLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plusLeftLabel.Location = New System.Drawing.Point(75, 75)
        Me.plusLeftLabel.Name = "plusLeftLabel"
        Me.plusLeftLabel.Size = New System.Drawing.Size(60, 50)
        Me.plusLeftLabel.TabIndex = 2
        Me.plusLeftLabel.Text = "?"
        Me.plusLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(141, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 50)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "+"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'plusRightLabel
        '
        Me.plusRightLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plusRightLabel.Location = New System.Drawing.Point(207, 75)
        Me.plusRightLabel.Name = "plusRightLabel"
        Me.plusRightLabel.Size = New System.Drawing.Size(60, 50)
        Me.plusRightLabel.TabIndex = 4
        Me.plusRightLabel.Text = "?"
        Me.plusRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(273, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 50)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "="
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sum
        '
        Me.sum.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sum.Location = New System.Drawing.Point(339, 84)
        Me.sum.Name = "sum"
        Me.sum.Size = New System.Drawing.Size(100, 35)
        Me.sum.TabIndex = 2
        '
        'difference
        '
        Me.difference.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.difference.Location = New System.Drawing.Point(339, 125)
        Me.difference.Name = "difference"
        Me.difference.Size = New System.Drawing.Size(100, 35)
        Me.difference.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(273, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 50)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "="
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'minusRightLabel
        '
        Me.minusRightLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minusRightLabel.Location = New System.Drawing.Point(207, 116)
        Me.minusRightLabel.Name = "minusRightLabel"
        Me.minusRightLabel.Size = New System.Drawing.Size(60, 50)
        Me.minusRightLabel.TabIndex = 9
        Me.minusRightLabel.Text = "?"
        Me.minusRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(141, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 50)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "-"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'minusLeftLabel
        '
        Me.minusLeftLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minusLeftLabel.Location = New System.Drawing.Point(75, 116)
        Me.minusLeftLabel.Name = "minusLeftLabel"
        Me.minusLeftLabel.Size = New System.Drawing.Size(60, 50)
        Me.minusLeftLabel.TabIndex = 7
        Me.minusLeftLabel.Text = "?"
        Me.minusLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'product
        '
        Me.product.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.product.Location = New System.Drawing.Point(339, 166)
        Me.product.Name = "product"
        Me.product.Size = New System.Drawing.Size(100, 35)
        Me.product.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(273, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 50)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "="
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timesRightLabel
        '
        Me.timesRightLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timesRightLabel.Location = New System.Drawing.Point(207, 157)
        Me.timesRightLabel.Name = "timesRightLabel"
        Me.timesRightLabel.Size = New System.Drawing.Size(60, 50)
        Me.timesRightLabel.TabIndex = 14
        Me.timesRightLabel.Text = "?"
        Me.timesRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(141, 157)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 50)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "×"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timesLeftLabel
        '
        Me.timesLeftLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timesLeftLabel.Location = New System.Drawing.Point(75, 157)
        Me.timesLeftLabel.Name = "timesLeftLabel"
        Me.timesLeftLabel.Size = New System.Drawing.Size(60, 50)
        Me.timesLeftLabel.TabIndex = 12
        Me.timesLeftLabel.Text = "?"
        Me.timesLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'quotient
        '
        Me.quotient.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quotient.Location = New System.Drawing.Point(339, 207)
        Me.quotient.Name = "quotient"
        Me.quotient.Size = New System.Drawing.Size(100, 35)
        Me.quotient.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(273, 198)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 50)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "="
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dividedRightLabel
        '
        Me.dividedRightLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dividedRightLabel.Location = New System.Drawing.Point(207, 198)
        Me.dividedRightLabel.Name = "dividedRightLabel"
        Me.dividedRightLabel.Size = New System.Drawing.Size(60, 50)
        Me.dividedRightLabel.TabIndex = 19
        Me.dividedRightLabel.Text = "?"
        Me.dividedRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(141, 198)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 50)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "÷"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dividedLeftLabel
        '
        Me.dividedLeftLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dividedLeftLabel.Location = New System.Drawing.Point(75, 198)
        Me.dividedLeftLabel.Name = "dividedLeftLabel"
        Me.dividedLeftLabel.Size = New System.Drawing.Size(60, 50)
        Me.dividedLeftLabel.TabIndex = 17
        Me.dividedLeftLabel.Text = "?"
        Me.dividedLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'startButton
        '
        Me.startButton.AutoSize = True
        Me.startButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startButton.Location = New System.Drawing.Point(178, 320)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(132, 34)
        Me.startButton.TabIndex = 1
        Me.startButton.Text = "Start the quiz!"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 366)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.quotient)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.dividedRightLabel)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.dividedLeftLabel)
        Me.Controls.Add(Me.product)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.timesRightLabel)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.timesLeftLabel)
        Me.Controls.Add(Me.difference)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.minusRightLabel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.minusLeftLabel)
        Me.Controls.Add(Me.sum)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.plusRightLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.plusLeftLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.timeLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Math Quiz"
        CType(Me.sum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.difference, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.product, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.quotient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents timeLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents plusLeftLabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents plusRightLabel As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents sum As System.Windows.Forms.NumericUpDown
    Friend WithEvents difference As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents minusRightLabel As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents minusLeftLabel As System.Windows.Forms.Label
    Friend WithEvents product As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents timesRightLabel As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents timesLeftLabel As System.Windows.Forms.Label
    Friend WithEvents quotient As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dividedRightLabel As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dividedLeftLabel As System.Windows.Forms.Label
    Friend WithEvents startButton As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Me.timeLabel = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.plusLeftLabel = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.plusRightLabel = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.sum = New System.Windows.Forms.NumericUpDown
        Me.difference = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.minusRightLabel = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.minusLeftLabel = New System.Windows.Forms.Label
        Me.product = New System.Windows.Forms.NumericUpDown
        Me.Label8 = New System.Windows.Forms.Label
        Me.timesRightLabel = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.timesLeftLabel = New System.Windows.Forms.Label
        Me.quotient = New System.Windows.Forms.NumericUpDown
        Me.Label12 = New System.Windows.Forms.Label
        Me.dividedRightLabel = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.dividedLeftLabel = New System.Windows.Forms.Label
        Me.startButton = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.sum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.difference, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.product, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.quotient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'timeLabel
        '
        Me.timeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.timeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timeLabel.Location = New System.Drawing.Point(280, 9)
        Me.timeLabel.Name = "timeLabel"
        Me.timeLabel.Size = New System.Drawing.Size(200, 30)
        Me.timeLabel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(173, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Time Left"
        '
        'plusLeftLabel
        '
        Me.plusLeftLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plusLeftLabel.Location = New System.Drawing.Point(75, 75)
        Me.plusLeftLabel.Name = "plusLeftLabel"
        Me.plusLeftLabel.Size = New System.Drawing.Size(60, 50)
        Me.plusLeftLabel.TabIndex = 2
        Me.plusLeftLabel.Text = "?"
        Me.plusLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(141, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 50)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "+"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'plusRightLabel
        '
        Me.plusRightLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plusRightLabel.Location = New System.Drawing.Point(207, 75)
        Me.plusRightLabel.Name = "plusRightLabel"
        Me.plusRightLabel.Size = New System.Drawing.Size(60, 50)
        Me.plusRightLabel.TabIndex = 4
        Me.plusRightLabel.Text = "?"
        Me.plusRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(273, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 50)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "="
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sum
        '
        Me.sum.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sum.Location = New System.Drawing.Point(339, 84)
        Me.sum.Name = "sum"
        Me.sum.Size = New System.Drawing.Size(100, 35)
        Me.sum.TabIndex = 2
        '
        'difference
        '
        Me.difference.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.difference.Location = New System.Drawing.Point(339, 125)
        Me.difference.Name = "difference"
        Me.difference.Size = New System.Drawing.Size(100, 35)
        Me.difference.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(273, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 50)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "="
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'minusRightLabel
        '
        Me.minusRightLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minusRightLabel.Location = New System.Drawing.Point(207, 116)
        Me.minusRightLabel.Name = "minusRightLabel"
        Me.minusRightLabel.Size = New System.Drawing.Size(60, 50)
        Me.minusRightLabel.TabIndex = 9
        Me.minusRightLabel.Text = "?"
        Me.minusRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(141, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 50)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "-"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'minusLeftLabel
        '
        Me.minusLeftLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minusLeftLabel.Location = New System.Drawing.Point(75, 116)
        Me.minusLeftLabel.Name = "minusLeftLabel"
        Me.minusLeftLabel.Size = New System.Drawing.Size(60, 50)
        Me.minusLeftLabel.TabIndex = 7
        Me.minusLeftLabel.Text = "?"
        Me.minusLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'product
        '
        Me.product.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.product.Location = New System.Drawing.Point(339, 166)
        Me.product.Name = "product"
        Me.product.Size = New System.Drawing.Size(100, 35)
        Me.product.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(273, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 50)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "="
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timesRightLabel
        '
        Me.timesRightLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timesRightLabel.Location = New System.Drawing.Point(207, 157)
        Me.timesRightLabel.Name = "timesRightLabel"
        Me.timesRightLabel.Size = New System.Drawing.Size(60, 50)
        Me.timesRightLabel.TabIndex = 14
        Me.timesRightLabel.Text = "?"
        Me.timesRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(141, 157)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 50)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "×"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timesLeftLabel
        '
        Me.timesLeftLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timesLeftLabel.Location = New System.Drawing.Point(75, 157)
        Me.timesLeftLabel.Name = "timesLeftLabel"
        Me.timesLeftLabel.Size = New System.Drawing.Size(60, 50)
        Me.timesLeftLabel.TabIndex = 12
        Me.timesLeftLabel.Text = "?"
        Me.timesLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'quotient
        '
        Me.quotient.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quotient.Location = New System.Drawing.Point(339, 207)
        Me.quotient.Name = "quotient"
        Me.quotient.Size = New System.Drawing.Size(100, 35)
        Me.quotient.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(273, 198)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 50)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "="
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dividedRightLabel
        '
        Me.dividedRightLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dividedRightLabel.Location = New System.Drawing.Point(207, 198)
        Me.dividedRightLabel.Name = "dividedRightLabel"
        Me.dividedRightLabel.Size = New System.Drawing.Size(60, 50)
        Me.dividedRightLabel.TabIndex = 19
        Me.dividedRightLabel.Text = "?"
        Me.dividedRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(141, 198)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 50)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "÷"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dividedLeftLabel
        '
        Me.dividedLeftLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dividedLeftLabel.Location = New System.Drawing.Point(75, 198)
        Me.dividedLeftLabel.Name = "dividedLeftLabel"
        Me.dividedLeftLabel.Size = New System.Drawing.Size(60, 50)
        Me.dividedLeftLabel.TabIndex = 17
        Me.dividedLeftLabel.Text = "?"
        Me.dividedLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'startButton
        '
        Me.startButton.AutoSize = True
        Me.startButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startButton.Location = New System.Drawing.Point(178, 320)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(132, 34)
        Me.startButton.TabIndex = 1
        Me.startButton.Text = "Start the quiz!"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 366)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.quotient)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.dividedRightLabel)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.dividedLeftLabel)
        Me.Controls.Add(Me.product)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.timesRightLabel)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.timesLeftLabel)
        Me.Controls.Add(Me.difference)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.minusRightLabel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.minusLeftLabel)
        Me.Controls.Add(Me.sum)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.plusRightLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.plusLeftLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.timeLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Math Quiz"
        CType(Me.sum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.difference, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.product, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.quotient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents timeLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents plusLeftLabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents plusRightLabel As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents sum As System.Windows.Forms.NumericUpDown
    Friend WithEvents difference As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents minusRightLabel As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents minusLeftLabel As System.Windows.Forms.Label
    Friend WithEvents product As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents timesRightLabel As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents timesLeftLabel As System.Windows.Forms.Label
    Friend WithEvents quotient As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dividedRightLabel As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dividedLeftLabel As System.Windows.Forms.Label
    Friend WithEvents startButton As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class

