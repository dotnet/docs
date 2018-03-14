' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomRepeaterOnBubbleEvent
        Inherits System.Web.UI.WebControls.Repeater

        Protected Overrides Function OnBubbleEvent(ByVal [source] As Object, ByVal args As System.EventArgs) As Boolean

            ' If the EventArgs are of type RepeaterCommadnEventArgs,
            ' then call the OnItemCommand event handler and return true (bubble up the event)
            ' else return false (don't bubble up the event).
            Dim isHandled As Boolean = False
            If TypeOf args Is System.Web.UI.WebControls.RepeaterCommandEventArgs Then
                Me.OnItemCommand(CType(args, System.Web.UI.WebControls.RepeaterCommandEventArgs))
                isHandled = True
            End If
            Return isHandled
        End Function
    End Class
End Namespace
' </Snippet2>
