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