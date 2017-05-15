
// System.Reflection.Emit.EnumBuilder.GetCustomAttributes(bool)
// System.Reflection.Emit.EnumBuilder.SetCustomAttribute(ConstructorInfo, byte[])
/*
   The following program demonstrates 'GetCustomAttributes(bool)'
   and 'SetCustomAttribute(ConstructorInfo, byte[])' methods of 
   'System.Reflection.Emit.EnumBuilder' class. It defines 'MyAttribute' 
   class which is derived from 'System.Attribute' class. It builds an 
   Enum and sets 'MyAttribute' as  custom attribute to the Enum. 
   It gets the custom attributes of the Enum type and displays its contents 
   on the console.
*/
// <Snippet1>
// <Snippet2>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

[AttributeUsage(AttributeTargets::All,AllowMultiple=false)]
public ref class MyAttribute: public Attribute
{
public:
   bool myBoolValue;
   MyAttribute( bool myBool )
   {
      this->myBoolValue = myBool;
   }
};

ref class MyApplication
{
private:
   static EnumBuilder^ myEnumBuilder;

public:
   static void Main()
   {
      try
      {
         CreateCallee( Thread::GetDomain() );
         array<Object^>^myAttributesArray = myEnumBuilder->GetCustomAttributes( true );
         
         // Read the attributes and display them on the console.
         Console::WriteLine( "Custom attribute contains: " );
         for ( int index = 0; index < myAttributesArray->Length; index++ )
         {
            if ( dynamic_cast<MyAttribute^>(myAttributesArray[ index ]) )
            {
               Console::WriteLine( "myBoolValue: {0}", (dynamic_cast<MyAttribute^>(myAttributesArray[ index ]))->myBoolValue );
            }
         }
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "The following exception is raised:{0}", e->Message );
      }

   }

private:
   static void CreateCallee( AppDomain^ domain )
   {
      AssemblyName^ myAssemblyName = gcnew AssemblyName;

      // Create a name for the assembly.
      myAssemblyName->Name = "EmittedAssembly";

      // Create the dynamic assembly.
      AssemblyBuilder^ myAssemblyBuilder = domain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );
      Type^ myType = MyAttribute::typeid;
      array<Type^>^temp0 = {bool::typeid};
      ConstructorInfo^ myInfo = myType->GetConstructor( temp0 );

      // Create a dynamic module.
      ModuleBuilder^ myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "EmittedModule" );

      // Create a dynamic Enum.
      myEnumBuilder = myModuleBuilder->DefineEnum( "MyNamespace.MyEnum", TypeAttributes::Public, Int32::typeid );
      FieldBuilder^ myFieldBuilder1 = myEnumBuilder->DefineLiteral( "FieldOne", 1 );
      FieldBuilder^ myFieldBuilder2 = myEnumBuilder->DefineLiteral( "FieldTwo", 2 );
      myEnumBuilder->CreateType();
      array<Byte>^temp1 = {01,00,01};
      myEnumBuilder->SetCustomAttribute( myInfo, temp1 );
   }
};

int main()
{
   MyApplication::Main();
}
// </Snippet2>
// </Snippet1>
