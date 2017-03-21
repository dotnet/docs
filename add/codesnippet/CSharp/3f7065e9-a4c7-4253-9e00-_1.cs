            // Code to create a ServiceHost not shown.
            ServiceAuthorizationBehavior MyServiceAuthoriationBehavior = 
                serviceHost.Description.Behaviors.Find<ServiceAuthorizationBehavior>();
            MyServiceAuthoriationBehavior.ImpersonateCallerForAllOperations = true;