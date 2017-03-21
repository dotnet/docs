      ' Get the well-known types registered at the client.
      Dim myEntries As WellKnownClientTypeEntry() = _ 
                              RemotingConfiguration.GetRegisteredWellKnownClientTypes()
      Console.WriteLine("The number of WellKnownClientTypeEntries are:" +  _ 
                                                        myEntries.Length.ToString())
      Console.WriteLine("The Object type is:" + myEntries(0).ObjectType.ToString())
      Console.WriteLine("The Object Url is:" + myEntries(0).ObjectUrl.ToString())