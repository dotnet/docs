// System.Reflection.Emit.ModuleBuilder.DefineInitializedData

/*
The following example demonstrates the 'DefineInitializedData' method of 
'ModuleBuilder' class.
A dynamic assembly with a module in it is created in 'CodeGenerator' class. 
A initialized data field is created using  'DefineInitializedData'
method for creating the initialized data.
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
      // <Snippet1>
      AppDomain^ currentDomain;
      AssemblyName^ myAssemblyName;
      
      // Get the current application domain for the current thread.
      currentDomain = AppDomain::CurrentDomain;
      myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "TempAssembly";
      
      // Define a dynamic assembly in the 'currentDomain'.
      myAssemblyBuilder =
         currentDomain->DefineDynamicAssembly(
            myAssemblyName, AssemblyBuilderAccess::Run );
      
      // Define a dynamic module in "TempAssembly" assembly.
      myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "TempModule" );
      
      // Define the initialized data field in the .sdata section of the PE file.
      array<Byte>^ temp0 = {01,00,01};
      FieldBuilder^ myFieldBuilder =
         myModuleBuilder->DefineInitializedData( "MyField", temp0,
            (FieldAttributes)(FieldAttributes::Static | FieldAttributes::Public) );
      myModuleBuilder->CreateGlobalFunctions();
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
   FieldInfo^ myInfo = myBuilder->GetField( "MyField" );
   Console::WriteLine( "The name of the initialized data field is :" + myInfo->Name );
   Console::WriteLine( "The object having the field value is :" + myInfo->GetValue( myBuilder ) );
}
