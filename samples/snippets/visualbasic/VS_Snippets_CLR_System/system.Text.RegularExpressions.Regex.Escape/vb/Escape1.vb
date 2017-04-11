' Visual Basic .NET Document
Option Strict On

Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Unescaped()
      Console.WriteLine("-------")
      Escaped()
   End Sub
   
   Private Sub Unescaped()
      ' <Snippet1>
      Dim pattern As String = "[(.*?)]" 
      Dim input As String = "The animal [what kind?] was visible [by whom?] from the window."
      
      Dim matches As MatchCollection = Regex.Matches(input, pattern)
      Dim commentNumber As Integer = 0
      Console.WriteLine("{0} produces the following matches:", pattern)
      For Each match As Match In matches
         commentNumber += 1
         Console.WriteLine("{0}: {1}", commentNumber, match.Value)       
      Next      
      ' This example displays the following output:
      '       1: ?
      '       2: ?
      '       3: .
      ' </Snippet1>      
   End Sub
   
   Private Sub Escaped()
      ' <Snippet2>
      Dim pattern As String = Regex.Escape("[") + "(.*?)]" 
      Dim input As String = "The animal [what kind?] was visible [by whom?] from the window."
      
      Dim matches As MatchCollection = Regex.Matches(input, pattern)
      Dim commentNumber As Integer = 0
      Console.WriteLine("{0} produces the following matches:", pattern)
      For Each match As Match In matches
         commentNumber += 1
         Console.WriteLine("   {0}: {1}", commentNumber, match.Value)  
      Next
      ' This example displays the following output:
      '       \[(.*?)] produces the following matches:
      '          1: [what kind?]
      '          2: [by whom?]
      ' </Snippet2>
   End Sub
End Module

