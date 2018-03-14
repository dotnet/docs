' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection

Module Example
   Public Sub Main()
      ' Instantiate a target object.
      Dim integer1 As Integer = 1632
      ' Instantiate an Assembly class to the assembly housing the Integer type.
      Dim systemAssembly As Assembly = integer1.GetType().Assembly
      ' Get the location of the assembly using the file: protocol.
      Console.WriteLine("CodeBase = {0}", systemAssembly.CodeBase)
   End Sub
End Module
' The example displays output like the following:
'   CodeBase = file:///C:/Windows/Microsoft.NET/Framework64/v4.0.30319/mscorlib.dll
' </Snippet1>
