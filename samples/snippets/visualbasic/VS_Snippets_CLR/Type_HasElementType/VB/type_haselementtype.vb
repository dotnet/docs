' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

Public Class Example

    ' This method is for demonstration purposes.
    Public Shared Sub Test(ByRef x As Integer, <Out> ByRef y As Integer)
    End Sub

    Public Shared Sub Main()
        ' All of the following display 'True'.

        ' Define an array, get its type, and display HasElementType. 
        Dim nums() As Integer = {1, 1, 2, 3, 5, 8, 13}
        Dim t As Type = nums.GetType()
        Console.WriteLine("HasElementType is '{0}' for array types.", t.HasElementType)

        ' Test an array type without defining an array.
        t = GetType(Example())
        Console.WriteLine("HasElementType is '{0}' for array types.", t.HasElementType)

        ' When you use Reflection Emit to emit dynamic methods and
        ' assemblies, you can create array types using MakeArrayType.
        ' The following creates the type 'array of Example'.
        t = GetType(Example).MakeArrayType()
        Console.WriteLine("HasElementType is '{0}' for array types.", t.HasElementType)

        ' When you reflect over methods, HasElementType is true for
        ' ref, out, and pointer parameter types. The following 
        ' gets the Test method, defined above, and examines its
        ' parameters.
        Dim mi As MethodInfo = GetType(Example).GetMethod("Test")
        Dim parms() As ParameterInfo = mi.GetParameters()
        t = parms(0).ParameterType
        Console.WriteLine("HasElementType is '{0}' for ref parameter types.", t.HasElementType)
        t = parms(1).ParameterType
        Console.WriteLine("HasElementType is '{0}' for <Out> parameter types.", t.HasElementType)

        ' When you use Reflection Emit to emit dynamic methods and
        ' assemblies, you can create pointer and ByRef types to use
        ' when you define method parameters.
        t = GetType(Example).MakePointerType()
        Console.WriteLine("HasElementType is '{0}' for pointer types.", t.HasElementType)
        t = GetType(Example).MakeByRefType()
        Console.WriteLine("HasElementType is '{0}' for ByRef types.", t.HasElementType)
    End Sub 

End Class
' </Snippet1>