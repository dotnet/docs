         Dim myAssembly As [Assembly] = [Assembly].GetAssembly(GetType(MyServerImpl))
         Dim myName As AssemblyName = myAssembly.GetName()
         ' Check whether the 'MyServerImpl' type is registered as
         ' a remotely activated client type.
         Dim myActivatedClientEntry As ActivatedClientTypeEntry = _
                 RemotingConfiguration.IsRemotelyActivatedClientType(GetType(MyServerImpl).FullName, _
                 myName.Name)
         Console.WriteLine("The Object type : " + myActivatedClientEntry.ObjectType.ToString())
         Console.WriteLine("The Application Url : " + myActivatedClientEntry.ApplicationUrl)
         if myActivatedClientEntry is nothing then
	   Console.WriteLine("The object is not client activated")
	else
           Console.WriteLine("The object is client activated")
	end if