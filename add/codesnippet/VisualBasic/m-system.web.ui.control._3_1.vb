   Public Class ChildControl
      Inherits Button
      
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub OnClick(e As EventArgs)
         MyBase.OnClick(e)
         Context.Response.Write("<br><br>ChildControl's OnClick called.")
         ' Bubble this event to parent.
         RaiseBubbleEvent(Me, e)
      End Sub 'OnClick
   End Class 'ChildControl 