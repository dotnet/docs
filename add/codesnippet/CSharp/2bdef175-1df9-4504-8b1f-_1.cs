         MyServerImpl myObject = new MyServerImpl();
         // Get the assembly for the 'MyServerImpl' object.
         Assembly myAssembly = Assembly.GetAssembly(typeof(MyServerImpl));
         AssemblyName myName = myAssembly.GetName();
        // Check whether the specified object type is registered as
        // well-known client type.
        WellKnownClientTypeEntry myWellKnownClientType =
           RemotingConfiguration.IsWellKnownClientType(
                             (typeof(MyServerImpl)).FullName,myName.Name);
        Console.WriteLine("The Object type :"
                        +myWellKnownClientType.ObjectType);
        Console.WriteLine("The Object Uri :"
                        +myWellKnownClientType.ObjectUrl);