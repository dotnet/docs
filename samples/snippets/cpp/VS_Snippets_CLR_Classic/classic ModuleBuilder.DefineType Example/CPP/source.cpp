using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

public ref class Sample
{
public:
   void Method()
   {
      // <Snippet1>
      AssemblyName^ asmname = gcnew AssemblyName;
      asmname->Name = "assemfilename.exe";
      AssemblyBuilder^ asmbuild = System::Threading::Thread::GetDomain()->
         DefineDynamicAssembly( asmname, AssemblyBuilderAccess::RunAndSave );
      ModuleBuilder^ modbuild = asmbuild->DefineDynamicModule( "modulename",
         "assemfilename.exe" );
      TypeBuilder^ typebuild1 = modbuild->DefineType( "typename" );
      typebuild1->CreateType();
      asmbuild->Save( "assemfilename.exe" );
      // </Snippet1>
   }
};
