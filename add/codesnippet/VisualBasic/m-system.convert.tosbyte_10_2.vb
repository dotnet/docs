Module modMain
   Public Sub Main()
      Dim positiveByte As SByte = 120
      Dim negativeByte As SByte = -101
      
      
      Dim positiveString As New ByteString()
      positiveString.Sign = CType(Math.Sign(positiveByte), SignBit)
      positiveString.Value = positiveByte.ToString("X2")
      
      Dim negativeString As New ByteString()
      negativeString.Sign = CType(Math.Sign(negativeByte), SignBit)
      negativeString.Value = negativeByte.ToString("X2")
      
      Try
         Console.WriteLine("'{0}' converts to {1}.", positiveString.Value, Convert.ToSByte(positiveString))
      Catch e As OverflowException
         Console.WriteLine("0x{0} is outside the range of the Byte type.", positiveString.Value)
      End Try

      Try
         Console.WriteLine("'{0}' converts to {1}.", negativeString.Value, Convert.ToSByte(negativeString))
      Catch e As OverflowException
         Console.WriteLine("0x{0} is outside the range of the Byte type.", negativeString.Value)
      End Try   
   End Sub
End Module
' The example dosplays the following output:
'       '78' converts to 120.
'       '9B' converts to -101.