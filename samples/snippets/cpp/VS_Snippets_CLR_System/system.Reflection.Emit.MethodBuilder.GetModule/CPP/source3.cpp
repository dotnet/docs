
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
class MoreMethodBuilderSnippets
{
public:
   static void ContainerMethod( AssemblyBuilder^ myAsmBuilder )
   {
      
      // <Snippet1>
      ModuleBuilder^ myModBuilder = myAsmBuilder->DefineDynamicModule( "MathFunctions" );
      TypeBuilder^ myTypeBuilder = myModBuilder->DefineType( "MyMathFunctions", TypeAttributes::Public );
      array<Type^>^temp0 = {int::typeid,int::typeid};
      MethodBuilder^ myMthdBuilder = myTypeBuilder->DefineMethod( "Adder", MethodAttributes::Public, int::typeid, temp0 );
      
      // Create body via ILGenerator here ...
      Type^ myNewType = myTypeBuilder->CreateType();
      Module^ myModule = myMthdBuilder->GetModule();
      array<Type^>^myModTypes = myModule->GetTypes();
      Console::WriteLine( "Module: {0}", myModule->Name );
      Console::WriteLine( "------- with path {0}", myModule->FullyQualifiedName );
      Console::WriteLine( "------- in assembly {0}", myModule->Assembly->FullName );
      System::Collections::IEnumerator^ myEnum = myModTypes->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Type^ myModType = safe_cast<Type^>(myEnum->Current);
         Console::WriteLine( "------- has type {0}", myModType->FullName );
      }
   }

};

// </Snippet1>
