' The following code example uses a BitVector32 as a collection of bit flags.


'<snippet1>
Imports System
Imports System.Collections.Specialized

Public Class SamplesBitVector32

   Public Shared Sub Main()

      ' Creates and initializes a BitVector32 with all bit flags set to FALSE.
      Dim myBV As New BitVector32(0)

      ' Creates masks to isolate each of the first five bit flags.
      Dim myBit1 As Integer = BitVector32.CreateMask()
      Dim myBit2 As Integer = BitVector32.CreateMask(myBit1)
      Dim myBit3 As Integer = BitVector32.CreateMask(myBit2)
      Dim myBit4 As Integer = BitVector32.CreateMask(myBit3)
      Dim myBit5 As Integer = BitVector32.CreateMask(myBit4)

      ' Sets the alternating bits to TRUE.
      Console.WriteLine("Setting alternating bits to TRUE:")
      Console.WriteLine("   Initial:         {0}", myBV.ToString())
      myBV(myBit1) = True
      Console.WriteLine("   myBit1 = TRUE:   {0}", myBV.ToString())
      myBV(myBit3) = True
      Console.WriteLine("   myBit3 = TRUE:   {0}", myBV.ToString())
      myBV(myBit5) = True
      Console.WriteLine("   myBit5 = TRUE:   {0}", myBV.ToString())
   End Sub 'Main 
End Class 'SamplesBitVector32


' This code produces the following output.
'
' Setting alternating bits to TRUE:
'    Initial:         BitVector32{00000000000000000000000000000000}
'    myBit1 = TRUE:   BitVector32{00000000000000000000000000000001}
'    myBit3 = TRUE:   BitVector32{00000000000000000000000000000101}
'    myBit5 = TRUE:   BitVector32{00000000000000000000000000010101}

'</snippet1>
