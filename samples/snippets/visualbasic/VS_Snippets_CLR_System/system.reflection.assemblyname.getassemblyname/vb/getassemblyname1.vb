' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection

Public Module Example
   Public Sub Main
      Console.WriteLine(AssemblyName.GetAssemblyName(".\UtilityLibrary.dll"))
   End Sub
End Module
' The example displays output like the following:
'   UtilityLibrary, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
' </Snippet1>
