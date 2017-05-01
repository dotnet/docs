'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form
    Private addressTextBox As System.Windows.Forms.TextBox
    Private label2 As System.Windows.Forms.Label
    Private cityTextBox As System.Windows.Forms.TextBox
    Private label3 As System.Windows.Forms.Label
    Private stateTextBox As System.Windows.Forms.TextBox
    Private zipTextBox As System.Windows.Forms.TextBox
    Private helpProvider1 As System.Windows.Forms.HelpProvider
    Private helpLabel As System.Windows.Forms.Label

    <STAThread()>  _
    Shared Sub Main()
        Application.Run(New Form1())
    End Sub 'Main
    
    Public Sub New()
        Me.addressTextBox = New System.Windows.Forms.TextBox()
        Me.helpLabel = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.cityTextBox = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.stateTextBox = New System.Windows.Forms.TextBox()
        Me.zipTextBox = New System.Windows.Forms.TextBox()

        ' Help Label
        Me.helpLabel.Location = New System.Drawing.Point(8, 80)
        Me.helpLabel.Size = New System.Drawing.Size(272, 72)
        Me.helpLabel.TabIndex = 1
        Me.helpLabel.Text = "Click the Help button in the title bar, then click a control " & _
            "to see a Help tooltip for the control.  Click on a control and press F1 to invoke " & _
            "the Help system with a sample Help file."

        ' Address Label
        Me.label2.Location = New System.Drawing.Point(16, 8)
        Me.label2.Size = New System.Drawing.Size(100, 16)
        Me.label2.Text = "Address:"

        ' Comma Label
        Me.label3.Location = New System.Drawing.Point(136, 56)
        Me.label3.Size = New System.Drawing.Size(16, 16)
        Me.label3.Text = ","

        '<Snippet4>
        ' Creates the HelpProvider.
        Me.helpProvider1 = New System.Windows.Forms.HelpProvider()
        '</Snippet4>

        '<Snippet2>
        ' Tell the HelpProvider what controls to provide Help for, and
        ' what the Help string is.
        Me.helpProvider1.SetHelpString(Me.addressTextBox, "Enter the street address in this text box.")
        Me.helpProvider1.SetShowHelp(Me.addressTextBox, True)

        Me.helpProvider1.SetHelpString(Me.cityTextBox, "Enter the city here.")
        Me.helpProvider1.SetShowHelp(Me.cityTextBox, True)

        Me.helpProvider1.SetHelpString(Me.stateTextBox, "Enter the state in this text box.")
        Me.helpProvider1.SetShowHelp(Me.stateTextBox, True)

        Me.helpProvider1.SetHelpString(Me.zipTextBox, "Enter the zip code here.")
        Me.helpProvider1.SetShowHelp(Me.zipTextBox, True)
        '</Snippet2>

        '<Snippet3>
        ' Sets what the Help file will be for the HelpProvider.
        Me.helpProvider1.HelpNamespace = "mspaint.chm"
        '</Snippet3>

        ' Set properties for the different address fields.

        ' Address TextBox
        Me.addressTextBox.Location = New System.Drawing.Point(16, 24)
        Me.addressTextBox.Size = New System.Drawing.Size(264, 20)
        Me.addressTextBox.TabIndex = 0
        Me.addressTextBox.Text = ""


        ' City TextBox
        Me.cityTextBox.Location = New System.Drawing.Point(16, 48)
        Me.cityTextBox.Size = New System.Drawing.Size(120, 20)
        Me.cityTextBox.TabIndex = 3
        Me.cityTextBox.Text = ""

        ' State TextBox
        Me.stateTextBox.Location = New System.Drawing.Point(152, 48)
        Me.stateTextBox.MaxLength = 2
        Me.stateTextBox.Size = New System.Drawing.Size(32, 20)
        Me.stateTextBox.TabIndex = 5
        Me.stateTextBox.Text = ""

        ' Zip TextBox
        Me.zipTextBox.Location = New System.Drawing.Point(192, 48)
        Me.zipTextBox.Size = New System.Drawing.Size(88, 20)
        Me.zipTextBox.TabIndex = 6
        Me.zipTextBox.Text = ""

        ' Add the controls to the form.
        Me.Controls.AddRange(New System.Windows.Forms.Control() { Me.zipTextBox, _
                                       Me.stateTextBox, Me.label3, _
                                       Me.cityTextBox, Me.label2, _
                                       Me.helpLabel, Me.addressTextBox})

        ' Set the form to look like a dialog, and show the HelpButton.    
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ClientSize = New System.Drawing.Size(292, 160)
        Me.Text = "Help Provider Demonstration"

    End Sub 'New        
End Class 'Form1
'</Snippet1>