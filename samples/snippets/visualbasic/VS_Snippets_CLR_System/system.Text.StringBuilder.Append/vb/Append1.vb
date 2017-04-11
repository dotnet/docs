' Visual Basic .NET Document
Option Strict On

Imports System.Text

<Assembly: CLSCompliant(True)>
Module modMain
   Public Sub Main()
      ' <Snippet1>
      Dim characters() As Char = {"/"c, "<"c, "<"c, " "c, ">"c, ">"c, "\"c}
      Const beginPosition As Integer = 0
      Const endPosition As Integer = 3 
      
      Dim title As String = "The Hound of the Baskervilles"
      
      Dim sb As New StringBuilder()
      sb.Append(characters, beginPosition, 4)
      sb.Append(title)
      sb.Append(characters, endPosition, 4)
      Console.WriteLine(sb.ToString())
      ' The example displays the following output:
      '      /<< The Hound of the Baskervilles >>\      
      ' </Snippet1>
   End Sub
End Module

