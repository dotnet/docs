' <Snippet1>
' The following example uses the 
' DataBindingHandlerAttribute(String) constructor to designate
' the custom DataBindingHandler class, named MyDataBindingHandler,
' for the custom MyWebControl class.
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design
Imports System.ComponentModel.Design
Imports System.Security.Permissions

Namespace MyTextCustomControl

 <DataBindingHandlerAttribute("MyTextCustomControl.MyDataBindingHandler")>  _
 <AspNetHostingPermission(SecurityAction.Demand, _
   Level:=AspNetHostingPermissionLevel.Minimal)> _
 Public NotInheritable Class MyWebControl
   Inherits WebControl
   
   Protected Overrides Sub Render(output As HtmlTextWriter)
      output.Write("This class uses the DataBindingHandlerAttribute class.")
   End Sub 'Render 
 End Class 'MyWebControl


 Public Class MyDataBindingHandler
   Inherits TextDataBindingHandler
   
   Public Overrides Sub DataBindControl(host As IDesignerHost, myControl As Control)
      CType(myControl, TextBox).Text = "Added by MyDataBindingHandler"
   End Sub 'DataBindControl
 End Class 'MyDataBindingHandler
End Namespace 'MyTextCustomControl
' </Snippet1>