' <snippet2>
Imports System.IO

Module Module1

    Sub Main()
        Dim di1 As DirectoryInfo = New DirectoryInfo("\\tempshare\tempdir")
        Dim di2 As DirectoryInfo = New DirectoryInfo("tempdir")
        Dim di3 As DirectoryInfo = New DirectoryInfo("x:\tempdir")
        Dim di4 As DirectoryInfo = New DirectoryInfo("c:\")

        Console.WriteLine("The root path of '{0}' is '{1}'", di1.FullName, di1.Root)
        Console.WriteLine("The root path of '{0}' is '{1}'", di2.FullName, di2.Root)
        Console.WriteLine("The root path of '{0}' is '{1}'", di3.FullName, di3.Root)
        Console.WriteLine("The root path of '{0}' is '{1}'", di4.FullName, di4.Root)
    End Sub

End Module

' This code produces output similar to the following:

' The root path of '\\tempshare\tempdir' is '\\tempshare\tempdir'
' The root path of 'c:\Projects\ConsoleApplication1\ConsoleApplication1\bin\Debug\tempdir' is 'c:\'
' The root path of 'x:\tempdir' is 'x:\'
' The root path of 'c:\' is 'c:\'
' Press any key to continue . . .

' </snippet2>
