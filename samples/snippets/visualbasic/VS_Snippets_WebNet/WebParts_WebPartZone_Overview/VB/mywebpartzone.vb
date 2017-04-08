' <Snippet3>
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.Web
Imports System.Security.Permissions
Imports System.ComponentModel
Imports System.Collections
Imports System

Namespace Samples.AspNet.VB.Controls
  

<AspNetHostingPermission(SecurityAction.Demand, _
  Level := AspNetHostingPermissionLevel.Minimal)> _
<AspNetHostingPermission(SecurityAction.InheritanceDemand, _
  Level := AspNetHostingPermissionLevel.Minimal)> _
Public Class MyWebPartZone
  Inherits WebPartZone
  
  Public Sub New()
    MyBase.New
    MyBase.VerbButtonType = ButtonType.Button
    MyBase.CloseVerb.Enabled = false
  End Sub
End Class
  
End Namespace
' </Snippet3>