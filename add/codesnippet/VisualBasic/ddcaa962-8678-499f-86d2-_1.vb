        Console.WriteLine(vbCrLf & "Use the Invoke method to execute the dynamic method:")
        ' Create an array of arguments to use with the Invoke method.
        Dim invokeArgs() As Object = {vbCrLf & "Hello, World!", 42}
        ' Invoke the dynamic method using the arguments. This is much
        ' slower than using the delegate, because you must create an
        ' array to contain the arguments, and value-type arguments
        ' must be boxed.
        Dim objRet As Object = hello.Invoke(Nothing, _
            BindingFlags.ExactBinding, Nothing, invokeArgs, _
            New CultureInfo("en-us"))
        Console.WriteLine("hello.Invoke returned: {0}", objRet)