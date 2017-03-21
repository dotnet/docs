   // Check whether the specified object type is registered as 
   // well known client type or not.
   WellKnownClientTypeEntry^ myWellKnownClientType = RemotingConfiguration::IsWellKnownClientType( MyServerImpl::typeid );
   Console::WriteLine( "The Object type is {0}", myWellKnownClientType->ObjectType );
   Console::WriteLine( "The Object Url is {0}", myWellKnownClientType->ObjectUrl );