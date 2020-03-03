' <snippet8>
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class LogOnControl
   Inherits UserControl

   Public user As TextBox
   Public password As TextBox
   Public Message As Label
   
   Public Sub Page_Load(sender As [Object], e As EventArgs)
      Message.Text = "Welcome to a simple User Control!"
   End Sub
End Class
' </snippet8>