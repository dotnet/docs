' <snippet2>
Imports System.IO

Module Module1

    Sub Main()
        Dim di As DirectoryInfo = New DirectoryInfo("C:\ExampleDir")
        Console.WriteLine("No search pattern returns:")
        For Each fi In di.EnumerateFiles()
            Console.WriteLine(fi.Name)
        Next

        Console.WriteLine()

        Console.WriteLine("Search pattern *2* returns:")
        For Each fi In di.EnumerateFiles("*2*")
            Console.WriteLine(fi.Name)
        Next

        Console.WriteLine()

        Console.WriteLine("Search pattern test?.txt returns:")
        For Each fi In di.EnumerateFiles("test?.txt")
            Console.WriteLine(fi.Name)
        Next

        Console.WriteLine()

        Console.WriteLine("Search pattern AllDirectories returns:")
        For Each fi In di.EnumerateFiles("*", SearchOption.AllDirectories)
            Console.WriteLine(fi.Name)
        Next
    End Sub

End Module

' This code produces output similar to the following:

' No search pattern returns:
' log1.txt
' log2.txt
' test1.txt
' test2.txt
' test3.txt

' Search pattern *2* returns:
' log2.txt
' test2.txt

' Search pattern test?.txt returns:
' test1.txt
' test2.txt
' test3.txt

' Search pattern AllDirectories returns:
' log1.txt
' log2.txt
' test1.txt
' test2.txt
' test3.txt
' SubFile.txt
' Press any key to continue . . .

' </snippet2>
