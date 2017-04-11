' <snippet1>
Imports System
Imports System.IO

Public Class DirectoryTest

    Public Shared Sub Main()
        ' Open an existing file, or create a new one.
        Dim fi As New FileInfo("temp.txt")

        ' Determine the full path of the file just created.
        Dim di As DirectoryInfo = fi.Directory

        ' Figure out what other entries are in that directory.
        Dim fsi As FileSystemInfo() = di.GetFileSystemInfos()

        ' Print the names of all the files and subdirectories of that directory.
        Console.WriteLine("The directory '{0}' contains the following files and directories:", di.FullName)
        Dim info As FileSystemInfo
        For Each info In fsi
            Console.WriteLine(info.Name)
        Next info
    End Sub 'Main
End Class 'DirectoryTest

'This code produces output similar to the following; 
'results may vary based on the computer/file structure/etc.:
'
'The directory 'C:\Visual Studio 2005\release' contains the following files 
'and directories:
'TempPE
'fileinfodirectory.exe
'fileinfodirectory.pdb
'fileinfodirectory.Resources.resources
'fileinfodirectory.vbproj.GenerateResource.Cache
'fileinfodirectory.xml
'
' </snippet1>