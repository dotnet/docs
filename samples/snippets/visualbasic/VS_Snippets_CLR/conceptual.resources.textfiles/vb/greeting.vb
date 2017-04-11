' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection
Imports System.Resources

Module Example
   Public Sub Main()
      Dim rm As New ResourceManager("GreetingResources", 
                                    GetType(Example).Assembly())
      Console.Write(rm.GetString("prompt"))
      Dim name As String = Console.ReadLine()
      Console.WriteLine(rm.GetString("greeting"), name)                                                                          
   End Sub
End Module
' The example displays output like the following:
'       Enter your name: Wilberforce
'       Hello, Wilberforce!
' </Snippet1>
