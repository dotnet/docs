' <Snippet1>
Imports System
Imports System.Web.UI
Imports System.Collections
Imports System.Collections.Specialized

Namespace CustomControls    
    
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> Public Class MyButton
        Inherits Control
        Implements IPostBackEventHandler
        
        ' Define the Click event.
        Public Event Click As EventHandler
        
        
        ' Invoke delegates registered with the Click event.
        Protected Overridable Sub OnClick(e As EventArgs)            
            RaiseEvent Click(Me, e)
        End Sub
        
        
        ' Define the method of IPostBackEventHandler that raises change events.
        Public Sub RaisePostBackEvent(eventArgument As String) _
        Implements IPostBackEventHandler.RaisePostBackEvent
        
            OnClick(New EventArgs())
        End Sub       
        
        
        Protected Overrides Sub Render(output As HtmlTextWriter)
            output.Write("<INPUT TYPE = submit name = " & Me.UniqueID & _
                " Value = 'Click Me' />")
        End Sub
        
    End Class
End Namespace

' </Snippet1>
