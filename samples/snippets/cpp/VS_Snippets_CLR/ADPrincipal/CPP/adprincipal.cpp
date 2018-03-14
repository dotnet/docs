
// <SNIPPET1>
using namespace System;
using namespace System::Security::Principal;
using namespace System::Threading;
ref class ADPrincipal
{
public:
   static void PrintPrincipalInformation()
   {
      IPrincipal^ curPrincipal = Thread::CurrentPrincipal;
      if ( curPrincipal != nullptr )
      {
         Console::WriteLine( "Type: {0}", curPrincipal->GetType()->Name );
         Console::WriteLine( "Name: {0}", curPrincipal->Identity->Name );
         Console::WriteLine( "Authenticated: {0}", curPrincipal->Identity->IsAuthenticated );
         Console::WriteLine();
      }
   }

};

int main()
{
   
   // Create a new thread with a generic principal.
   Thread^ t = gcnew Thread( gcnew ThreadStart( ADPrincipal::PrintPrincipalInformation ) );
   t->Start();
   t->Join();
   
   // Set the principal policy to WindowsPrincipal.
   AppDomain^ currentDomain = AppDomain::CurrentDomain;
   currentDomain->SetPrincipalPolicy( PrincipalPolicy::WindowsPrincipal );
   
   // The new thread will have a Windows principal representing the
   // current user.
   t = gcnew Thread( gcnew ThreadStart( ADPrincipal::PrintPrincipalInformation ) );
   t->Start();
   t->Join();
   
   // Create a principal to use for new threads.
   IIdentity^ identity = gcnew GenericIdentity( "NewUser" );
   IPrincipal^ principal = gcnew GenericPrincipal( identity,nullptr );
   currentDomain->SetThreadPrincipal( principal );
   
   // Create a new thread with the principal created above.
   t = gcnew Thread( gcnew ThreadStart( ADPrincipal::PrintPrincipalInformation ) );
   t->Start();
   t->Join();
   
   // Wait for user input before terminating.
   Console::ReadLine();
}

// </SNIPPET1>
