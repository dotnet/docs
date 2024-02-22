' Visual Basic .NET Document
Option Strict On
' <Snippet3>
Imports System.Reflection

Module Example4
    Public Sub Main()
        ' Get the version of a specific assembly.
        Dim filename As String = ".\StringLibrary.dll"
        Dim assem As Assembly = Assembly.ReflectionOnlyLoadFrom(filename)
        Dim assemName As AssemblyName = assem.GetName()
        Dim ver As Version = assemName.Version
        Console.WriteLine("{0}, Version {1}", assemName.Name, ver.ToString())
    End Sub
End Module
' </Snippet3>

