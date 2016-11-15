        Dim writeline1 = Sub(x) Console.WriteLine(x)
        Dim writeline2 = Sub(x)
                             Console.WriteLine(x)
                         End Sub

        ' Write "Hello".
        writeline1("Hello")

        ' Write "World"
        writeline2("World")