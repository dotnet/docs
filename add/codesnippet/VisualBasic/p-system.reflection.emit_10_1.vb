        ' Display the declaring type, which is always Nothing for dynamic
        ' methods.
        If hello.DeclaringType Is Nothing Then
            Console.WriteLine(vbCrLf & "DeclaringType is always Nothing for dynamic methods.")
        Else
            Console.WriteLine("DeclaringType: {0}", hello.DeclaringType)
        End If