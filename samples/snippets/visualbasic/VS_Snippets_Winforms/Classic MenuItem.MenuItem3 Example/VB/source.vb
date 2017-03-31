Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
' <Snippet1>
 Public Sub CreateMyMenuItem()
     ' Create a MenuItem with caption, shortcut key, and an event handler
     ' specified.
     Dim MenuItem1 As New MenuItem("&New", _
        New System.EventHandler(AddressOf Me.MenuItem1_Click), Shortcut.CtrlL)
 End Sub    
    
 ' The following method is an event handler for menuItem1 to use when
 ' connecting the event handler.
 Private Sub MenuItem1_Click(sender As Object, e As EventArgs)
     ' Code goes here that handles the Click event.
 End Sub

' </Snippet1>
End Class


