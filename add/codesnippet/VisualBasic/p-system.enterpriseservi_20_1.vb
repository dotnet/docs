<SecurityRole("Role1")>  _
Public Class ContextUtil_IsSecurityEnabled
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Display whether role-based security is active for the current COM+
        ' context.
        MsgBox("Role-based security active in current context: " & ContextUtil.IsSecurityEnabled)

    End Sub 'Example
End Class 'ContextUtil_IsSecurityEnabled