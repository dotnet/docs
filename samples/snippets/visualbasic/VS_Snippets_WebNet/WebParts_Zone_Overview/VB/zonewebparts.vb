' <snippet2> 
Imports System
Imports System.Security.Permissions 
Imports System.Web
Imports System.Web.UI.WebControls 
Imports System.Web.UI.WebControls.WebParts

Namespace Samples.AspNet.VB.Controls

<AspNetHostingPermission(SecurityAction.Demand, _ 
  Level := AspNetHostingPermissionLevel.Minimal)> _ 
<AspNetHostingPermission(SecurityAction.InheritanceDemand, _
  Level := AspNetHostingPermissionLevel.Minimal)> _ 
Public Class CalendarWebPart
  Inherits WebPart
  Private _calendar As Calendar

  Public Sub New()
    Me.AllowClose = False

  End Sub

  Protected Overrides Sub CreateChildControls()
      Controls.Clear()
      _calendar = New Calendar()
      _calendar.Caption = "My Calendar"
      Me.Controls.Add(_calendar)
      ChildControlsCreated = True
  
  End Sub 
  
End Class 

  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class LinksWebPart
    Inherits WebPart
    Private _literal As Literal
    Private Const _literalText As String = _
      "<table>" & _
      "<tr>" & _
      "<td><a href='http://msdn.microsoft.com'>MSDN</a></td>" & _
      "</tr>" & _
      "<tr>" & _
      "<td><a href='http://msn.microsoft.com'>MSN</a></td>" & _
      "</tr>" & _
      "<tr>" & _
      "<td><a href='http://www.msnbc.msn.com'>MSNBC</a></td>" & _
      "</tr>" & _
      "</table>"

    Public Sub New()
      Me.AllowClose = False

    End Sub


    Protected Overrides Sub CreateChildControls()
      Controls.Clear()

      _literal = New Literal()
      _literal.Text = _literalText
      Me.Controls.Add(_literal)

      ChildControlsCreated = True

    End Sub
  End Class

End Namespace 
' </snippet2>