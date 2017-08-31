<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShapeContextMenuStrip
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
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.OvalShape1 = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.XXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.OvalShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(292, 266)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'OvalShape1
        '
        Me.OvalShape1.Location = New System.Drawing.Point(46, 75)
        Me.OvalShape1.Name = "OvalShape1"
        Me.OvalShape1.Size = New System.Drawing.Size(207, 83)
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu1ToolStripMenuItem, Me.Menu2ToolStripMenuItem, Me.Menu3ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(118, 70)
        '
        'Menu1ToolStripMenuItem
        '
        Me.Menu1ToolStripMenuItem.Name = "Menu1ToolStripMenuItem"
        Me.Menu1ToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.Menu1ToolStripMenuItem.Text = "Menu1"
        '
        'Menu2ToolStripMenuItem
        '
        Me.Menu2ToolStripMenuItem.Name = "Menu2ToolStripMenuItem"
        Me.Menu2ToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.Menu2ToolStripMenuItem.Text = "Menu2"
        '
        'Menu3ToolStripMenuItem
        '
        Me.Menu3ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VBToolStripMenuItem, Me.XXToolStripMenuItem})
        Me.Menu3ToolStripMenuItem.Name = "Menu3ToolStripMenuItem"
        Me.Menu3ToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.Menu3ToolStripMenuItem.Text = "Menu3"
        '
        'VBToolStripMenuItem
        '
        Me.VBToolStripMenuItem.Name = "VBToolStripMenuItem"
        Me.VBToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.VBToolStripMenuItem.Text = "VB"
        '
        'XXToolStripMenuItem
        '
        Me.XXToolStripMenuItem.Name = "XXToolStripMenuItem"
        Me.XXToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.XXToolStripMenuItem.Text = "XX"
        '
        'ShapeContextMenuStrip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "ShapeContextMenuStrip"
        Me.Text = "Form1"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents OvalShape1 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Menu1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VBToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XXToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
