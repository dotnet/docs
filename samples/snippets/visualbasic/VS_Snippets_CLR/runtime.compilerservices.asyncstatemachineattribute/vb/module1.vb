'<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Reflection
Imports System.Threading.Tasks
Imports System.Runtime.CompilerServices


Module Module1

    ' This class is used by the code below to discover method attributes.
    Public Class TheClass
        Public Async Function AsyncMethod() As Task(Of Integer)
            Await Task.Delay(5)
            Return 1
        End Function

        Public Iterator Function IteratorMethod() As IEnumerable(Of Integer)
            Yield 1
            Yield 2
        End Function

        Public Function RegularMethod() As Integer
            Return 0
        End Function
    End Class


    Private Function IsAsyncMethod(classType As Type, methodName As String)
        ' Obtain the method with the specified name.
        Dim method As MethodInfo = classType.GetMethod(methodName)

        Dim attType As Type = GetType(AsyncStateMachineAttribute)

        Dim attrib = CType(method.GetCustomAttribute(attType), AsyncStateMachineAttribute)
        ' The above variable contains the StateMachineType property.

        Return (attrib IsNot Nothing)
    End Function

    Private Function IsIteratorMethod(classType As Type, methodName As String)
        ' Obtain the method with the specified name.
        Dim method As MethodInfo = classType.GetMethod(methodName)

        Dim attType As Type = GetType(IteratorStateMachineAttribute)

        ' Obtain the custom attribute for the method.
        ' The value returned contains the StateMachineType property.
        ' Nothing is returned if the attribute isn't present for the method.
        Dim attrib = CType(method.GetCustomAttribute(attType), IteratorStateMachineAttribute)

        Return (attrib IsNot Nothing)
    End Function

    Private Sub ShowResult(classType As Type, methodName As String)
        Console.Write((methodName & ": ").PadRight(16))

        If IsAsyncMethod(classType, methodName) Then
            Console.WriteLine("Async method")
        ElseIf IsIteratorMethod(classType, methodName) Then
            Console.WriteLine("Iterator method")
        Else
            Console.WriteLine("Regular method")
        End If

        ' Note: The IteratorStateMachineAttribute applies to Visual Basic methods
        ' but not C# methods.
    End Sub

    Sub Main()
        ShowResult(GetType(TheClass), "AsyncMethod")
        ShowResult(GetType(TheClass), "IteratorMethod")
        ShowResult(GetType(TheClass), "RegularMethod")

        Console.ReadKey()
    End Sub

    '   AsyncMethod:    Async method
    '   IteratorMethod: Iterator method
    '   RegularMethod:  Regular method

End Module
'</snippet1>
