' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomXmlAddParsedSubObject
        Inherits System.Web.UI.WebControls.Xml

        Protected Overrides Sub AddParsedSubObject(ByVal obj As Object)

            ' Call the base AddParseSubObject method.
            MyBase.AddParsedSubObject(obj)

            ' Note: This method does not get called when transforming XML.
        End Sub
    End Class
End Namespace
' </Snippet2>
