' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.IO
Imports System.Reflection
Imports System.Resources

Module Example3
    Public Sub Main()
        If Environment.GetCommandLineArgs.Length = 1 Then
            Console.WriteLine("No filename.")
            Exit Sub
        End If
        Dim filename As String = Environment.GetCommandLineArgs(1).Trim()
        ' Check whether the file exists.
        If Not File.Exists(filename) Then
            Console.WriteLine("{0} does not exist.", filename)
            Exit Sub
        End If

        ' Try to load the assembly.
        Dim assem As Assembly = Assembly.LoadFrom(filename)
        Console.WriteLine("File: {0}", filename)

        ' Enumerate the resource files.
        Dim resNames() As String = assem.GetManifestResourceNames()
        If resNames.Length = 0 Then
            Console.WriteLine("   No resources found.")
        End If
        For Each resName In resNames
            Console.WriteLine("   Resource: {0}", resName.Replace(".resources", ""))
        Next
        Console.WriteLine()
    End Sub
End Module
' </Snippet4>
