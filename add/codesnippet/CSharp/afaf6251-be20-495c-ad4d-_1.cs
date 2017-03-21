            ServiceHost myServiceHost = new ServiceHost(typeof(Calculator), baseUri);
            ServiceAuthorizationBehavior myServiceBehavior =
                myServiceHost.Description.Behaviors.Find<ServiceAuthorizationBehavior>();
            myServiceBehavior.PrincipalPermissionMode =
                PrincipalPermissionMode.UseAspNetRoles;
            MyServiceAuthorizationManager sm = new MyServiceAuthorizationManager();
            myServiceBehavior.ServiceAuthorizationManager = sm;