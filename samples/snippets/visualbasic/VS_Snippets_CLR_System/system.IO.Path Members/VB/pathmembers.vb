' <Snippet1>
Imports System
Imports System.IO

Public Class PathSnippets
    Public Sub ChangeExtension()
        Dim goodFileName As String = "C:\mydir\myfile.com.extension"
        Dim badFileName As String = "C:\mydir\"
        Dim result As String
        result = Path.ChangeExtension(goodFileName, ".old")
        Console.WriteLine("ChangeExtension({0}, '.old') returns '{1}'", goodFileName, result)
        result = Path.ChangeExtension(goodFileName, "")
        Console.WriteLine("ChangeExtension({0}, '') returns '{1}'", goodFileName, result)
        result = Path.ChangeExtension(badFileName, ".old")
        Console.WriteLine("ChangeExtension({0}, '.old') returns '{1}'", badFileName, result)

        ' This code produces output similar to the following:
        '
        ' ChangeExtension(C:\mydir\myfile.com.extension, '.old') returns 'C:\mydir\myfile.com.old'
        ' ChangeExtension(C:\mydir\myfile.com.extension, '') returns 'C:\mydir\myfile.com.'
        ' ChangeExtension(C:\mydir\, '.old') returns 'C:\mydir\.old'
        ' </Snippet1>
        Console.WriteLine()
    End Sub 'ChangeExtension

    Public Sub Combine()
        ' <Snippet2>
        Dim pathname1 As String = "  C:\mydir1"
        Dim pathname2 As String = "mydir2"
        Dim pathname3 As String = " mydir3"
        Dim combinedPaths As String

        combinedPaths = Path.Combine(pathname1, pathname2)
        Console.WriteLine("Combine('{0}', '{1}') returns '{2}'", pathname1, pathname2, combinedPaths)

        combinedPaths = Path.Combine(pathname1, pathname3)
        Console.WriteLine("Combine('{0}', '{1}') returns '{2}'", pathname1, pathname3, combinedPaths)

        ' This code produces output similar to the following:
        '
        ' Combine('  C:\mydir1', 'mydir2') returns '  C:\mydir1\mydir2'
        ' Combine('  C:\mydir1', ' mydir3') returns '  C:\mydir1\ mydir3'
        ' </Snippet2>
        Console.WriteLine()
    End Sub 'Combine


    Public Sub GetDirectoryName()
        ' <Snippet3>
        Dim filepath As String = "C:\MyDir\MySubDir\myfile.ext"
        Dim directoryName As String
        Dim i As Integer = 0

        While filepath <> Nothing
            directoryName = Path.GetDirectoryName(filepath)
            Console.WriteLine("GetDirectoryName('{0}') returns '{1}'", _
                filepath, directoryName)
            filepath = directoryName
            If i = 1
               filepath = directoryName + "\"  ' this will preserve the previous path
            End If
            i = i + 1
        End While

        'This code produces the following output:
        '
        ' GetDirectoryName('C:\MyDir\MySubDir\myfile.ext') returns 'C:\MyDir\MySubDir'
        ' GetDirectoryName('C:\MyDir\MySubDir') returns 'C:\MyDir'
        ' GetDirectoryName('C:\MyDir\') returns 'C:\MyDir'
        ' GetDirectoryName('C:\MyDir') returns 'C:\'
        ' GetDirectoryName('C:\') returns ''
        ' </Snippet3>
        Console.WriteLine()
    End Sub 'GetDirectoryName


    Public Sub GetExtension()
        ' <Snippet4>
        Dim fileName As String = "C:\mydir.old\myfile.ext"
        Dim pathname As String = "C:\mydir.old\"
        Dim extension As String

        extension = Path.GetExtension(fileName)
        Console.WriteLine("GetExtension('{0}') returns '{1}'", fileName, extension)

        extension = Path.GetExtension(pathname)
        Console.WriteLine("GetExtension('{0}') returns '{1}'", pathname, extension)

        ' This code produces output similar to the following:
        '
        ' GetExtension('C:\mydir.old\myfile.ext') returns '.ext'
        ' GetExtension('C:\mydir.old\') returns ''
        ' </Snippet4>
        Console.WriteLine()
    End Sub 'GetExtension


    Public Sub GetFileName()
        ' <Snippet5>
        Dim fileName As String = "C:\mydir\myfile.ext"
        Dim pathname As String = "C:\mydir\"
        Dim result As String

        result = Path.GetFileName(fileName)
        Console.WriteLine("GetFileName('{0}') returns '{1}'", fileName, result)

        result = Path.GetFileName(pathname)
        Console.WriteLine("GetFileName('{0}') returns '{1}'", pathname, result)

        ' This code produces output similar to the following:
        '
        ' GetFileName('C:\mydir\myfile.ext') returns 'myfile.ext'
        ' GetFileName('C:\mydir\') returns ''
        ' </Snippet5>
        Console.WriteLine()
    End Sub 'GetFileName


    Public Sub GetFileNameWithoutExtension()
        ' <Snippet6>
        Dim fileName As String = "C:\mydir\myfile.ext"
        Dim pathname As String = "C:\mydir\"
        Dim result As String

        result = Path.GetFileNameWithoutExtension(fileName)
        Console.WriteLine("GetFileNameWithoutExtension('{0}') returns '{1}'", fileName, result)

        result = Path.GetFileName(pathname)
        Console.WriteLine("GetFileName('{0}') returns '{1}'", pathname, result)

        ' This code produces output similar to the following:
        '
        ' GetFileNameWithoutExtension('C:\mydir\myfile.ext') returns 'myfile'
        ' GetFileName('C:\mydir\') returns ''
        ' </Snippet6>
        Console.WriteLine()
    End Sub 'GetFileNameWithoutExtension


    Public Sub GetFullPath()
        ' <Snippet7>
        Dim fileName As string = "myfile.ext"
        Dim path1 As string = "mydir"
        Dim path2 As string = "\mydir"
        Dim fullPath As string

        fullPath = Path.GetFullPath(path1)
        Console.WriteLine("GetFullPath('{0}') returns '{1}'", _
            path1, fullPath)
        
        fullPath = Path.GetFullPath(fileName)
        Console.WriteLine("GetFullPath('{0}') returns '{1}'", _
            fileName, fullPath)

        fullPath = Path.GetFullPath(path2)
        Console.WriteLine("GetFullPath('{0}') returns '{1}'", _
            path2, fullPath)

        ' Output is based on your current directory, except
        ' in the last case, where it is based on the root drive
        ' GetFullPath('mydir') returns 'C:\temp\Demo\mydir'
        ' GetFullPath('myfile.ext') returns 'C:\temp\Demo\myfile.ext'
        ' GetFullPath('\mydir') returns 'C:\mydir'
        ' </Snippet7>
        Console.WriteLine()
    End Sub 'GetFullPath


    Public Sub GetPathRoot()
        ' <Snippet8>
        Dim pathname As String = "\mydir\"
        Dim fileName As String = "myfile.ext"
        Dim fullPath As String = "C:\mydir\myfile.ext"
        Dim pathnameRoot As String

        pathnameRoot = Path.GetPathRoot(pathname)
        Console.WriteLine("GetPathRoot('{0}') returns '{1}'", pathname, pathnameRoot)

        pathnameRoot = Path.GetPathRoot(fileName)
        Console.WriteLine("GetPathRoot('{0}') returns '{1}'", fileName, pathnameRoot)

        pathnameRoot = Path.GetPathRoot(fullPath)
        Console.WriteLine("GetPathRoot('{0}') returns '{1}'", fullPath, pathnameRoot)

        ' This code produces output similar to the following:
        '
        ' GetPathRoot('\mydir\') returns '\'
        ' GetPathRoot('myfile.ext') returns ''
        ' GetPathRoot('C:\mydir\myfile.ext') returns 'C:\'
        ' </Snippet8>
        Console.WriteLine()
    End Sub 'GetPathRoot



    Public Sub GetTempFileName()
        ' <Snippet9>
        Dim fileName As String = Path.GetTempFileName()
        Dim fileInfo As New FileInfo(fileName)

        Console.WriteLine("File '{0}' created of size {1} bytes", fileName, fileInfo.Length)
        Dim f As New FileStream(fileName, FileMode.Open)
        Dim s As New StreamWriter(f)

        ' Write some text to the file.
        s.WriteLine("Output to the file")
        s.Close()
        f.Close()

        fileInfo.Refresh()
        Console.WriteLine("File '{0}' now has size {1} bytes", fileName, fileInfo.Length)

        ' This code produces output similar to the following:
        '
        ' File 'D:\Documents and Settings\cliffc\Local Settings\Temp\8\tmp38.tmp' created of size 0 bytes
        ' File 'D:\Documents and Settings\cliffc\Local Settings\Temp\8\tmp38.tmp' now has size 20 bytes
        ' </Snippet9>
        Console.WriteLine()
    End Sub 'GetTempFileName



    Public Sub GetTempPath()
        ' <Snippet10>
        Dim tempPath As String = Path.GetTempPath()
        Console.WriteLine("Temporary pathname is '{0}'", tempPath)

        Dim tempDir As New DirectoryInfo(tempPath)
        Console.WriteLine("{0} contains {1} files", tempPath, tempDir.GetFiles().Length)

        ' This code produces output similar to the following:
        '
        ' Temporary path is 'D:\Documents and Settings\cliffc\Local Settings\Temp\8\'
        ' D:\Documents and Settings\cliffc\Local Settings\Temp\8\ contains 6 files
        ' </Snippet10>
        Console.WriteLine()
    End Sub 'GetTempPath



    Public Sub HasExtension()
        ' <Snippet11>
        Dim fileName1 As String = "myfile.ext"
        Dim fileName2 As String = "mydir\myfile"
        Dim pathname As String = "C:\mydir.ext\"
        Dim result As Boolean

        result = Path.HasExtension(fileName1)
        Console.WriteLine("HasExtension('{0}') returns {1}", fileName1, result)

        result = Path.HasExtension(fileName2)
        Console.WriteLine("HasExtension('{0}') returns {1}", fileName2, result)

        result = Path.HasExtension(pathname)
        Console.WriteLine("HasExtension('{0}') returns {1}", pathname, result)

        ' This code produces output similar to the following:
        '
        ' HasExtension('myfile.ext') returns True
        ' HasExtension('mydir\myfile') returns False
        ' HasExtension('C:\mydir.ext\') returns False
        ' </Snippet11>
        Console.WriteLine()
    End Sub 'HasExtension


    Public Sub IsPathRooted()
        ' <Snippet12>
        Dim fileName As String = "C:\mydir\myfile.ext"
        Dim UncPath As String = "\\myPc\mydir\myfile"
        Dim relativePath As String = "mydir\sudir\"
        Dim result As Boolean

        result = Path.IsPathRooted(fileName)
        Console.WriteLine("IsPathRooted('{0}') returns {1}", fileName, result)

        result = Path.IsPathRooted(UncPath)
        Console.WriteLine("IsPathRooted('{0}') returns {1}", UncPath, result)

        result = Path.IsPathRooted(relativePath)
        Console.WriteLine("IsPathRooted('{0}') returns {1}", relativePath, result)

        ' This code produces output similar to the following:
        '
        ' IsPathRooted('C:\mydir\myfile.ext') returns True
        ' IsPathRooted('\\myPc\mydir\myfile') returns True
        ' IsPathRooted('mydir\sudir\') returns False
        ' </Snippet12>
        Console.WriteLine()
    End Sub 'IsPathRooted


    Public Sub StaticProperties()
        ' <Snippet13>
        Console.WriteLine("Path.AltDirectorySeparatorChar={0}", Path.AltDirectorySeparatorChar)
        Console.WriteLine("Path.DirectorySeparatorChar={0}", Path.DirectorySeparatorChar)
        Console.WriteLine("Path.PathSeparator={0}", Path.PathSeparator)
        Console.WriteLine("Path.VolumeSeparatorChar={0}", Path.VolumeSeparatorChar)

        Console.Write("Path.GetInvalidPathChars()=")
        Dim c As Char
        For Each c In Path.GetInvalidPathChars()
            Console.Write(c)
        Next c
        Console.WriteLine()

        ' This code produces output similar to the following:
        ' Note that the InvalidPathCharacters contain characters
        ' outside of the printable character set.
        '
        ' Path.AltDirectorySeparatorChar=/
        ' Path.DirectorySeparatorChar=\
        ' Path.PathSeparator=;
        ' Path.VolumeSeparatorChar=:
        ' </Snippet13>
        Console.WriteLine()
    End Sub 'StaticProperties


    Public Shared Sub Main()
        Console.WriteLine()
        Dim pathnameSnippets As New PathSnippets()
        pathnameSnippets.StaticProperties()
        pathnameSnippets.ChangeExtension()
        pathnameSnippets.Combine()
        pathnameSnippets.GetDirectoryName()
        pathnameSnippets.GetExtension()
        pathnameSnippets.GetFileName()
        pathnameSnippets.GetFileNameWithoutExtension()
        pathnameSnippets.GetFullPath()
        pathnameSnippets.GetPathRoot()
        pathnameSnippets.GetTempFileName()
        pathnameSnippets.GetTempPath()
        pathnameSnippets.HasExtension()
        pathnameSnippets.IsPathRooted()
    End Sub 'Main
End Class 'PathSnippets