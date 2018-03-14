// System.Reflection.Emit.ConstructorBuilder.AddDeclarativeSecurity()
// System.Reflection.Emit.ConstructorBuilder.Attributes
// System.Reflection.Emit.ConstructorBuilder.DeclaringType
// System.Reflection.Emit.ConstructorBuilder.DefineParameter()

/* The following program demonstrates the 'AddDeclarativeSecurity',
'DefineParameter' methods, and  'Attributes', 'DeclaringType' properties
of the ConstructorBuilder class. Create the assembly in the current domain
with dynamic module in the assembly. Constructor  builder is used in
conjunction with the 'TypeBuilder' class to create constructor at run time.
Add declarative security to the constructor. Display the 'Attributes',
'DeclaringType' and 'DefineParameter'.
*/

using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Security::Permissions;
using namespace System::Security;

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
// <Snippet2>
// <Snippet3>
      MethodBuilder^ myMethodBuilder = nullptr;

      AppDomain^ myCurrentDomain = AppDomain::CurrentDomain;
      // Create assembly in current CurrentDomain
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "TempAssembly";
      // Create a dynamic assembly
      myAssemblyBuilder = myCurrentDomain->DefineDynamicAssembly(
         myAssemblyName, AssemblyBuilderAccess::RunAndSave );
      // Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "TempModule" );
      FieldInfo^ myFieldInfo =
         myModuleBuilder->DefineUninitializedData( "myField", 2, FieldAttributes::Public );
      // Create a type in the module
      TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType( "TempClass", TypeAttributes::Public );
      FieldBuilder^ myGreetingField = myTypeBuilder->DefineField( "Greeting",
         String::typeid, FieldAttributes::Public );
      array<Type^>^myConstructorArgs = {String::typeid};
      // Define a constructor of the dynamic class.
      ConstructorBuilder^ myConstructor = myTypeBuilder->DefineConstructor(
         MethodAttributes::Public, CallingConventions::Standard, myConstructorArgs );
      PermissionSet^ myPset = gcnew PermissionSet( PermissionState::Unrestricted );
      // Add declarative security to the constructor.
      Console::WriteLine( "Adding declarative security to the constructor....." );
      Console::WriteLine( "The Security action to be taken is \"DENY\" and" +
         " Permission set is \"UNRESTRICTED\"." );
      myConstructor->AddDeclarativeSecurity( SecurityAction::Deny, myPset );
// </Snippet3>
      MethodAttributes myMethodAttributes = myConstructor->Attributes;
      Type^ myAttributeType = MethodAttributes::typeid;
      int myAttribValue = (int)myMethodAttributes;
      if (  !myAttributeType->IsEnum )
      {
         Console::WriteLine( "This is not an Enum" );
      }
      array<FieldInfo^>^myFieldInfo1 = myAttributeType->GetFields( static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Static) );
      Console::WriteLine( "The Field info names of the Attributes for the constructor are:" );
      for ( int i = 0; i < myFieldInfo1->Length; i++ )
      {
         int myFieldValue =  *dynamic_cast<Int32^>(myFieldInfo1[ i ]->GetValue( nullptr ));
         if ( (myFieldValue & myAttribValue) == myFieldValue )
         {
            Console::WriteLine( "   {0}", myFieldInfo1[ i ]->Name );
         }
      }

      Type^ myType2 = myConstructor->DeclaringType;
      Console::WriteLine( "The declaring type is : {0}", myType2 );
// </Snippet2>
      ParameterBuilder^ myParameterBuilder1 =
         myConstructor->DefineParameter( 1, ParameterAttributes::Out, "My Parameter Name1" );
      Console::WriteLine( "The name of the parameter is : {0}",
         myParameterBuilder1->Name );
      if ( myParameterBuilder1->IsIn )
            Console::WriteLine( "{0} is Input parameter.", myParameterBuilder1->Name );
      else
            Console::WriteLine( "{0} is not Input Parameter.", myParameterBuilder1->Name );
      ParameterBuilder^ myParameterBuilder2 =
         myConstructor->DefineParameter( 1, ParameterAttributes::In, "My Parameter Name2" );
      Console::WriteLine( "The Parameter name is : {0}",
         myParameterBuilder2->Name );
      if ( myParameterBuilder2->IsIn )
            Console::WriteLine( "{0} is Input parameter.", myParameterBuilder2->Name );
      else
            Console::WriteLine( "{0} is not Input Parameter.", myParameterBuilder2->Name );
// </Snippet1>
      // Generate MSIL for the method, call its base class constructor and store the arguments
      // in the private field.
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
      // Generate MSIL for the method.
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
      array<Object^>^myObject = {"hello"};
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
