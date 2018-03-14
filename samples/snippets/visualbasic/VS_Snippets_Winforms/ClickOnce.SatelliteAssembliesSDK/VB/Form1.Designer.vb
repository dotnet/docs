<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.textBox1 = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'textBox1
        '
        Me.textBox1.AccessibleDescription = Nothing
        Me.textBox1.AccessibleName = Nothing
        resources.ApplyResources(Me.textBox1, "textBox1")
        Me.textBox1.BackgroundImage = Nothing
        Me.textBox1.Font = Nothing
        Me.textBox1.Name = "textBox1"
        '
        'label1
        '
        Me.label1.AccessibleDescription = Nothing
        Me.label1.AccessibleName = Nothing
        resources.ApplyResources(Me.label1, "label1")
        Me.label1.Font = Nothing
        Me.label1.Name = "label1"
        '
        'Form1
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.label1)
        Me.Font = Nothing
        Me.Icon = Nothing
        Me.Name = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
