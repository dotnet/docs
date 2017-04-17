'<SNIPPET1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        Main(System.Environment.GetCommandLineArgs())
    End Sub

    Private Overloads Shared Sub Main(ByVal args() As String)
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub 'Main

    Private WithEvents FirstNameBox, LastNameBox As TextBox
    Private WithEvents ValidateButton As Button
    Private FlowLayout1 As FlowLayoutPanel

    Private Sub New()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' Turn off validation when a control loses focus. This will be inherited by child
        ' controls on the form, enabling us to validate the entire form when the 
        ' button is clicked instead of one control at a time.
        Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable

        FlowLayout1 = New FlowLayoutPanel()
        FlowLayout1.Dock = DockStyle.Fill

        FirstNameBox = New TextBox()
        FirstNameBox.Name = "FirstNameBox"
        FirstNameBox.Location = New Point(10, 10)
        FirstNameBox.Size = New Size(75, FirstNameBox.Size.Height)
        FirstNameBox.CausesValidation = True
        FlowLayout1.Controls.Add(FirstNameBox)

        LastNameBox = New TextBox()
        LastNameBox.Name = "LastNameBox"
        LastNameBox.Location = New Point(90, 10)
        LastNameBox.Size = New Size(75, LastNameBox.Size.Height)
        LastNameBox.CausesValidation = True
        FlowLayout1.Controls.Add(LastNameBox)

        ValidateButton = New Button()
        ValidateButton.Text = "Validate"
        ValidateButton.Location = New Point(170, 10)
        ValidateButton.Size = New Size(75, ValidateButton.Size.Height)
        FlowLayout1.Controls.Add(ValidateButton)

        Me.Text = "Test Validation"

        Me.Controls.Add(FlowLayout1)
    End Sub


    Private Sub FirstNameBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles FirstNameBox.Validating
        If FirstNameBox.Text.Length = 0 Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub


    Private Sub LastNameBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles LastNameBox.Validating
        e.Cancel = False
    End Sub


    Private Sub ValidateButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ValidateButton.Click
        If ValidateChildren() Then
            MessageBox.Show("Validation succeeded!")
        Else
            MessageBox.Show("Validation failed.")
        End If
    End Sub
End Class
'</SNIPPET1>