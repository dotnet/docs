' <snippet2>
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls


Public Class SimpleControl
   Inherits UserControl
   Public name As TextBox
   Public output As Label
   Public myButton As Button
   
   
   Public Sub myButton_Click(sender As Object, e As EventArgs)

      output.Text = "Hello, " + name.Text + "."

   End Sub  

End Class
' </snippet2>