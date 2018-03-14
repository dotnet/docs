Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace PropChanged
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private WithEvents currencyTextBox As System.Windows.Forms.TextBox
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New
       
      
      Private Sub InitializeComponent()
         Me.currencyTextBox = New System.Windows.Forms.TextBox()
         Me.SuspendLayout()
         ' 
         ' currencyTextBox
         ' 
         Me.currencyTextBox.Location = New System.Drawing.Point(8, 8)
         Me.currencyTextBox.Name = "currencyTextBox"
         Me.currencyTextBox.Size = New System.Drawing.Size(104, 20)
         Me.currencyTextBox.TabIndex = 0
         Me.currencyTextBox.Text = ""
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(194, 103)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.currencyTextBox})
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       
      
      <STAThread()> _
      Shared Sub Main()
         Application.Run(New Form1())
      End Sub 'Main
      
      
' <snippet1>
Private Sub currencyTextBox_TextChanged(sender As Object, _ 
  e As EventArgs) Handles currencyTextBox.TextChanged
   Try
      ' Convert the text to a Double and determine if it is a negative number.
      If Double.Parse(currencyTextBox.Text) < 0 Then
         ' If the number is negative, display it in Red.
         currencyTextBox.ForeColor = Color.Red
      Else
         ' If the number is not negative, display it in Black.
         currencyTextBox.ForeColor = Color.Black
      End If
   Catch
      ' If there is an error, display the text using the system colors.
      currencyTextBox.ForeColor = SystemColors.ControlText
   End Try
End Sub 
' </snippet1>
      
   End Class
End Namespace