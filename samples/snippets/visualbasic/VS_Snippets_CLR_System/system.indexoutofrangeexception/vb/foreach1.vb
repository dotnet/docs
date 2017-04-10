' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Module Example
   Public Sub Main()
      ' Generate array of random values.
      Dim values() As Integer = PopulateArray(5, 10)
      ' Display each element in the array.
      For Each value In values
         Console.Write("{0}   ", values(value))
      Next
   End Sub
   
   Private Function PopulateArray(items As Integer, 
                                  maxValue As Integer) As Integer()
      Dim values(items - 1) As Integer
      Dim rnd As New Random()
      For ctr As Integer = 0 To items - 1
         values(ctr) = rnd.Next(0, maxValue + 1)   
      Next    
      Return values                                                      
   End Function
End Module
' The example displays output like the following:
'    6   4   4
'    Unhandled Exception: System.IndexOutOfRangeException: 
'    Index was outside the bounds of the array.
'       at Example.Main()
' </Snippet7>
