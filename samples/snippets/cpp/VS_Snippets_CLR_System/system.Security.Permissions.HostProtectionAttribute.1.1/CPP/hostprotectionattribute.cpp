

//<Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::IO;
using namespace System::Threading;
using namespace System::Security;
using namespace System::Security::Policy;
using namespace System::Security::Principal;
using namespace System::Security::Permissions;
using namespace System::Diagnostics;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Security::Permissions;

//<Snippet5>
// The following class is an example of code that exposes external process management.
// Add the LicenseProviderAttribute to the control.

[LicenseProvider(LicFileLicenseProvider::typeid)]
public ref class MyControl: public System::Windows::Forms::Control
{
private:

   // Create a new, null license.
   License^ license;

public:
   [HostProtection(ExternalProcessMgmt=true)]
   MyControl()
   {
      license = nullptr;
      
      // Determine if a valid license can be granted.
      bool isValid = LicenseManager::IsValid( MyControl::typeid );
      Console::WriteLine( "The result of the IsValid method call is {0}", isValid );
   }

};
//</Snippet5>

// If this application is run on a server that implements host protection, the HostProtection attribute  
// is applied. If the application is run on a server that is not host-protected, the attribute 
// evaporates; it is not detected and therefore not applied. HostProtection can be configured with 
// members of the HostProtectionResource enumeration to customize the protection offered. 
// The primary intent of this sample is to show situations in which the HostProtection attribute
// might be meaningfully used.  The environment required to demonstrate a particular HostProtection is
// too complex to invoke within the scope of this sample.
public ref class HostProtectionExample
{
public:
   static int Success = 100;

private:

   //<Snippet2>
   // Use the enumeration flags to indicate that this method exposes shared state and 
   // self-affecting process management.
   // Either of the following attribute statements can be used to set the 
   // resource flags.
   // Exit the sample when an exception is thrown.

   [HostProtection(SharedState=true,SelfAffectingProcessMgmt=true)]
   [HostProtection(Resources=HostProtectionResource::SharedState|
   HostProtectionResource::SelfAffectingProcessMgmt)]
   static void Exit( String^ Message, int Code )
   {
      Console::WriteLine( "\nFAILED: {0} {1}", Message, Code );
      Environment::ExitCode = Code;
      Environment::Exit( Code );
   }
   //</Snippet2>

   //<Snippet3>
   // Use the enumeration flags to indicate that this method exposes shared state, 
   // self-affecting process management, and self-affecting threading.
   // This method allows the user to quit the sample.

   [HostProtection(SharedState=true,SelfAffectingProcessMgmt=true,
   SelfAffectingThreading=true,UI=true)]
   static void ExecuteBreak()
   {
      Console::WriteLine( "Executing Debugger.Break." );
      Debugger::Break();
      Debugger::Log( 1, "info", "test message" );
   }
   //</Snippet3>

   //<Snippet4>
   // Use the enumeration flags to indicate that this method exposes shared state, 
   // self-affecting threading and the security infrastructure.
   // ApplyIdentity sets the current identity.

   [HostProtection(SharedState=true,SelfAffectingThreading=true,
   SecurityInfrastructure=true)]
   static int ApplyIdentity()
   {
      array<String^>^roles = {"User"};
      try
      {
         AppDomain^ mAD = AppDomain::CurrentDomain;
         GenericPrincipal^ mGenPr = gcnew GenericPrincipal( WindowsIdentity::GetCurrent(),roles );
         mAD->SetPrincipalPolicy( PrincipalPolicy::WindowsPrincipal );
         mAD->SetThreadPrincipal( mGenPr );
         return Success;
      }
      catch ( Exception^ e ) 
      {
         Exit( e->ToString(), 5 );
      }

      return 0;
   }
   //</Snippet4>

public:

   // The following method is started on a separate thread.
   [PermissionSet(SecurityAction::Demand, Name="FullTrust")]
   static void WatchFileEvents()
   {
      try
      {
         Console::WriteLine( "In the child thread." );
         FileSystemWatcher^ watcher = gcnew FileSystemWatcher;
         watcher->Path = "C:\\Temp";
         
         // Watch for changes in LastAccess and LastWrite times, and 
         // name changes to files or directories. 
         watcher->NotifyFilter = static_cast<NotifyFilters>(NotifyFilters::LastAccess | NotifyFilters::LastWrite | NotifyFilters::FileName | NotifyFilters::DirectoryName);
         
         // Watch only text files.
         watcher->Filter = "*.txt";
         
         // Add event handlers.
         watcher->Changed += gcnew FileSystemEventHandler( OnChanged );
         watcher->Created += gcnew FileSystemEventHandler( OnChanged );
         watcher->Deleted += gcnew FileSystemEventHandler( OnChanged );
         
         // Begin watching.
         watcher->EnableRaisingEvents = true;
         
         // Wait for the user to quit the program.
         Console::WriteLine( "Event handlers have been enabled." );
         while ( Console::Read() != 'q' )
                  ;
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e->Message );
      }

   }


