Module Example
   Public Sub Main()
      Dim positiveValue As UInt64 = CULng(UInt64.MaxValue - 100000)
      Dim negativeValue As Int64 = -1
      
      
      Dim positiveString As New HexString()
      positiveString.Sign = CType(Math.Sign(positiveValue), SignBit)
      positiveString.Value = positiveValue.ToString("X")
      
      Dim negativeString As New HexString()
      negativeString.Sign = CType(Math.Sign(negativeValue), SignBit)
      negativeString.Value = negativeValue.ToString("X")
      
      Try
         Console.WriteLine("0x{0} converts to {1}.", positiveString.Value, Convert.ToUInt64(positiveString))
      Catch e As OverflowException
         Console.WriteLine("{0} is outside the range of the UInt64 type.", _
                           Int64.Parse(positiveString.Value, NumberStyles.HexNumber))
      End Try

      Try
         Console.WriteLine("0x{0} converts to {1}.", negativeString.Value, Convert.ToUInt64(negativeString))
      Catch e As OverflowException
         Console.WriteLine("{0} is outside the range of the UInt64 type.", _
                           Int64.Parse(negativeString.Value, NumberStyles.HexNumber))
      End Try   
   End Sub
End Module
' The example dosplays the following output:
'       0xFFFFFFFFFFFE795F converts to 18446744073709451615.
'       -1 is outside the range of the UInt64 type.