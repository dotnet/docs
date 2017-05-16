
//  <SNIPPET1>
using namespace System;
using namespace System::Reflection;
using namespace System::Security::Policy;

ref class Worker : MarshalByRefObject
{
public:
   void TestLoad()
   {
      // You must supply a valid fully qualified assembly name here.
      Assembly::Load("Text assembly name, Culture, PublicKeyToken, Version");
      for each (Assembly^ assem in AppDomain::CurrentDomain->GetAssemblies())
         Console::WriteLine(assem->FullName);
   }
};

//for evidence Object*
// The following attribute indicates to loader that multiple application
// domains are used in this application.

[LoaderOptimizationAttribute(LoaderOptimization::MultiDomainHost)]
int main()
{
   
   // Create application domain setup information for new application domain.
   AppDomainSetup^ domaininfo = gcnew AppDomainSetup;
   domaininfo->ApplicationBase = System::Environment::CurrentDirectory;
   domaininfo->ApplicationName = "MyMultiDomain Application";
   
   //Create evidence for the new appdomain from evidence of current application domain.
   Evidence^ adevidence = AppDomain::CurrentDomain->Evidence;
   
   // Create appdomain.
   AppDomain^ newDomain = AppDomain::CreateDomain( "MyMultiDomain", adevidence, domaininfo );
   
   // Load an assembly into the new application domain.
   Worker^ w = (Worker^) newDomain->CreateInstanceAndUnwrap(
      Worker::typeid->Assembly->GetName()->Name,
      "Worker"
   );
   w->TestLoad();

   //Unload the application domain, which also unloads the assembly.
   AppDomain::Unload(newDomain);
}

//  </SNIPPET1>
