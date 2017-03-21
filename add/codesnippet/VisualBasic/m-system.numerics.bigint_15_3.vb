      Dim originalNumber As ULong = UInt64.MaxValue
      ' Convert an unsigned integer to a byte array.
      Dim bytes() As Byte = BitConverter.GetBytes(originalNumber)
      ' Determine whether the MSB of the highest-order byte is set.
      If originalNumber > 0 And (bytes(bytes.Length - 1) And &h80) > 0 Then
         ' If the MSB is set, add one zero-value byte to the end of the array.
         ReDim Preserve bytes(bytes.Length)
      End If
      
      Dim newNumber As New BigInteger(bytes)
      Console.WriteLine("Converted the UInt64 value {0:N0} to {1:N0}.", 
                        originalNumber, newNumber) 
      ' The example displays the following output:
      '    Converted the UInt64 value 18,446,744,073,709,551,615 to 18,446,744,073,709,551,615.