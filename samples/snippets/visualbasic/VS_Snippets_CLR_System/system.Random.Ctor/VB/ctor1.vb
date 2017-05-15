' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Threading

Module RandomNumbers
   Public Sub Main()
      Dim rand1 As New Random()
      Dim rand2 As New Random()
      Thread.Sleep(2000)
      Dim rand3 As New Random()
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
' The example displays the following output to the console:
'       28   35  133  224   58
'    
'       28   35  133  224   58
'    
'       32  222   43  251   49
' </Snippet2>

