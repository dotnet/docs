' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      ' Instantiate random number generator using system-supplied value as seed.
      Dim rand As New Random()
      ' Generate and display 5 random byte (integer) values.
      Dim bytes(4) As Byte
      rand.NextBytes(bytes)
      Console.WriteLine("Five random byte values:")
      For Each byteValue As Byte In bytes
         Console.Write("{0, 5}", byteValue)
      Next
      Console.WriteLine()   
      ' Generate and display 5 random integers.
      Console.WriteLine("Five random integer values:")
      For ctr As Integer = 0 To 4
         Console.Write("{0,15:N0}", rand.Next)
      Next                     
      Console.WriteLine()
      ' Generate and display 5 random integers between 0 and 100.'
      Console.WriteLine("Five random integers between 0 and 100:")
      For ctr As Integer = 0 To 4
         Console.Write("{0,8:N0}", rand.Next(101))
      Next                     
      Console.WriteLine()
      ' Generate and display 5 random integers from 50 to 100.
      Console.WriteLine("Five random integers between 50 and 100:")
      For ctr As Integer = 0 To 4
         Console.Write("{0,8:N0}", rand.Next(50, 101))
      Next                     
      Console.WriteLine()
      ' Generate and display 5 random floating point values from 0 to 1.
      Console.WriteLine("Five Doubles.")
      For ctr As Integer = 0 To 4
         Console.Write("{0,8:N3}", rand.NextDouble())
      Next                     
      Console.WriteLine()
      ' Generate and display 5 random floating point values from 0 to 5.
      Console.WriteLine("Five Doubles between 0 and 5.")
      For ctr As Integer = 0 To 4
         Console.Write("{0,8:N3}", rand.NextDouble() * 5)
      Next                     
   End Sub
End Module
' The example displays output like the following:
'    Five random byte values:
'      194  185  239   54  116
'    Five random integer values:
'        507,353,531  1,509,532,693  2,125,074,958  1,409,512,757    652,767,128
'    Five random integers between 0 and 100:
'          16      78      94      79      52
'    Five random integers between 50 and 100:
'          56      66      96      60      65
'    Five Doubles.
'       0.943   0.108   0.744   0.563   0.415
'    Five Doubles between 0 and 5.
'       2.934   3.130   0.292   1.432   4.369
' </Snippet2>

