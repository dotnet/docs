        ' Display parameter information.
        Dim parameters() As ParameterInfo = hello.GetParameters()
        Console.WriteLine(vbCrLf & "Parameters: name, type, ParameterAttributes")
        For Each p As ParameterInfo In parameters
            Console.WriteLine(vbTab & "{0}, {1}, {2}", _ 
                p.Name, p.ParameterType, p.Attributes)
        Next p