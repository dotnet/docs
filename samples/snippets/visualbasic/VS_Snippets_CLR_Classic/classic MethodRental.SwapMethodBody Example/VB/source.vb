' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices

Class SwapMethodBodySample
    
    ' First make a method that returns 0.
    ' Then swap the method body with a body that returns 1.
    Public Shared Sub Main()
        ' Construct a dynamic assembly
        Dim g As Guid = Guid.NewGuid()
        Dim asmname As New AssemblyName()
        asmname.Name = "tempfile" + g.ToString()
        Dim asmbuild As AssemblyBuilder = _
           System.Threading.Thread.GetDomain().DefineDynamicAssembly _
           (asmname, AssemblyBuilderAccess.Run)
        
        ' Add a dynamic module that contains one type that has one method that
        ' has no arguments.
        Dim modbuild As ModuleBuilder = asmbuild.DefineDynamicModule("test")
        Dim tb As TypeBuilder = modbuild.DefineType("name of the Type")
        Dim somemethod As MethodBuilder = _
           tb.DefineMethod("My method Name", _
           MethodAttributes.Public Or(MethodAttributes.Static), _
           GetType(Integer), New Type() {})
        ' Define the body of the method to return 0.
        Dim ilg As ILGenerator = somemethod.GetILGenerator()
        ilg.Emit(OpCodes.Ldc_I4_0)
        ilg.Emit(OpCodes.Ret)
        
        ' Complete the type and verify that it returns 0.
        Dim tbBaked As Type = tb.CreateType()
        Dim res1 As Integer = _
           CInt(tbBaked.GetMethod("My method Name").Invoke _
           (Nothing, New Object() {}))
        If res1 <> 0 Then
            Console.WriteLine("Err_001a, should have returned 0")
        Else
            Console.WriteLine("Original method returned 0")
        End If
        
        ' Define a new method body that will return a 1 instead.
        Dim methodBytes As Byte() = _
        {&H3, &H30, &HA, &H0, &H2, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H17, &H2A}
        '&H2     code size
        '&H17    ldc_i4_1
        '&H2A    ret
        
        ' Get the token for the method whose body you are replacing.
        Dim somemethodToken As MethodToken = somemethod.GetToken()
        
        ' Get the pointer to the method body.
        Dim hmem As GCHandle = _
           GCHandle.Alloc(CType(methodBytes, Object), GCHandleType.Pinned)
        Dim addr As IntPtr = hmem.AddrOfPinnedObject()
        Dim cbSize As Integer = methodBytes.Length
        
        ' Swap the old method body with the new body.
        MethodRental.SwapMethodBody(tbBaked, somemethodToken.Token, addr, _
           cbSize, MethodRental.JitImmediate)
        
        ' Verify that the modified method returns 1.
        Dim res2 As Integer = _
           CInt(tbBaked.GetMethod("My method Name").Invoke _
           (Nothing, New Object() {}))
        If res2 <> 1 Then
            Console.WriteLine("Err_001b, should have returned 1")
        Else
            Console.WriteLine("Swapped method body returned 1")
        End If
    End Sub
End Class
' </Snippet1>
