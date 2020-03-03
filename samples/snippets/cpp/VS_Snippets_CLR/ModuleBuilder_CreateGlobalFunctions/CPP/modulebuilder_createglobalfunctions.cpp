// System.Reflection.Emit.ModuleBuilder.DefineGlobalMethod(String,MethodAttributes,Type,Type[])
// System.Reflection.Emit.ModuleBuilder.CreateGlobalFunctions

/*
The following example demonstrates the 'DefineGlobalMethod(String,MethodAttributes,Type,Type[])'
and 'CreateGlobalFunctions' methods of 'ModuleBuilder' class. 
A dynamic assembly with a module in it is created in 'CodeGenerator' class. Then a global method 
is created in the module using the 'DefineGlobalMethod' method. The global method is called from
the 'CallerClass'.
*/

using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

public ref class CodeGenerator
{
private:
   ModuleBuilder^ myModuleBuilder;
   AssemblyBuilder^ myAssemblyBuilder;

public:
   CodeGenerator()
   {
      myModuleBuilder = nullptr;
      myAssemblyBuilder = nullptr;
      
      // <Snippet1>
      // <Snippet2>
      AppDomain^ currentDomain;
      AssemblyName^ myAssemblyName;
      MethodBuilder^ myMethodBuilder = nullptr;
      ILGenerator^ myILGenerator;
      
      // Get the current application domain for the current thread.
      currentDomain = AppDomain::CurrentDomain;
      myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "TempAssembly";
      
      // Define a dynamic assembly in the 'currentDomain'.
      myAssemblyBuilder = 
         currentDomain->DefineDynamicAssembly(
            myAssemblyName, AssemblyBuilderAccess::RunAndSave );
      
      // Define a dynamic module in "TempAssembly" assembly.
      myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "TempModule" );
      
      // Define a global method in the 'TempModule' module.
      myMethodBuilder = myModuleBuilder->DefineGlobalMethod(
         "MyMethod1", (MethodAttributes)(MethodAttributes::Static | MethodAttributes::Public),
         nullptr, nullptr );
      myILGenerator = myMethodBuilder->GetILGenerator();
      myILGenerator->EmitWriteLine( "Hello World from global method." );
      myILGenerator->Emit( OpCodes::Ret );
      
      // Fix up the 'TempModule' module .
      myModuleBuilder->CreateGlobalFunctions();
      // </Snippet2>
      // </Snippet1>
   }

   property AssemblyBuilder^ MyAssembly 
   {
      AssemblyBuilder^ get()
      {
         return this->myAssemblyBuilder;
      }
   }
};

int main()
{
   CodeGenerator^ myGenerator = gcnew CodeGenerator;
   AssemblyBuilder^ myAssembly = myGenerator->MyAssembly;
   ModuleBuilder^ myBuilder = myAssembly->GetDynamicModule( "TempModule" );
   Console::WriteLine( "Invoking the global method..." );
   MethodInfo^ myMethodInfo = myBuilder->GetMethod( "MyMethod1" );
   myMethodInfo->Invoke( nullptr, nullptr );
}
