'Types:System.IO.FileSystemInfo Vendor: Richter
'<snippet1>
Imports System.IO
Module Module1

    Sub Main()
        ' Loop through all the immediate subdirectories of C.
        For Each entry As String In Directory.GetDirectories("C:\")
            DisplayFileSystemInfoAttributes(New DirectoryInfo(entry))
        Next

        ' Loop through all the files in C.
        For Each entry As String In Directory.GetFiles("C:\")
            DisplayFileSystemInfoAttributes(New FileInfo(entry))
        Next
    End Sub

    '<snippet2>
    Sub DisplayFileSystemInfoAttributes(ByVal fsi As IO.FileSystemInfo)
        ' Assume that this entry is a file.
        Dim entryType As String = "File"

        ' Determine if this entry is really a directory.
        If (fsi.Attributes And FileAttributes.Directory) = FileAttributes.Directory Then
            entryType = "Directory"
        End If

        ' Show this entry's type, name, and creation date.
        Console.WriteLine("{0} entry {1} was created on {2:D}", _
            entryType, fsi.FullName, fsi.CreationTime)
    End Sub
    '</snippet2>
End Module

' Output will vary based on contents of drive C.
' 
' Directory entry C:\Documents and Settings was created on Tuesday, November 25, 2003
' Directory entry C:\Inetpub was created on Monday, January 12, 2004
' Directory entry C:\Program Files was created on Tuesday, November 25, 2003
' Directory entry C:\RECYCLER was created on Tuesday, November 25, 2003
' Directory entry C:\System Volume Information was created on Tuesday, November 2, 2003
' Directory entry C:\WINDOWS was created on Tuesday, November 25, 2003
' File entry C:\IO.SYS was created on Tuesday, November 25, 2003
' File entry C:\MSDOS.SYS was created on Tuesday, November 25, 2003
' File entry C:\pagefile.sys was created on Saturday, December 27, 2003
'</snippet1>

