' <snippet1>
Imports System
Imports System.IO

Public Class OpenTest

    Public Shared Sub Main()
        ' Open an existing file, or create a new one.
        Dim fi As New FileInfo("temp.txt")

        ' Open the file just specified such that no one else can use it.
        Dim fs As FileStream = fi.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)

        ' Create another reference to the same file.
        Dim nextfi As New FileInfo("temp.txt")

        Try
            ' Try opening the same file, which was locked by the previous process.
            nextfi.Open(FileMode.OpenOrCreate, FileAccess.Read)
            Console.WriteLine("The file was not locked, and was opened by a second process.")
        Catch i as IOException
            Console.WriteLine(i.ToString())
        Catch e As Exception
            Console.WriteLine(e.ToString())
        End Try

        ' Close the file so it can be deleted.
        fs.Close()
    End Sub 'Main
End Class 'OpenTest
'This code produces output similar to the following; 
'results may vary based on the computer/file structure/etc.:
'
'System.IO.IOException: The process cannot access the file 
''C:\Documents and Settings\mydirectory\My Documents\Visual Studio 2005
'\Projects\fileinfoopen\fileinfoopen\obj\Release\temp.txt' 
'because it is being used by another process.
'at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
'at System.IO.FileStream.Init(String path, FileMode mode, FileAccess access, 
'Int32 rights, Boolean useRights, FileShare share, Int32 bufferSize, FileOptions
'options, SECURITY_ATTRIBUTES secAttrs, String msgPath, Boolean bFromProxy)
'at System.IO.FileStream..ctor(String path, FileMode mode, FileAccess access,
'FileShare share) at System.IO.FileInfo.Open(FileMode mode, FileAccess access)
'at VB_Console_Application.OpenTest.Main() in C:\Documents and Settings
'\mydirectory\My Documents\Visual Studio 2005\Projects\VB_Console_Application
'\VB_Console_Application\Module1.vb:line 19
' </snippet1>