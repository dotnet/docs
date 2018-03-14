'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form
    Private WithEvents addressTextBox As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents cityTextBox As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents stateTextBox As System.Windows.Forms.TextBox
    Private WithEvents zipTextBox As System.Windows.Forms.TextBox
    Private WithEvents helpLabel As System.Windows.Forms.Label

    <STAThread()> _
    Shared Sub Main()
        Application.Run(New Form1)
    End Sub 'Main

    Public Sub New()
        Me.addressTextBox = New System.Windows.Forms.TextBox
        Me.helpLabel = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.cityTextBox = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.stateTextBox = New System.Windows.Forms.TextBox
        Me.zipTextBox = New System.Windows.Forms.TextBox

        ' Help Label
        Me.helpLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.helpLabel.Location = New System.Drawing.Point(8, 80)
        Me.helpLabel.Size = New System.Drawing.Size(272, 72)
        Me.helpLabel.Text = "Click on any control to give it focus, and then " & _
            "press F1 to display help for that" + " control.  Alternately, you can " & _
            "click the help button at the top of the dialog and then click on a control."

        ' Address Label
        Me.label2.Location = New System.Drawing.Point(16, 8)
        Me.label2.Size = New System.Drawing.Size(100, 16)
        Me.label2.Text = "Address:"

        ' Comma Label
        Me.label3.Location = New System.Drawing.Point(136, 56)
        Me.label3.Size = New System.Drawing.Size(16, 16)
        Me.label3.Text = ","

        ' Address TextBox
        Me.addressTextBox.Location = New System.Drawing.Point(16, 24)
        Me.addressTextBox.Size = New System.Drawing.Size(264, 20)
        Me.addressTextBox.TabIndex = 0
        Me.addressTextBox.Tag = "Enter the stree address in this text box."
        Me.addressTextBox.Text = ""

        ' City TextBox
        Me.cityTextBox.Location = New System.Drawing.Point(16, 48)
        Me.cityTextBox.Size = New System.Drawing.Size(120, 20)
        Me.cityTextBox.TabIndex = 3
        Me.cityTextBox.Tag = "Enter the city here."
        Me.cityTextBox.Text = ""

        ' State TextBox
        Me.stateTextBox.Location = New System.Drawing.Point(152, 48)
        Me.stateTextBox.MaxLength = 2
        Me.stateTextBox.Size = New System.Drawing.Size(32, 20)
        Me.stateTextBox.TabIndex = 5
        Me.stateTextBox.Tag = "Enter the state in this text box."
        Me.stateTextBox.Text = ""

        ' Zip TextBox
        Me.zipTextBox.Location = New System.Drawing.Point(192, 48)
        Me.zipTextBox.Size = New System.Drawing.Size(88, 20)
        Me.zipTextBox.TabIndex = 6
        Me.zipTextBox.Tag = "Enter the zip code here."
        Me.zipTextBox.Text = ""

        ' Set up how the form should be displayed and add the controls to the form.
        Me.ClientSize = New System.Drawing.Size(292, 160)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.zipTextBox, _
                                Me.stateTextBox, Me.label3, Me.cityTextBox, _
                                Me.label2, Me.helpLabel, Me.addressTextBox})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Text = "Help Event Demonstration"
    End Sub 'New

    Private Sub textBox_HelpRequested(ByVal sender As Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) Handles addressTextBox.HelpRequested, cityTextBox.HelpRequested, stateTextBox.HelpRequested, zipTextBox.HelpRequested
        ' This event is raised when the F1 key is pressed or the
        ' Help cursor is clicked on any of the address fields.
        ' The Help text for the field is in the control's
        ' Tag property. It is retrieved and displayed in the label.

        Dim requestingControl As Control = CType(sender, Control)
        helpLabel.Text = CStr(requestingControl.Tag)
        hlpevent.Handled = True

    End Sub 'textBox_HelpRequested
End Class 'Form1
'</Snippet1>