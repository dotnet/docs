
      // Check whether the 'MyServerImpl' object is allowed for 
      // activation or not.
      if(RemotingConfiguration.IsActivationAllowed(typeof(MyServerImpl)))
      {
       // Get the registered activated service types .
       ActivatedServiceTypeEntry[] myActivatedServiceEntries =
             RemotingConfiguration.GetRegisteredActivatedServiceTypes();
      Console.WriteLine("The Length of the registered activated service"
                       +" type array is "+myActivatedServiceEntries.Length);
      Console.WriteLine("The Object type is:"
                          +myActivatedServiceEntries[0].ObjectType);
      }
