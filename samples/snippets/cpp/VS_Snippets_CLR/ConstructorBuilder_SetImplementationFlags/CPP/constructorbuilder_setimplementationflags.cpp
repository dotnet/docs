
// System::Reflection::Emit::ConstructorBuilder.SetImplementationFlags()
/* The following program demonstrates the 'SetImplementationFlags'
   method of ConstructorBuilder class. It creates an assembly in the
   current domain with a dynamic module in the assembly. Constructor 
   builder is used in conjunction with the 'TypeBuilder' class to create
   constructor at run time. It then sets the method implementation flags
   for the constructor and displays the same.
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
      try
      {
         // <Snippet1>
         MethodBuilder^ myMethodBuilder = nullptr;
         AppDomain^ myCurrentDomain = AppDomain::CurrentDomain;

         // Create assembly in current CurrentDomain.
         AssemblyName^ myAssemblyName = gcnew AssemblyName;
         myAssemblyName->Name = "TempAssembly";

         // Create a dynamic assembly.
         myAssemblyBuilder = myCurrentDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );

         // Create a dynamic module in the assembly.
         myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "TempModule", true );
         FieldInfo^ myFieldInfo2 = myModuleBuilder->DefineUninitializedData( "myField", 2, FieldAttributes::Public );

         // Create a type in the module.
         TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType( "TempClass", TypeAttributes::Public );
         FieldBuilder^ myGreetingField = myTypeBuilder->DefineField( "Greeting", String::typeid, FieldAttributes::Public );
         array<Type^>^myConstructorArgs = {String::typeid};

         // Define a constructor of the dynamic class.
         ConstructorBuilder^ myConstructor = myTypeBuilder->DefineConstructor( MethodAttributes::Public, CallingConventions::Standard, myConstructorArgs );

         // Set the method implementation flags for the constructor.
         myConstructor->SetImplementationFlags( static_cast<MethodImplAttributes>(MethodImplAttributes::PreserveSig | MethodImplAttributes::Runtime) );

         // Get the method implementation flags for the constructor.
         MethodImplAttributes myMethodAttributes = myConstructor->GetMethodImplementationFlags();
         Type^ myAttributeType = MethodImplAttributes::typeid;
         int myAttribValue = (int)myMethodAttributes;
         if (  !myAttributeType->IsEnum )
         {
            Console::WriteLine( "This is not an Enum" );
         }

         // Display the field info names of the retrieved method implementation flags.
         array<FieldInfo^>^myFieldInfo = myAttributeType->GetFields( static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Static) );
         Console::WriteLine( "The Field info names of the MethodImplAttributes for the constructor are:" );
         for ( int i = 0; i < myFieldInfo->Length; i++ )
         {
            int myFieldValue =  *safe_cast<Int32^>(myFieldInfo[ i ]->GetValue( nullptr ));
            if ( (myFieldValue & myAttribValue) == myFieldValue )
            {
               Console::WriteLine( " {0}", myFieldInfo[ i ]->Name );
            }
         }
         // </Snippet1>

         // Add a method to the type.
         myMethodBuilder = myTypeBuilder->DefineMethod( "HelloWorld", MethodAttributes::Public, nullptr, nullptr );

         // Generate IL for the method.
         ILGenerator^ myILGenerator2 = myMethodBuilder->GetILGenerator();
         myILGenerator2->EmitWriteLine( "Hello World from global" );
         myILGenerator2->Emit( OpCodes::Ret );
         myModuleBuilder->CreateGlobalFunctions();
         myType1 = myTypeBuilder->CreateType();
      }
      catch ( InvalidOperationException^ ex ) 
      {
         Console::WriteLine( "The following exception has occured : {0}", ex->Message );
      }
      catch ( Exception^ ex ) 
      {
         Console::WriteLine( "The following exception has occured : {0}", ex->Message );
      }
   }

   property Type^ MyTypeProperty 
   {
      Type^ get()
      {
         return this->myType1;
      }
   }
};

void main()
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
