
// System.Reflection.Emit.SetCustomAttribute(ConstructorInfo, byte[])
/*
The following program demonstrates the 'SetCustomAttribute(ConstructorInfo, byte[])'
method of 'AssemblyBuilder' class. It defines a 'MyAttribute' class which is derived
from 'Attribute' class. It builds an assembly by setting 'MyAttribute' custom attribute
and defines 'HelloWorld' type. Then it gets the custom attributes of 'HelloWorld' type
and displays its contents to the console.
*/

// <Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

[AttributeUsage(AttributeTargets::All,AllowMultiple=false)]
public ref class MyAttribute: public Attribute
{
public:
   bool s;
   MyAttribute( bool s )
   {
      this->s = s;
   }
};

Type^ CreateCallee( AppDomain^ domain )
{
   AssemblyName^ myAssemblyName = gcnew AssemblyName;
   myAssemblyName->Name = "EmittedAssembly";
   AssemblyBuilder^ myAssembly = domain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );
   Type^ myType = MyAttribute::typeid;
   array<Type^>^temp0 = {bool::typeid};
   ConstructorInfo^ infoConstructor = myType->GetConstructor( temp0 );
   array<Byte>^temp1 = {01,00,01};
   myAssembly->SetCustomAttribute( infoConstructor, temp1 );
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
         break;
      }
   }
}
// </Snippet1>
