Module Example
   Public Sub Main()
      Dim positiveValue As UInt32 = 320000000
      Dim negativeValue As Int32 = -1
      
      
      Dim positiveString As New HexString()
      positiveString.Sign = CType(Math.Sign(positiveValue), SignBit)
      positiveString.Value = positiveValue.ToString("X4")
      
      Dim negativeString As New HexString()
      negativeString.Sign = CType(Math.Sign(negativeValue), SignBit)
      negativeString.Value = negativeValue.ToString("X4")
      
      Try
         Console.WriteLine("0x{0} converts to {1}.", positiveString.Value, Convert.ToUInt32(positiveString))
      Catch e As OverflowException
         Console.WriteLine("{0} is outside the range of the UInt32 type.", _
                           Int32.Parse(positiveString.Value, NumberStyles.HexNumber))
      End Try

      Try
         Console.WriteLine("0x{0} converts to {1}.", negativeString.Value, Convert.ToUInt32(negativeString))
      Catch e As OverflowException
         Console.WriteLine("{0} is outside the range of the UInt32 type.", _
                           Int32.Parse(negativeString.Value, NumberStyles.HexNumber))
      End Try   
   End Sub
End Module
' The example dosplays the following output:
'       0x1312D000 converts to 320000000.
'       -1 is outside the range of the UInt32 type.