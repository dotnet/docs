' Visual Basic .NET Document
Option Strict On

Imports System.Collections.Generic

Public Class TrimExample
   ' <Snippet3>
   Public Shared Sub Main()
      Dim lines() As String = {"Public Module HelloWorld", _
                               "   Public Sub Main()", _
                               "      ' This code displays a simple greeting", _
                               "      ' to the console.", _
                               "      Console.WriteLine(""Hello, World."")", _
                               "   End Sub", _
                               " End Module"}
      Console.WriteLine("Code before call to StripComments:")
      For Each line As String In lines
         Console.WriteLine("   {0}", line)                         
      Next                            
      
      Dim strippedLines() As String = StripComments(lines) 
      Console.WriteLine("Code after call to StripComments:")
      For Each line As String In strippedLines
         Console.WriteLine("   {0}", line)                         
      Next                            
   End Sub
   ' This code produces the following output to the console:
   '    Code before call to StripComments:
   '       Public Module HelloWorld
   '          Public Sub Main()
   '             ' This code displays a simple greeting
   '             ' to the console.
   '             Console.WriteLine("Hello, World.")
   '          End Sub
   '       End Module
   '    Code after call to StripComments:
   '       This code displays a simple greeting
   '       to the console.   
   ' </Snippet3>
   ' <Snippet2>
   Public Shared Function StripComments(lines() As String) As String()
      Dim lineList As New List(Of String)
      For Each line As String In lines
         If line.TrimStart(" "c).StartsWith("'") Then
            linelist.Add(line.TrimStart("'"c, " "c))
         End If
      Next
      Return lineList.ToArray()
   End Function   
   ' </Snippet2>
   ' <Snippet1>
   Public Sub Main()
      ' TrimStart Examples
      Dim lineWithLeadingSpaces as String = "   Hello World!"
	  Dim lineWithLeadingSymbols as String = "$$$$Hello World!"
      Dim lineWithLeadingUnderscores as String = "_____Hello World!"
      Dim lineWithLeadingLetters as String = "xxxxHello World!"
      Dim lineAfterTrimStart = String.Empty

      ' Make it easy to print out and work with all of the examples
      Dim lines As String() = { lineWithLeadingSpaces, line lineWithLeadingSymbols, lineWithLeadingUnderscores, lineWithLeadingLetters }

      For Each line As String in lines
        Console.WriteLine($"This line has leading characters: {line}")
      Next
      ' Output:
      ' This line has leading characters:    Hello World!
      ' This line has leading characters: $$$$Hello World!
      ' This line has leading characters: _____Hello World!
      ' This line has leading characters: xxxxHello World!

      Console.WriteLine($"This line has leading spaces: {lineWithLeadingSpaces}")
      ' This line has leading spaces:   Hello World!

      ' A basic demonstration of TrimStart in action
      lineAfterTrimStart = lineWithLeadingSpaces.TrimStart(" "c)
      Console.WriteLine($"This is the result after calling TrimStart: {lineAfterTrimStart}")
      ' This is the result after calling TrimStart: Hello World!

      ' Since TrimStart accepts a character array of leading items to be removed as an argument,
      ' it's possible to do things like trim multiple pieces of data that each have different 
      ' leading characters,
      For Each lineToEdit As String in lines
        Console.WriteLine(lineToEdit.TrimStart(" "c, "$"c, "_"c, "x"c ))
      Next
      ' Result for each: Hello World!

      ' or handle pieces of data that have multiple kinds of leading characters
      Dim lineToBeTrimmed as String = "__###__ John Smith"
      lineAfterTrimStart = lineToBeTrimmed.TrimStart("_"c , "#"c , " "c)
      Console.WriteLine(lineAfterTrimStart)
      ' Result: John Smith

    End Sub
   '</Snippet1>   
End Class

