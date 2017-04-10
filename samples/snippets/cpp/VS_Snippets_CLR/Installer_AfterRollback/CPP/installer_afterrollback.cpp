

// System::Configuration::Install::Installer.AfterRollback
/* The following program demonstrates the 'AfterRollback' event of the
'Installer' class. It overrides the Install method, explicitly throws
arguement exception so that 'Rollback' method is called. When the
'RollBack' is complete, 'AfterRollback' event occurs and a message is
displayed when the event occurs.
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
private:

   // Event handler for 'AfterRollback' event.
   void MyInstaller_AfterRollBack( Object^ sender, InstallEventArgs^ e )
   {
      Console::WriteLine( "AfterRollBack Event occured." );
   }


public:
   MyInstallerClass()
   {
      
      // Attach the 'AfterRollback' event.
      this->AfterRollback += gcnew InstallEventHandler( this, &MyInstallerClass::MyInstaller_AfterRollBack );
   }


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
   Console::WriteLine( "Usage : installutil.exe Installer_AfterRollback.exe " );
}

// </Snippet1>
