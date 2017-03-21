         // Get the well-known types registered at the client.
         WellKnownClientTypeEntry[] myEntries =
                RemotingConfiguration.GetRegisteredWellKnownClientTypes();
         Console.WriteLine("The number of WellKnownClientTypeEntries are:"
                                    +myEntries.Length);
         Console.WriteLine("The Object type is:"+myEntries[0].ObjectType);
         Console.WriteLine("The Object Url is:"+myEntries[0].ObjectUrl);