Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
   Inherits Form
   
' <snippet1>
Public Sub InitMyForm()
   ' Adds a label to the form.
   Dim label1 As New Label()
   label1.Location = New System.Drawing.Point(54, 128)
   label1.Name = "label1"
   label1.Size = New System.Drawing.Size(220, 80)
   label1.Text = "Start position information"
   Me.Controls.Add(label1)
   
   ' Moves the start position to the center of the screen.
   StartPosition = FormStartPosition.CenterScreen
   ' Displays the position information.
   label1.Text = "The start position is " + StartPosition
End Sub 'InitMyForm
' </snippet1>
Public Shared Sub Main()
   System.Windows.Forms.Application.Run(New Form1())
End Sub

End Class
