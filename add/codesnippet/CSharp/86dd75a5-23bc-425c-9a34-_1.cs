
   // Retrive the array of objects registered as well known types at
   // the service end.
   WellKnownServiceTypeEntry[] myEntries =
             RemotingConfiguration.GetRegisteredWellKnownServiceTypes();
   Console.WriteLine("The number of WellKnownServiceTypeEntries are:"
                                 +myEntries.Length);
   Console.WriteLine("The Object Type is:"+myEntries[0].ObjectType);
   Console.WriteLine("The Object Uri is:"+myEntries[0].ObjectUri);
   Console.WriteLine("The Mode is:"+myEntries[0].Mode);
