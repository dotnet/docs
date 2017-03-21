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
      
      // Define the managed embedded resource, 'MyResource' in 'TempModule'
      // with the specified attribute.
      IResourceWriter^ writer = myModuleBuilder->DefineResource( "MyResource.resource", "Description", ResourceAttributes::Public );
      
      // Add resources to the resource writer.
      writer->AddResource( "String 1", "First String" );
      writer->AddResource( "String 2", "Second String" );
      writer->AddResource( "String 3", "Third String" );
      myAssemblyBuilder->Save( "MyAssembly.dll" );
   }

};

int main()
{
   CodeGenerator^ myGenerator = gcnew CodeGenerator;
   Console::WriteLine( "A resource named 'MyResource::resource' has been created and can be viewed in the 'MyAssembly.dll'" );
}
