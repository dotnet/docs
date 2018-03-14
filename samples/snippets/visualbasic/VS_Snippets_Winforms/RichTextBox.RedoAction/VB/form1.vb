Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents button1 As System.Windows.Forms.Button
    Friend WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button()
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(367, 115)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 3
        Me.button1.Text = "button1"
        '
        'richTextBox1
        '
        Me.richTextBox1.Location = New System.Drawing.Point(71, 91)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.Size = New System.Drawing.Size(240, 208)
        Me.richTextBox1.TabIndex = 2
        Me.richTextBox1.Text = "richTextBox1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(368, 224)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Undo"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(512, 390)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button2, Me.button1, Me.richTextBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
        RedoAllButDeletes()
    End Sub 'button1_Click


    '<Snippet1>
    Private Sub RedoAllButDeletes()

        ' Determines if a Redo operation can be performed.
        If richTextBox1.CanRedo = True Then
            ' Determines if the redo operation deletes text.
            If richTextBox1.RedoActionName <> "Delete" Then
                ' Perform the redo.
                richTextBox1.Redo()
            End If
        End If
    End Sub
    '</Snippet1>

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        richTextBox1.Undo()
    End Sub
End Class
