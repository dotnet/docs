Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class Form1
    Inherits Page
    
    Protected Label2 As Label
    
' <Snippet1>
 Sub R1_ItemCommand(Sender As Object, e As RepeaterCommandEventArgs)
     Label2.Text = "The " & CType(e.CommandSource, Button).Text & _
        " button has just been clicked; <br>"
 End Sub

' </Snippet1>
End Class

