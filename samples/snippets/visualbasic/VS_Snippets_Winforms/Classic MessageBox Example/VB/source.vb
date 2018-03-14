Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    '<snippet1>
    Private Sub Form1_FormClosing( _
        ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) _
        Handles MyBase.FormClosing

        Dim message As String = _
                "Are you sure that you would like to close the form?"
        Dim caption As String = "Form Closing"
        Dim result = MessageBox.Show(message, caption, _
                                     MessageBoxButtons.YesNo, _
                                     MessageBoxIcon.Question)

        ' If the no button was pressed ...
        If (result = DialogResult.No) Then
            ' cancel the closure of the form.
            e.Cancel = True
        End If
    End Sub
    '</snippet1>

    Private Sub InitializeComponent()

        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(273, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Close this form to display the message box."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 262)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "MessageBox Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    <STAThread()> _
    Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    Public Sub New()
        MyBase.New()

        InitializeComponent()
    End Sub

    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
