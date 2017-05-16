' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomRadioButtonListCreateControlStyle
        Inherits System.Web.UI.WebControls.RadioButtonList

        Protected Overrides Function CreateControlStyle() As System.Web.UI.WebControls.Style

            ' Initializes and return a new instance of the TableStyle class.
            Return New System.Web.UI.WebControls.TableStyle(Me.ViewState)
        End Function
    End Class
End Namespace
' </Snippet2>
