Imports System.Runtime.CompilerServices

Module Module3

    Sub Main()
        Dim ex As New ExampleClass
        ' The following statement calls the extension method.
        ex.ExampleMethod("Extension method")
        ' The following statement calls the instance method.
        ex.ExampleMethod()
    End Sub

    Class ExampleClass
        ' Define an instance method named ExampleMethod.
        Public Sub ExampleMethod()
            Console.WriteLine("Instance method")
        End Sub
    End Class

    <Extension()> 
    Sub ExampleMethod(ByVal ec As ExampleClass, 
                  ByVal stringParameter As String)
        Console.WriteLine(stringParameter)
    End Sub

End Module