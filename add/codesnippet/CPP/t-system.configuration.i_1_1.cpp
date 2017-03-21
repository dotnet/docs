#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Configuration::Install;
using namespace System::IO;

[RunInstaller(true)]
ref class MyInstaller: public Installer
{
public:
   virtual void Install( IDictionary^ savedState ) override
   {
      Installer::Install( savedState );
      Console::WriteLine( "Install ..." );
      
      // Commit is called when install goes through successfully.
      // Rollback is called if there is any error during Install.
      // Uncommenting the code below will lead to 'RollBack' being called,
      // currently 'Commit' shall be called.
      // throw new IOException();
   }


   virtual void Commit( IDictionary^ savedState ) override
   {
      Installer::Commit( savedState );
      Console::WriteLine( "Commit ..." );
      
      // Throw an error if a particular file doesn't exist.
      if (  !File::Exists( "FileDoesNotExist.txt" ) )
            throw gcnew InstallException;

      
      // Perform the final installation if the file exists.
   }


   virtual void Rollback( IDictionary^ savedState ) override
   {
      Installer::Rollback( savedState );
      Console::WriteLine( "RollBack ..." );
      try
      {
         
         // Performing some activity during rollback that raises an 'IOException*'.
         throw gcnew IOException;
      }
      catch ( Exception^ e ) 
      {
         throw gcnew InstallException( "IOException* raised",e );
      }

      
      // Perform the remaining rollback activites if no exception raised.
   }


   virtual void Uninstall( IDictionary^ savedState ) override
   {
      Installer::Uninstall( savedState );
      Console::WriteLine( "UnInstall ..." );
      
      // Throw an error if a particular file doesn't exist.
      if (  !File::Exists( "FileDoesNotExist.txt" ) )
            throw gcnew InstallException( "The file 'FileDoesNotExist'  does not exist" );

      
      // Perform the uninstall activites if the file exists.
   }

};

int main()
{
   Console::WriteLine( "This assembly is just an example for the Installer" );
}
