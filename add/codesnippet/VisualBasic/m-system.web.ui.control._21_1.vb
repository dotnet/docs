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
      End Sub 'Render
   End Class 'ParentControl
    _