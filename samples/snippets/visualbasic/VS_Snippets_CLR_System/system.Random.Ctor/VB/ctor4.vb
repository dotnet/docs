' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Threading

Module RandomNumbers
   Public Sub Main()
      Dim rand1 As New Random(CInt(Date.Now.Ticks And &h0000FFFF))
      Dim rand2 As New Random(CInt(Date.Now.Ticks And &h0000FFFF))
      Thread.Sleep(20)
      Dim rand3 As New Random(CInt(Date.Now.Ticks And &h0000FFFF))
      ShowRandomNumbers(rand1)
      ShowRandomNumbers(rand2)
      ShowRandomNumbers(rand3)
   End Sub
   
   Private Sub ShowRandomNumbers(rand As Random)
      Console.WriteLine()
      Dim values(4) As Byte
      rand.NextBytes(values)
      For Each value As Byte In values
         Console.Write("{0, 5}", value)
      Next      
      Console.WriteLine() 
   End Sub
End Module
' The example displays output similar to the following:
'      145  214  177  134  173
'    
'      145  214  177  134  173
'    
'      126  185  175  249  157
' </Snippet4>

