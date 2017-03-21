   // Retrive the array of objects registered as well known types at
   // the service end.
   array<WellKnownServiceTypeEntry^>^myEntries = RemotingConfiguration::GetRegisteredWellKnownServiceTypes();
   Console::WriteLine( "The number of WellKnownServiceTypeEntries are:{0}", myEntries->Length );
   Console::WriteLine( "The Object Type is:{0}", myEntries[ 0 ]->ObjectType );
   Console::WriteLine( "The Object Uri is:{0}", myEntries[ 0 ]->ObjectUri );
   Console::WriteLine( "The Mode is:{0}", myEntries[ 0 ]->Mode );