Module Example
   Public Sub Main()
      Dim positiveValue As UInt16 = 32000
      Dim negativeValue As Int16 = -1
      
      
      Dim positiveString As New HexString()
      positiveString.Sign = CType(Math.Sign(positiveValue), SignBit)
      positiveString.Value = positiveValue.ToString("X4")
      
      Dim negativeString As New HexString()
      negativeString.Sign = CType(Math.Sign(negativeValue), SignBit)
      negativeString.Value = negativeValue.ToString("X4")
      
      Try
         Console.WriteLine("0x{0} converts to {1}.", positiveString.Value, Convert.ToUInt16(positiveString))
      Catch e As OverflowException
         Console.WriteLine("{0} is outside the range of the UInt16 type.", _
                           Int16.Parse(positiveString.Value, NumberStyles.HexNumber))
      End Try

      Try
         Console.WriteLine("0x{0} converts to {1}.", negativeString.Value, Convert.ToUInt16(negativeString))
      Catch e As OverflowException
         Console.WriteLine("{0} is outside the range of the UInt16 type.", _
                           Int16.Parse(negativeString.Value, NumberStyles.HexNumber))
      End Try   
   End Sub
End Module
' The example dosplays the following output:
'       0x7D00 converts to 32000.
'       -1 is outside the range of the UInt16 type.