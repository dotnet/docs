
// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
void InstantiateMyType( AppDomain^ domain )
{
   try
   {
      
      // You must supply a valid fully qualified assembly name here.
      domain->CreateInstance( "Assembly text name, Version, Culture, PublicKeyToken", "MyType" );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }

}


// Loads the content of a file to a Byte array.
array<Byte>^ loadFile( String^ filename )
{
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   array<Byte>^buffer = gcnew array<Byte>((int)fs->Length);
   fs->Read( buffer, 0, buffer->Length );
   fs->Close();
   return buffer;
}


// Creates a dynamic assembly with symbol information
// and saves them to temp.dll and temp.pdb
void EmitAssembly( AppDomain^ domain )
{
   AssemblyName^ assemblyName = gcnew AssemblyName;
   assemblyName->Name = "MyAssembly";
   AssemblyBuilder^ assemblyBuilder = domain->DefineDynamicAssembly( assemblyName, AssemblyBuilderAccess::Save );
   ModuleBuilder^ moduleBuilder = assemblyBuilder->DefineDynamicModule( "MyModule", "temp.dll", true );
   TypeBuilder^ typeBuilder = moduleBuilder->DefineType( "MyType", TypeAttributes::Public );
   ConstructorBuilder^ constructorBuilder = typeBuilder->DefineConstructor( MethodAttributes::Public, CallingConventions::Standard, nullptr );
   ILGenerator^ ilGenerator = constructorBuilder->GetILGenerator();
   ilGenerator->EmitWriteLine( "MyType instantiated!" );
   ilGenerator->Emit( OpCodes::Ret );
   typeBuilder->CreateType();
   assemblyBuilder->Save( "temp.dll" );
}

ref class Resolver
{
public:
   static Assembly^ MyResolver( Object^ sender, ResolveEventArgs^ args )
   {
      AppDomain^ domain = dynamic_cast<AppDomain^>(sender);
      
      // Once the files are generated, this call is
      // actually no longer necessary.
      EmitAssembly( domain );
      array<Byte>^rawAssembly = loadFile( "temp.dll" );
      array<Byte>^rawSymbolStore = loadFile( "temp.pdb" );
      Assembly^ assembly = domain->Load( rawAssembly, rawSymbolStore );
      return assembly;
   }

};

int main()
{
   AppDomain^ currentDomain = AppDomain::CurrentDomain;
   InstantiateMyType( currentDomain ); // Failed!
   currentDomain->AssemblyResolve += gcnew ResolveEventHandler( Resolver::MyResolver );
   InstantiateMyType( currentDomain ); // OK!
}

// </Snippet1>
