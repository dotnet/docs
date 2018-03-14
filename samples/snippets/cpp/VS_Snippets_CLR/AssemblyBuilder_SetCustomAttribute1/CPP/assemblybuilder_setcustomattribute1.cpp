
// System.Reflection.Emit.SetCustomAttribute(CustomAttributeBuilder)
/*
The following program demonstrates the 'SetCustomAttribute(CustomAttributeBuilder)'
method of 'AssemblyBuilder' class. It defines a 'MyAttribute' class which is derived
from 'Attribute' class. It builds an assembly by setting 'MyAttribute' custom attribute
and defines 'HelloWorld' type. Then it gets the custom attributes of 'HelloWorld' type
and displays its contents to the console.
*/
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

// <Snippet1>
[AttributeUsage(AttributeTargets::All,AllowMultiple=false)]
public ref class MyAttribute: public Attribute
{
public:
   String^ s;
   int x;
   MyAttribute( String^ s, int x )
   {
      this->s = s;
      this->x = x;
   }
};

Type^ CreateCallee( AppDomain^ domain )
{
   AssemblyName^ myAssemblyName = gcnew AssemblyName;
   myAssemblyName->Name = "EmittedAssembly";
   AssemblyBuilder^ myAssembly = domain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );
   Type^ myType = MyAttribute::typeid;
   array<Type^>^temp0 = {String::typeid,int::typeid};
   ConstructorInfo^ infoConstructor = myType->GetConstructor( temp0 );
   array<Object^>^temp1 = {"Hello",2};
   CustomAttributeBuilder^ attributeBuilder = gcnew CustomAttributeBuilder( infoConstructor,temp1 );
   myAssembly->SetCustomAttribute( attributeBuilder );
   ModuleBuilder^ myModule = myAssembly->DefineDynamicModule( "EmittedModule" );
   
   // Define a public class named "HelloWorld" in the assembly.
   TypeBuilder^ helloWorldClass = myModule->DefineType( "HelloWorld", TypeAttributes::Public );
   return (helloWorldClass->CreateType());
}

int main()
{
   Type^ customAttribute = CreateCallee( Thread::GetDomain() );
   array<Object^>^attributes = customAttribute->Assembly->GetCustomAttributes( true );
   Console::WriteLine( "MyAttribute custom attribute contains : " );
   for ( int index = 0; index < attributes->Length; index++ )
   {
      if ( dynamic_cast<MyAttribute^>(attributes[ index ]) )
      {
         Console::WriteLine( "s : {0}", (dynamic_cast<MyAttribute^>(attributes[ index ]))->s );
         Console::WriteLine( "x : {0}", (dynamic_cast<MyAttribute^>(attributes[ index ]))->x );
         break;
      }
   }
}
// </Snippet1>
