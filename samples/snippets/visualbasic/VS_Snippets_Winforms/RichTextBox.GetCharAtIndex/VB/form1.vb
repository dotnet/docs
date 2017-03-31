Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
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
    Friend WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'richTextBox1
        '
        Me.richTextBox1.Location = New System.Drawing.Point(24, 24)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.Size = New System.Drawing.Size(320, 264)
        Me.richTextBox1.TabIndex = 1
        Me.richTextBox1.Text = "There once was a man from Nantucket."
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(368, 310)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.richTextBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '<Snippet1>
    Private Sub richTextBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles richTextBox1.MouseDown
        ' Determine which mouse button is clicked.
        If e.Button = MouseButtons.Left Then
            ' Obtain the character at which the mouse cursor was clicked.
            Dim tempChar As Char = richTextBox1.GetCharFromPosition(New Point(e.X, e.Y))
            ' Determine whether the character is an empty space.
            If tempChar <> " " Then
                ' Display the character in a message box.
                MessageBox.Show(("The character at the specified position is " + tempChar + "."))
            End If
        End If
    End Sub
    '</Snippet1>

End Class
