Imports System
Imports System.Data
Imports System.Security.Principal
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected Sub Method(userToken As IntPtr)
' <Snippet1>
 Dim ImpersonationCtx As WindowsImpersonationContext = _
    WindowsIdentity.Impersonate(userToken)
 'Do something under the context of the impersonated user. 
 ImpersonationCtx.Undo()

' </Snippet1>
    End Sub
End Class

