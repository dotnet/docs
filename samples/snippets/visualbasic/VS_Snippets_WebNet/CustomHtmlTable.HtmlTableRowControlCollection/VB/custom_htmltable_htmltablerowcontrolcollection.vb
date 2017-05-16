' <Snippet2>
Imports System.Web
Imports System.Web.UI
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomHtmlTableRowControlCollection
        Inherits System.Web.UI.HtmlControls.HtmlTable

        Protected Overrides Function CreateControlCollection() As System.Web.UI.ControlCollection

            Return New MyHtmlTableRowControlCollection(Me)

        End Function

        Protected Class MyHtmlTableRowControlCollection
            Inherits ControlCollection

            Friend Sub New(ByVal owner As Control)

                MyBase.New(owner)

            End Sub

            Public Overrides Sub Add(ByVal child As Control)

                ' Always add new rows at the top of the table.
                MyBase.AddAt(0, child)

            End Sub

        End Class

    End Class

End Namespace
' </Snippet2>
