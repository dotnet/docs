
//  <SNIPPET1>
using namespace System;
using namespace System::IO;
using namespace System::Reflection;
using namespace System::Security::Policy;    // For Evidence object.

int main()
{
   
   // Create application domain setup information
   AppDomainSetup^ domaininfo = gcnew AppDomainSetup;
   domaininfo->ConfigurationFile = String::Format("{0}{1}ADSetup.exe.config", 
                                                  Environment::CurrentDirectory,
                                                  Path::DirectorySeparatorChar);
   domaininfo->ApplicationBase = String::Format("{0}", System::Environment::CurrentDirectory);
   
   //Create evidence for the new appdomain from evidence of the current application domain
   Evidence^ adevidence = AppDomain::CurrentDomain->Evidence;
   
   // Create appdomain
   AppDomain^ domain = AppDomain::CreateDomain("Domain2", adevidence, domaininfo);
   
   // Display application domain information
   Console::WriteLine("Host domain: {0}", AppDomain::CurrentDomain->FriendlyName);
   Console::WriteLine("Child domain: {0}", domain->FriendlyName);
   Console::WriteLine();
   Console::WriteLine("Configuration file: {0}", domain->SetupInformation->ConfigurationFile);
   Console::WriteLine( "Application Base Directory: {0}", domain->BaseDirectory);
   
   AppDomain::Unload(domain);
}
// The example displays output like the following:
//    Host domain: adsetup.exe
//    Child domain: Domain2
//    
//    Configuration file: C:\Test\ADSetup.exe.config
//    Application Base Directory: C:\Test
//  </SNIPPET1>
