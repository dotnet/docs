'Types:System.IO.DirectoryNotFoundException Vendor: Richter
'<snippet1>
Imports System.IO

Module Module1
    Sub Main()
        Try

            ' Specify a directory name that does not exist for this demo.
            Dim dir As String = "c:\78fe9lk"

            ' If this directory does not exist, a DirectoryNotFoundException is thrown
            ' when attempting to set the current directory.
            Directory.SetCurrentDirectory(dir)

        Catch ex As System.IO.DirectoryNotFoundException

            ' Let the user know that the directory did not exist.
            Console.WriteLine("Directory not found: " + ex.Message)
        End Try
    End Sub
End Module
'</snippet1>

' This code produces the following output.
' 
' Directory not found: Could not find a part of the path 'c:\78fe9lk'.
