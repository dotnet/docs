' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.IO

Module Example
   Public Sub Main()
      Dim result As Tuple(Of Double, Long) = GetResult()
      Console.WriteLine("Sample mean: {0}, N = {1:N0}",
                        result.Item1, result.Item2)
   End Sub

   Private Function GetResult As Tuple(Of Double, Long)
      Dim chunkSize As Integer = 50000000
      Dim nToGet As Integer = 200000000
      Dim rnd As New Random()
'       Dim fs As New FileStream(".\data.bin", FileMode.Create)
'       Dim bin As New BinaryWriter(fs)
'       bin.Write(CInt(0))
      Dim n As Integer
      Dim sum As Double
      For outer As Integer = 0 To CInt(Math.Ceiling(nToGet/chunkSize) - 1)
         For inner = 0 To Math.Min(nToGet - n - 1, chunkSize - 1)
            Dim value As Double = rnd.NextDouble()
            sum += value
            n += 1
'            bin.Write(value)
         Next
      Next
'       bin.Seek(0, SeekOrigin.Begin)
'       bin.Write(n)
'       bin.Close()
      Return New Tuple(Of Double, Long)(sum/n, n)
   End Function
End Module
' The example displays output like the following:
'   Sample mean: 0.500022771458399, N = 200,000,000
' </Snippet4>