private:

   //<Snippet6>
   // Use the enumeration flags to indicate that this method exposes synchronization 
   //  and external threading.

   [HostProtection(Synchronization=true,ExternalThreading=true)]
   static void StartThread()
   {
      Thread^ t = gcnew Thread( gcnew ThreadStart( WatchFileEvents ) );
      
      // Start the new thread.  On a uniprocessor, the thread is not given 
      // any processor time until the main thread yields the processor.  
      t->Start();
      
      // Give the new thread a chance to execute.
      Thread::Sleep( 1000 );
   }
   //</Snippet6>

public:

   // Call methods that show the use of the HostProtectionResource enumeration.
   [HostProtection(Resources=HostProtectionResource::All)]
   static int Main()
   {
      try
      {
         
         // Show use of the HostProtectionResource.SharedState,
         //   HostProtectionResource.SelfAffectingThreading, and
         //   HostProtectionResource.Security enumeration values.
         ApplyIdentity();
         Directory::CreateDirectory( "C:\\Temp" );
         
         // Show use of the HostProtectionResource.Synchronization and
         //   HostProtectionResource.ExternalThreading enumeration values.
         StartThread();
         Console::WriteLine( "In the main thread." );
         Console::WriteLine( "Deleting and creating 'MyTestFile.txt'." );
         if ( File::Exists( "C:\\Temp\\MyTestFile.txt" ) )
         {
            File::Delete( "C:\\Temp\\MyTestFile.txt" );
         }
         StreamWriter^ sr = File::CreateText( "C:\\Temp\\MyTestFile.txt" );
         sr->WriteLine( "This is my file." );
         sr->Close();
         Thread::Sleep( 1000 );
         
         // Show use of the HostProtectionResource.SharedState,
         //   HostProtectionResource.SelfProcessMgmt,
         //   HostProtectionResource.SelfAffectingThreading, and
         //   HostProtectionResource.UI enumeration values.
         ExecuteBreak();
         
         // Show the use of the HostProtectionResource.ExternalProcessManagement enumeration value.
         MyControl^ myControl = gcnew MyControl;
         Console::WriteLine( "Enter 'q' to quit the sample." );
         return 100;
      }
      catch ( Exception^ e ) 
      {
         Exit( e->ToString(), 0 );
         return 0;
      }
   }

   // Define the event handlers.
   private:
   static void OnChanged( Object^ /*source*/, FileSystemEventArgs^ e )
   {
      
      // Specify whether a file is changed, created, or deleted.
      Console::WriteLine( "In the OnChanged event handler." );
      Console::WriteLine( "File: {0} {1}", e->FullPath, e->ChangeType );
   }

};

int main()
{
   return HostProtectionExample::Main();
}
//</Snippet1>
