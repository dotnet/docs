using namespace System;
using namespace System::Security::Policy;

int main()
{
   // <Snippet1>
   // Set up the AppDomainSetup
   AppDomainSetup^ setup = gcnew AppDomainSetup;
   setup->ApplicationBase = "(some directory)";
   setup->ConfigurationFile = "(some file)";
   
   // Set up the Evidence
   Evidence^ baseEvidence = AppDomain::CurrentDomain->Evidence;
   Evidence^ evidence = gcnew Evidence( baseEvidence );
   evidence->AddAssembly( "(some assembly)" );
   evidence->AddHost( "(some host)" );
   
   // Create the AppDomain
   AppDomain^ newDomain = AppDomain::CreateDomain( "newDomain", evidence, setup );
   // </Snippet1>
}
