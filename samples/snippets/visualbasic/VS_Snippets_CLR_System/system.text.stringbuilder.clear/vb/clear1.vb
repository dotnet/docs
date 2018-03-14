' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text

Module Example
   Public Sub Main()
      Dim sb As New StringBuilder("This is a string.")
      Console.WriteLine("{0} ({1} characters)", sb.ToString(), sb.Length)
      
      sb.Clear()
      Console.WriteLine("{0} ({1} characters)", sb.ToString(), sb.Length)

      sb.Append("This is a second string.")
      Console.WriteLine("{0} ({1} characters)", sb.ToString(), sb.Length)
   End Sub            
End Module
' The example displays the following output:
'       This is a string. (17 characters)
'        (0 characters)
'       This is a second string. (24 characters)
' </Snippet1>
