Module Program
    Sub Main(args As String())
        ' <MainMethod>
        Console.WriteLine(vbCrLf + "What is your name? ")
        Dim name = Console.ReadLine()
        Dim currentDate = DateTime.Now
        Console.WriteLine($"{vbCrLf}Hello, {name}, on {currentDate:d} at {currentDate:t}")
        Console.Write(vbCrLf + "Press any key to exit... ")
        Console.ReadKey(True)
        ' </MainMethod>
    End Sub
End Module
