

' This example demonstrates handling the use of a ColorDialog object. 
' The ColorDialog object does not allow the user to set a custom color 
' but it allows the full set of basic colors to be displayed. By setting the
' SolidColorOnly property to false, it allows the display of colors that 
' are combinations of other colors on systems with 256 or less colors. 
' The dialog also shows the handling of a HelpRequest event.


Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        InitializeColorDialog()
    End Sub

    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog


    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        Me.Button1.Location = New System.Drawing.Point(24, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 56)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Click to change the color of the textbox"
        Me.TextBox1.Location = New System.Drawing.Point(24, 88)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(96, 96)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "Here is some text"
        Me.ClientSize = New System.Drawing.Size(152, 266)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
    End Sub

    <System.STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    '<snippet1>
    
    ' This method initializes ColorDialog1 to allow any colors, 
    ' and combination colors on systems with 256 colors or less, 
    ' but will not allow the user to set custom colors.  The
    ' dialog will contain the help button.
    Private Sub InitializeColorDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.ColorDialog1.AllowFullOpen = False
        Me.ColorDialog1.AnyColor = True
        Me.ColorDialog1.SolidColorOnly = False
        Me.ColorDialog1.ShowHelp = True
    End Sub
  

    ' This method opens the dialog and checks the DialogResult value. 
    ' If the result is OK, the text box's background color will be changed 
    ' to the user-selected color.
    Private Sub Button1_Click(ByVal sender As System.Object,  _
        ByVal e As System.EventArgs) Handles Button1.Click
        Dim result As DialogResult = ColorDialog1.ShowDialog()
        If (result.Equals(DialogResult.OK)) Then
            TextBox1.BackColor = ColorDialog1.Color
        End If
    End Sub
 
  
    ' This method is called when the HelpRequest event is raised, 
    'which occurs when the user clicks the Help button on the ColorDialog object.
    Private Sub ColorDialog1_HelpRequest(ByVal sender As Object, _ 
        ByVal e As System.EventArgs) Handles ColorDialog1.HelpRequest

        MessageBox.Show("Please select a color by clicking it." _
        & "This will change the BackColor property of the TextBox.")
    End Sub
     '</snippet1>

End Class




