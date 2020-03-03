
// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Runtime::Remoting;

ref class ADDyno
{
public:
   static Type^ CreateADynamicAssembly( interior_ptr<AppDomain^> myNewDomain, String^ executableNameNoExe )
   {
      String^ executableName = String::Concat( executableNameNoExe, ".exe" );
      AssemblyName^ myAsmName = gcnew AssemblyName;
      myAsmName->Name = executableNameNoExe;
      myAsmName->CodeBase = Environment::CurrentDirectory;
      AssemblyBuilder^ myAsmBuilder = ( *myNewDomain)->DefineDynamicAssembly( myAsmName, AssemblyBuilderAccess::RunAndSave );
      Console::WriteLine( "-- Dynamic Assembly instantiated." );
      ModuleBuilder^ myModBuilder = myAsmBuilder->DefineDynamicModule( executableNameNoExe, executableName );
      TypeBuilder^ myTypeBuilder = myModBuilder->DefineType( executableNameNoExe, TypeAttributes::Public, MarshalByRefObject::typeid );
      array<Type^>^temp0 = nullptr;
      MethodBuilder^ myFCMethod = myTypeBuilder->DefineMethod( "CountLocalFiles", static_cast<MethodAttributes>(MethodAttributes::Public | MethodAttributes::Static), nullptr, temp0 );
      MethodInfo^ currentDirGetMI = Environment::typeid->GetProperty( "CurrentDirectory" )->GetGetMethod();
      array<Type^>^temp1 = {String::typeid};
      MethodInfo^ writeLine0objMI = Console::typeid->GetMethod( "WriteLine", temp1 );
      array<Type^>^temp2 = {String::typeid,Object::typeid,Object::typeid};
      MethodInfo^ writeLine2objMI = Console::typeid->GetMethod( "WriteLine", temp2 );
      array<Type^>^temp3 = {String::typeid};
      MethodInfo^ getFilesMI = Directory::typeid->GetMethod( "GetFiles", temp3 );
      myFCMethod->InitLocals = true;
      ILGenerator^ myFCIL = myFCMethod->GetILGenerator();
      Console::WriteLine( "-- Generating MSIL method body..." );
      LocalBuilder^ v0 = myFCIL->DeclareLocal( String::typeid );
      LocalBuilder^ v1 = myFCIL->DeclareLocal( int::typeid );
      LocalBuilder^ v2 = myFCIL->DeclareLocal( String::typeid );
      LocalBuilder^ v3 = myFCIL->DeclareLocal( array<String^>::typeid );
      Label evalForEachLabel = myFCIL->DefineLabel();
      Label topOfForEachLabel = myFCIL->DefineLabel();

      // Build the method body.
      myFCIL->EmitCall( OpCodes::Call, currentDirGetMI, nullptr );
      myFCIL->Emit( OpCodes::Stloc_S, v0 );
      myFCIL->Emit( OpCodes::Ldc_I4_0 );
      myFCIL->Emit( OpCodes::Stloc_S, v1 );
      myFCIL->Emit( OpCodes::Ldstr, "---" );
      myFCIL->EmitCall( OpCodes::Call, writeLine0objMI, nullptr );
      myFCIL->Emit( OpCodes::Ldloc_S, v0 );
      myFCIL->EmitCall( OpCodes::Call, getFilesMI, nullptr );
      myFCIL->Emit( OpCodes::Stloc_S, v3 );
      myFCIL->Emit( OpCodes::Br_S, evalForEachLabel );

      // foreach loop starts here.
      myFCIL->MarkLabel( topOfForEachLabel );

      // Load array of strings and index, store value at index for output.
      myFCIL->Emit( OpCodes::Ldloc_S, v3 );
      myFCIL->Emit( OpCodes::Ldloc_S, v1 );
      myFCIL->Emit( OpCodes::Ldelem_Ref );
      myFCIL->Emit( OpCodes::Stloc_S, v2 );
      myFCIL->Emit( OpCodes::Ldloc_S, v2 );
      myFCIL->EmitCall( OpCodes::Call, writeLine0objMI, nullptr );

      // Increment counter by one.
      myFCIL->Emit( OpCodes::Ldloc_S, v1 );
      myFCIL->Emit( OpCodes::Ldc_I4_1 );
      myFCIL->Emit( OpCodes::Add );
      myFCIL->Emit( OpCodes::Stloc_S, v1 );

      // Determine if end of file list array has been reached.
      myFCIL->MarkLabel( evalForEachLabel );
      myFCIL->Emit( OpCodes::Ldloc_S, v1 );
      myFCIL->Emit( OpCodes::Ldloc_S, v3 );
      myFCIL->Emit( OpCodes::Ldlen );
      myFCIL->Emit( OpCodes::Conv_I4 );
      myFCIL->Emit( OpCodes::Blt_S, topOfForEachLabel );

      //foreach loop end here.
      myFCIL->Emit( OpCodes::Ldstr, "---" );
      myFCIL->EmitCall( OpCodes::Call, writeLine0objMI, nullptr );
      myFCIL->Emit( OpCodes::Ldstr, "There are {0} files in {1}." );
      myFCIL->Emit( OpCodes::Ldloc_S, v1 );
      myFCIL->Emit( OpCodes::Box, int::typeid );
      myFCIL->Emit( OpCodes::Ldloc_S, v0 );
      myFCIL->EmitCall( OpCodes::Call, writeLine2objMI, nullptr );
      myFCIL->Emit( OpCodes::Ret );
      Type^ myType = myTypeBuilder->CreateType();
      myAsmBuilder->SetEntryPoint( myFCMethod );
      myAsmBuilder->Save( executableName );
      Console::WriteLine( "-- Method generated, type completed, and assembly saved to disk." );
      return myType;
   }
};

