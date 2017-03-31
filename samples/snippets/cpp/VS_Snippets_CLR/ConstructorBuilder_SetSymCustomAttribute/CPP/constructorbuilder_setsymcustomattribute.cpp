// System.Reflection.Emit.ConstructorBuilder.SetSymCustomAttribute()

/* The following program demonstrates the 'SetSymCustomAttribute' method
of ConstructorBuilder class. It creates an assembly in the current 
domain with dynamic module in the assembly. Constructor builder is
used in conjunction with the 'TypeBuilder' class to create constructor
at run time. It then sets this constructor's custom attribute associated
with symbolic information.
*/

using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

public ref class MyConstructorBuilder
{
private:
   Type^ myType1;
   ModuleBuilder^ myModuleBuilder;
   AssemblyBuilder^ myAssemblyBuilder;

public:
   MyConstructorBuilder()
   {
      myModuleBuilder = nullptr;
      myAssemblyBuilder = nullptr;
      
// <Snippet1>
      MethodBuilder^ myMethodBuilder = nullptr;
      AppDomain^ myCurrentDomain = AppDomain::CurrentDomain;
      // Create assembly in current CurrentDomain.
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "TempAssembly";
      // Create a dynamic assembly.
      myAssemblyBuilder = myCurrentDomain->DefineDynamicAssembly(
         myAssemblyName, AssemblyBuilderAccess::Run );
      // Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "TempModule", true );
      FieldInfo^ myFieldInfo =
         myModuleBuilder->DefineUninitializedData( "myField", 2, FieldAttributes::Public );
      // Create a type in the module.
      TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType( "TempClass", TypeAttributes::Public );
      FieldBuilder^ myGreetingField = myTypeBuilder->DefineField( "Greeting",
         String::typeid, FieldAttributes::Public );
      array<Type^>^ myConstructorArgs = {String::typeid};
      // Define a constructor of the dynamic class.
      ConstructorBuilder^ myConstructor = myTypeBuilder->DefineConstructor( MethodAttributes::Public, CallingConventions::Standard, myConstructorArgs );
      // Display the name of the constructor.
      Console::WriteLine( "The constructor name is  : {0}", myConstructor->Name );
      array<Byte>^ temp0 = {01,00,00};
      myConstructor->SetSymCustomAttribute( "MySimAttribute", temp0 );
// </Snippet1>
      // Generate the IL for the method and call its superclass constructor.
      ILGenerator^ myILGenerator3 = myConstructor->GetILGenerator();
      myILGenerator3->Emit( OpCodes::Ldarg_0 );
      ConstructorInfo^ myConstructorInfo = Object::typeid->GetConstructor( gcnew array<Type^>(0) );
      myILGenerator3->Emit( OpCodes::Call, myConstructorInfo );
      myILGenerator3->Emit( OpCodes::Ldarg_0 );
      myILGenerator3->Emit( OpCodes::Ldarg_1 );
      myILGenerator3->Emit( OpCodes::Stfld, myGreetingField );
      myILGenerator3->Emit( OpCodes::Ret );
      // Add a method to the type.
      myMethodBuilder = myTypeBuilder->DefineMethod(
         "HelloWorld", MethodAttributes::Public, nullptr, nullptr );
      // Generate IL for the method.
      ILGenerator^ myILGenerator2 = myMethodBuilder->GetILGenerator();
      myILGenerator2->EmitWriteLine( "Hello World from global" );
      myILGenerator2->Emit( OpCodes::Ret );
      myModuleBuilder->CreateGlobalFunctions();
      myType1 = myTypeBuilder->CreateType();
   }

   property Type^ MyTypeProperty 
   {
      Type^ get()
      {
         return this->myType1;
      }
   }
};

int main()
{
   MyConstructorBuilder^ myConstructorBuilder = gcnew MyConstructorBuilder;
   Type^ myType1 = myConstructorBuilder->MyTypeProperty;
   if ( nullptr != myType1 )
   {
      Console::WriteLine( "Instantiating the new type..." );
      array<Object^>^ myObject = {"hello"};
      Object^ myObject1 = Activator::CreateInstance( myType1, myObject, nullptr );
      MethodInfo^ myMethodInfo = myType1->GetMethod( "HelloWorld" );
      if ( nullptr != myMethodInfo )
      {
         Console::WriteLine( "Invoking dynamically created HelloWorld method..." );
         myMethodInfo->Invoke( myObject1, nullptr );
      }
      else
      {
         Console::WriteLine( "Could not locate HelloWorld method" );
      }
   }
   else
   {
      Console::WriteLine( "Could not access Type." );
   }
}
