using namespace System;
using namespace System::Collections;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

public ref class MyEnumBuilderSample
{
private:
   static AssemblyBuilder^ myAssemblyBuilder;
   static ModuleBuilder^ myModuleBuilder;
   static EnumBuilder^ myEnumBuilder;

public:
   static void Main()
   {
      try
      {
         CreateCallee( Thread::GetDomain(), AssemblyBuilderAccess::Save );
         array<Type^>^myTypeArray = myModuleBuilder->GetTypes();
         IEnumerator^ myEnum = myTypeArray->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Type^ myType = safe_cast<Type^>(myEnum->Current);
            Console::WriteLine( "Enum Builder defined in the module builder is: {0}", myType->Name );
         }
         Console::WriteLine( "Properties of EnumBuilder : " );
         Console::WriteLine( "Enum Assembly is :{0}", myEnumBuilder->Assembly );
         Console::WriteLine( "Enum AssemblyQualifiedName is :{0}", myEnumBuilder->AssemblyQualifiedName );
         Console::WriteLine( "Enum Module is :{0}", myEnumBuilder->Module );
         Console::WriteLine( "Enum Name is :{0}", myEnumBuilder->Name );
         Console::WriteLine( "Enum NameSpace is :{0}", myEnumBuilder->Namespace );
         myAssemblyBuilder->Save( "EmittedAssembly.dll" );
      }
      catch ( NotSupportedException^ ex ) 
      {
         Console::WriteLine( "The following is the exception is raised: {0}", ex->Message );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "The following is the exception raised: {0}", e->Message );
      }
   }

private:
   static void CreateCallee( AppDomain^ myAppDomain, AssemblyBuilderAccess /*access*/ )
   {
      // Create a name for the assembly.
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "EmittedAssembly";

      // Create the dynamic assembly.
      myAssemblyBuilder = myAppDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Save );

      // Create a dynamic module.
      myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "EmittedModule", "EmittedModule.mod" );

      // Create a dynamic Enum.
      myEnumBuilder = myModuleBuilder->DefineEnum( "MyNamespace.MyEnum", TypeAttributes::Public, Int32::typeid );
      FieldBuilder^ myFieldBuilder1 = myEnumBuilder->DefineLiteral( "FieldOne", 1 );
      FieldBuilder^ myFieldBuilder2 = myEnumBuilder->DefineLiteral( "FieldTwo", 2 );
      myEnumBuilder->CreateType();
   }
};

int main()
{
   MyEnumBuilderSample::Main();
}