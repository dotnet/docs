   // Check whether the 'MyServerImpl' object is allowed for 
   // activation or not.
   if ( RemotingConfiguration::IsActivationAllowed( MyServerImpl::typeid ) )
   {
      // Get the registered activated service types .
      array<ActivatedServiceTypeEntry^>^myActivatedServiceEntries = RemotingConfiguration::GetRegisteredActivatedServiceTypes();
      Console::WriteLine( "The Length of the registered activated service type array is {0}", myActivatedServiceEntries->Length );
      Console::WriteLine( "The Object type is:{0}", myActivatedServiceEntries[ 0 ]->ObjectType );
   }