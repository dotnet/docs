' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim rnd As New Random()

      Console.WriteLine("20 random integers from -100 to 100:")
      For ctr As Integer = 1 To 20
         Console.Write("{0,6}", rnd.Next(-100, 101))
         If ctr Mod 5 = 0 Then Console.WriteLine()
      Next
      Console.WriteLine()
      
      Console.WriteLine("20 random integers from 1000 to 10000:")      
      For ctr As Integer = 1 To 20
         Console.Write("{0,8}", rnd.Next(1000, 10001))
         If ctr Mod 5 = 0 Then Console.WriteLine()
      Next
      Console.WriteLine()
      
      Console.WriteLine("20 random integers from 1 to 10:")
      For ctr As Integer = 1 To 20
         Console.Write("{0,6}", rnd.Next(1, 11))
         If ctr Mod 5 = 0 Then Console.WriteLine()
      Next
   End Sub
End Module
' The example displays output similar to the following:
'       20 random integers from -100 to 100:
'           65   -95   -10    90   -35
'          -83   -16   -15   -19    41
'          -67   -93    40    12    62
'          -80   -95    67   -81   -21
'       
'       20 random integers from 1000 to 10000:
'           4857    9897    4405    6606    1277
'           9238    9113    5151    8710    1187
'           2728    9746    1719    3837    3736
'           8191    6819    4923    2416    3028
'       
'       20 random integers from 1 to 10:
'            9     8     5     9     9
'            9     1     2     3     8
'            1     4     8    10     5
'            9     7     9    10     5
' </Snippet2>
