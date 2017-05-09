<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShapeSelect
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
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.OvalShape1 = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.OvalShape2 = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.OvalShape3 = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.OvalShape3, Me.OvalShape2, Me.OvalShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(292, 266)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'OvalShape1
        '
        Me.OvalShape1.Location = New System.Drawing.Point(28, 26)
        Me.OvalShape1.Name = "OvalShape1"
        Me.OvalShape1.Size = New System.Drawing.Size(196, 45)
        '
        'OvalShape2
        '
        Me.OvalShape2.Location = New System.Drawing.Point(36, 103)
        Me.OvalShape2.Name = "OvalShape2"
        Me.OvalShape2.Size = New System.Drawing.Size(202, 45)
        '
        'OvalShape3
        '
        Me.OvalShape3.Location = New System.Drawing.Point(38, 187)
        Me.OvalShape3.Name = "OvalShape3"
        Me.OvalShape3.Size = New System.Drawing.Size(200, 45)
        '
        'ShapeSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "ShapeSelect"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents OvalShape1 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents OvalShape3 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents OvalShape2 As Microsoft.VisualBasic.PowerPacks.OvalShape

End Class
