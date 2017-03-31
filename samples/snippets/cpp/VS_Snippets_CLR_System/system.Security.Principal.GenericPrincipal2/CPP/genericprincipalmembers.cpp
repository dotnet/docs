// This sample demonstrates how to call each member of the GenericPrincipal
// class.
//<Snippet1>
using namespace System;
using namespace System::Security::Principal;

ref class GenericPrincipalMembers
{
public:
   [STAThread]
   static void Main()
   {
      // Retrieve a GenericPrincipal that is based on the current user's
      // WindowsIdentity.
      GenericPrincipal^ genericPrincipal = GetGenericPrincipal();
      
      // Retrieve the generic identity of the GenericPrincipal object.
      //<Snippet3>
      GenericIdentity^ principalIdentity =
         dynamic_cast<GenericIdentity^>(genericPrincipal->Identity);
      //</Snippet3>

      // Display the identity name and authentication type.
      if ( principalIdentity->IsAuthenticated )
      {
         Console::WriteLine( principalIdentity->Name );
         Console::WriteLine( L"Type:{0}",
            principalIdentity->AuthenticationType );
      }
      
      // Verify that the generic principal has been assigned the
      // NetworkUser role.
      //<Snippet4>
      if ( genericPrincipal->IsInRole( L"NetworkUser" ) )
      {
         Console::WriteLine( L"User belongs to the NetworkUser role." );
      }
      //</Snippet4>
      Console::WriteLine( L"The sample completed successfully; "
      L"press Enter to continue." );
      Console::ReadLine();
   }

private:
   // Create a generic principal based on values from the current
   // WindowsIdentity.
   static GenericPrincipal^ GetGenericPrincipal()
   {
      // Use values from the current WindowsIdentity to construct
      // a set of GenericPrincipal roles.
      //<Snippet2>
      WindowsIdentity^ windowsIdentity = WindowsIdentity::GetCurrent();
      array<String^>^roles = gcnew array<String^>(10);
      if ( windowsIdentity->IsAuthenticated )
      {
         
         // Add custom NetworkUser role.
         roles[ 0 ] = L"NetworkUser";
      }

      if ( windowsIdentity->IsGuest )
      {
         
         // Add custom GuestUser role.
         roles[ 1 ] = L"GuestUser";
      }

      if ( windowsIdentity->IsSystem )
      {
         
         // Add custom SystemUser role.
         roles[ 2 ] = L"SystemUser";
      }
      
      // Construct a GenericIdentity object based on the current Windows
      // identity name and authentication type.
      String^ authenticationType = windowsIdentity->AuthenticationType;
      String^ userName = windowsIdentity->Name;
      GenericIdentity^ genericIdentity = gcnew GenericIdentity(
         userName,authenticationType );
      
      // Construct a GenericPrincipal object based on the generic identity
      // and custom roles for the user.
      GenericPrincipal^ genericPrincipal = gcnew GenericPrincipal(
         genericIdentity,roles );
      //</Snippet2>

      return genericPrincipal;
   }
};

int main()
{
   GenericPrincipalMembers::Main();
}


//</Snippet1>
