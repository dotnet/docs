// System.Reflection.Emit.ModuleBuilder.DefinePInvokeMethod(String,String,MethodAttributes,
//                  CallingConventions,Type,Type[],CallingConvention,CharSet)
/*
   The following example demonstrates that DefinePInvokeMethod doesn't work unless you 
   add a DLLImportAttribute...which you can do just as well with DefineGlobalMethod.

*/
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Runtime::InteropServices;

const int MB_RETRYCANCEL = 5;

void main()
{
   AssemblyName^ myAssemblyName = gcnew AssemblyName("TempAssembly");

   // Define a dynamic assembly in the current application domain.
   AssemblyBuilder^ myAssemblyBuilder = 
      AppDomain::CurrentDomain->DefineDynamicAssembly(
                  myAssemblyName, AssemblyBuilderAccess::Run);

   // Define a dynamic module in "TempAssembly" assembly.
   ModuleBuilder^ myModuleBuilder = 
      myAssemblyBuilder->DefineDynamicModule("TempModule");

   array<Type^>^ paramTypes = 
      { int::typeid, String::typeid, String::typeid, int::typeid };

   // Define a PInvoke method.
   MethodBuilder^ piMethodBuilder = myModuleBuilder->DefinePInvokeMethod(
      "MessageBoxA",
      "user32.dll",
      MethodAttributes::Public | MethodAttributes::Static | MethodAttributes::PinvokeImpl,
      CallingConventions::Standard,
      int::typeid,
      paramTypes,
      CallingConvention::Winapi,
      CharSet::Ansi);

   // Add PreserveSig to the method implementation flags. NOTE: If this line
   // is commented out, the return value will be zero when the method is
   // invoked.
   piMethodBuilder->SetImplementationFlags(
      piMethodBuilder->GetMethodImplementationFlags() | MethodImplAttributes::PreserveSig);

   // Create global methods.
   myModuleBuilder->CreateGlobalFunctions();

   // Arguments for calling the method.
   array<Object^>^ arguments = 
      { (Object^)(int) 0, "Hello World", "Title", MB_RETRYCANCEL };

   MethodInfo^ pinvokeMethod = myModuleBuilder->GetMethod("MessageBoxA");
   Console::WriteLine("Testing module-level PInvoke method created with DefinePInvokeMethod...");
   Console::WriteLine("Message box returned: {0}", 
      pinvokeMethod->Invoke(nullptr, arguments));
};


/* This code example produces input similar to the following:

Testing module-level PInvoke method created with DefinePInvokeMethod...
Message box returned: 4
 */
// </Snippet1>
