      Assembly^ myAssembly = Assembly::GetAssembly( MyServerImpl::typeid );
      AssemblyName^ myName = myAssembly->GetName();

      // Check whether the 'MyServerImpl' type is registered as
      // a remotely activated client type.
      ActivatedClientTypeEntry^ myActivatedClientEntry = 
		  RemotingConfiguration::IsRemotelyActivatedClientType( MyServerImpl::typeid->FullName, myName->Name );
      Console::WriteLine( "The Object type : {0}", myActivatedClientEntry->ObjectType );
      Console::WriteLine( "The Application Url : {0}", myActivatedClientEntry->ApplicationUrl );
      if (myActivatedClientEntry)
         Console::WriteLine( "The object is client activated");
      else
	Console::WriteLine("The object is not client activated");