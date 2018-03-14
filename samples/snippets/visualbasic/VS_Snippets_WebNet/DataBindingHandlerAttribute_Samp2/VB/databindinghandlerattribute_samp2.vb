' <Snippet1>
' The following example uses the Default
' DataBindingHandlerAttribute constructor.
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace MyTextCustomControl

 <DataBindingHandlerAttribute()>  _
 <AspNetHostingPermission(SecurityAction.Demand, _
   Level:=AspNetHostingPermissionLevel.Minimal)> _
 Public NotInheritable Class MyTextBox
   Inherits TextBox
   
   Protected Overrides Sub Render(output As HtmlTextWriter)
      output.Write("This class uses the DataBindingHandlerAttribute class.")
   End Sub 'Render 

 End Class 'MyTextBox
End Namespace 'MyTextCustomControl
' </Snippet1>