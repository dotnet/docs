

// System::Configuration::Install::InstallException
// System::Configuration::Install::InstallException.InstallException()
// System::Configuration::Install::InstallException.InstallException(String, Exception)
// System::Configuration::Install::InstallException.InstallException(String)
/*
The following example demonstrates the 'InstallException()', 'InstallException(String)'
and 'InstallException(String, Exception)' constructors for 'InstallException' class.
This example shows an assembly having its own installer named 'MyInstaller'
which has an attribute 'RunInstallerAttribute', indicating that this installer
will be invoked by InstallUtil.exe. InstallUtil.exe calls the 'Install', 'Commit',
'Rollback' and 'Uninstall' methods. The code in 'Commit' method presumes that
a file named 'FileDoesNotExist.txt' exists before the installation of the
assembly can be committed. If the file 'FileDoesNotExist.txt' does not exist
'Commit' raises a 'InstallException'. Same is the case with 'Uninstall',
uninstalltion will only progress if the file named 'FileDoesNotExist.txt'
exists else it raises an 'InstallException'. In 'Rollback' some piece of
code is executed which may raise an exception. If the exception is raised then
it is caught and an 'InstallException' is raised with that exception being passed
to it.

Note : Run this example with the help of 'InstallUtil.exe'
InstallUtil InstallException.exe
InstallUtil /u InstallException.exe
*/
// <Snippet1>
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


   // <Snippet2>
   virtual void Commit( IDictionary^ savedState ) override
   {
      Installer::Commit( savedState );
      Console::WriteLine( "Commit ..." );
      
      // Throw an error if a particular file doesn't exist.
      if (  !File::Exists( "FileDoesNotExist.txt" ) )
            throw gcnew InstallException;

      
      // Perform the final installation if the file exists.
   }


   // </Snippet2>
   // <Snippet3>
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


   // </Snippet3>
   // <Snippet4>
   virtual void Uninstall( IDictionary^ savedState ) override
   {
      Installer::Uninstall( savedState );
      Console::WriteLine( "UnInstall ..." );
      
      // Throw an error if a particular file doesn't exist.
      if (  !File::Exists( "FileDoesNotExist.txt" ) )
            throw gcnew InstallException( "The file 'FileDoesNotExist'  does not exist" );

      
      // Perform the uninstall activites if the file exists.
   }

   // </Snippet4>
};

int main()
{
   Console::WriteLine( "This assembly is just an example for the Installer" );
}

// </Snippet1>
