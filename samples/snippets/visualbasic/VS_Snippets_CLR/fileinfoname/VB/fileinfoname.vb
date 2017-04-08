' <snippet1>
Imports System
Imports System.IO

Public Class NameTest
    Public Shared Sub Main()
        ' Create a reference to the current directory.
        Dim di As New DirectoryInfo(Environment.CurrentDirectory)
        ' Create an array representing the files in the current directory.
        Dim fi As FileInfo() = di.GetFiles()
        Console.WriteLine("The following files exist in the current directory:")
        ' Print out the names of the files in the current directory.
        Dim fiTemp As FileInfo
        For Each fiTemp In fi
            Console.WriteLine(fiTemp.Name)
        Next fiTemp
    End Sub 'Main
End Class 'NameTest
'This code produces output similar to the following; 
'results may vary based on the computer/file structure/etc.:
'
'The following files exist in the current directory:
'newTemp.txt
'fileinfoname.exe
'fileinfoname.pdb
'fileinfoname.Resources.resources
'fileinfoname.vbproj.GenerateResource.Cache
'fileinfoname.xml
' </snippet1>