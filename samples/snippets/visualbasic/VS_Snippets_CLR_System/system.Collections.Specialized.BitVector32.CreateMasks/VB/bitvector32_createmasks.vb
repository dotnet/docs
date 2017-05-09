' The following code example shows how to create and use masks.

' <snippet1>
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
      Console.WriteLine("Initial:               " + ControlChars.Tab + "{0}", myBV.ToString())
      
      ' Sets the third bit to TRUE.
      myBV(myBit3) = True
      Console.WriteLine("myBit3 = TRUE          " + ControlChars.Tab + "{0}", myBV.ToString())
      
      ' Combines two masks to access multiple bits at a time.
      myBV((myBit4 + myBit5)) = True
      Console.WriteLine("myBit4 + myBit5 = TRUE " + ControlChars.Tab + "{0}", myBV.ToString())
      myBV((myBit1 Or myBit2)) = True
      Console.WriteLine("myBit1 | myBit2 = TRUE " + ControlChars.Tab + "{0}", myBV.ToString())

   End Sub 'Main 

End Class 'SamplesBitVector32


' This code produces the following output.
'
' Initial:                BitVector32{00000000000000000000000000000000}
' myBit3 = TRUE           BitVector32{00000000000000000000000000000100}
' myBit4 + myBit5 = TRUE  BitVector32{00000000000000000000000000011100}
' myBit1 | myBit2 = TRUE  BitVector32{00000000000000000000000000011111}
' </snippet1>