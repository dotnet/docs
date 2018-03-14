Imports System


Namespace SystemByte_Examples
    _
   '/ <summary>
   '/ Summary description for Class1.
   '/ </summary>
   Class Class1

      Overloads Shared Sub Main(ByVal args() As String)
         Dim sbe As New SystemByteExamples()
         Dim numberToSet As Integer
         Dim compareByte As [Byte]
         Dim stringToConvert As [String]

         numberToSet = 120
         stringToConvert = "200"
         compareByte = 201

         sbe.MinMaxFields(numberToSet)
         sbe.ParseByte()

         sbe.Compare(compareByte)
      End Sub 'Main
   End Class 'Class1
    _

   Class SystemByteExamples
      Private MemberByte As [Byte]


      ' c'tor()
      Public Sub New()
         MemberByte = 0
      End Sub 'New


      ' The following example demonstrates using the MinValue and MaxValue fields to
      '  determine whether an integer value falls within range of a byte.  If it does,
      '  the value is set.  If not, an error message is displayed.
      ' MemberByte is assumed to exist as a class member.
      '<Snippet1>
      Public Sub MinMaxFields(ByVal numberToSet As Integer)
         If numberToSet <= CInt([Byte].MaxValue) And numberToSet >= CInt([Byte].MinValue) Then
            ' You must explicitly convert an integer to a byte.
            MemberByte = CType(numberToSet, [Byte])

            ' Displays MemberByte using the ToString() method.
            Console.WriteLine("The MemberByte value is {0}.", MemberByte.ToString())
         Else
            Console.WriteLine("The value {0} is outside of the range of possible Byte values.", numberToSet.ToString())
         End If
      End Sub 'MinMaxFields

      '</Snippet1>
      ' The following example converts the string representation of a byte
      '  into its actual numeric value.
      ' MemberByte is assumed to exist as a class member.
      Public Sub ParseByte()
         ' <Snippet2>
         Dim stringToConvert As String = " 162"
         Dim byteValue As Byte
         Try
            byteValue  = Byte.Parse(stringToConvert)
            Console.WriteLine("The byte value is {0}.", byteValue.ToString())
         Catch e As System.OverflowException
            Console.WriteLine("Exception: {0}", e.Message)
         End Try
      ' </Snippet2>
      End Sub 'ParseByte

      ' The following example checks to see whether a byte passed in is
      '  greater than, less than, or equal to the member byte.
      ' MemberByte is assumed to exist as a class member.
      '<Snippet3>
      Public Sub Compare(ByVal myByte As [Byte])
         Dim myCompareResult As Integer

         myCompareResult = MemberByte.CompareTo(myByte)

         If myCompareResult > 0 Then
            Console.WriteLine("{0} is less than the MemberByte value {1}", myByte.ToString(), MemberByte.ToString())
         Else
            If myCompareResult < 0 Then
               Console.WriteLine("{0} is greater than the MemberByte value {1}", myByte.ToString(), MemberByte.ToString())
            Else
               Console.WriteLine("{0} is equal to the MemberByte value {1}", myByte.ToString(), MemberByte.ToString())
            End If
         End If
      End Sub 'Compare 
      '</Snippet3>
   End Class 'SystemByteExamples
End Namespace 'SystemByte_Examples
