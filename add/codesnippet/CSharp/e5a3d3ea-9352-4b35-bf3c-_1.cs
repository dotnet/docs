         // Check whether the specified object type is registered as 
         // well known client type or not.
         WellKnownClientTypeEntry myWellKnownClientType =
             RemotingConfiguration.IsWellKnownClientType(typeof(MyServerImpl));
         Console.WriteLine("The Object type is "
                           +myWellKnownClientType.ObjectType);
         Console.WriteLine("The Object Url is "
                           +myWellKnownClientType.ObjectUrl);