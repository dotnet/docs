' <snippet1>
Imports System.IO

Module Module1

    Sub Main()
        Dim fileCreatedDate As DateTime = File.GetCreationTime("C:\Example\MyTest.txt")
        Console.WriteLine("file created: " + fileCreatedDate)
    End Sub

End Module
' </snippet1>