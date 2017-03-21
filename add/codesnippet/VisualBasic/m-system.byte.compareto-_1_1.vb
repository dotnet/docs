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