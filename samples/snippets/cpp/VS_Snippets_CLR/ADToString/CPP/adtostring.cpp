
//  <SNIPPET1>
using namespace System;
using namespace System::Reflection;
using namespace System::Security::Policy;

//for evidence Object*
int main()
{
   
   // Create application domain setup information
   AppDomainSetup^ domaininfo = gcnew AppDomainSetup;
   
   //Create evidence for the new appdomain from evidence of the current application domain
   Evidence^ adevidence = AppDomain::CurrentDomain->Evidence;
   
   // Create appdomain
   AppDomain^ domain = AppDomain::CreateDomain( "MyDomain", adevidence, domaininfo );
   
   // Write out application domain information
   Console::WriteLine( "Host domain: {0}", AppDomain::CurrentDomain->FriendlyName );
   Console::WriteLine( "child domain: {0}", domain->FriendlyName );
   Console::WriteLine( "child domain name using ToString: {0}", domain );
   Console::WriteLine();
   AppDomain::Unload( domain );
}

//  </SNIPPET1>
