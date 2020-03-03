
//  <SNIPPET1>
using namespace System;
using namespace System::Reflection;
using namespace System::Security::Policy;

//for Evidence Object
int main()
{
   AppDomain^ currentDomain = AppDomain::CurrentDomain;
   
   //Provide the current application domain evidence for the assembly.
   Evidence^ asEvidence = currentDomain->Evidence;
   
   //Load the assembly from the application directory using a simple name.
   //Create an assembly called CustomLibrary to run this sample.
   currentDomain->Load( "CustomLibrary", asEvidence );
   
   //Make an array for the list of assemblies.
   array<Assembly^>^assems = currentDomain->GetAssemblies();
   
   //List the assemblies in the current application domain.
   Console::WriteLine( "List of assemblies loaded in current appdomain:" );
   System::Collections::IEnumerator^ myEnum = assems->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Assembly^ assem = safe_cast<Assembly^>(myEnum->Current);
      Console::WriteLine( assem );
   }
}

//  </SNIPPET1>
