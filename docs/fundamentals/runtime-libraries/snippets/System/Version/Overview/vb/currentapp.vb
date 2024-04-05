' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Reflection

Module Example3
    Public Sub Main()
        ' Get the version of the executing assembly (that is, this assembly).
        Dim assem As Assembly = Assembly.GetEntryAssembly()
        Dim assemName As AssemblyName = assem.GetName()
        Dim ver As Version = assemName.Version
        Console.WriteLine("Application {0}, Version {1}", assemName.Name, ver.ToString())
    End Sub
End Module
' </Snippet5>

