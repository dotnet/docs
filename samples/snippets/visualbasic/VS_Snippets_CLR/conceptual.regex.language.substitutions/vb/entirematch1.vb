' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "^(\w+\s?)+$"
      Dim titles() As String = { "A Tale of Two Cities", _
                                 "The Hound of the Baskervilles", _
                                 "The Protestant Ethic and the Spirit of Capitalism", _
                                 "The Origin of Species" }
      Dim replacement As String = """$&"""
      For Each title As String In titles
         Console.WriteLine(Regex.Replace(title, pattern, replacement))
      Next  
   End Sub
End Module
' The example displays the following output:
'       "A Tale of Two Cities"
'       "The Hound of the Baskervilles"
'       "The Protestant Ethic and the Spirit of Capitalism"
'       "The Origin of Species"
' </Snippet3>
