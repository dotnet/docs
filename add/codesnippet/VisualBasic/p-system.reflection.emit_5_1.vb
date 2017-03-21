        ' For dynamic methods, the reflected type is always Nothing.
        If hello.ReflectedType Is Nothing Then
            Console.WriteLine(vbCrLf & "ReflectedType is Nothing.")
        Else
            Console.WriteLine(vbCrLf & "ReflectedType: {0}", _
                hello.ReflectedType)
        End If