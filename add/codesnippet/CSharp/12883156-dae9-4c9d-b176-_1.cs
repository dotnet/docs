            Assembly myAssembly = Assembly.GetAssembly(typeof(MyServerImpl));
            AssemblyName myName = myAssembly.GetName();
            // Check whether the 'MyServerImpl' type is registered as
            // a remotely activated client type.
            ActivatedClientTypeEntry myActivatedClientEntry =
            RemotingConfiguration.IsRemotelyActivatedClientType(
                                 (typeof(MyServerImpl)).FullName,myName.Name);
            Console.WriteLine("The Object type : "
                   +myActivatedClientEntry.ObjectType);
            Console.WriteLine("The Application Url : "
                   +myActivatedClientEntry.ApplicationUrl);
	    if (myActivatedClientEntry != null)
		Console.WriteLine("Object is client activated");
	    else 
		Console.WriteLine("Object is not client activated");