' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection
Imports System.Resources

<Assembly: NeutralResourcesLanguage("fr", UltimateResourceFallbackLocation.Satellite)>
Module Example
    Public Sub Main()
        Dim rm As New ResourceManager("resources", GetType(Example).Assembly)
        Dim greeting As String = rm.GetString("Greeting")
        Console.WriteLine(greeting)
    End Sub
End Module
' </Snippet1>

