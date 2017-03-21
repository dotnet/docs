    Dim myServiceBehavior As ServiceAuthorizationBehavior
    myServiceBehavior = _
       myServiceHost.Description.Behaviors.Find(Of ServiceAuthorizationBehavior)()
    myServiceBehavior.PrincipalPermissionMode = _
       PrincipalPermissionMode.UseAspNetRoles