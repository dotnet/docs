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