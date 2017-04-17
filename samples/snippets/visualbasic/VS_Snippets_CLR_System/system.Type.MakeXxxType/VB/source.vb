'<Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Public Class Example
    Public Shared Sub Main()
        ' Create a Type object that represents a one-dimensional
        ' array of Example objects.
        Dim t As Type = GetType(Example).MakeArrayType()
        Console.WriteLine(vbCrLf & "Array of Example: " & t.ToString())

        ' Create a Type object that represents a two-dimensional
        ' array of Example objects.
        t = GetType(Example).MakeArrayType(2)
        Console.WriteLine(vbCrLf & "Two-dimensional array of Example: " & t.ToString())

        ' Demonstrate an exception when an invalid array rank is
        ' specified.
        Try
            t = GetType(Example).MakeArrayType(-1)
        Catch ex As Exception
            Console.WriteLine(vbCrLf & ex.ToString())
        End Try

        ' Create a Type object that represents a ByRef parameter
        ' of type Example.
        t = GetType(Example).MakeByRefType()
        Console.WriteLine(vbCrLf & "ByRef Example: " & t.ToString())

        ' Get a Type object representing the Example class, a
        ' MethodInfo representing the "Test" method, a ParameterInfo
        ' representing the parameter of type Example, and finally
        ' a Type object representing the type of this ByRef parameter.
        ' Compare this Type object with the Type object created using
        ' MakeByRefType.
        Dim t2 As Type = GetType(Example)
        Dim mi As MethodInfo = t2.GetMethod("Test")
        Dim pi As ParameterInfo = mi.GetParameters()(0)
        Dim pt As Type = pi.ParameterType
        Console.WriteLine("Are the ByRef types equal? " & (t Is pt))

        ' Create a Type object that represents a pointer to an
        ' Example object.
        t = GetType(Example).MakePointerType()
        Console.WriteLine(vbCrLf & "Pointer to Example: " & t.ToString())
    End Sub

    ' A sample method with a ByRef parameter.
    '
    Public Sub Test(ByRef e As Example)
    End Sub
End Class

' This example produces output similar to the following:
'
'Array of Example: Example[]
'
'Two-dimensional array of Example: Example[,]
'
'System.IndexOutOfRangeException: Index was outside the bounds of the array.
'   at System.RuntimeType.MakeArrayType(Int32 rank) in c:\vbl\ndp\clr\src\BCL\System\RtType.cs:line 2999
'   at Example.Main()
'
'ByRef Example: Example&
'Are the ByRef types equal? True
'
'Pointer to Example: Example*
'</Snippet1>