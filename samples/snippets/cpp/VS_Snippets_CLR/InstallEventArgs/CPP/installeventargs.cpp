// System::Configuration::Install::InstallEventArgs
// System::Configuration::Install::InstallEventArgs.InstallEventArgs()
// System::Configuration::Install::InstallEventArgs.InstallEventArgs(IDictionary*)
// System::Configuration::Install::InstallEventArgs.SavedState

/*
   The following example demonstrates the 'InstallEventArgs()' and
   'InstallEventArgs(IDictionary*)' constructors and the 'SavedState'
   property of the 'InstallEventArgs' property. There are two new
   events called 'BeforeCommit' and 'AfterCommit'. The handlers of
   these events are invoked from the protected:
   methods named 'OnBeforeCommit'
   and 'OnAfterCommit' respectively. These events are raised when the
   'Commit' method is called.

   Note :
   a) The two events named 'BeforeCommit' and 'AfterCommit' are added
   only for example purposes, since there are already
   events named 'Committing' and 'Committed' which perform the same
   function. This example can be made a basis for a new stage being
   added to the already existing four stages namely 'Install', 'Commit',
   'Rollback' and 'Uninstall'.

   b) Run the example with the help of InstallUtil.exe
   InstallUtil InstallEventArgs.exe
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

// <Snippet3>
   // Protected method that invoke the handlers associated with the 'BeforeCommit' event.
protected:
   virtual void OnBeforeCommit( IDictionary^ savedState )
   {
      BeforeCommit( this, gcnew InstallEventArgs( savedState ) );
   }
// </Snippet3>

// <Snippet2>
   // Protected method that invoke the handlers associated with the 'AfterCommit' event.
protected:
   virtual void OnAfterCommit( IDictionary^ savedState )
   {
      AfterCommit( this, gcnew InstallEventArgs );
   }
// </Snippet2>

// <Snippet4>
   // A simple event handler to exemplify the example.
   void BeforeCommitHandler( Object^ sender, InstallEventArgs^ e )
   {
      Console::WriteLine( "BeforeCommitHandler event handler has been called\n" );
      Console::WriteLine( "The count of saved state objects are : {0}\n",
         e->SavedState->Count );
   }
// </Snippet4>

   // A simple event handler to exemplify the example.
private:
   void AfterCommitHandler( Object^ sender, InstallEventArgs^ e )
   {
      Console::WriteLine( "AfterCommitHandler event handler has been called\n" );
   }
};
// </Snippet1>

// An Assembly that has its own installer.
void main()
{
   Console::WriteLine( "This assembly is just an example for the Installer\n" );
}
