' <Snippet1>         
Imports System
Imports System.Reflection

Public Class MyClass1
    Public Class NestClass
        Public Shared myPublicInt As Integer = 0
    End Class 'NestClass

    Public Structure NestStruct
        Public myPublicInt As Integer
    End Structure 'NestStruct
End Class 'MyClass1

Public Class MyMainClass
    Public Shared Sub Main()
        Try
            ' Get the Type object corresponding to MyClass.
            Dim myType As Type = GetType(MyClass1)
            ' Get an array of nested type objects in MyClass.                 
            Dim nestType As Type() = myType.GetNestedTypes()
            Console.WriteLine("The number of nested types is {0}.", nestType.Length)
            Dim t As Type
            For Each t In nestType
                Console.WriteLine("Nested type is {0}.", t.ToString())
            Next t
        Catch e As Exception
            Console.WriteLine("Error", e.Message.ToString())
        End Try
    End Sub 'Main
End Class 'MyMainClass
' </Snippet1>