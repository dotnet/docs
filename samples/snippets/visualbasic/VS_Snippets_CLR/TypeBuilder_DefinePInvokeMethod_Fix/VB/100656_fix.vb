'<Snippet1>
Imports System
Imports System.Text
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices

Public Class Example
    
    Public Shared Sub Main() 
        
        ' Create the AssemblyBuilder.
        Dim asmName As New AssemblyName("PInvokeTest")
        Dim dynamicAsm As AssemblyBuilder = _
            AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, _
                AssemblyBuilderAccess.RunAndSave)
        
        ' Create the module.
        Dim dynamicMod As ModuleBuilder = _
            dynamicAsm.DefineDynamicModule(asmName.Name, asmName.Name & ".dll")
        
        ' Create the TypeBuilder for the class that will contain the 
        ' signature for the PInvoke call.
        Dim tb As TypeBuilder = dynamicMod.DefineType("MyType", _
            TypeAttributes.Public Or TypeAttributes.UnicodeClass)
        
        Dim mb As MethodBuilder = tb.DefinePInvokeMethod( _
            "GetTickCount", _
            "Kernel32.dll", _
            MethodAttributes.Public Or MethodAttributes.Static Or MethodAttributes.PinvokeImpl, _
            CallingConventions.Standard, _
            GetType(Integer), _
            Type.EmptyTypes, _
            CallingConvention.Winapi, _
            CharSet.Ansi)

        ' Add PreserveSig to the method implementation flags. NOTE: If this line
        ' is commented out, the return value will be zero when the method is
        ' invoked.
        mb.SetImplementationFlags( _
            mb.GetMethodImplementationFlags() Or MethodImplAttributes.PreserveSig)
        
        ' The PInvoke method does not have a method body.
        
        ' Create the class and test the method.
        Dim t As Type = tb.CreateType()

        Dim mi As MethodInfo = t.GetMethod("GetTickCount")
        Console.WriteLine("Testing PInvoke method...")
        Console.WriteLine("GetTickCount returned: {0}", mi.Invoke(Nothing, Nothing))

        ' Produce the .dll file.
        Console.WriteLine("Saving: " & asmName.Name & ".dll")
        dynamicAsm.Save(asmName.Name & ".dll")
    
    End Sub  
End Class 

' This example produces output similar to the following:
'
'Testing PInvoke method...
'GetTickCount returned: 1313078714
'Saving: PInvokeTest.dll
'</Snippet1>