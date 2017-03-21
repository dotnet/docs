   static void DemandSecurityPermissions()
   {
      Console::WriteLine( "\nExecuting DemandSecurityPermissions.\n" );
      try
      {
         SecurityPermission^ sp = gcnew SecurityPermission( SecurityPermissionFlag::Assertion );
         Console::WriteLine( "Demanding SecurityPermissionFlag::Assertion" );
         sp->Demand();
         Console::WriteLine( "Demand for SecurityPermissionFlag::Assertion succeeded." );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Demand for SecurityPermissionFlag::Assertion failed: {0}", e->Message );
      }

      try
      {
         SecurityPermission^ sp = gcnew SecurityPermission( SecurityPermissionFlag::ControlAppDomain );
         Console::WriteLine( "Demanding SecurityPermissionFlag::ControlAppDomain" );
         sp->Demand();
         Console::WriteLine( "Demand for SecurityPermissionFlag::ControlAppDomain succeeded." );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Demand for SecurityPermissionFlag::ControlAppDomain failed: {0}", e->Message );
      }

      try
      {
         SecurityPermission^ sp = gcnew SecurityPermission( SecurityPermissionFlag::ControlDomainPolicy );
         Console::WriteLine( "Demanding SecurityPermissionFlag::ControlDomainPolicy" );
         sp->Demand();
         Console::WriteLine( "Demand for SecurityPermissionFlag::ControlDomainPolicy succeeded." );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Demand for SecurityPermissionFlag::ControlDomainPolicy failed: {0}", e->Message );
      }

      try
      {
         SecurityPermission^ sp = gcnew SecurityPermission( SecurityPermissionFlag::ControlEvidence );
         Console::WriteLine( "Demanding SecurityPermissionFlag::ControlEvidence" );
         sp->Demand();
         Console::WriteLine( "Demand for SecurityPermissionFlag::ControlEvidence succeeded." );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Demand for SecurityPermissionFlag::ControlEvidence failed: {0}", e->Message );
      }

      try
      {
         SecurityPermission^ sp = gcnew SecurityPermission( SecurityPermissionFlag::ControlPolicy );
         Console::WriteLine( "Demanding SecurityPermissionFlag::ControlPolicy" );
         sp->Demand();
         Console::WriteLine( "Demand for SecurityPermissionFlag::ControlPolicy succeeded." );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Demand for SecurityPermissionFlag::ControlPolicy failed: {0}", e->Message );
      }

      try
      {
         SecurityPermission^ sp = gcnew SecurityPermission( SecurityPermissionFlag::ControlPrincipal );
         Console::WriteLine( "Demanding SecurityPermissionFlag::ControlPrincipal" );
         sp->Demand();
         Console::WriteLine( "Demand for SecurityPermissionFlag::ControlPrincipal succeeded." );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Demand for SecurityPermissionFlag::ControlPrincipal failed: {0}", e->Message );
      }

      try
      {
         SecurityPermission^ sp = gcnew SecurityPermission( SecurityPermissionFlag::ControlThread );
         Console::WriteLine( "Demanding SecurityPermissionFlag::ControlThread" );
         sp->Demand();
         Console::WriteLine( "Demand for SecurityPermissionFlag::ControlThread succeeded." );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Demand for SecurityPermissionFlag::ControlThread failed: {0}", e->Message );
      }

      try
      {
         SecurityPermission^ sp = gcnew SecurityPermission( SecurityPermissionFlag::Execution );
         Console::WriteLine( "Demanding SecurityPermissionFlag::Execution" );
         sp->Demand();
         Console::WriteLine( "Demand for SecurityPermissionFlag::Execution succeeded." );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Demand for SecurityPermissionFlag::Execution failed: {0}", e->Message );
      }

      try
      {
         SecurityPermission^ sp = gcnew SecurityPermission( SecurityPermissionFlag::Infrastructure );
         Console::WriteLine( "Demanding SecurityPermissionFlag::Infrastructure" );
         sp->Demand();
         Console::WriteLine( "Demand for SecurityPermissionFlag::Infrastructure succeeded." );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Demand for SecurityPermissionFlag::Infrastructure failed: {0}", e->Message );
      }

      try
      {
         SecurityPermission^ sp = gcnew SecurityPermission( SecurityPermissionFlag::RemotingConfiguration );
         Console::WriteLine( "Demanding SecurityPermissionFlag::RemotingConfiguration" );
         sp->Demand();
         Console::WriteLine( "Demand for SecurityPermissionFlag::RemotingConfiguration succeeded." );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Demand for SecurityPermissionFlag::RemotingConfiguration failed: {0}", e->Message );
      }

      try
      {
         SecurityPermission^ sp = gcnew SecurityPermission( SecurityPermissionFlag::SerializationFormatter );
         Console::WriteLine( "Demanding SecurityPermissionFlag::SerializationFormatter" );
         sp->Demand();
         Console::WriteLine( "Demand for SecurityPermissionFlag::SerializationFormatter succeeded." );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Demand for SecurityPermissionFlag::SerializationFormatter failed: {0}", e->Message );
      }

      try
      {
         SecurityPermission^ sp = gcnew SecurityPermission( SecurityPermissionFlag::SkipVerification );
         Console::WriteLine( "Demanding SecurityPermissionFlag::SkipVerification" );
         sp->Demand();
         Console::WriteLine( "Demand for SecurityPermissionFlag::SkipVerification succeeded." );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Demand for SecurityPermissionFlag::SkipVerification failed: {0}", e->Message );
      }

      try
      {
         SecurityPermission^ sp = gcnew SecurityPermission( SecurityPermissionFlag::UnmanagedCode );
         Console::WriteLine( "Demanding SecurityPermissionFlag::UnmanagedCode" );
         sp->Demand();
         Console::WriteLine( "Demand for SecurityPermissionFlag::UnmanagedCode succeeded." );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Demand for SecurityPermissionFlag::UnmanagedCode failed: {0}", e->Message );
      }

   }