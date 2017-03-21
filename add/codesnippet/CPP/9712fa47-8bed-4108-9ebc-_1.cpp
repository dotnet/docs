   ServiceInstaller^ myServiceInstaller = gcnew ServiceInstaller;
   // Check whether 'ServiceInstaller' object can handle the same
   // kind of installation as 'EventLogInstaller' object.
   if ( myEventLogInstaller->IsEquivalentInstaller( myServiceInstaller ) )
   {
      Console::WriteLine( "'ServiceInstaller' can handle the same kind " +
         "of installation as EventLogInstaller" );
   }
   else
   {
      Console::WriteLine( "'ServiceInstaller' can't handle the same " +
         "kind of installation as 'EventLogInstaller'" );
   }