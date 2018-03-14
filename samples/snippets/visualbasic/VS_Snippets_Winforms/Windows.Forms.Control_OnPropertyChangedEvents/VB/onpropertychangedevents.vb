Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace PropChanged
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private currencyTextBox As MyTextBox
      Private button1 As System.Windows.Forms.Button
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New
       
      Private Sub InitializeComponent()
         Me.currencyTextBox = New PropChanged.MyTextBox()
         Me.button1 = New System.Windows.Forms.Button()
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
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(64, 48)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 1
         Me.button1.Text = "button1"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(194, 103)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.currencyTextBox})
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent

      <STAThread()> _
      Shared Sub Main() 
         Application.Run(New Form1())
      End Sub 'Main
   End Class 'Form1


   Public Class MyTextBox
      Inherits TextBox
      

' <snippet1>
Protected Overrides Sub OnTextChanged(e As System.EventArgs)
   Try
      ' Convert the text to a Double and determine
      ' if it is a negative number.
      If Double.Parse(Me.Text) < 0 Then
         ' If the number is negative, display it in Red.
         Me.ForeColor = Color.Red
      Else
         ' If the number is not negative, display it in Black.
         Me.ForeColor = Color.Black
      End If
   Catch
      ' If there is an error, display the
      ' text using the system colors.
      Me.ForeColor = SystemColors.ControlText
   End Try

   MyBase.OnTextChanged(e)
End Sub
' </snippet1>

   End Class 
End Namespace


