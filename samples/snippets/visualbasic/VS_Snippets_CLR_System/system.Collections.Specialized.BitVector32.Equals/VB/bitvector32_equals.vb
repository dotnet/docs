' The following code example compares a BitVector32 with another BitVector32 and with an Int32.

' <snippet1>
Imports System
Imports System.Collections.Specialized


Public Class SamplesBitVector32

   Public Shared Sub Main()
      
      ' Creates and initializes a BitVector32 with the value 123.
      ' This is the BitVector32 that will be compared to different types.
      Dim myBV As New BitVector32(123)
      
      ' Creates and initializes a new BitVector32 which will be set up as sections.
      Dim myBVsect As New BitVector32(0)
      
      ' Compares myBV and myBVsect.
      Console.WriteLine("myBV                 : {0}", myBV.ToString())
      Console.WriteLine("myBVsect             : {0}", myBVsect.ToString())
      If myBV.Equals(myBVsect) Then
         Console.WriteLine("   myBV({0}) equals myBVsect({1}).", myBV.Data, myBVsect.Data)
      Else
         Console.WriteLine("   myBV({0}) does not equal myBVsect({1}).", myBV.Data, myBVsect.Data)
      End If
      Console.WriteLine()
      
      ' Assigns values to the sections of myBVsect.
      Dim mySect1 As BitVector32.Section = BitVector32.CreateSection(5)
      Dim mySect2 As BitVector32.Section = BitVector32.CreateSection(1, mySect1)
      Dim mySect3 As BitVector32.Section = BitVector32.CreateSection(20, mySect2)
      myBVsect(mySect1) = 3
      myBVsect(mySect2) = 1
      myBVsect(mySect3) = 7
      
      ' Compares myBV and myBVsect.
      Console.WriteLine("myBV                 : {0}", myBV.ToString())
      Console.WriteLine("myBVsect with values : {0}", myBVsect.ToString())
      If myBV.Equals(myBVsect) Then
         Console.WriteLine("   myBV({0}) equals myBVsect({1}).", myBV.Data, myBVsect.Data)
      Else
         Console.WriteLine("   myBV({0}) does not equal myBVsect({1}).", myBV.Data, myBVsect.Data)
      End If
      Console.WriteLine()
      
      ' Compare myBV with an Int32.
      Console.WriteLine("Comparing myBV with an Int32: ")
      Dim myInt32 As Int32 = 123
      ' Using Equals will fail because Int32 is not compatible with BitVector32.
      If myBV.Equals(myInt32) Then
         Console.WriteLine("   Using BitVector32.Equals, myBV({0}) equals myInt32({1}).", myBV.Data, myInt32)
      Else
         Console.WriteLine("   Using BitVector32.Equals, myBV({0}) does not equal myInt32({1}).", myBV.Data, myInt32)
      End If ' To compare a BitVector32 with an Int32, use the "==" operator.
      If myBV.Data = myInt32 Then
         Console.WriteLine("   Using the ""=="" operator, myBV.Data({0}) equals myInt32({1}).", myBV.Data, myInt32)
      Else
         Console.WriteLine("   Using the ""=="" operator, myBV.Data({0}) does not equal myInt32({1}).", myBV.Data, myInt32)
      End If 

   End Sub 'Main

End Class 'SamplesBitVector32 


' This code produces the following output.
'
' myBV                 : BitVector32{00000000000000000000000001111011}
' myBVsect             : BitVector32{00000000000000000000000000000000}
'    myBV(123) does not equal myBVsect(0).
'
' myBV                 : BitVector32{00000000000000000000000001111011}
' myBVsect with values : BitVector32{00000000000000000000000001111011}
'    myBV(123) equals myBVsect(123).
'
' Comparing myBV with an Int32:
'    Using BitVector32.Equals, myBV(123) does not equal myInt32(123).
'    Using the "==" operator, myBV.Data(123) equals myInt32(123).
' </snippet1>