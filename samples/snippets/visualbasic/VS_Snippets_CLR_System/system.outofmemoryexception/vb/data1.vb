' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim values() As Double = GetData()
      ' Compute mean.
      Console.WriteLine("Sample mean: {0}, N = {1}",
                        GetMean(values), values.Length)
   End Sub
   
   Private Function GetData() As Double()
      Dim rnd As New Random()
      Dim values As New List(Of Double)()
      For ctr As Integer = 1 To 200000000
         values.Add(rnd.NextDouble)
         If ctr Mod 10000000 = 0 Then
            Console.WriteLine("Retrieved {0:N0} items of data.",
                              ctr)
         End If
      Next
      Return values.ToArray()
   End Function
   
   Private Function GetMean(values() As Double) As Double
      Dim sum As Double = 0
      For Each value In values
         sum += value
      Next
      Return sum / values.Length
   End Function
End Module
' The example displays output like the following:
'    Retrieved 10,000,000 items of data.
'    Retrieved 20,000,000 items of data.
'    Retrieved 30,000,000 items of data.
'    Retrieved 40,000,000 items of data.
'    Retrieved 50,000,000 items of data.
'    Retrieved 60,000,000 items of data.
'    Retrieved 70,000,000 items of data.
'    Retrieved 80,000,000 items of data.
'    Retrieved 90,000,000 items of data.
'    Retrieved 100,000,000 items of data.
'    Retrieved 110,000,000 items of data.
'    Retrieved 120,000,000 items of data.
'    Retrieved 130,000,000 items of data.
'
'    Unhandled Exception: OutOfMemoryException.
' </Snippet3>

