
// <Snippet1>
using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
public ref class GacIdentityPermissionDemo
{
private:

   // <Snippet2>
   // IsSubsetOf determines whether the current permission is a subset of the specified permission.
   bool IsSubsetOfDemo()
   {
      try
      {
         
         //<Snippet9>
         GacIdentityPermission ^ Gac1 = gcnew GacIdentityPermission;
         GacIdentityPermission ^ Gac2 = gcnew GacIdentityPermission( PermissionState::None );
         if ( Gac1->Equals( Gac2 ) )
                  Console::WriteLine( "GacIdentityPermission() equals GacIdentityPermission(PermissionState.None)." );

         
         //</Snippet9>
         if ( Gac1->IsSubsetOf( Gac2 ) )
         {
            Console::WriteLine( "{0} is a subset of {1}", Gac1, Gac2 );
         }
         else
         {
            Console::WriteLine( "{0} is not a subset of {1}", Gac1, Gac2 );
         }
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "An exception was thrown : {0}", e );
         return false;
      }

      return true;
   }


   // </Snippet2>
   // <Snippet3>
   // Union creates a new permission that is the union of the current permission 
   // and the specified permission.
   bool UnionDemo()
   {
      
      //<Snippet7>
      GacIdentityPermission ^ Gac1 = gcnew GacIdentityPermission( PermissionState::None );
      
      //</Snippet7>
      //<Snippet8>
      GacIdentityPermission ^ Gac2 = gcnew GacIdentityPermission;
      
      //</Snippet8>
      try
      {
         GacIdentityPermission ^ p3 = dynamic_cast<GacIdentityPermission^>(Gac1->Union( Gac2 ));
         if ( p3 != nullptr )
         {
            Console::WriteLine( "The union of two GacIdentityPermissions was successful." );
         }
         else
         {
            Console::WriteLine( "The union of two GacIdentityPermissions failed." );
            return false;
         }
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "An exception was thrown : {0}", e );
         return false;
      }

      return true;
   }


   // </Snippet3>
   // <Snippet4>
   // Intersect creates and returns a new permission that is the intersection of the 
   // current permission and the specified permission.
   bool IntersectDemo()
   {
      GacIdentityPermission ^ Gac1 = gcnew GacIdentityPermission;
      GacIdentityPermission ^ Gac2 = gcnew GacIdentityPermission;
      try
      {
         GacIdentityPermission ^ p3 = dynamic_cast<GacIdentityPermission^>(Gac1->Intersect( Gac2 ));
         if ( p3 != nullptr )
         {
            Console::WriteLine( "The intersection of the two permissions = {0}\n", p3 );
         }
         else
         {
            Console::WriteLine( "The intersection of the two permissions is null.\n" );
         }
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "An exception was thrown : {0}", e );
         return false;
      }

      return true;
   }


   //</Snippet4>
   //<Snippet5>
   //Copy creates and returns an identical copy of the current permission.
   bool CopyDemo()
   {
      GacIdentityPermission ^ Gac1 = gcnew GacIdentityPermission;
      GacIdentityPermission ^ Gac2 = gcnew GacIdentityPermission;
      Console::WriteLine( "**************************************************************************" );
      try
      {
         Gac2 = dynamic_cast<GacIdentityPermission^>(Gac1->Copy());
         if ( Gac2 != nullptr )
         {
            Console::WriteLine( "Result of copy = {0}\n", Gac2 );
         }
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Copy failed : {0}{1}", Gac1, e );
         return false;
      }

      return true;
   }


   //</Snippet5>
   //<Snippet6>
   // ToXml creates an XML encoding of the permission and its current state; FromXml reconstructs a 
   // permission with the specified state from the XML encoding. 
   bool ToFromXmlDemo()
   {
      GacIdentityPermission ^ Gac1 = gcnew GacIdentityPermission;
      GacIdentityPermission ^ Gac2 = gcnew GacIdentityPermission;
      Console::WriteLine( "**************************************************************************" );
      try
      {
         Gac2 = gcnew GacIdentityPermission( PermissionState::None );
         Gac2->FromXml( Gac1->ToXml() );
         bool result = Gac2->Equals( Gac1 );
         if ( Gac2->IsSubsetOf( Gac1 ) && Gac1->IsSubsetOf( Gac2 ) )
         {
            Console::WriteLine( "Result of ToFromXml = {0}", Gac2 );
         }
         else
         {
            Console::WriteLine( Gac2 );
            Console::WriteLine( Gac1 );
            return false;
         }
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "ToFromXml failed. {0}", e );
         return false;
      }

      return true;
   }


public:

   //</Snippet6>
   // Invoke all demos.
   bool RunDemo()
   {
      bool returnCode = true;
      bool tempReturnCode;
      
      // Call the IsSubsetOf demo.
      if ( tempReturnCode = IsSubsetOfDemo() )
            Console::WriteLine( "IsSubsetOf demo completed successfully." );
      else
            Console::WriteLine( "Subset demo failed." );

      returnCode = tempReturnCode && returnCode;
      
      // Call the Union demo.
      if ( tempReturnCode = UnionDemo() )
            Console::WriteLine( "Union demo completed successfully." );
      else
            Console::WriteLine( "Union demo failed." );

      returnCode = tempReturnCode && returnCode;
      
      // Call the Intersect demo. 
      if ( tempReturnCode = IntersectDemo() )
            Console::WriteLine( "Intersect demo completed successfully." );
      else
            Console::WriteLine( "Intersect demo failed." );

      returnCode = tempReturnCode && returnCode;
      
      // Call the Copy demo. 
      if ( tempReturnCode = CopyDemo() )
            Console::WriteLine( "Copy demo completed successfully." );
      else
            Console::WriteLine( "Copy demo failed." );

      returnCode = tempReturnCode && returnCode;
      
      // Call the ToFromXML demo. 
      if ( tempReturnCode = ToFromXmlDemo() )
            Console::WriteLine( "ToFromXML demo completed successfully." );
      else
            Console::WriteLine( "ToFromXml demo failed." );

      returnCode = tempReturnCode && returnCode;
      return (returnCode);
   }

};


// Test harness.
int main()
{
   try
   {
      GacIdentityPermissionDemo^ testcase = gcnew GacIdentityPermissionDemo;
      bool returnCode = testcase->RunDemo();
      if ( returnCode )
      {
         Console::WriteLine( "The GacIdentityPermission demo completed successfully." );
         Console::WriteLine( "Press the Enter key to exit." );
         Console::ReadLine();
         System::Environment::ExitCode = 100;
      }
      else
      {
         Console::WriteLine( "The GacIdentityPermission demo failed." );
         Console::WriteLine( "Press the Enter key to exit." );
         Console::ReadLine();
         System::Environment::ExitCode = 101;
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The GacIdentityPermission demo failed." );
      Console::WriteLine( e );
      Console::WriteLine( "Press the Enter key to exit." );
      Console::ReadLine();
      System::Environment::ExitCode = 101;
   }

}

// </Snippet1>
