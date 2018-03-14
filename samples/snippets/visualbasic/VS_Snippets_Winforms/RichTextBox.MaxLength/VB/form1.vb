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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button()
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(311, 67)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 3
        Me.button1.Text = "button1"
        '
        'richTextBox1
        '
        Me.richTextBox1.Location = New System.Drawing.Point(79, 59)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.Size = New System.Drawing.Size(208, 176)
        Me.richTextBox1.TabIndex = 2
        Me.richTextBox1.Text = "richTextBox1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(464, 294)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.richTextBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
        richTextBox1.Clear()
        richTextBox1.MaxLength = 2
        AddMyText("Foo")
    End Sub 'button1_Click


    '<Snippet1>
    Private Sub AddMyText(ByVal textToAdd As String)
        ' Determine if the text to add is larger than the max length property.
        If textToAdd.Length > richTextBox1.MaxLength Then
            ' Alert user text is too large.
            MessageBox.Show("The text is too large to addo to the RichTextBox")
            ' Add the text to be added to the control.
        Else
            richTextBox1.SelectedText = textToAdd
        End If
    End Sub
    '</Snippet1>
End Class
