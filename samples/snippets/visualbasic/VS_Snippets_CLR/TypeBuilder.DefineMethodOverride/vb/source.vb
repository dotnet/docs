'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

Public Interface I
    Sub M() 
End Interface

Public Class A
    Public Overridable Sub M() 
        Console.WriteLine("In method A.M")
    End Sub
End Class

' The object of this code example is to emit code equivalent to
' the following C# code:
'
Public Class C
    Inherits A
    Implements I
    
    Public Overrides Sub M() 
        Console.WriteLine("Overriding A.M from C.M")
    End Sub
    
    ' In order to provide a different implementation from C.M when 
    ' emitting the following explicit interface implementation, 
    ' it is necessary to use a MethodImpl.
    '
    Private Sub IM() Implements I.M
        Console.WriteLine("The I.M implementation of C")
    End Sub
End Class

Class Test
    
    Shared Sub Main() 

        Dim name As String = "DefineMethodOverrideExample"
        Dim asmName As New AssemblyName(name)
        Dim ab As AssemblyBuilder = _
            AppDomain.CurrentDomain.DefineDynamicAssembly( _
                asmName, AssemblyBuilderAccess.RunAndSave)
        Dim mb As ModuleBuilder = _
            ab.DefineDynamicModule(name, name & ".dll")
        
        Dim tb As TypeBuilder = _
            mb.DefineType("C", TypeAttributes.Public, GetType(A))
        tb.AddInterfaceImplementation(GetType(I))
        
        ' Build the method body for the explicit interface 
        ' implementation. The name used for the method body 
        ' can be anything. Here, it is the name of the method,
        ' qualified by the interface name.
        '
        Dim mbIM As MethodBuilder = _
            tb.DefineMethod("I.M", _
            MethodAttributes.Private Or MethodAttributes.HideBySig Or _
                MethodAttributes.NewSlot Or MethodAttributes.Virtual Or _
                MethodAttributes.Final, _
            Nothing, _
            Type.EmptyTypes)
        Dim il As ILGenerator = mbIM.GetILGenerator()
        il.Emit(OpCodes.Ldstr, "The I.M implementation of C")
        il.Emit(OpCodes.Call, GetType(Console).GetMethod("WriteLine", _
            New Type() {GetType(String)}))
        il.Emit(OpCodes.Ret)
        
        ' DefineMethodOverride is used to associate the method 
        ' body with the interface method that is being implemented.
        '
        tb.DefineMethodOverride(mbIM, GetType(I).GetMethod("M"))
        
        Dim mbM As MethodBuilder = tb.DefineMethod("M", _
            MethodAttributes.Public Or MethodAttributes.ReuseSlot Or _
                MethodAttributes.Virtual Or MethodAttributes.HideBySig, _
            Nothing, _
            Type.EmptyTypes)
        il = mbM.GetILGenerator()
        il.Emit(OpCodes.Ldstr, "Overriding A.M from C.M")
        il.Emit(OpCodes.Call, GetType(Console).GetMethod("WriteLine", _
            New Type() {GetType(String)}))
        il.Emit(OpCodes.Ret)
        
        Dim tc As Type = tb.CreateType()
        
        ' Save the emitted assembly, to examine with Ildasm.exe.
        ab.Save(name & ".dll")
        
        Dim test As Object = Activator.CreateInstance(tc)
        
        Dim mi As MethodInfo = GetType(I).GetMethod("M")
        mi.Invoke(test, Nothing)
        
        mi = GetType(A).GetMethod("M")
        mi.Invoke(test, Nothing)
    
    End Sub
End Class

' This code example produces the following output:
'
'The I.M implementation of C
'Overriding A.M from C.M
' 
'</Snippet1>