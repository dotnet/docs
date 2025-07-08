' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Reflection

Module Example1
    Public Sub Main()
        ' Get the version of the current assembly.
        Dim assem As Assembly = GetType(Example).Assembly
        Dim assemName As AssemblyName = assem.GetName()
        Dim ver As Version = assemName.Version
        Console.WriteLine("{0}, Version {1}", assemName.Name, ver.ToString())
    End Sub
End Module
' </Snippet4>

