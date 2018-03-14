// System.Reflection.Emit.ModuleBuilder.DefinePInvokeMethod(String,String,MethodAttributes,
//                  CallingConventions,Type,Type[],CallingConvention,CharSet)
/*
   The following example demonstrates that DefinePInvokeMethod doesn't work (that is,
   you don't get the return value) unless you add PreserveSig.

*/
// <Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace PInvoke
{
   public class Example
   {
      const int MB_RETRYCANCEL = 5;

      static void Main()
      {
         AssemblyName myAssemblyName = new AssemblyName("TempAssembly");

         // Define a dynamic assembly in the current application domain.
         AssemblyBuilder myAssemblyBuilder = 
            AppDomain.CurrentDomain.DefineDynamicAssembly(
                        myAssemblyName, AssemblyBuilderAccess.Run);

         // Define a dynamic module in "TempAssembly" assembly.
         ModuleBuilder myModuleBuilder = 
            myAssemblyBuilder.DefineDynamicModule("TempModule");

         Type[] paramTypes = { typeof(int), typeof(string), typeof(string), typeof(int) };

         // Define a PInvoke method.
         MethodBuilder piMethodBuilder = myModuleBuilder.DefinePInvokeMethod(
            "MessageBoxA",
            "user32.dll",
            MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.PinvokeImpl,
            CallingConventions.Standard,
            typeof(int),
            paramTypes,
            CallingConvention.Winapi,
            CharSet.Ansi);
         
         // Add PreserveSig to the method implementation flags. NOTE: If this line
         // is commented out, the return value will be zero when the method is
         // invoked.
         piMethodBuilder.SetImplementationFlags(
            piMethodBuilder.GetMethodImplementationFlags() | MethodImplAttributes.PreserveSig);

         // Create global methods.
         myModuleBuilder.CreateGlobalFunctions();

         // Arguments for calling the method.
         Object[] arguments = { 0, "Hello World", "Title", MB_RETRYCANCEL };

         MethodInfo pinvokeMethod = myModuleBuilder.GetMethod("MessageBoxA");
         Console.WriteLine("Testing module-level PInvoke method created with DefinePInvokeMethod...");
         Console.WriteLine("Message box returned: {0}", 
            pinvokeMethod.Invoke(null, arguments));
      }
   }
}

/* This code example produces input similar to the following:

Testing module-level PInvoke method created with DefinePInvokeMethod...
Message box returned: 4
 */
// </Snippet1>
