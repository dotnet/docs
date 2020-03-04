Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


Namespace Bubble
    _
   ' <snippet1>
   Public Class ParentControl
      Inherits Control
      
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Function OnBubbleEvent(sender As Object, e As EventArgs) As Boolean
         Context.Response.Write("<br><br>ParentControl's OnBubbleEvent called.")
         Context.Response.Write(("<br>Source of event is: " + sender.ToString()))
         Return True
      End Function 'OnBubbleEvent
      
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub Render(myWriter As HtmlTextWriter)
         myWriter.Write("ParentControl")
         RenderChildren(myWriter)
      End Sub
   End Class
    _
   ' </snippet1>
   ' <snippet2>
   Public Class ChildControl
      Inherits Button
      
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub OnClick(e As EventArgs)
         MyBase.OnClick(e)
         Context.Response.Write("<br><br>ChildControl's OnClick called.")
         ' Bubble this event to parent.
         RaiseBubbleEvent(Me, e)
      End Sub
   End Class
   ' </snippet2>  
End Namespace 'Bubble