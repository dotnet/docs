
// System.Reflection.Emit.EnumBuilder
// System.Reflection.Emit.EnumBuilder.IsDefined()
// System.Reflection.Emit.EnumBuilder.GetCustomAttributes(Type, bool)
// System.Reflection.Emit.EnumBuilder.SetCustomAttribute(CustomAttributeBuilder)
/*
   The following program demonstrates the EnumBuilder class and
   its methods  'IsDefined', 'GetCustomAttributes(Type, bool)' and
   'SetCustomAttribute(CustomAttributeBuilder)'. It defines a 'MyAttribute'
   class which is derived from 'System.Attribute' class. It builds an Enum
   and sets 'MyAttribute' as  custom attribute to the Enum.It gets the
   custom attributes of the Enum type and displays its contents on the console.
*/
// <Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

// <Snippet2>

[AttributeUsage(AttributeTargets::All,AllowMultiple=false)]
public ref class MyAttribute: public Attribute
{
public:
   String^ myString;
   int myInteger;
   MyAttribute( String^ myString1, int myInteger1 )
   {
      this->myString = myString1;
      this->myInteger = myInteger1;
   }

};

ref class MyApplication
{
private:
   static AssemblyBuilder^ myAssemblyBuilder;
   static EnumBuilder^ myEnumBuilder;

public:
   static void Main()
   {
      try
      {
         CreateCallee( Thread::GetDomain() );
         if ( myEnumBuilder->IsDefined( MyAttribute::typeid, false ) )
         {
            array<Object^>^myAttributesArray = myEnumBuilder->GetCustomAttributes( MyAttribute::typeid, false );
            Console::WriteLine( "Custom attribute contains: " );

            // Read the attributes and display them on the console.
            for ( int index = 0; index < myAttributesArray->Length; index++ )
            {
               if ( dynamic_cast<MyAttribute^>(myAttributesArray[ index ]) )
               {
                  Console::WriteLine( "The value of myString  is: {0}", (dynamic_cast<MyAttribute^>(myAttributesArray[ index ]))->myString );
                  Console::WriteLine( "The value of myInteger is: {0}", (dynamic_cast<MyAttribute^>(myAttributesArray[ index ]))->myInteger );
               }
            }
         }
         else
         {
            Console::WriteLine( "Custom Attributes are not set for the EnumBuilder" );
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
      // Create a name for the assembly.
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "EmittedAssembly";

      // Create the dynamic assembly.
      myAssemblyBuilder = domain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );
      Type^ myType = MyAttribute::typeid;
      array<Type^>^temp0 = {String::typeid,int::typeid};
      ConstructorInfo^ myInfo = myType->GetConstructor( temp0 );
      array<Object^>^temp1 = {"Hello",2};
      CustomAttributeBuilder^ myCustomAttributeBuilder = gcnew CustomAttributeBuilder( myInfo,temp1 );

      // Create a dynamic module.
      ModuleBuilder^ myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "EmittedModule" );

      // Create a dynamic Enum.
      myEnumBuilder = myModuleBuilder->DefineEnum( "MyNamespace.MyEnum", TypeAttributes::Public, Int32::typeid );
      FieldBuilder^ myFieldBuilder1 = myEnumBuilder->DefineLiteral( "FieldOne", 1 );
      FieldBuilder^ myFieldBuilder2 = myEnumBuilder->DefineLiteral( "FieldTwo", 2 );
      myEnumBuilder->CreateType();
      myEnumBuilder->SetCustomAttribute( myCustomAttributeBuilder );
   }
};

int main()
{
   MyApplication::Main();
}
// </Snippet2>
// </Snippet1>
