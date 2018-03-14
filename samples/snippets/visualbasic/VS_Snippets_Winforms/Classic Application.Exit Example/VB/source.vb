Imports System
Imports System.Windows.Forms

Public Class Form1
 Inherits Form
 
 Protected listBox1 As ListBox

' <Snippet1>
 <STAThread()> _
 Shared Sub Main() 	
    ' Starts the application.
    Application.Run(New Form1())
 End Sub
 
 Private Sub button1_Click(sender As object, e As System.EventArgs)
    ' Populates a list box with three numbers.
    Dim i As Integer = 3
    Dim j As Integer
    For j = 1 To i - 1
       listBox1.Items.Add(j)
    Next
 
    ' Checks to see whether the user wants to exit the application.
    ' If not, adds another number to the list box.
    While (MessageBox.Show("Exit application?", "", MessageBoxButtons.YesNo) = _ 
       DialogResult.No)
       ' Increments the counter and adds the number to the list box.
       i = i + 1
       listBox1.Items.Add(i)
    End While
 
    ' The user wants to exit the application. Close everything down.
    Application.Exit()
 End Sub

' </Snippet1>
End Class
