using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

class TypeBuilderMemberDemo
{
public:
   static void DefineDynamicModuleDemo1()
   {
      // <Snippet1>
      AppDomain^ myAppDomain = Thread::GetDomain();
      AssemblyName^ myAsmName = gcnew AssemblyName;
      myAsmName->Name = "MyAssembly";
      AssemblyBuilder^ myAsmBuilder = myAppDomain->DefineDynamicAssembly(
         myAsmName, AssemblyBuilderAccess::Run );
      
      // Create a transient dynamic module. Since no DLL name is specified with
      // this constructor, it cannot be saved.
      ModuleBuilder^ myModuleBuilder = myAsmBuilder->DefineDynamicModule( "MyModule1" );
      // </Snippet1>
   }

   static void DefineDynamicModuleDemo2()
   {
      // <Snippet2>
      AppDomain^ myAppDomain = Thread::GetDomain();
      AssemblyName^ myAsmName = gcnew AssemblyName;
      myAsmName->Name = "MyAssembly";
      AssemblyBuilder^ myAsmBuilder = myAppDomain->DefineDynamicAssembly(
         myAsmName, AssemblyBuilderAccess::Run );
      
      // Create a transient dynamic module. Since no DLL name is specified with
      // this constructor, it can not be saved. By specifying the second parameter
      // of the constructor as false, we can suppress the emission of symbol info.
      ModuleBuilder^ myModuleBuilder = myAsmBuilder->DefineDynamicModule(
         "MyModule2", false );
      // </Snippet2>
   }

   static void DefineDynamicModuleDemo3()
   {
      // <Snippet3>
      AppDomain^ myAppDomain = Thread::GetDomain();
      AssemblyName^ myAsmName = gcnew AssemblyName;
      myAsmName->Name = "MyAssembly";
      AssemblyBuilder^ myAsmBuilder = myAppDomain->DefineDynamicAssembly(
         myAsmName, AssemblyBuilderAccess::Run );
      
      // Create a dynamic module that can be saved as the specified DLL name.
      ModuleBuilder^ myModuleBuilder = myAsmBuilder->DefineDynamicModule(
         "MyModule3", "MyModule3.dll" );
      // </Snippet3>
   }

   static void DefineDynamicModuleDemo4()
   {
      // <Snippet4>
      AppDomain^ myAppDomain = Thread::GetDomain();
      AssemblyName^ myAsmName = gcnew AssemblyName;
      myAsmName->Name = "MyAssembly";
      AssemblyBuilder^ myAsmBuilder = myAppDomain->DefineDynamicAssembly(
         myAsmName, AssemblyBuilderAccess::Run );
      
      // Create a dynamic module that can be saved as the specified DLL name. By
      // specifying the third parameter as true, we can allow the emission of symbol info.
      ModuleBuilder^ myModuleBuilder = myAsmBuilder->DefineDynamicModule(
         "MyModule4", "MyModule4.dll", true );
      // </Snippet4>
   }
};
