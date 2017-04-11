' <Snippet12>
Imports System
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports Microsoft.VisualBasic
' </Snippet12>

Public Class FileInfoSnippets
    Public Sub Attributes()
        ' <Snippet1>
        Dim fileName As String = "C:\autoexec.bat"
        Dim fileInfo As New FileInfo(fileName)
        If Not fileInfo.Exists Then
            Return
        End If
        Console.WriteLine("{0} has attributes of {1}", fileName, fileInfo.Attributes)
        ' Toggle the archive flag of the file.
        Dim archiveFlag As Boolean = CBool(fileInfo.Attributes And FileAttributes.Archive)
        If archiveFlag Then
            fileInfo.Attributes = fileInfo.Attributes And Not FileAttributes.Archive
        Else
            fileInfo.Attributes = fileInfo.Attributes Or FileAttributes.Archive
        End If
        Console.WriteLine("{0} has attributes of {1}", fileName, fileInfo.Attributes)
        ' This code produces output similar to the following,
        ' though actual results may vary by machine:
        ' 
        ' C:\autoexec.bat has attributes of Normal
        ' C:\autoexec.bat has attributes of Archive
        ' </Snippet1>
        Console.WriteLine()
    End Sub 'Attributes
    Public Sub CreationTime()
        ' <Snippet2>
        Dim fileName As String = "C:\autoexec.bat"
        Dim fileInfo As New FileInfo(fileName)
        If Not fileInfo.Exists Then
            Return
        End If

        Console.WriteLine("{0} was created at {1}", fileName, fileInfo.CreationTime)

        ' Add two hours to the creation time.
        fileInfo.CreationTime.Add(TimeSpan.FromHours(2.0))

        Console.WriteLine("{0} is now created at {1}", fileName, fileInfo.CreationTime)
        ' This code produces output similar to the following,
        ' though actual results may vary by machine:
        ' 
        ' C:\autoexec.bat was created at 8/17/2004 5:30:13 PM
        ' C:\autoexec.bat is now created at 8/17/2004 7:30:13 PM
        ' </Snippet2>
        Console.WriteLine()
    End Sub 'CreationTime


    Public Sub DirectoryName()
        ' <Snippet3>
        Dim fileName As String = "C:\TMP\log.txt"
        Dim fileInfo As New FileInfo(fileName)
        If Not fileInfo.Exists Then
            Return
        End If

        Console.WriteLine("{0} has a directoryName of {1}", fileName, fileInfo.DirectoryName)
        ' This code produces output similar to the following,
        ' though actual results may vary by machine:
        ' 
        ' C:\TMP\log.txt has a directory name of C:\TMP
        ' </Snippet3>
        Console.WriteLine()
    End Sub 'DirectoryName


    Public Sub Directory()
        ' <Snippet4>
        Dim fileName As String = "C:\autoexec.bat"
        Dim fileInfo As New FileInfo(fileName)
        If Not fileInfo.Exists Then
            Return
        End If
        Dim dirInfo As DirectoryInfo = fileInfo.Directory

        Console.WriteLine("{0} is in a directory of {1} files.", fileName, dirInfo.GetFiles().Length)
        ' This code produces output similar to the following,
        ' though actual results may vary by machine:
        ' 
        ' C:\autoexec.bat is in a directory of 24 files.
        ' </Snippet4>
        Console.WriteLine()
    End Sub 'Directory


    Public Sub ExtensionAndName()
        ' <Snippet5>
        Dim dirName As String = "C:\"
        Dim dirInfo As New DirectoryInfo(dirName)

        Console.WriteLine("{0} contains the following system files:", dirName)
        Dim fileInfo As FileInfo
        For Each fileInfo In dirInfo.GetFiles()
            If fileInfo.Extension.ToLower().Equals(".sys") Then
                Console.WriteLine(fileInfo.Name)
            End If
        Next fileInfo
        ' This code produces output similar to the following,
        ' though actual results may vary by machine:
        ' 
        ' C:\ contains the following system files:
        ' CONFIG.SYS
        ' IO.SYS
        ' MSDOS.SYS
        ' pagefile.sys
        ' </Snippet5>
        Console.WriteLine()
    End Sub 'ExtensionAndName


    Public Sub LastAccessTime()
        ' <Snippet6>
        Dim fileName As String = "C:\autoexec.bat"
        Dim fileInfo As New FileInfo(fileName)
        If Not fileInfo.Exists Then
            Return
        End If

        Console.WriteLine("{0} was last accessed at {1}", fileName, fileInfo.LastAccessTime)

        ' Set the access time back two hours.
        fileInfo.LastAccessTime.Subtract(TimeSpan.FromHours(2.0))

        Console.WriteLine("{0} now was last accessed at {1}", fileName, fileInfo.LastAccessTime)
        ' This code produces output similar to the following,
        ' though actual results may vary by machine:
        ' 
        ' C:\autoexec.bat was last accessed at 8/17/2004 1:30:13 PM
        ' C:\autoexec.bat now was last accessed at 8/17/2004 11:30:13 AM
        ' </Snippet6>
        Console.WriteLine()
    End Sub 'LastAccessTime


    Public Sub LastWriteTime()
        ' <Snippet7>
        Dim fileName As String = "C:\autoexec.bat"
        Dim fileInfo As New FileInfo(fileName)
        If Not fileInfo.Exists Then
            Return
        End If

        Console.WriteLine("{0} was last written to at {1}", fileName, fileInfo.LastWriteTime)

        ' Set the last write time back two hours.
        fileInfo.LastWriteTime.Subtract(TimeSpan.FromHours(2.0))

        Console.WriteLine("{0} now was last written to at {1}", fileName, fileInfo.LastWriteTime)
        ' This code produces output similar to the following,
        ' though actual results may vary by machine:
        ' 
        ' C:\autoexec.bat was last written to at 8/17/2004 1:30:13 PM
        ' C:\autoexec.bat now was last written to at 8/17/2004 11:30:13 AM
        ' </Snippet7>
        Console.WriteLine()
    End Sub 'LastWriteTime


    Public Sub Length()
        ' <Snippet8>
        Dim dirName As String = "C:\"
        Dim dirInfo As New DirectoryInfo(dirName)

        Console.WriteLine("{0} contains the following files:", dirName)
        Console.WriteLine("Size  Filename")
        Dim fileInfo As FileInfo
        For Each fileInfo In dirInfo.GetFiles()
            Try
                Console.WriteLine("{0}" + ChrW(9) + " {1}", fileInfo.Length, fileInfo.Name)
            Catch e As IOException
                Console.WriteLine(ChrW(9) + " {0}: {1}", fileInfo.Name, e.Message)
            End Try
        Next fileInfo
        ' This code produces output similar to the following,
        ' though actual results may vary by machine:
        ' 
        ' C:\ contains the following files:
        ' Size   Filename
        ' 0  AUTOEXEC.BAT
        ' 211    boot.ini
        ' 0  CONFIG.SYS
        ' 885    InoSetRTThread.log
        ' 0  IO.SYS
        ' 0  MSDOS.SYS
        ' 47564  NTDETECT.COM
        ' 250032     ntldr
        ' 1610612736     pagefile.sys
        ' 1479   PatchInfo.txt
        ' 102    Platform.ini
        ' 548    RISGX280.log
        ' 196568     UpdatePatch.log
        ' </Snippet8>
        Console.WriteLine()
    End Sub 'Length


    Public Sub AppendTextAndOpenText()
        ' <Snippet9>
        Dim fileName As String = Path.GetTempFileName()
        Dim fileInfo As New FileInfo(fileName)
        Console.WriteLine("File '{0}' created of size {1} bytes", fileName, fileInfo.Length)

        ' Append some text to the file.
        Dim s As StreamWriter = fileInfo.AppendText()
        s.WriteLine("The text in the file")
        s.Close()

        fileInfo.Refresh()
        Console.WriteLine("File '{0}' now has size {1} bytes", fileName, fileInfo.Length)

        ' Read the text file.
        Dim r As StreamReader = fileInfo.OpenText()
        Dim textLine As String = r.ReadLine()
        Console.WriteLine(textLine)
        r.Close()
        ' This code produces output similar to the following,
        ' though actual results may vary by machine:
        ' 
        ' File 'C:\DOCUME~1\cliffc\LOCALS~1\Temp\tmp12C.tmp' created of size 0 bytes
        ' File 'C:\DOCUME~1\cliffc\LOCALS~1\Temp\tmp12C.tmp' now has size 22 bytes
        ' The text in the file
        ' </Snippet9>
        Console.WriteLine()
    End Sub 'AppendTextAndOpenText


    Public Sub CreateText()
        ' <Snippet10>
        Dim fileInfo As New FileInfo("myFile")

        ' Create the file and output some text to it.
        Dim s As StreamWriter = fileInfo.CreateText()
        s.WriteLine("Output to the file")
        s.Close()

        fileInfo.Refresh()
        Console.WriteLine("File '{0}' now has size {1} bytes", fileInfo.Name, fileInfo.Length)
        ' This code produces output similar to the following,
        ' though actual results may vary by machine:
        ' 
        ' File 'myFile' now has size 20 bytes
        ' </Snippet10>
        Console.WriteLine()
    End Sub 'CreateText


    Public Sub OpenWriteAndOpenRead()
        ' <Snippet11>
        ' Create a temporary file.
        Dim fileName As String = Path.GetTempFileName()
        Dim fileInfo As New FileInfo(fileName)

        ' Write the current time to the file in binary form.
        Dim currentTime As DateTime = DateTime.Now
        Dim fileWriteStream As FileStream = fileInfo.OpenWrite()
        Dim binaryFormatter As New BinaryFormatter()
        binaryFormatter.Serialize(fileWriteStream, currentTime)
        fileWriteStream.Close()

        ' Read the time back from the file.
        Dim fileReadStream As FileStream = fileInfo.OpenRead()
        Dim timeRead As DateTime = CType(binaryFormatter.Deserialize(fileReadStream), DateTime)
        fileReadStream.Close()

        Console.WriteLine("Value written {0}", currentTime)
        Console.WriteLine("Value read    {0}", timeRead)
        ' This code produces output similar to the following,
        ' though actual results may vary by machine:
        ' 
        ' Value written 9/9/2005 3:46:24 PM
        ' Value read    9/9/2005 3:46:24 PM
        ' </Snippet11>
        Console.WriteLine()
    End Sub 'OpenWriteAndOpenRead
    Public Shared Sub Main()
        Console.WriteLine()
        Dim fileInfoSnippets As New FileInfoSnippets()
        fileInfoSnippets.Attributes()
        fileInfoSnippets.CreationTime()
        fileInfoSnippets.DirectoryName()
        fileInfoSnippets.Directory()
        fileInfoSnippets.ExtensionAndName()
        fileInfoSnippets.LastAccessTime()
        fileInfoSnippets.LastWriteTime()
        fileInfoSnippets.Length()
        fileInfoSnippets.AppendTextAndOpenText()
        fileInfoSnippets.CreateText()
        fileInfoSnippets.OpenWriteAndOpenRead()
    End Sub 'Main
End Class 'FileInfoSnippets
