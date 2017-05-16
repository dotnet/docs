' <Snippet1>
' The following example displays the names and sizes
' of the files in the specified directory.
Imports System
Imports System.IO

Public Class FileLength

    Public Shared Sub Main()
        ' Make a reference to a directory.
        Dim di As New DirectoryInfo("c:\")
        ' Get a reference to each file in that directory.
        Dim fiArr As FileInfo() = di.GetFiles()
        ' Display the names and sizes of the files.
        Dim f As FileInfo
        Console.WriteLine("The directory {0} contains the following files:", di.Name)
        For Each f In fiArr
            Console.WriteLine("The size of {0} is {1} bytes.", f.Name, f.Length)
        Next f
    End Sub 'Main
End Class 'FileLength 

'This code produces output similar to the following; 
'results may vary based on the computer/file structure/etc.:
'
'The directory c:\ contains the following files:
'The size of MyComputer.log is 274 bytes.
'The size of AUTOEXEC.BAT is 0 bytes.
'The size of boot.ini is 211 bytes.
'The size of CONFIG.SYS is 0 bytes.
'The size of hiberfil.sys is 1072775168 bytes.
'The size of IO.SYS is 0 bytes.
'The size of MASK.txt is 2700 bytes.
'The size of mfc80.dll is 1093632 bytes.
'The size of mfc80u.dll is 1079808 bytes.
'The size of MSDOS.SYS is 0 bytes.
'The size of NTDETECT.COM is 47564 bytes.
'The size of ntldr is 250032 bytes.
'The size of pagefile.sys is 1610612736 bytes.
'The size of UpdatePatch.log is 22778 bytes.
'The size of UpdatePatch.txt is 30 bytes.
'The size of wt3d.ini is 234 bytes.
' </Snippet1>