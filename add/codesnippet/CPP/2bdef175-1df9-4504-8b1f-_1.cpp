   MyServerImpl ^ myObject = gcnew MyServerImpl;

   // Get the assembly for the 'MyServerImpl' object.
   Assembly^ myAssembly = Assembly::GetAssembly( MyServerImpl::typeid );
   AssemblyName^ myName = myAssembly->GetName();

   // Check whether the specified object type is registered as
   // well-known client type.
   WellKnownClientTypeEntry^ myWellKnownClientType = RemotingConfiguration::IsWellKnownClientType( MyServerImpl::typeid->FullName, myName->Name );
   Console::WriteLine( "The Object type :{0}", myWellKnownClientType->ObjectType );
   Console::WriteLine( "The Object Uri :{0}", myWellKnownClientType->ObjectUrl );