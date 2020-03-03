
// System::Reflection::Emit::FieldBuilder.SetCustomAttribute(ConstructorInfo, Byte->Item[])
// System::Reflection::Emit::FieldBuilder.SetCustomAttribute(CustomAttributeBuilder)
/*
   The following program demonstrates 'SetCustomAttribute(ConstructorInfo, Byte[])'
   and 'SetCustomAttribute(CustomAttributeBuilder)' methods of 'FieldBuilder' class.
   A dynamic assembly is created. A new class of type 'MyClass' is created.
   A 'Method' and a 'Field are defined in the class.Two 'CustomAttributes' are
   set to the field.The method initializes a value to 'Field'.Value of the field
   is displayed to console.Values of Attributes applied to field are retreived and
   displayed to console.
*/
// <Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

[AttributeUsage(AttributeTargets::All,AllowMultiple=false)]
public ref class MyAttribute1: public Attribute
{
public:
   String^ myCustomAttributeValue;
   MyAttribute1( String^ myString )
   {
      myCustomAttributeValue = myString;
   }
};


[AttributeUsage(AttributeTargets::All,AllowMultiple=false)]
public ref class MyAttribute2: public Attribute
{
public:
   bool myCustomAttributeValue;
   MyAttribute2( bool myBool )
   {
      myCustomAttributeValue = myBool;
   }
};

Type^ CreateCallee( AppDomain^ currentDomain )
{
   // Create a simple name for the assembly.
   AssemblyName^ myAssemblyName = gcnew AssemblyName;
   myAssemblyName->Name = "EmittedAssembly";

   // Create the called dynamic assembly.
   AssemblyBuilder^ myAssemblyBuilder = currentDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::RunAndSave );
   ModuleBuilder^ myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "EmittedModule", "EmittedModule.mod" );

   // Define a public class named 'CustomClass' in the assembly.
   TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType( "CustomClass", TypeAttributes::Public );

   // Define a private String field named 'MyField' in the type.
   FieldBuilder^ myFieldBuilder = myTypeBuilder->DefineField( "MyField", String::typeid, FieldAttributes::Public );
   Type^ myAttributeType1 = MyAttribute1::typeid;

   // Create a Constructorinfo Object* for attribute 'MyAttribute1'.
   array<Type^>^type1 = {String::typeid};
   ConstructorInfo^ myConstructorInfo = myAttributeType1->GetConstructor( type1 );

   // Create the CustomAttribute instance of attribute of type 'MyAttribute1'.
   array<Object^>^obj1 = {"Test"};
   CustomAttributeBuilder^ attributeBuilder = gcnew CustomAttributeBuilder( myConstructorInfo,obj1 );

   // Set the CustomAttribute 'MyAttribute1' to the Field.
   myFieldBuilder->SetCustomAttribute( attributeBuilder );
   Type^ myAttributeType2 = MyAttribute2::typeid;

   // Create a Constructorinfo Object* for attribute 'MyAttribute2'.
   array<Type^>^type2 = {bool::typeid};
   ConstructorInfo^ myConstructorInfo2 = myAttributeType2->GetConstructor( type2 );

   // Set the CustomAttribute 'MyAttribute2' to the Field.
   array<Byte>^bytes = {01,00,01,00,00};
   myFieldBuilder->SetCustomAttribute( myConstructorInfo2, bytes );

   // Create a method.
   array<Type^>^type3 = {String::typeid,int::typeid};
   MethodBuilder^ myMethodBuilder = myTypeBuilder->DefineMethod( "MyMethod", MethodAttributes::Public, nullptr, type3 );
   ILGenerator^ myILGenerator = myMethodBuilder->GetILGenerator();
   myILGenerator->Emit( OpCodes::Ldarg_0 );
   myILGenerator->Emit( OpCodes::Ldarg_1 );
   myILGenerator->Emit( OpCodes::Stfld, myFieldBuilder );
   myILGenerator->EmitWriteLine( "Value of the Field is :" );
   myILGenerator->EmitWriteLine( myFieldBuilder );
   myILGenerator->Emit( OpCodes::Ret );
   return myTypeBuilder->CreateType();
}

int main()
{
   try
   {
      Type^ myCustomClass = CreateCallee( Thread::GetDomain() );

      // Construct an instance of a type.
      Object^ myObject = Activator::CreateInstance( myCustomClass );
      Console::WriteLine( "FieldBuilder Sample" );

      // Find a method in this type and call it on this Object*.
      MethodInfo^ myMethodInfo = myCustomClass->GetMethod( "MyMethod" );
      array<Object^>^obj1 = {"Sample string",3};
      myMethodInfo->Invoke( myObject, obj1 );

      // Retrieve the values of Attributes applied to field and display to console.
      array<FieldInfo^>^myFieldInfo = myCustomClass->GetFields();
      for ( int i = 0; i < myFieldInfo->Length; i++ )
      {
         array<Object^>^attributes = myFieldInfo[ i ]->GetCustomAttributes( true );
         for ( int index = 0; index < attributes->Length; index++ )
         {
            if ( dynamic_cast<MyAttribute1^>(attributes[ index ]) )
            {
               MyAttribute1^ myCustomAttribute = safe_cast<MyAttribute1^>(attributes[ index ]);
               Console::WriteLine( "Attribute Value of (MyAttribute1): {0}", myCustomAttribute->myCustomAttributeValue );
            }
            if ( dynamic_cast<MyAttribute2^>(attributes[ index ]) )
            {
               MyAttribute2^ myCustomAttribute = safe_cast<MyAttribute2^>(attributes[ index ]);
               Console::WriteLine( "Attribute Value of (MyAttribute2): {0}", myCustomAttribute->myCustomAttributeValue );
            }
         }
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception Caught {0}", e->Message );
   }
}
// </Snippet1>
