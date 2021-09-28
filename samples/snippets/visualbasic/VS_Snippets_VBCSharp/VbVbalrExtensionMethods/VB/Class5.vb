
Imports System.Runtime.CompilerServices

Module Class5
    '<Snippet7>
    Sub Main()
        Dim example As New ExampleClass
        Dim arg1 As Long = 10
        Dim arg2 As Integer = 5

        ' The following statement calls the instance method.
        example.ExampleMethod(arg1)
        ' The following statement calls the instance method.
        example.ExampleMethod(arg2)
    End Sub
    '</Snippet7>

    '<Snippet6>
    Class ExampleClass
        ' Define an instance method named ExampleMethod.
        Public Sub ExampleMethod(ByVal m As Long)
            Console.WriteLine("Instance method")
        End Sub
    End Class

    <Extension()> 
    Sub ExampleMethod(ByVal ec As ExampleClass, 
                      ByVal n As Integer)
        Console.WriteLine("Extension method")
    End Sub
    '</Snippet6>

End Module
