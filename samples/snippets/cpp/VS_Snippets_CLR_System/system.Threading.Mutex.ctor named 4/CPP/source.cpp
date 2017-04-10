//<Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Security::AccessControl;
using namespace System::Security::Permissions;

public ref class Example
{
public:
   [SecurityPermissionAttribute(SecurityAction::Demand,Flags=SecurityPermissionFlag::UnmanagedCode)]
   static void Main()
   {
      //<Snippet2>
      String^ mutexName = L"MutexExample4";

      Mutex^ m = nullptr;
      bool doesNotExist = false;
      bool unauthorized = false;
      
      // The value of this variable is set by the mutex
      // constructor. It is true if the named system mutex was
      // created, and false if the named mutex already existed.
      //
      bool mutexWasCreated = false;

      // Attempt to open the named mutex.
      try
      {
         // Open the mutex with (MutexRights.Synchronize |
         // MutexRights.Modify), to enter and release the
         // named mutex.
         //
         m = Mutex::OpenExisting( mutexName );
      }
      catch ( WaitHandleCannotBeOpenedException^ ) 
      {
         Console::WriteLine( L"Mutex does not exist." );
         doesNotExist = true;
      }
      catch ( UnauthorizedAccessException^ ex ) 
      {
         Console::WriteLine( L"Unauthorized access: {0}", ex->Message );
         unauthorized = true;
      }
      //</Snippet2>

      // There are three cases: (1) The mutex does not exist.
      // (2) The mutex exists, but the current user doesn't
      // have access. (3) The mutex exists and the user has
      // access.
      //
      if ( doesNotExist )
      {
         //<Snippet4>
         // The mutex does not exist, so create it.
         // Create an access control list (ACL) that denies the
         // current user the right to enter or release the
         // mutex, but allows the right to read and change
         // security information for the mutex.
         //
         String^ user = String::Concat( Environment::UserDomainName, L"\\",
            Environment::UserName );
         MutexSecurity^ mSec = gcnew MutexSecurity;

         MutexAccessRule^ rule = gcnew MutexAccessRule( user,
            static_cast<MutexRights>(
               MutexRights::Synchronize |
               MutexRights::Modify),
            AccessControlType::Deny );
         mSec->AddAccessRule( rule );

         rule = gcnew MutexAccessRule( user,
            static_cast<MutexRights>(
               MutexRights::ReadPermissions |
                MutexRights::ChangePermissions),
            AccessControlType::Allow );
         mSec->AddAccessRule( rule );
         
         // Create a Mutex object that represents the system
         // mutex named by the constant 'mutexName', with
         // initial ownership for this thread, and with the
         // specified security access. The Boolean value that
         // indicates creation of the underlying system object
         // is placed in mutexWasCreated.
         //
         m = gcnew Mutex( true,mutexName, mutexWasCreated,mSec );
         
         // If the named system mutex was created, it can be
         // used by the current instance of this program, even
         // though the current user is denied access. The current
         // program owns the mutex. Otherwise, exit the program.
         //
         if ( mutexWasCreated )
         {
            Console::WriteLine( L"Created the mutex." );
         }
         else
         {
            Console::WriteLine( L"Unable to create the mutex." );
            return;
         }
         //</Snippet4>
      }
      else if ( unauthorized )
      {
         //<Snippet3>
         // Open the mutex to read and change the access control
         // security. The access control security defined above
         // allows the current user to do this.
         //
         try
         {
            m = Mutex::OpenExisting( mutexName,
               static_cast<MutexRights>(
                  MutexRights::ReadPermissions |
                  MutexRights::ChangePermissions) );
            
            // Get the current ACL. This requires
            // MutexRights.ReadPermissions.
            MutexSecurity^ mSec = m->GetAccessControl();

            String^ user = String::Concat( Environment::UserDomainName,
               L"\\", Environment::UserName );
            
            // First, the rule that denied the current user
            // the right to enter and release the mutex must
            // be removed.
            MutexAccessRule^ rule = gcnew MutexAccessRule( user,
               static_cast<MutexRights>(
                  MutexRights::Synchronize |
                  MutexRights::Modify),
               AccessControlType::Deny );
            mSec->RemoveAccessRule( rule );
            
            // Now grant the user the correct rights.
            //
            rule = gcnew MutexAccessRule( user,
               static_cast<MutexRights>(
                  MutexRights::Synchronize |
                  MutexRights::Modify),
               AccessControlType::Allow );
            mSec->AddAccessRule( rule );
            
            // Update the ACL. This requires
            // MutexRights.ChangePermissions.
            m->SetAccessControl( mSec );

            Console::WriteLine( L"Updated mutex security." );
            
            // Open the mutex with (MutexRights.Synchronize
            // | MutexRights.Modify), the rights required to
            // enter and release the mutex.
            //
            m = Mutex::OpenExisting( mutexName );
            //</Snippet3>
         }
         catch ( UnauthorizedAccessException^ ex ) 
         {
            Console::WriteLine(
               L"Unable to change permissions: {0}", ex->Message );
            return;
         }
      }
      
      // If this program created the mutex, it already owns
      // the mutex.
      //
      if ( !mutexWasCreated )
      {
         // Enter the mutex, and hold it until the program
         // exits.
         //
         try
         {
            Console::WriteLine( L"Wait for the mutex." );
            m->WaitOne();
            Console::WriteLine( L"Entered the mutex." );
         }
         catch ( UnauthorizedAccessException^ ex ) 
         {
            Console::WriteLine( L"Unauthorized access: {0}",
               ex->Message );
         }
      }

      Console::WriteLine( L"Press the Enter key to exit." );
      Console::ReadLine();
      m->ReleaseMutex();
      m->Dispose();
   }
};

int main()
{
   Example::Main();
}
//</Snippet1>
