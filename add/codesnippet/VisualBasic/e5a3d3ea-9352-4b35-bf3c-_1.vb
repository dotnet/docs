      ' Check whether the specified object type is registered as 
      ' well known client type or not.
      Dim myWellKnownClientType As WellKnownClientTypeEntry = _ 
                         RemotingConfiguration.IsWellKnownClientType(GetType(MyServerImpl))
      Console.WriteLine("The Object type is " + myWellKnownClientType.ObjectType.ToString())
      Console.WriteLine("The Object Url is " + myWellKnownClientType.ObjectUrl)