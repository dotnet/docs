' The following code example uses a BitVector32 as a collection of sections.


' <snippet1>
Imports System
Imports System.Collections.Specialized

Public Class SamplesBitVector32
   
   Public Shared Sub Main()
      
      ' Creates and initializes a BitVector32.
      Dim myBV As New BitVector32(0)
      
      ' Creates four sections in the BitVector32 with maximum values 6, 3, 1, and 15.
      ' mySect3, which uses exactly one bit, can also be used as a bit flag.
      Dim mySect1 As BitVector32.Section = BitVector32.CreateSection(6)
      Dim mySect2 As BitVector32.Section = BitVector32.CreateSection(3, mySect1)
      Dim mySect3 As BitVector32.Section = BitVector32.CreateSection(1, mySect2)
      Dim mySect4 As BitVector32.Section = BitVector32.CreateSection(15, mySect3)
      
      ' Displays the values of the sections.
      Console.WriteLine("Initial values:")
      Console.WriteLine(ControlChars.Tab + "mySect1: {0}", myBV(mySect1))
      Console.WriteLine(ControlChars.Tab + "mySect2: {0}", myBV(mySect2))
      Console.WriteLine(ControlChars.Tab + "mySect3: {0}", myBV(mySect3))
      Console.WriteLine(ControlChars.Tab + "mySect4: {0}", myBV(mySect4))
      
      ' Sets each section to a new value and displays the value of the BitVector32 at each step.
      Console.WriteLine("Changing the values of each section:")
      Console.WriteLine(ControlChars.Tab + "Initial:    " + ControlChars.Tab + "{0}", myBV.ToString())
      myBV(mySect1) = 5
      Console.WriteLine(ControlChars.Tab + "mySect1 = 5:" + ControlChars.Tab + "{0}", myBV.ToString())
      myBV(mySect2) = 3
      Console.WriteLine(ControlChars.Tab + "mySect2 = 3:" + ControlChars.Tab + "{0}", myBV.ToString())
      myBV(mySect3) = 1
      Console.WriteLine(ControlChars.Tab + "mySect3 = 1:" + ControlChars.Tab + "{0}", myBV.ToString())
      myBV(mySect4) = 9
      Console.WriteLine(ControlChars.Tab + "mySect4 = 9:" + ControlChars.Tab + "{0}", myBV.ToString())
      
      ' Displays the values of the sections.
      Console.WriteLine("New values:")
      Console.WriteLine(ControlChars.Tab + "mySect1: {0}", myBV(mySect1))
      Console.WriteLine(ControlChars.Tab + "mySect2: {0}", myBV(mySect2))
      Console.WriteLine(ControlChars.Tab + "mySect3: {0}", myBV(mySect3))
      Console.WriteLine(ControlChars.Tab + "mySect4: {0}", myBV(mySect4))

   End Sub 'Main 

End Class 'SamplesBitVector32


' This code produces the following output.
'
' Initial values:
'        mySect1: 0
'        mySect2: 0
'        mySect3: 0
'        mySect4: 0
' Changing the values of each section:
'        Initial:        BitVector32{00000000000000000000000000000000}
'        mySect1 = 5:    BitVector32{00000000000000000000000000000101}
'        mySect2 = 3:    BitVector32{00000000000000000000000000011101}
'        mySect3 = 1:    BitVector32{00000000000000000000000000111101}
'        mySect4 = 9:    BitVector32{00000000000000000000001001111101}
' New values:
'        mySect1: 5
'        mySect2: 3
'        mySect3: 1
'        mySect4: 9
' </snippet1>
