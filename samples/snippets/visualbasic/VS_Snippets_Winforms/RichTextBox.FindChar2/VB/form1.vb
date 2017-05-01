Imports System
imports System.Drawing
imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Public NotInheritable Class Form1
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
    Friend WithEvents button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'richTextBox1
        '
        Me.richTextBox1.Location = New System.Drawing.Point(16, 16)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.Size = New System.Drawing.Size(248, 192)
        Me.richTextBox1.TabIndex = 3
        Me.richTextBox1.Text = "Alpha Bravo Charlie Delta Echo"
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(200, 224)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 2
        Me.button1.Text = "button1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(296, 270)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.richTextBox1, Me.button1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' <Snippet1>
    Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
        MessageBox.Show(FindMyText(New Char() {"B"c, "r"c, "a"c, "v"c, "o"c}, 5).ToString())
    End Sub


    Public Function FindMyText(ByVal text() As Char, ByVal start As Integer) As Integer
        ' Initialize the return value to false by default.
        Dim returnValue As Integer = -1

        ' Ensure that a valid char array has been specified and a valid start point.
        If [text].Length > 0 And start >= 0 Then
            ' Obtain the location of the first character found in the control
            ' that matches any of the characters in the char array.
            Dim indexToText As Integer = richTextBox1.Find([text], start)
            ' Determine whether any of the chars are found in richTextBox1.
            If indexToText >= 0 Then
                ' Return the location of the character.
                returnValue = indexToText
            End If
        End If

        Return returnValue
    End Function
    '</Snippet1>

End Class
