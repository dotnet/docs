' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Module Example
   Public Sub Main()
      Dim values1() As Integer = { 3, 6, 9, 12, 15, 18, 21 }
      Dim values2(5) As Integer
      
      ' Assign last element of the array to the new array.
      values2(values1.Length - 1) = values1(values1.Length - 1)
   End Sub
End Module
' The example displays the following output:
'       Unhandled Exception: 
'       System.IndexOutOfRangeException: 
'       Index was outside the bounds of the array.
'       at Example.Main()
' </Snippet10>
