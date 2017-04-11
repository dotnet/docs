imports System
imports System.Data
imports System.ComponentModel
imports System.Windows.Forms

Public Class Form1: Inherits Form

 Protected textBox1 As TextBox
' <Snippet1>
 Public Sub CreateMyMenuItem()
     ' Create an instance of MenuItem with caption and an event 
     ' handler
     Dim MenuItem1 As New MenuItem("&New", New _
         System.EventHandler(AddressOf Me.MenuItem1_Click))
 End Sub
 ' This method is an event handler for MenuItem1 to use when 
 ' connecting its event handler.
 Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal _
     e as System.EventArgs)
     ' Code goes here that handles the Click event.
 End Sub
   
' </Snippet1>
End Class
