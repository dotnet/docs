
// System::Reflection::Emit::ModuleBuilder.DefineResource(String, String)
/*
The following example demonstrates the 'DefineResource(String, String)' method
of 'ModuleBuilder' class.
A dynamic assembly with a module in it is created in 'CodeGenerator' class.
Then a managed resource is defined in the module using the 'DefineResource'
method.
*/
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Resources;
public ref class CodeGenerator
{
public:
   CodeGenerator()
   {
      
      // Get the current application domain for the current thread.
      AppDomain^ currentDomain = AppDomain::CurrentDomain;
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "TempAssembly";
      
      // Define 'TempAssembly' assembly in the current application domain.
      AssemblyBuilder^ myAssemblyBuilder = currentDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::RunAndSave );
      
      // Define 'TempModule' module in 'TempAssembly' assembly.
      ModuleBuilder^ myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "TempModule", "TempModule.netmodule", true );
      
      // Define the managed embedded resource, 'MyResource' in 'TempModule'.
      IResourceWriter^ myResourceWriter = myModuleBuilder->DefineResource( "MyResource.resource", "Description" );
      
      // Add resources to the resource writer.
      myResourceWriter->AddResource( "String 1", "First String" );
      myResourceWriter->AddResource( "String 2", "Second String" );
      myResourceWriter->AddResource( "String 3", "Third String" );
      myAssemblyBuilder->Save( "MyAssembly.dll" );
   }

};

int main()
{
   CodeGenerator^ myGenerator = gcnew CodeGenerator;
   Console::WriteLine( "A resource named 'MyResource.resource' has been created and can be viewed in the 'MyAssembly.dll'" );
}

// </Snippet1>
