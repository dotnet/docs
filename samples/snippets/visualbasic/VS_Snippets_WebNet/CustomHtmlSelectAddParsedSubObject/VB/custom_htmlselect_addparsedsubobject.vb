Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlSelectAddParsedSubObject
        Inherits System.Web.UI.HtmlControls.HtmlSelect

        Protected Overrides Sub AddParsedSubObject(ByVal obj As Object)

            ' If the object is a ListItem, then add the ListItem to the Items collection.
            If TypeOf obj Is System.Web.UI.WebControls.ListItem Then
                Items.Add(CType(obj, System.Web.UI.WebControls.ListItem))
            Else
                Throw New System.Web.HttpException("You cannot have a child control of type " + obj.GetType().Name.ToString())
            End If
        End Sub
    End Class
    ' </Snippet2>
End Namespace