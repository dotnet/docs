// System.Reflection.Emit.ConstructorBuilder.GetModule()
// System.Reflection.Emit.ConstructorBuilder.GetToken()
// System.Reflection.Emit.ConstructorBuilder.GetMethodImplementationFlags()
// System.Reflection.Emit.ConstructorBuilder.GetParameters()

/* The following program demonstrates the 'GetModule','GetToken',
'GetMethodImplementationFlags' and 'GetParameters'
methods of 'ConstructorBuilder' class.  Create the assembly
in the current domain with dynamic module in the assembly. Constructor
builder is used in conjunction with the 'TypeBuilder' class to create
constructor at run time. Set a custom attribute using a custom attribute
builder and displays module name, Token id and parameter info of this class.
*/

using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Security;
using namespace System::Security::Permissions;

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
// <Snippet3>

      MethodBuilder^ myMethodBuilder = nullptr;
      AppDomain^ myCurrentDomain = AppDomain::CurrentDomain;
      // Create assembly in current CurrentDomain.
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "TempAssembly";
      // Create a dynamic assembly.
      myAssemblyBuilder = myCurrentDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );
      // Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "TempModule" );
      // Create a type in the module.
      TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType( "TempClass", TypeAttributes::Public );
      FieldBuilder^ myGreetingField = myTypeBuilder->DefineField( "Greeting",
         String::typeid, FieldAttributes::Public );
      array<Type^>^myConstructorArgs = {String::typeid};
// <Snippet2>
// <Snippet4>
      // Define a constructor of the dynamic class.
      ConstructorBuilder^ myConstructorBuilder = myTypeBuilder->DefineConstructor(
         MethodAttributes::Public, CallingConventions::Standard, myConstructorArgs );
      // Get a reference to the module that contains this constructor.
      Module^ myModule = myConstructorBuilder->GetModule();
      Console::WriteLine( "Module Name : {0}", myModule->Name );
      // Get the 'MethodToken' that represents the token for this constructor.
      MethodToken myMethodToken = myConstructorBuilder->GetToken();
      Console::WriteLine( "Constructor Token is : {0}", myMethodToken.Token );
      // Get the method implementation flags for this constructor.
      MethodImplAttributes myMethodImplAttributes = myConstructorBuilder->GetMethodImplementationFlags();
      Console::WriteLine( "MethodImplAttributes : {0}", myMethodImplAttributes );
// </Snippet3>
// </Snippet2>
// </Snippet1>
      // Generate IL for the method, call its base class constructor and store the arguments
      // in the private field.
      ILGenerator^ myILGenerator3 = myConstructorBuilder->GetILGenerator();
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

      // Get the parameters of this constructor.
      array<ParameterInfo^>^myParameterInfo = myConstructorBuilder->GetParameters();
      for ( int i = 0; i < myParameterInfo->Length; i++ )
      {
         Console::WriteLine( "Declaration type : {0}", myParameterInfo[ i ]->Member->DeclaringType );
      }
// </Snippet4>
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
   MyConstructorBuilder^ myConstructorBuilder1 = gcnew MyConstructorBuilder;
   Type^ myTypeProperty = myConstructorBuilder1->MyTypeProperty;
   if ( nullptr != myTypeProperty )
   {
      array<Object^>^myObject = {"Hello"};
      Object^ myObject1 = Activator::CreateInstance( myTypeProperty, myObject, (Object^) 0 );
      MethodInfo^ myMethodInfo = myTypeProperty->GetMethod( "HelloWorld" );

      if ( nullptr != myMethodInfo )
      {
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
