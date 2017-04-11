' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomTextBoxOnTextChanged
        Inherits System.Web.UI.WebControls.TextBox

        Private isDirty As Boolean = False

        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)

            ' Call the base OnTextChanged method.
            MyBase.OnTextChanged(e)

            ' Change the dirty flag to True.
            isDirty = True
        End Sub
    End Class
End Namespace
' </Snippet2>
