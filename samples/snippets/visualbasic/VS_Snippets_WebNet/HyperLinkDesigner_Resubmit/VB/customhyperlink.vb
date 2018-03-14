' CustomHyperlink.vb
' <snippet3>
Imports System.Web
Imports System.ComponentModel
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Examples.VB.WebControls.Design

    ' The CustomHyperLink is a copy of the HyperLink.
    ' It uses the CustomHyperLinkDesigner for design-time support. 
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(Examples.VB.WebControls.Design. _
        CustomHyperLinkDesigner))> _
    Public Class CustomHyperLink
        Inherits HyperLink
    End Class ' CustomHyperLink
End Namespace ' Examples.VB.WebControls.Design
' </snippet3>
