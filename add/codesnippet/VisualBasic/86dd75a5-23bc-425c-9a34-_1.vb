
      ' Retrive the array of objects registered as well known types at
      ' the service end.
      Dim myEntries As WellKnownServiceTypeEntry() = _ 
                       RemotingConfiguration.GetRegisteredWellKnownServiceTypes()
      Console.WriteLine("The number of WellKnownServiceTypeEntries are:" + myEntries.Length.ToString())
      Console.WriteLine("The Object Type is:" + myEntries(0).ObjectType.ToString())
      Console.WriteLine("The Object Uri is:" + myEntries(0).ObjectUri)
      Console.WriteLine("The Mode is:" + myEntries(0).Mode.ToString())
      