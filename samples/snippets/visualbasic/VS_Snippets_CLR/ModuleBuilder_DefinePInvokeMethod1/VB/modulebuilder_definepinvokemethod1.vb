' System.Reflection.Emit.ModuleBuilder.DefinePInvokeMethod(String,String,MethodAttributes,
'                  CallingConventions,Type,Type(),CallingConvention,CharSet)
'
'   The following example demonstrates that DefinePInvokeMethod doesn't work unless you 
'   add a DLLImportAttribute...which you can do just as well with DefineGlobalMethod.
'
'
' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices

Namespace PInvoke

   Public Class Example
   
      Const MB_RETRYCANCEL As Integer = 5

      Shared Sub Main()
      
         Dim myAssemblyName As New AssemblyName("TempAssembly")

         ' Define a dynamic assembly in the current application domain.
         Dim myAssemblyBuilder As AssemblyBuilder = _
            AppDomain.CurrentDomain.DefineDynamicAssembly( _
                        myAssemblyName, AssemblyBuilderAccess.Run)

         ' Define a dynamic module in "TempAssembly" assembly.
         Dim myModuleBuilder As ModuleBuilder = _
            myAssemblyBuilder.DefineDynamicModule("TempModule")

         Dim paramTypes() As Type = _
            { GetType(Integer), GetType(string), GetType(string), GetType(Integer) }

         ' Define a PInvoke method.
         Dim piMethodBuilder As MethodBuilder = myModuleBuilder.DefinePInvokeMethod( _
            "MessageBoxA", _
            "user32.dll", _
            MethodAttributes.Public Or MethodAttributes.Static Or MethodAttributes.PinvokeImpl, _
            CallingConventions.Standard, _
            GetType(Integer), _
            paramTypes, _
            CallingConvention.Winapi, _
            CharSet.Ansi)
         
         ' Add PreserveSig to the method implementation flags. NOTE: If this line
         ' is commented out, the return value will be zero when the method is
         ' invoked.
         piMethodBuilder.SetImplementationFlags( _
            piMethodBuilder.GetMethodImplementationFlags() Or MethodImplAttributes.PreserveSig)

         ' Create global methods.
         myModuleBuilder.CreateGlobalFunctions()

         ' Arguments for calling the method.
         Dim arguments() As Object= { 0, "Hello World", "Title", MB_RETRYCANCEL }

         Dim pinvokeMethod As MethodInfo = _
            myModuleBuilder.GetMethod("MessageBoxA")
         Console.WriteLine("Testing module-level PInvoke method created with DefinePInvokeMethod...")
         Console.WriteLine("Message box returned: {0}", _
            pinvokeMethod.Invoke(Nothing, arguments))

      End Sub
   End Class
End Namespace

' This code example produces input similar to the following:
'
'Testing module-level PInvoke method created with DefinePInvokeMethod...
'Message box returned: 4
' </Snippet1>
