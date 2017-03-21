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
