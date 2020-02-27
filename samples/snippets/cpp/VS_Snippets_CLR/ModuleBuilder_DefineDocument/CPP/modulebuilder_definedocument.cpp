
// System::Reflection::Emit::ModuleBuilder.DefineDocument
/*
The following example demonstrates the 'DefineDocument' method
of 'ModuleBuilder' class.
A dynamic assembly with a module in it is created in 'CodeGenerator' class.
It gets the Object* representing the defined document using the method
'DefineDocument'.
*/
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Resources;
using namespace System::Diagnostics::SymbolStore;
public ref class CodeGenerator
{
private:
   ModuleBuilder^ myModuleBuilder;
   AssemblyBuilder^ myAssemblyBuilder;

public:
   CodeGenerator()
   {
      
      // Get the current application domain for the current thread.
      AppDomain^ currentDomain = AppDomain::CurrentDomain;
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "TempAssembly";
      
      // Define a dynamic assembly in the current domain.
      myAssemblyBuilder = currentDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::RunAndSave );
      
      // Define a dynamic module in S"TempAssembly" assembly.
      myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "TempModule", "Resource.mod", true );
      
      // Define a document for source.on 'TempModule' module.
      ISymbolDocumentWriter^ myDocument = myModuleBuilder->DefineDocument( "RTAsm.il", SymDocumentType::Text, SymLanguageType::ILAssembly, SymLanguageVendor::Microsoft );
      Console::WriteLine( "The object representing the defined document is: {0}", myDocument );
   }

};

int main()
{
   CodeGenerator^ myGenerator = gcnew CodeGenerator;
}

// </Snippet1>
