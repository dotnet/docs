' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls

Public NotInheritable Class CustomHtmlTextAreaAddParsedSubObject
   Inherits System.Web.UI.HtmlControls.HtmlTextArea

        <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
        Protected Overrides Sub AddParsedSubObject(ByVal obj As Object)

            ' If the object is a LiteralControl or a DataBoundLiteralControl control, 
            ' then pass the object to the base class's AddParsedSubObject method.
            If TypeOf obj Is System.Web.UI.LiteralControl OrElse TypeOf obj Is System.Web.UI.DataBoundLiteralControl Then
                MyBase.AddParsedSubObject(obj)
            Else
                Throw New System.Web.HttpException("You cannot have a child control of type " _ 
                  & obj.GetType().Name.ToString() & ".")
            End If
        End Sub

End Class
End Namespace
' </Snippet2>
