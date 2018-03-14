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
        Me.richTextBox1.Location = New System.Drawing.Point(4, 47)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.Size = New System.Drawing.Size(408, 232)
        Me.richTextBox1.TabIndex = 1
        Me.richTextBox1.Text = "There once was a brown man from Nantucket..."
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(416, 326)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.richTextBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '<Snippet1>
    Private Sub richTextBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles richTextBox1.MouseDown
        ' Declare the string to search for in the control.
        Dim searchString As String = "brown"

        ' Determine whether the user clicks the left mouse button and whether it is a double click.
        If e.Clicks = 1 And e.Button = MouseButtons.Left Then
            ' Obtain the character index where the user clicks on the control.
            Dim positionToSearch As Integer = richTextBox1.GetCharIndexFromPosition(New Point(e.X, e.Y))
            ' Search for the search string text within the control from the point the user clicked.
            Dim textLocation As Integer = richTextBox1.Find(searchString, positionToSearch, RichTextBoxFinds.None)

            ' If the search string is found (value greater than -1), display the index the string was found at.
            If textLocation >= 0 Then
                MessageBox.Show(("The search string was found at character index " + textLocation.ToString() + "."))
                ' Display a message box alerting the user that the text was not found.
            Else
                MessageBox.Show("The search string was not found within the text of the control.")
            End If
        End If
    End Sub
    '</Snippet1>

End Class
