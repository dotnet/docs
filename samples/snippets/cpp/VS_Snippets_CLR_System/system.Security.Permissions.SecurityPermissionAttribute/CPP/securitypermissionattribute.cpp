
//<Snippet1>
// This sample demonstrates the use of the SecurityPermissionAttribute.
using namespace System;
using namespace System::Security::Permissions;
using namespace System::Security;
class MyClass
{
public:
   static void PermissionDemo()
   {
      try
      {
         DenySecurityPermissions();
         DenyAllSecurityPermissions();
         DoNotDenySecurityPermissions();
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e->Message );
      }

   }


   // This method demonstrates the use of the SecurityPermissionAttribute to deny individual security permissions.
   //<Snippet2>
   // Set the Assertion property.
   [SecurityPermissionAttribute(SecurityAction::Deny,Assertion=true)]
   //</Snippet2>
   //<Snippet3>
   // Set the ControlAppDomain property.
   [SecurityPermissionAttribute(SecurityAction::Deny,ControlAppDomain=true)]
   //</Snippet3>
   //<Snippet4>
   // Set the ControlDomainPolicy property.
   [SecurityPermissionAttribute(SecurityAction::Deny,ControlDomainPolicy=true)]
   //</Snippet4>
   //<Snippet5>
   [SecurityPermissionAttribute(SecurityAction::Deny,ControlEvidence=true)]
   // Set the ControlEvidence property.
   //</Snippet5>
   //<Snippet6>
   [SecurityPermissionAttribute(SecurityAction::Deny,ControlPolicy=true)]
   // Set the ControlPolicy property.
   //</Snippet6>
   //<Snippet7>
   [SecurityPermissionAttribute(SecurityAction::Deny,ControlPrincipal=true)]
   // Set the ControlPrincipal property.
   //</Snippet7>
   //<Snippet8>
   // Set the ControlThread property.
   [SecurityPermissionAttribute(SecurityAction::Deny,ControlThread=true)]
   //</Snippet8>
   //<Snippet9>
   // Set the Execution property.
   [SecurityPermissionAttribute(SecurityAction::Deny,Execution=true)]
   //</Snippet9>
   //<Snippet11>
   // Set the Flags property.
   [SecurityPermissionAttribute(SecurityAction::Deny,Flags=SecurityPermissionFlag::NoFlags)]
   //</Snippet11>
   //<Snippet12>
   // Set the Infrastructure property.
   [SecurityPermissionAttribute(SecurityAction::Deny,Infrastructure=true)]
   //</Snippet12>
   //<Snippet13>
   // Set the RemotingConfiguration property.
   [SecurityPermissionAttribute(SecurityAction::Deny,RemotingConfiguration=true)]
   //</Snippet13>
   //<Snippet15>
   // Set the SerializationFormatter property.
   [SecurityPermissionAttribute(SecurityAction::Deny,SerializationFormatter=true)]
   //</Snippet15>
   //<Snippet16>
   // Set the SkipVerification property.
   [SecurityPermissionAttribute(SecurityAction::Deny,SkipVerification=true)]
   //</Snippet16>
   //<Snippet17>
   // Set the UnmanagedCode property.
   [SecurityPermissionAttribute(SecurityAction::Deny,UnmanagedCode=true)]
   //</Snippet17>

   static void DenySecurityPermissions()
   {
      Console::WriteLine( "Executing DenySecurityPermissions." );
      Console::WriteLine( "Denied all permissions individually." );
      TestSecurityPermissions();
   }


   // This method demonstrates the use of SecurityPermissionFlag::AllFlags to deny all security permissions.

   [SecurityPermissionAttribute(SecurityAction::Deny,Flags=SecurityPermissionFlag::AllFlags)]
   static void DenyAllSecurityPermissions()
   {
      Console::WriteLine( "\nExecuting DenyAllSecurityPermissions." );
      Console::WriteLine( "Denied all permissions using SecurityPermissionFlag::AllFlags." );
      TestSecurityPermissions();
   }


   // This method demonstrates the effect of not denying security permissions.
   static void DoNotDenySecurityPermissions()
   {
      Console::WriteLine( "\nExecuting DoNotDenySecurityPermissions." );
      Console::WriteLine( "No permissions have been denied." );
      DemandSecurityPermissions();
   }

   static void TestSecurityPermissions()
   {
      Console::WriteLine( "\nExecuting TestSecurityPermissions.\n" );
      try
      {
         SecurityPermission^ sp = gcnew SecurityPermission( SecurityPermissionFlag::Assertion );
         Console::WriteLine( "Demanding SecurityPermissionFlag::Assertion" );
         
         // This demand should cause an exception.
         sp->Demand();
         
         // The TestFailed method is called if an exception is not thrown.
         TestFailed();
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
         TestFailed();
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
         TestFailed();
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
         TestFailed();
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
         TestFailed();
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
         TestFailed();
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
         TestFailed();
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
         TestFailed();
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
         TestFailed();
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
         TestFailed();
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
         TestFailed();
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
         TestFailed();
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Demand for SecurityPermissionFlag::SkipVerification failed: {0}", e->Message );
      }

      try
      {
         SecurityPermission^ sp = gcnew SecurityPermission( SecurityPermissionFlag::UnmanagedCode );
         Console::WriteLine( "Demanding SecurityPermissionFlag::UnmanagedCode" );
         
         // This demand should cause an exception.
         sp->Demand();
         
         // The TestFailed method is called if an exception is not thrown.
         TestFailed();
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Demand for SecurityPermissionFlag::UnmanagedCode failed: {0}", e->Message );
      }

   }

   static void TestFailed()
   {
      Console::WriteLine( "In TestFailed method." );
      Console::WriteLine( "Throwing an exception." );
      throw gcnew Exception;
   }
   
//<Snippet18>
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
//</Snippet18>

};

int main()
{
   MyClass::PermissionDemo();
}

//</Snippet1>
