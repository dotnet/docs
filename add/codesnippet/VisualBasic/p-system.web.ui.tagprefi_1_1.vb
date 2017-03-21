
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

<assembly: TagPrefix("CustomControls", "custom")> _

Namespace CustomControls
   
   ' Simple custom control
   Public Class MyVB_Control 
   Inherits Control
      Private message As String = "Hello"
      
      Public  Property getMessage() As String
         Get
            Return message
         End Get
         Set (ByVal value As String)
            message = value
         End Set
      End Property
      
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub Render(writer As HtmlTextWriter)
         writer.Write(("<span style='background-color:aqua; font:8pt tahoma, verdana;'> " + Me.getMessage + "<br>" + "VB version. The time on the server is " + System.DateTime.Now.ToLongTimeString() + "</span>"))
      End Sub 'Render
   End Class 'MyControl
End Namespace 'CustomControls 
