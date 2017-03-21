      Dim myObject As New MyServerImpl()
      ' Get the assembly for the 'MyServerImpl' object.
      Dim myAssembly As [Assembly] = [Assembly].GetAssembly(GetType(MyServerImpl))
      Dim myName As AssemblyName = myAssembly.GetName()
      ' Check whether the specified object type is registered as
      ' well-known client type.
      Dim myWellKnownClientType As WellKnownClientTypeEntry = _
           RemotingConfiguration.IsWellKnownClientType(GetType(MyServerImpl).FullName, myName.Name)
      Console.WriteLine("The Object type :" + myWellKnownClientType.ObjectType.ToString())
      Console.WriteLine("The Object Uri :" + myWellKnownClientType.ObjectUrl)