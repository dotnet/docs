Imports System.Globalization
Imports System.IO

Module TryExplicitCatchFinally
    Sub Main()
        Dim streamReader As StreamReader = Nothing
        Try
            streamReader = New StreamReader("file1.txt")
            Dim contents As String = streamReader.ReadToEnd()
            Dim info As StringInfo = New StringInfo(contents)
            Console.WriteLine($"The file has {info.LengthInTextElements} text elements.")
        Catch e As FileNotFoundException
            Console.WriteLine("The file cannot be found.")
        Catch e As IOException
            Console.WriteLine("An I/O error has occurred.")
        Catch e As OutOfMemoryException
            Console.WriteLine("There is insufficient memory to read the file.")
        Finally
            If streamReader IsNot Nothing Then streamReader.Dispose()
        End Try
    End Sub
End Module
