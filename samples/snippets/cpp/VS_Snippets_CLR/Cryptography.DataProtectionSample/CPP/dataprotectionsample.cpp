//<snippet1>
#using <System.Security.dll>

using namespace System;
using namespace System::Security::Cryptography;

public ref class DataProtectionSample
{
private:

   // Create byte array for additional entropy when using Protect method.
   static array<Byte>^s_aditionalEntropy = {9,8,7,6,5};

public:
   static void Main()
   {
      
      // Create a simple byte array containing data to be encrypted.
      array<Byte>^secret = {0,1,2,3,4,1,2,3,4};
      
      //Encrypt the data.
      array<Byte>^encryptedSecret = Protect( secret );
      Console::WriteLine( "The encrypted byte array is:" );
      PrintValues( encryptedSecret );
      
      // Decrypt the data and store in a byte array.
      array<Byte>^originalData = Unprotect( encryptedSecret );
      Console::WriteLine( "{0}The original data is:", Environment::NewLine );
      PrintValues( originalData );
   }

   static array<Byte>^ Protect( array<Byte>^data )
   {
      try
      {
         
         // Encrypt the data using DataProtectionScope.CurrentUser. The result can be decrypted
         //  only by the same current user.
         return ProtectedData::Protect( data, s_aditionalEntropy, DataProtectionScope::CurrentUser );
      }
      catch ( CryptographicException^ e ) 
      {
         Console::WriteLine( "Data was not encrypted. An error occurred." );
         Console::WriteLine( e );
         return nullptr;
      }
   }

   static array<Byte>^ Unprotect( array<Byte>^data )
   {
      try
      {
         
         //Decrypt the data using DataProtectionScope.CurrentUser.
         return ProtectedData::Unprotect( data, s_aditionalEntropy, DataProtectionScope::CurrentUser );
      }
      catch ( CryptographicException^ e ) 
      {
         Console::WriteLine( "Data was not decrypted. An error occurred." );
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
   DataProtectionSample::Main();
}
//</snippet1>
