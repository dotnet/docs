' Visual Basic .NET Document
Option Strict On

Imports System.IO
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim filename As String = ".\Caching1.txt"
      ' <Snippet1>
      Dim sr As New StreamReader(filename)
      Dim input As String
      Dim pattern As String = "\b(\w+)\s\1\b"
      Do While sr.Peek() >= 0
         input = sr.ReadLine()
         Dim rgx As New Regex(pattern, RegexOptions.IgnoreCase)
         Dim matches As MatchCollection = rgx.Matches(input)
         If matches.Count > 0 Then
            Console.WriteLine("{0} ({1} matches):", input, matches.Count)
            For Each match As Match In matches
               Console.WriteLine("   " + match.Value)
            Next   
         End If
      Loop
      sr.Close()   
      ' </Snippet1>
      Console.WriteLine()
      Main2()
   End Sub
   
   Public Sub Main2()
      Dim filename As String = ".\Caching1.txt"
      ' <Snippet2>
      Dim sr As New StreamReader(filename)
      Dim input As String
      Dim pattern As String = "\b(\w+)\s\1\b"
      Dim rgx As New Regex(pattern, RegexOptions.IgnoreCase)
      Do While sr.Peek() >= 0
         input = sr.ReadLine()
         Dim matches As MatchCollection = rgx.Matches(input)
         If matches.Count > 0 Then
            Console.WriteLine("{0} ({1} matches):", input, matches.Count)
            For Each match As Match In matches
               Console.WriteLine("   " + match.Value)
            Next   
         End If
      Loop
      sr.Close()   
      ' </Snippet2>
      Console.WriteLine()
   End Sub  
End Module

