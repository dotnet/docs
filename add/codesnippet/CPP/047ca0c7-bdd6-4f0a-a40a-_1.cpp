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
   // Simple events to handle before and after commit handlers.
   event InstallEventHandler^ BeforeCommit;
   event InstallEventHandler^ AfterCommit;

   MyInstaller()
   {
      // Add handlers to the events.
      BeforeCommit += gcnew InstallEventHandler( this, &MyInstaller::BeforeCommitHandler );
      AfterCommit += gcnew InstallEventHandler( this, &MyInstaller::AfterCommitHandler );
   }

   virtual void Install( IDictionary^ savedState ) override
   {
      Installer::Install( savedState );
      Console::WriteLine( "Install ...\n" );
   }

   virtual void Commit( IDictionary^ savedState ) override
   {
      Console::WriteLine( "Before Committing ...\n" );
      // Call the 'OnBeforeCommit' protected method.
      OnBeforeCommit( savedState );
      Installer::Commit( savedState );
      Console::WriteLine( "Committing ...\n" );
      // Call the 'OnAfterCommit' protected method.
      OnAfterCommit( savedState );
      Console::WriteLine( "After Committing ...\n" );
   }

   virtual void Rollback( IDictionary^ savedState ) override
   {
      Installer::Rollback( savedState );
      Console::WriteLine( "RollBack ...\n" );
   }

   virtual void Uninstall( IDictionary^ savedState ) override
   {
      Installer::Uninstall( savedState );
      Console::WriteLine( "UnInstall ...\n" );
   }

   // Protected method that invoke the handlers associated with the 'BeforeCommit' event.
protected:
   virtual void OnBeforeCommit( IDictionary^ savedState )
   {
      BeforeCommit( this, gcnew InstallEventArgs( savedState ) );
   }

   // Protected method that invoke the handlers associated with the 'AfterCommit' event.
protected:
   virtual void OnAfterCommit( IDictionary^ savedState )
   {
      AfterCommit( this, gcnew InstallEventArgs );
   }

   // A simple event handler to exemplify the example.
   void BeforeCommitHandler( Object^ sender, InstallEventArgs^ e )
   {
      Console::WriteLine( "BeforeCommitHandler event handler has been called\n" );
      Console::WriteLine( "The count of saved state objects are : {0}\n",
         e->SavedState->Count );
   }

   // A simple event handler to exemplify the example.
private:
   void AfterCommitHandler( Object^ sender, InstallEventArgs^ e )
   {
      Console::WriteLine( "AfterCommitHandler event handler has been called\n" );
   }
};