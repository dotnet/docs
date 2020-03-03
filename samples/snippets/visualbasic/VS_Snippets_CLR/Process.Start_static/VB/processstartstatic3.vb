' Place this code into a console project called ArgsEcho to build the argsecho.exe target

Module Module1
    Sub Main()
        Dim i As Integer = 0

        For Each s As String In My.Application.CommandLineArgs
            Console.WriteLine($"[{i}] = {s}")
            i = i + 1
        Next

        Console.WriteLine(Environment.NewLine + "Press any key to exit")
        Console.ReadLine()
    End Sub
End Module