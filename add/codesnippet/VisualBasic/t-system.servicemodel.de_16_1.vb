			Dim myServiceHost As New ServiceHost(GetType(Calculator), baseUri)
			Dim myServiceBehavior As ServiceAuthorizationBehavior = myServiceHost.Description.Behaviors.Find(Of ServiceAuthorizationBehavior)()
			myServiceBehavior.PrincipalPermissionMode = PrincipalPermissionMode.UseAspNetRoles