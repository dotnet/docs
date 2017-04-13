// System.Reflection.Emit.ModuleBuilder.GetArrayMethod
// System.Reflection.Emit.ModuleBuilder.GetArrayMethodToken

/*
The following example demonstrates 'GetArrayMethod' and 'GetArrayMethodToken'
methods of 'ModuleBuilder' class.
A dynamic assembly with a module having a runtime class, 'TempClass' is created. 
This class defines a method, 'SortArray', which sorts the elements of the array 
passed to it.The 'GetArrayMethod' method is used to obtain the 'MethodInfo' object 
corresponding to the 'Sort' method of the 'Array' .The token used to identify the 'Sort' 
method in dynamic module is displayed using 'GetArrayMethodToken' method.
*/

using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

public ref class CodeGenerator
{
private:
   AssemblyBuilder^ myAssemblyBuilder;

public:
   CodeGenerator()
   {
      AppDomain^ myCurrentDomain = AppDomain::CurrentDomain;
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "TempAssembly";
      
      // Define a dynamic assembly in the current application domain.
      myAssemblyBuilder = myCurrentDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::RunAndSave );
      
// <Snippet1>
// <Snippet2>
      // Define a dynamic module in "TempAssembly" assembly.
      ModuleBuilder^ myModuleBuilder = myAssemblyBuilder->
         DefineDynamicModule( "TempModule" );

      // Define a runtime class with specified name and attributes.
      TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType(
         "TempClass", TypeAttributes::Public );
      array<Type^>^ paramArray = { Array::typeid };
      // Add 'SortArray' method to the class, with the given signature.
      MethodBuilder^ myMethod = myTypeBuilder->DefineMethod( "SortArray",
         MethodAttributes::Public, Array::typeid, paramArray );

      array<Type^>^ myArrayClass = gcnew array<Type^>( 1 );
      array<Type^>^ parameterTypes = { Array::typeid };
      // Get the 'MethodInfo' object corresponding to 'Sort' method of 'Array' class.
      MethodInfo^ myMethodInfo = myModuleBuilder->GetArrayMethod(
         myArrayClass->GetType(), "Sort", CallingConventions::Standard,
         nullptr, parameterTypes );

      // Get the token corresponding to 'Sort' method of 'Array' class.
      MethodToken myMethodToken = myModuleBuilder->GetArrayMethodToken(
         myArrayClass->GetType(), "Sort", CallingConventions::Standard,
         nullptr, parameterTypes );
      Console::WriteLine( "Token used by module to identify the 'Sort' method"
         + " of 'Array' class is : {0:x} ", myMethodToken.Token );

      ILGenerator^ methodIL = myMethod->GetILGenerator();
      methodIL->Emit( OpCodes::Ldarg_1 );
      methodIL->Emit( OpCodes::Call, myMethodInfo );
      methodIL->Emit( OpCodes::Ldarg_1 );
      methodIL->Emit( OpCodes::Ret );

      // Complete the creation of type.
      myTypeBuilder->CreateType();
      // </Snippet2>
      // </Snippet1>
   }

   property AssemblyBuilder^ MyBuilder 
   {
      AssemblyBuilder^ get()
      {
         return this->myAssemblyBuilder;
      }
   }
};

int main()
{
   CodeGenerator^ myCodeGenerator = gcnew CodeGenerator;
   AssemblyBuilder^ myAssemblyBuilder = myCodeGenerator->MyBuilder;
   ModuleBuilder^ myModuleBuilder = myAssemblyBuilder->
      GetDynamicModule( "TempModule" );
   Type^ myType = myModuleBuilder->GetType( "TempClass" );
   Object^ myObject = Activator::CreateInstance( myType );
   MethodInfo^ sortArray = myType->GetMethod( "SortArray" );
   if ( nullptr != sortArray )
   {
      array<String^>^ arrayToSort = {"I","am","not","sorted"};
      Console::WriteLine( "Array elements before sorting " );
      for ( int i = 0; i < arrayToSort->Length; i++ )
      {
         Console::WriteLine( "Array element {0} : {1} ", i, arrayToSort[ i ] );
      }
      array<Object^>^arguments = {arrayToSort};
      Console::WriteLine( "Invoking our dynamically "
         + "created SortArray method..." );
      Object^ myOutput = sortArray->Invoke( myObject, arguments );
      array<String^>^ mySortedArray = ( array<String^>^ )myOutput;
      Console::WriteLine( "Array elements after sorting " );
      for ( int i = 0; i < mySortedArray->Length; i++ )
      {
         Console::WriteLine( "Array element {0} : {1} ", i, mySortedArray[ i ] );
      }
   }
}
