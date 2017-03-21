            ' Code to create a ServiceHost not shown.
            Dim MyServiceAuthoriationBehavior As ServiceAuthorizationBehavior 
            MyServiceAuthoriationBehavior= serviceHost.Description.Behaviors.Find _
            (Of ServiceAuthorizationBehavior)()
            MyServiceAuthoriationBehavior.ImpersonateCallerForAllOperations = True