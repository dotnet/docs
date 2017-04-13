' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomRepeaterOnDataBinding
        Inherits System.Web.UI.WebControls.Repeater

        Protected Overrides Sub OnDataBinding(ByVal e As System.EventArgs)
            ' Raise the OnDataBinding event.
            MyBase.OnDataBinding(e)

            ' Clear out the controls collection and child viewstate.
            Me.Controls.Clear()
            Me.ClearChildViewState()

            ' Create a new control hierarchy.
            Me.CreateControlHierarchy(True)
            Me.ChildControlsCreated = True
        End Sub
    End Class
End Namespace
' </Snippet2>
