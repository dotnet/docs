#using <System.dll>
#using <System.Configuration.Install.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Configuration::Install;

[RunInstaller(true)]
ref class MyUninstallActionClass: public Installer
{
private:
   EventLogInstaller^ myInstaller;

public:
   MyUninstallActionClass()
   {
      myInstaller = gcnew EventLogInstaller;
   }


   // Override the 'Install' method.
   virtual void Install( IDictionary^ savedState ) override
   {
      Console::Write( "Enter a new log to create (eg: MyLog): " );
      myInstaller->Log = Console::ReadLine();
      Console::Write( "Enter a source for log (eg: MySource): " );
      myInstaller->Source = Console::ReadLine();
      Installers->Add( myInstaller );
      Installer::Install( savedState );
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


   virtual void Uninstall( IDictionary^ savedState ) override
   {
      Console::Write( "Enter a source from log to uninstall(eg: MySource): " );
      myInstaller->Source = Console::ReadLine();
      Console::Write( "Do you want to uninstall, press 'y' for 'YES' and 'n' for 'NO':" );
      String^ myUninstall = Console::ReadLine();
      if ( myUninstall->Equals( "n" ) )
      {
         
         // No action to be taken on the resource in the event log.
         myInstaller->UninstallAction = UninstallAction::NoAction;
      }
      else
      {
         
         // Remove the resource from the event log.
         myInstaller->UninstallAction = UninstallAction::Remove;
      }

      Installers->Add( myInstaller );
      Installer::Uninstall( savedState );
   }

};

int main()
{
   Console::WriteLine( "Syntax for install: installutil.exe UninstallAction_NoAction_Remove_3.exe " );
   Console::WriteLine( "Syntax for uninstall: installutil.exe /u UninstallAction_NoAction_Remove_3.exe " );
}
