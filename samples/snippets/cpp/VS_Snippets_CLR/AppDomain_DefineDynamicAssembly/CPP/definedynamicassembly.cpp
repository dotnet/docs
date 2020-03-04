
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
ref class Test
{
public:
   static void InstantiateMyDynamicType( AppDomain^ domain )
   {
      try
      {
         
         // You must supply a valid fully qualified assembly name here.
         domain->CreateInstance( "Assembly text name, Version, Culture, PublicKeyToken", "MyDynamicType" );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e->Message );
      }

   }

   static Assembly^ MyResolveEventHandler( Object^ sender, ResolveEventArgs^ args )
   {
      return DefineDynamicAssembly( dynamic_cast<AppDomain^>(sender) );
   }

   static Assembly^ DefineDynamicAssembly( AppDomain^ domain )
   {
      
      // Build a dynamic assembly using Reflection Emit API.
      AssemblyName^ assemblyName = gcnew AssemblyName;
      assemblyName->Name = "MyDynamicAssembly";
      AssemblyBuilder^ assemblyBuilder = domain->DefineDynamicAssembly( assemblyName, AssemblyBuilderAccess::Run );
      ModuleBuilder^ moduleBuilder = assemblyBuilder->DefineDynamicModule( "MyDynamicModule" );
      TypeBuilder^ typeBuilder = moduleBuilder->DefineType( "MyDynamicType", TypeAttributes::Public );
      ConstructorBuilder^ constructorBuilder = typeBuilder->DefineConstructor( MethodAttributes::Public, CallingConventions::Standard, nullptr );
      ILGenerator^ ilGenerator = constructorBuilder->GetILGenerator();
      ilGenerator->EmitWriteLine( "MyDynamicType instantiated!" );
      ilGenerator->Emit( OpCodes::Ret );
      typeBuilder->CreateType();
      return assemblyBuilder;
   }

};

int main()
{
   AppDomain^ currentDomain = AppDomain::CurrentDomain;
   Test::InstantiateMyDynamicType( currentDomain ); // Failed!
   currentDomain->AssemblyResolve += gcnew ResolveEventHandler( Test::MyResolveEventHandler );
   Test::InstantiateMyDynamicType( currentDomain ); // OK!
}

// </Snippet1>
