
// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
ref class AsmBuilderGetFileDemo
{
public:
   static String^ myResourceFileName = "MyResource.txt";
   static FileInfo^ CreateResourceFile()
   {
      FileInfo^ f = gcnew FileInfo( myResourceFileName );
      StreamWriter^ sw = f->CreateText();
      sw->WriteLine( "Hello, world!" );
      sw->Close();
      return f;
   }

   static AssemblyBuilder^ BuildDynAssembly()
   {
      String^ myAsmFileName = "MyAsm.dll";
      AppDomain^ myDomain = Thread::GetDomain();
      AssemblyName^ myAsmName = gcnew AssemblyName;
      myAsmName->Name = "MyDynamicAssembly";
      AssemblyBuilder^ myAsmBuilder = myDomain->DefineDynamicAssembly( myAsmName, AssemblyBuilderAccess::RunAndSave );
      myAsmBuilder->AddResourceFile( "MyResource", myResourceFileName );
      
      // To confirm that the resource file has been added to the manifest,
      // we will save the assembly as MyAsm.dll. You can view the manifest
      // and confirm the presence of the resource file by running
      // "ildasm MyAsm.dll" from the prompt in the directory where you executed
      // the compiled code.
      myAsmBuilder->Save( myAsmFileName );
      return myAsmBuilder;
   }

};

int main()
{
   FileStream^ myResourceFS = nullptr;
   AsmBuilderGetFileDemo::CreateResourceFile();
   Console::WriteLine( "The contents of MyResource.txt, via GetFile:" );
   AssemblyBuilder^ myAsm = AsmBuilderGetFileDemo::BuildDynAssembly();
   try
   {
      myResourceFS = myAsm->GetFile( AsmBuilderGetFileDemo::myResourceFileName );
   }
   catch ( NotSupportedException^ ) 
   {
      Console::WriteLine( "---" );
      Console::WriteLine( "System::Reflection::Emit::AssemblyBuilder::GetFile\nis not supported in this SDK build." );
      Console::WriteLine( "The file data will now be retrieved directly, via a new FileStream." );
      Console::WriteLine( "---" );
      myResourceFS = gcnew FileStream( AsmBuilderGetFileDemo::myResourceFileName,FileMode::Open );
   }

   StreamReader^ sr = gcnew StreamReader( myResourceFS,System::Text::Encoding::ASCII );
   Console::WriteLine( sr->ReadToEnd() );
   sr->Close();
}

// </Snippet1>
