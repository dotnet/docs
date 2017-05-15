
// System::Reflection::Emit::ConstructorBuilder.SetCustomAttribute(ConstructorInfo, Byte->Item[])
/*
   The following program demonstrates the 'SetCustomAttribute(ConstructorInfo, Byte[])'
   method of 'ConstructorBuilder' class. It defines a 'MyAttribute' class which is derived
   from 'Attribute' class. It builds a constructor by setting 'MyAttribute' custom attribute
   and defines 'Helloworld' type. Then it gets the custom attributes of 'HelloWorld' type
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
   bool myBoolean;
   MyAttribute( bool myBoolean )
   {
      this->myBoolean = myBoolean;
   }
};

static Type^ MyCreateCallee( AppDomain^ domain )
{
   AssemblyName^ myAssemblyName = gcnew AssemblyName;
   myAssemblyName->Name = "EmittedAssembly";
   
   // Define a dynamic assembly in the current application domain.
   AssemblyBuilder^ myAssembly = domain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );
   
   // Define a dynamic module in this assembly.
   ModuleBuilder^ myModuleBuilder = myAssembly->DefineDynamicModule( "EmittedModule" );
   
   // Construct a 'TypeBuilder' given the name and attributes.
   TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType( "HelloWorld", TypeAttributes::Public );
   
   // Define a constructor of the dynamic class.
   array<Type^>^type1 = {String::typeid};
   ConstructorBuilder^ myConstructor = myTypeBuilder->DefineConstructor( MethodAttributes::Public, CallingConventions::Standard, type1 );
   ILGenerator^ myILGenerator = myConstructor->GetILGenerator();
   myILGenerator->Emit( OpCodes::Ldstr, "Constructor is invoked" );
   myILGenerator->Emit( OpCodes::Ldarg_1 );
   array<Type^>^type2 = {String::typeid};
   MethodInfo^ myMethodInfo = Console::typeid->GetMethod( "WriteLine", type2 );
   myILGenerator->Emit( OpCodes::Call, myMethodInfo );
   myILGenerator->Emit( OpCodes::Ret );
   Type^ myType = MyAttribute::typeid;
   array<Type^>^type3 = {bool::typeid};
   ConstructorInfo^ myConstructorInfo = myType->GetConstructor( type3 );
   try
   {
      array<Byte>^bytes = {01,00,01};
      myConstructor->SetCustomAttribute( myConstructorInfo, bytes );
   }
   catch ( ArgumentNullException^ ex ) 
   {
      Console::WriteLine( "The following exception has occured : {0}", ex->Message );
   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( "The following exception has occured : {0}", ex->Message );
   }

   return myTypeBuilder->CreateType();
}

int main()
{
   Type^ myHelloworld = MyCreateCallee( Thread::GetDomain() );
   array<Type^>^type1 = {String::typeid};
   ConstructorInfo^ myConstructor = myHelloworld->GetConstructor( type1 );
   array<Object^>^myAttributes1 = myConstructor->GetCustomAttributes( true );
   Console::WriteLine( "MyAttribute custom attribute contains  " );
   for ( int index = 0; index < myAttributes1->Length; index++ )
   {
      if ( dynamic_cast<MyAttribute^>(myAttributes1[ index ]) )
      {
         Console::WriteLine( "myBoolean : {0}", safe_cast<MyAttribute^>(myAttributes1[ index ])->myBoolean );
      }
   }
}
// </Snippet1>
