' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomTextBoxAddParsedSubObject
        Inherits System.Web.UI.WebControls.TextBox

        Protected Overrides Sub AddParsedSubObject(ByVal obj As Object)

            ' If the object is a LiteralControl, then set this control's Text property.
            If TypeOf obj Is System.Web.UI.LiteralControl Then
                Me.Text = CType(obj, System.Web.UI.LiteralControl).Text
            Else
                Throw New System.Web.HttpException("You cannot have children controls of type " + obj.GetType().Name.ToString())
            End If
        End Sub
    End Class
End Namespace
' </Snippet2>
