 Dim ImpersonationCtx As WindowsImpersonationContext = _
    WindowsIdentity.Impersonate(userToken)
 'Do something under the context of the impersonated user. 
 ImpersonationCtx.Undo()
