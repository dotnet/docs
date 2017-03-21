        ' Display the default value for InitLocals.
        If hello.InitLocals Then
            Console.Write(vbCrLf & "This method contains verifiable code.")
        Else
            Console.Write(vbCrLf & "This method contains unverifiable code.")
        End If
        Console.WriteLine(" (InitLocals = {0})", hello.InitLocals)