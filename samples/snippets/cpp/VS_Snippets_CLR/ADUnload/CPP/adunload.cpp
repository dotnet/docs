
//  <SNIPPET1>
using namespace System;
using namespace System::Reflection;
using namespace System::Security::Policy;

//for evidence Object*
int main()
{
   
   //Create evidence for the new appdomain.
   Evidence^ adevidence = AppDomain::CurrentDomain->Evidence;
   
   // Create the new application domain.
   AppDomain^ domain = AppDomain::CreateDomain( "MyDomain", adevidence );
   Console::WriteLine( "Host domain: {0}", AppDomain::CurrentDomain->FriendlyName );
   Console::WriteLine( "child domain: {0}", domain->FriendlyName );
   
   // Unload the application domain.
   AppDomain::Unload( domain );
   try
   {
      Console::WriteLine();
      
      // Note that the following statement creates an exception because the domain no longer exists.
      Console::WriteLine( "child domain: {0}", domain->FriendlyName );
   }
   catch ( AppDomainUnloadedException^ /*e*/ ) 
   {
      Console::WriteLine( "The appdomain MyDomain does not exist." );
   }

}

//  </SNIPPET1>
