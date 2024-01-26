' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Reflection
Imports System.Resources

Module Example1
    Public Sub Main()
        ' Retrieve the resource.
        Dim rm As New ResourceManager("ExampleResources",
                                      GetType(Example).Assembly)
        Dim greeting As String = rm.GetString("Greeting")

        Console.Write("Enter your name: ")
        Dim name As String = Console.ReadLine()
        Console.WriteLine("{0} {1}!", greeting, name)
    End Sub
End Module
' The example produces output similar to the following:
'       Enter your name: John
'       Hello John!
' </Snippet1>
