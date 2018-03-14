' <Snippet1>
Imports System
Imports System.IO
Imports System.Diagnostics



Class Class1

    Public Shared Sub Main(ByVal args() As String)
        ' Get the file version for the notepad.
        ' Use either of the following two commands.
        FileVersionInfo.GetVersionInfo(Path.Combine(Environment.SystemDirectory, "Notepad.exe"))
        Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")


        ' Print the file name and version number.
        Console.WriteLine("File: " + myFileVersionInfo.FileDescription + vbLf + "Version number: " + myFileVersionInfo.FileVersion)

    End Sub
End Class

' </Snippet1>