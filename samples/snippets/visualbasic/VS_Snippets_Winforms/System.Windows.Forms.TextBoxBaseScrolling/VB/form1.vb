' The following code example demonstrates using the Keys enum,  
' and the TextBoxBase.ScrollToCaret,  and TextBox.HideSelection methods.
' It also demonstrates and handling the TextBox.Click event.


Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InitializeTextBox()
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
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(40, 80)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = "and the text will be added here."
        '


        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    '<snippet3>
    'Declare a textbox called TextBox1.
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

    'Initialize TextBox1.
    Private Sub InitializeTextBox()
        Me.TextBox1 = New TextBox
        Me.TextBox1.Location = New System.Drawing.Point(32, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(136, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "Type and hit enter here..."

        'Keep the selection highlighted, even after textbox loses focus.
        TextBox1.HideSelection = False
        Me.Controls.Add(TextBox1)
    End Sub
    '</snippet3>

    '<snippet2>
    'Selects everything in TextBox1.
    Private Sub TextBox1_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles TextBox1.Click
        TextBox1.SelectAll()
    End Sub
    '</snippet2>

    '<snippet1>
    'Handles the Enter key being pressed while TextBox1 has focus. 
    Private Sub TextBox1_KeyDown(ByVal sender As Object, _
        ByVal e As KeyEventArgs) Handles TextBox1.KeyDown
        TextBox1.HideSelection = False
        If e.KeyCode = Keys.Enter Then
            e.Handled = True

            ' Copy the text from TextBox1 to RichTextBox1, add a CRLF after 
            ' the copied text, and keep the caret in view.
            RichTextBox1.SelectedText = TextBox1.Text + _
                Microsoft.VisualBasic.vbCrLf
            RichTextBox1.ScrollToCaret()
        End If
    End Sub
    '</snippet1>

End Class
