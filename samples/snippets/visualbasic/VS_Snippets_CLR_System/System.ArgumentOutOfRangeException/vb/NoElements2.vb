' Visual Basic .NET Document
Option Strict On

' <Snippet13>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim numbers As New List(Of Integer)
      numbers.AddRange( { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 20 } )
      
      Dim squares As New List(Of Integer)
      For ctr As Integer = 0 To numbers.Count - 1
         squares(ctr) = CInt(numbers(ctr) ^ 2) 
      Next
   End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection.
'    Parameter name: index
'       at System.ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
'       at Example.Main()
' </Snippet13>

Module Correction
   Public Sub Test()
      Dim numbers As New List(Of Integer)
      numbers.AddRange( { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 20 } )
      
      ' <Snippet14>
      Dim squares As New List(Of Integer)
      For ctr As Integer = 0 To numbers.Count - 1
         squares.Add(CInt(numbers(ctr) ^ 2)) 
      Next
      ' </Snippet14>
   End Sub
End Module
