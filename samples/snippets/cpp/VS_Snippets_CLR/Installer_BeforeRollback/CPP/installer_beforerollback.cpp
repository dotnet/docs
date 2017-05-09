

// System::Configuration::Install::Installer.BeforeRollback
/* The following program demonstrates the 'BeforeRollback' event of the
'Installer' class. It overrides the Install method, explicitly throws
arguement exception so that 'Rollback' method is called. When the
'RollBack' is about to complete, 'BeforeRollback' event occurs and
a message is displayed when the event occurs.
*/
// <Snippet1>
#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Configuration::Install;

// Set 'RunInstaller' attribute to true.

[RunInstaller(true)]
ref class MyInstallerClass: public Installer
{
public:
   MyInstallerClass()
   {
      
      // Attach the 'BeforeRollback' event.
      this->BeforeRollback += gcnew InstallEventHandler( this, &MyInstallerClass::MyInstaller_BeforeRollBack );
      
      // Attach the 'AfterRollback' event.
      this->AfterRollback += gcnew InstallEventHandler( this, &MyInstallerClass::MyInstaller_AfterRollback );
   }


private:

   // Event handler for 'BeforeRollback' event.
   void MyInstaller_BeforeRollBack( Object^ sender, InstallEventArgs^ e )
   {
      Console::WriteLine( "" );
      Console::WriteLine( "BeforeRollback Event occured." );
      Console::WriteLine( "" );
   }


   // Event handler for 'AfterRollback' event.
   void MyInstaller_AfterRollback( Object^ sender, InstallEventArgs^ e )
   {
      Console::WriteLine( "" );
      Console::WriteLine( "AfterRollback Event occured." );
      Console::WriteLine( "" );
   }


public:

   // Override the 'Install' method.
   virtual void Install( IDictionary^ savedState ) override
   {
      Installer::Install( savedState );
      
      // Explicitly throw an exception so that roll back is called.
      throw gcnew ArgumentException( "Arg Exception" );
   }


   // Override the 'Commit' method.
   virtual void Commit( IDictionary^ savedState ) override
   {
      Installer::Commit( savedState );
   }


   // Override the 'Rollback' method.
   virtual void Rollback( IDictionary^ savedState ) override
   {
      Installer::Rollback( savedState );
   }

};

int main()
{
   Console::WriteLine( "Usage : installutil.exe Installer_BeforeRollback.exe " );
}

// </Snippet1>
