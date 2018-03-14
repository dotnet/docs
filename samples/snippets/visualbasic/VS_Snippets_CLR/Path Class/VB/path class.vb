' <Snippet1>
Imports System
Imports System.IO

Public Class Test

    Public Shared Sub Main()
        Dim path1 As String = "c:\temp\MyTest.txt"
        Dim path2 As String = "c:\temp\MyTest"
        Dim path3 As String = "temp"

        If Path.HasExtension(path1) Then
            Console.WriteLine("{0} has an extension.", path1)
        End If

        If Path.HasExtension(path2) = False Then
            Console.WriteLine("{0} has no extension.", path2)
        End If

        If Path.IsPathRooted(path3) = False Then
            Console.WriteLine("The string {0} contains no root information.", path3)
        End If

        Console.WriteLine("The full path of {0} is {1}.", path3, Path.GetFullPath(path3))
        Console.WriteLine("{0} is the location for temporary files.", Path.GetTempPath())
        Console.WriteLine("{0} is a file available for use.", Path.GetTempFileName())

        ' This code produces output similar to the following:
        ' c:\temp\MyTest.txt has an extension.
        ' c:\temp\MyTest has no extension.
        ' The string temp contains no root information.
        ' The full path of temp is D:\Documents and Settings\cliffc\My Documents\Visual Studio 2005\Projects\ConsoleApplication2\ConsoleApplication2\bin\Debug\temp.
        ' D:\Documents and Settings\cliffc\Local Settings\Temp\8\ is the location for temporary files.
        ' D:\Documents and Settings\cliffc\Local Settings\Temp\8\tmp3D.tmp is a file available for use.

    End Sub
End Class
' </Snippet1>
