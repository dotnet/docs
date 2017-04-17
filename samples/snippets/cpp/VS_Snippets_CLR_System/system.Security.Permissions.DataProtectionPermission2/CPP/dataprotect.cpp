
//<Snippet1>
#using <System.Security.dll>

using namespace System;
using namespace System::Security::Permissions;
using namespace System::Security::Cryptography;
using namespace System::Security;
using namespace System::IO;

[assembly:DataProtectionPermissionAttribute(
SecurityAction::RequestMinimum,
Flags=DataProtectionPermissionFlags::ProtectData)];
public ref class DataProtect
{
private:

   // Create a byte array for additional entropy when using the
   // Protect and Unprotect methods.
   static array<Byte>^ s_aditionalEntropy = {9,8,7,6,5};
   static array<Byte>^ encryptedSecret;
   static array<Byte>^ originalData;

public:
   static void Main()
   {
      
      //<Snippet2>
      Console::WriteLine( "Creating a permission with the Flags property ="
      " ProtectData." );
      DataProtectionPermission ^ sp = gcnew DataProtectionPermission( DataProtectionPermissionFlags::ProtectData );
      
	  ProtectData();
      //</Snippet2>
	  sp->PermitOnly();
      // The following code results in an exception due to an attempt
      // to unprotect data.
      UnprotectData();
      
      // Remove the restrictive permission.
	  CodeAccessPermission::RevertPermitOnly();

	  // The untprotect call will now succeed.
      UnprotectData();

      // Demonstrate the behavior of the class members.
      ShowMembers();
      Console::WriteLine( "Press the Enter key to exit." );
      Console::ReadKey();
      return;
   }


private:


   // The following method is intended to demonstrate only the behavior of
   // DataProtectionPermission class members,and not their practical usage.
   // Most properties and methods in this class are used for the resolution
   // and enforcement of security policy by the security infrastructure code.
   static void ShowMembers()
   {
      Console::WriteLine( "Creating four DataProtectionPermissions" );
      Console::WriteLine( "Creating the first permission with the Flags "
      "property = ProtectData." );
      DataProtectionPermission ^ sp1 = gcnew DataProtectionPermission( DataProtectionPermissionFlags::ProtectData );
      Console::WriteLine( "Creating the second permission with the Flags "
      "property = AllFlags." );
      DataProtectionPermission ^ sp2 = gcnew DataProtectionPermission( DataProtectionPermissionFlags::AllFlags );
      Console::WriteLine( "Creating the third permission with a permission "
      "state = Unrestricted." );
      
      //<Snippet9>
      DataProtectionPermission ^ sp3 = gcnew DataProtectionPermission( PermissionState::Unrestricted );
      
      //</Snippet9>
      Console::WriteLine( "Creating the fourth permission with a permission"
      " state = None." );
      DataProtectionPermission ^ sp4 = gcnew DataProtectionPermission( PermissionState::None );
      
      //<Snippet3>
      bool rc = sp2->IsSubsetOf( sp3 );
      Console::WriteLine( "Is the permission with all flags set (AllFlags) "
      "a subset of \n \tthe permission with an Unrestricted "
      "permission state? {0}", (rc ? (String^)"Yes" : "No") );
      rc = sp1->IsSubsetOf( sp2 );
      Console::WriteLine( "Is the permission with ProtectData access a "
      "subset of the permission with \n"
      "\tAllFlags set? {0}", (rc ? (String^)"Yes" : "No") );
      
      //</Snippet3>
      //<Snippet4>
      rc = sp3->IsUnrestricted();
      Console::WriteLine( "Is the third permission unrestricted? {0}", (rc ? (String^)"Yes" : "No") );
      
      //</Snippet4>
      //<Snippet5>
      Console::WriteLine( "Copying the second permission to the fourth "
      "permission." );
      sp4 = dynamic_cast<DataProtectionPermission^>(sp2->Copy());
      rc = sp4->Equals( sp2 );
      Console::WriteLine( "Is the fourth permission equal to the second "
      "permission? {0}", (rc ? (String^)"Yes" : "No") );
      
      //</Snippet5>
      //<Snippet10>
      Console::WriteLine( "Creating the intersection of the second and "
      "first permissions." );
      sp4 = dynamic_cast<DataProtectionPermission^>(sp2->Intersect( sp1 ));
      Console::WriteLine( "The value of the Flags property is: {0}", sp4->Flags );
      
      //</Snippet10>
      //<Snippet6>
      Console::WriteLine( "Creating the union of the second and first "
      "permissions." );
      sp4 = dynamic_cast<DataProtectionPermission^>(sp2->Union( sp1 ));
      Console::WriteLine( "Result of the union of the second permission "
      "with the first: {0}", sp4->Flags );
      
      //</Snippet6>
      //<Snippet7>
      Console::WriteLine( "Using an XML round trip to reset the fourth "
      "permission." );
      sp4->FromXml( sp2->ToXml() );
      rc = sp4->Equals( sp2 );
      Console::WriteLine( "Does the XML round trip result equal the "
      "original permission? {0}", (rc ? (String^)"Yes" : "No") );
      
      //</Snippet7>
   }


public:

   // Create a simple byte array containing data to be encrypted.
   static void ProtectData()
   {
      array<Byte>^secret = {0,1,2,3,4,1,2,3,4};
      
      //Encrypt the data.
      encryptedSecret = Protect( secret );
      Console::WriteLine( "The encrypted byte array is:" );
      if ( encryptedSecret != nullptr )
            PrintValues( encryptedSecret );
   }


   // Decrypt the data and store in a byte array.
   static void UnprotectData()
   {
      originalData = Unprotect( encryptedSecret );
      if ( originalData != nullptr )
      {
         Console::WriteLine( "\r\nThe original data is:" );
         PrintValues( originalData );
      }
   }


   // Encrypt data in the specified byte array.
   static array<Byte>^ Protect( array<Byte>^data )
   {
      try
      {
         
         // Encrypt the data using DataProtectionScope.CurrentUser.
         // The result can be decrypted only by the user who encrypted
         // the data.
         return ProtectedData::Protect( data, s_aditionalEntropy, DataProtectionScope::CurrentUser );
      }
      catch ( CryptographicException^ e ) 
      {
         Console::WriteLine( "Data was not encrypted. "
         "An error has occurred." );
         Console::WriteLine( e );
         return nullptr;
      }
      catch ( SecurityException^ e ) 
      {
         Console::WriteLine( "Insufficient permissions. "
         "An error has occurred." );
         Console::WriteLine( e );
         return nullptr;
      }

   }


   // Decrypt data in the specified byte array.
   static array<Byte>^ Unprotect( array<Byte>^data )
   {
      try
      {
         
         //Decrypt the data using DataProtectionScope.CurrentUser.
         return ProtectedData::Unprotect( data, s_aditionalEntropy, DataProtectionScope::CurrentUser );
      }
      catch ( CryptographicException^ e ) 
      {
         Console::WriteLine( "Data was not decrypted. "
         "An error has occurred." );
         Console::WriteLine( e );
         return nullptr;
      }
      catch ( SecurityException^ e ) 
      {
         Console::WriteLine( "Insufficient permissions. "
         "An error has occurred." );
         Console::WriteLine( e );
         return nullptr;
      }

   }

   static void PrintValues( array<Byte>^myArr )
   {
      System::Collections::IEnumerator^ myEnum = myArr->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Byte i = safe_cast<Byte>(myEnum->Current);
         Console::Write( "\t{0}", i );
      }

      Console::WriteLine();
   }

};

int main()
{
   DataProtect::Main();
}

//</Snippet1>
