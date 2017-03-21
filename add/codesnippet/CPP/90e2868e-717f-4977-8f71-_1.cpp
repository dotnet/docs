   // Get the well-known types registered at the client.
   array<WellKnownClientTypeEntry^>^myEntries = RemotingConfiguration::GetRegisteredWellKnownClientTypes();
   Console::WriteLine( "The number of WellKnownClientTypeEntries are:{0}", myEntries->Length );
   Console::WriteLine( "The Object type is:{0}", myEntries[ 0 ]->ObjectType );
   Console::WriteLine( "The Object Url is:{0}", myEntries[ 0 ]->ObjectUrl );