int main()
{
   String^ domainDir;
   String^ executableName = nullptr;
   Console::Write( "Enter a name for the file counting assembly: " );
   String^ executableNameNoExe = Console::ReadLine();
   executableName = String::Concat( executableNameNoExe, ".exe" );
   Console::WriteLine( "---" );
   domainDir = Environment::CurrentDirectory;
   AppDomain^ curDomain = Thread::GetDomain();

   // Create a new AppDomain, with the current directory as the base.
   Console::WriteLine( "Current Directory: {0}", Environment::CurrentDirectory );
   AppDomainSetup^ mySetupInfo = gcnew AppDomainSetup;
   mySetupInfo->ApplicationBase = domainDir;
   mySetupInfo->ApplicationName = executableNameNoExe;
   mySetupInfo->LoaderOptimization = LoaderOptimization::SingleDomain;
   AppDomain^ myDomain = AppDomain::CreateDomain( executableNameNoExe, nullptr, mySetupInfo );
   Console::WriteLine( "Creating a new AppDomain '{0}'...", executableNameNoExe );
   Console::WriteLine( "-- Base Directory = '{0}'", myDomain->BaseDirectory );
   Console::WriteLine( "-- Shadow Copy? = '{0}'", myDomain->ShadowCopyFiles );
   Console::WriteLine( "---" );
   Type^ myFCType = ADDyno::CreateADynamicAssembly(  &curDomain, executableNameNoExe );
   Console::WriteLine( "Loading '{0}' from '{1}'...", executableName, myDomain->BaseDirectory );
   BindingFlags bFlags = static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::CreateInstance | BindingFlags::Instance);
   Object^ myObjInstance = myDomain->CreateInstanceAndUnwrap( executableNameNoExe, executableNameNoExe, false, bFlags, nullptr, nullptr, nullptr, nullptr, nullptr );
   Console::WriteLine( "Executing method 'CountLocalFiles' in {0}...", myObjInstance );
   array<Object^>^temp4 = nullptr;
   myFCType->InvokeMember( "CountLocalFiles", BindingFlags::InvokeMethod, nullptr, myObjInstance, temp4 );
}
// </Snippet1>
