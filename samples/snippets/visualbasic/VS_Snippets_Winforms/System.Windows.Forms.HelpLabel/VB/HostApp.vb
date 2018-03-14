' <snippet10>
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class HostApp
   Inherits System.Windows.Forms.Form
    ' <summary>
    '    Required designer variable.
    ' </summary>
   Private components As System.ComponentModel.Container
   Private label1 As System.Windows.Forms.Label
   Private textBox1 As System.Windows.Forms.TextBox
   Private button1 As System.Windows.Forms.Button
    Private helpLabel1 As Microsoft.Samples.WinForms.Vb.HelpLabel.HelpLabel
   
   
   Public Sub New()
      '
      ' Required for Windows Form Designer support
      '
      InitializeComponent()
    End Sub


    ' <summary>
    '    Required method for Designer support - do not modify
    '    the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.label1 = New System.Windows.Forms.Label
        Me.button1 = New System.Windows.Forms.Button
        Me.textBox1 = New System.Windows.Forms.TextBox
        Me.helpLabel1 = New Microsoft.Samples.WinForms.Vb.HelpLabel.HelpLabel

        label1.Location = New System.Drawing.Point(16, 16)
        label1.Text = "Name:"
        label1.Size = New System.Drawing.Size(56, 24)
        label1.TabIndex = 3

        helpLabel1.Dock = System.Windows.Forms.DockStyle.Bottom
        helpLabel1.Size = New System.Drawing.Size(448, 40)
        helpLabel1.TabIndex = 0
        helpLabel1.Location = New System.Drawing.Point(0, 117)

        button1.Anchor = AnchorStyles.Right Or AnchorStyles.Bottom
        button1.Size = New System.Drawing.Size(104, 40)
        button1.TabIndex = 1
        helpLabel1.SetHelpText(button1, "This is the Save Button. Press the Save Button to save your work.")
        button1.Text = "&Save"
        button1.Location = New System.Drawing.Point(336, 56)

        Me.Text = "Control Example"
        Me.ClientSize = New System.Drawing.Size(448, 157)

        textBox1.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
        textBox1.Location = New System.Drawing.Point(80, 16)
        textBox1.Text = "<Name>"
        helpLabel1.SetHelpText(textBox1, "This is the name field. Please enter your name here.")
        textBox1.TabIndex = 2
        textBox1.Size = New System.Drawing.Size(360, 20)

        Me.Controls.Add(label1)
        Me.Controls.Add(textBox1)
        Me.Controls.Add(button1)
        Me.Controls.Add(helpLabel1)
    End Sub

    

    ' <summary>
    ' The main entry point for the application.
    ' </summary>
    <STAThread()> _
              Public Shared Sub Main(ByVal args() As String)
        Application.Run(New HostApp)
    End Sub
End Class
' </snippet10>