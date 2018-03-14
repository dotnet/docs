
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Threading;
using namespace System::Text;
using namespace System::Resources;
using namespace System::Collections;
using namespace System::IO;

// Helper class called when a resolve type event is raised.
ref class TypeResolveHandler
{
private:
   Module^ m_Module;

public:
   TypeResolveHandler( Module^ mod )
   {
      m_Module = mod;
   }

   Assembly^ ResolveEvent( Object^ sender, ResolveEventArgs^ args );
};

ref class NestedEnum
{
internal:
   static TypeBuilder^ enumType = nullptr;
   static Type^ tNested = nullptr;
   static Type^ tNesting = nullptr;

public:
   static void Main()
   {
      AssemblyName^ asmName = gcnew AssemblyName;
      asmName->Name = "NestedEnum";
      AssemblyBuilder^ asmBuild = Thread::GetDomain()->DefineDynamicAssembly( asmName, AssemblyBuilderAccess::RunAndSave );
      ModuleBuilder^ modBuild = asmBuild->DefineDynamicModule( "ModuleOne", "NestedEnum.dll" );
      
      // Hook up the event listening.
      TypeResolveHandler^ typeResolveHandler = gcnew TypeResolveHandler( modBuild );
      
      // Add a listener for the type resolve events.
      AppDomain^ currentDomain = Thread::GetDomain();
      ResolveEventHandler^ resolveHandler = gcnew ResolveEventHandler( typeResolveHandler, &TypeResolveHandler::ResolveEvent );
      currentDomain->TypeResolve += resolveHandler;
      TypeBuilder^ tb = modBuild->DefineType( "AType", TypeAttributes::Public );
      TypeBuilder^ eb = tb->DefineNestedType( "AnEnum", static_cast<TypeAttributes>(TypeAttributes::NestedPublic | TypeAttributes::Sealed), Enum::typeid, 0 );
      eb->DefineField( "value__", int::typeid, static_cast<FieldAttributes>(FieldAttributes::Private | FieldAttributes::SpecialName) );
      FieldBuilder^ fb = eb->DefineField( "Field1", eb, static_cast<FieldAttributes>(FieldAttributes::Public | FieldAttributes::Literal | FieldAttributes::Static) );
      fb->SetConstant( 1 );
      enumType = eb;
      
      // Comment out this field.
      // When this field is defined, the loader cannot determine the size
      // of the type. Therefore, a TypeResolve event is generated when the
      // nested type is completed.
      tb->DefineField( "Field2", eb, FieldAttributes::Public );
      tNesting = tb->CreateType();
      if ( tNesting == nullptr )
            Console::WriteLine( "NestingType CreateType failed but didn't throw!" );

      try
      {
         tNested = eb->CreateType();
         if ( tNested == nullptr )
                  Console::WriteLine( "NestedType CreateType failed but didn't throw!" );
      }
      catch ( Exception^ ) 
      {
         
         // This is needed because you might have already completed the type in the TypeResolve event.
      }

      if ( tNested != nullptr )
      {
         Type^ x = tNested->DeclaringType;
         if ( x == nullptr )
                  Console::WriteLine( "Declaring type is null." );
         else
                  Console::WriteLine( x->Name );
      }

      asmBuild->Save( "NestedEnum.dll" );
      
      // Remove the listener for the type resolve events.
      currentDomain->TypeResolve -= resolveHandler;
   }

};

Assembly^ TypeResolveHandler::ResolveEvent( Object^ sender, ResolveEventArgs^ args )
{
   Console::WriteLine( args->Name );
   
   // Use args.Name to look up the type name. In this case, you are getting AnEnum.
   try
   {
      NestedEnum::tNested = NestedEnum::enumType->CreateType();
   }
   catch ( Exception^ ) 
   {
      
      // This is needed to throw away InvalidOperationException.
      // Loader might send the TypeResolve event more than once
      // and the type might be complete already.
   }

   
   // Complete the type.
   return m_Module->Assembly;
}

int main()
{
   NestedEnum::Main();
}

// </Snippet1>
