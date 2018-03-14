Imports System.Drawing
Imports System.Windows.Forms
Imports System
Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InitializeRadioButtonsAndGroupBox()

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

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()


        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)

        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    '<snippet1>
    '<snippet2>
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton

    Private Sub InitializeRadioButtonsAndGroupBox()

        ' Construct the GroupBox object.
        Me.GroupBox1 = New GroupBox

        ' Construct the radio buttons.
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton

        ' Set the location, tab and text for each radio button
        ' to a cursor from the Cursors enumeration.
        Me.RadioButton1.Location = New System.Drawing.Point(24, 24)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "Help"
        Me.RadioButton1.Tag = Cursors.Help
        Me.RadioButton1.TextAlign = ContentAlignment.MiddleCenter

        Me.RadioButton2.Location = New System.Drawing.Point(24, 56)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Up Arrow"
        Me.RadioButton2.Tag = Cursors.UpArrow
        Me.RadioButton2.TextAlign = ContentAlignment.MiddleCenter

        Me.RadioButton3.Location = New System.Drawing.Point(24, 80)
        Me.RadioButton3.TabIndex = 3
        Me.RadioButton3.Text = "Cross"
        Me.RadioButton3.Tag = Cursors.Cross
        Me.RadioButton3.TextAlign = ContentAlignment.MiddleCenter

        ' Add the radio buttons to the GroupBox.  
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)

        ' Set the location of the GroupBox. 
        Me.GroupBox1.Location = New System.Drawing.Point(56, 64)
        Me.GroupBox1.Size = New System.Drawing.Size(200, 150)

        ' Set the text that will appear on the GroupBox.
        Me.GroupBox1.Text = "Choose a Cursor Style"
        '
        ' Add the GroupBox to the form.
        Me.Controls.Add(Me.GroupBox1)
        '

    End Sub
    ' </snippet1>

    Private Sub RadioButton_CheckedChanged _
        (ByVal sender As Object, ByVal e As EventArgs) _
            Handles RadioButton1.CheckedChanged, _
            RadioButton2.CheckedChanged, RadioButton3.CheckedChanged

        ' Cast the sender back to a RadioButton object.
        Dim selectedRadioButton As RadioButton = _
            CType(sender, RadioButton)

        ' If the radio button is in a checked state, then
        ' change the cursor.
        If (selectedRadioButton.Checked) Then
            Cursor = selectedRadioButton.Tag
        End If
    End Sub

    '</snippet2>
End Class
