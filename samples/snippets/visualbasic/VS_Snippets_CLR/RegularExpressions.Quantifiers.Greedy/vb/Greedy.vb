' Visual Basic .NET Document
Option Strict On

Imports System.Text.RegularExpressions

<Assembly: CLSCompliant(True)>
Module modMain
   Public Sub Main()
      ' <Snippet1>
      Dim greedyPattern As String = "\b.*([0-9]{4})\b"
      Dim input1 As String = "1112223333 3992991999"
      For Each match As Match In Regex.Matches(input1, greedypattern)
         Console.WriteLine("Account ending in ******{0}.", match.Groups(1).Value)
      Next
      ' The example displays the following output:
      '       Account ending in ******1999.
      ' </Snippet1>
      Console.WriteLine()     
      ' <Snippet2>
      Dim lazyPattern As String = "\b.*?([0-9]{4})\b"
      Dim input2 As String = "1112223333 3992991999"
      For Each match As Match In Regex.Matches(input2, lazypattern)
         Console.WriteLine("Account ending in ******{0}.", match.Groups(1).Value)
      Next     
      ' The example displays the following output:
      '       Account ending in ******3333.
      '       Account ending in ******1999.
      ' </Snippet2>
   End Sub
End Module

