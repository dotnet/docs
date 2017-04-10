' <Snippet1>
' This example shows a code-behind page that includes a custom control,
' MyControl. The control overrides its Render method to write some HTML
' to the page, while the Page uses the Control's constructor to instantiate
' MyControl. The page also overrides its own constructor to ensure that a
' custom Load event is used when the page is called by a request.

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB

<AspNetHostingPermission(SecurityAction.Demand, _
   Level:=AspNetHostingPermissionLevel.Minimal)> _
Public NotInheritable Class MyControl
   Inherits Control
   
   ' Override the Render method.
   Protected Overrides Sub Render(w As HtmlTextWriter)
      w.Write("<h2>Implementation Of Control</h2>")
      w.Write(("<h3><i><font color=green>Reference : " & CType(Controls(0), LiteralControl).Text + "</font></i></h3>"))
   End Sub 'Render
End Class 'MyControl

Public Class MyPage
   Inherits Page
   ' Create an instance of the MyControl class.
   Protected ctlOne As New MyControl()
   
   
' <snippet2>
   ' This is the constructor for a custom Page class. 
   ' When this constructor is called, it associates the Control.Load event,
   ' which the Page class inherits from the Control class, with the Page_Load
   ' event handler for this version of the page.
   Public Sub New()
      AddHandler Load, AddressOf Page_Load
   End Sub 'New
   
' </snippet2>
   Private Sub Page_Load(sender As Object, e As System.EventArgs)
      Page.Controls.Add(ctlOne)
      ' Add a LiteralControl to ctlOne.
      ctlOne.Controls.Add(New LiteralControl("<h4> MSDN Library <h4>"))
   End Sub 'Page_Load
End Class 'MyPage

End Namespace
' </Snippet1>