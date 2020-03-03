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
        Me.contactBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.contactDataGridView = New System.Windows.Forms.DataGridView
        CType(Me.contactBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.contactDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'contactDataGridView
        '
        Me.contactDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.contactDataGridView.Location = New System.Drawing.Point(12, 12)
        Me.contactDataGridView.Name = "contactDataGridView"
        Me.contactDataGridView.Size = New System.Drawing.Size(492, 258)
        Me.contactDataGridView.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 289)
        Me.Controls.Add(Me.contactDataGridView)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.contactBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.contactDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents contactBindingSource As System.Windows.Forms.BindingSource
    Private WithEvents contactDataGridView As System.Windows.Forms.DataGridView

End Class
