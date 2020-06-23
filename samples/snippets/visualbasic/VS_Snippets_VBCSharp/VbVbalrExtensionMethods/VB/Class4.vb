
Imports System.Runtime.CompilerServices

Module Module2

    '<Snippet5>
    Sub Main()
        Dim example As New ExampleClass
        Dim arg1 As Long = 10
        Dim arg2 As Integer = 5

        ' The following statement calls the extension method.
        example.exampleMethod(arg1)
        ' The following statement calls the instance method.
        example.exampleMethod(arg2)
    End Sub
    '</Snippet5>

    '<Snippet4>
    Class ExampleClass
        ' Define an instance method named ExampleMethod.
        Public Sub ExampleMethod(ByVal m As Integer)
            Console.WriteLine("Instance method")
        End Sub
    End Class

    <Extension()> 
    Sub ExampleMethod(ByVal ec As ExampleClass, 
                      ByVal n As Long)
        Console.WriteLine("Extension method")
    End Sub
    '</Snippet4>

End Module


