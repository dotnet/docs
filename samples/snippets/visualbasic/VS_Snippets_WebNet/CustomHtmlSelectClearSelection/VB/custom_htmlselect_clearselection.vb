Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlSelectClearSelection
        Inherits System.Web.UI.HtmlControls.HtmlSelect

        Protected Overrides Sub ClearSelection()

            ' For each item in the Items collection, 
            ' set the Selected property to false.
            Dim i As Integer
            For i = 0 To Items.Count - 1
                Items(i).Selected = False
            Next i
        End Sub
    End Class
    ' </Snippet2>
End Namespace
