' <snippet1>
Imports System.Web
Imports System.Security.Permissions
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.Design.WebControls.WebParts
Imports System.ComponentModel

' <summary>
' The PrettyPartManager class is an inherited copy of WebPartManager for
' the purpose of applying the PrettyPartManagerDesigner at design time.
' PrettyPartManager provides an arbitrary design time rendering of the
' control by overriding GetDesignTimeHtml()
' </summary>
Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(PrettyPartManagerDesigner))> _
    Public Class PrettyPartManager
        Inherits WebPartManager
    End Class

    Public Class PrettyPartManagerDesigner
        Inherits WebPartManagerDesigner
        Public Overrides Function GetDesignTimeHtml() As String
            Dim designTimeHtml As String = ""
            designTimeHtml = "<div style=""background-color:bisque;"
            designTimeHtml += "border:thick groove mediumseagreen"">"
            designTimeHtml += "<span style=""font:italic 16pt bold Garamond"">"
            designTimeHtml += "PrettyPartManager</span><br />"
            designTimeHtml += "<span style=""font:italic 12pt Garamond"">"
            Dim m As WebPartManager = DirectCast(Component, WebPartManager)
            designTimeHtml += m.ID
            designTimeHtml += "</ span></ div>"
            Return designTimeHtml
        End Function
    End Class
End Namespace
'</snippet1>
