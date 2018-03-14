' Visual Basic .NET Document
Option Strict On

Module modMain

   Public Sub Main()
      ConvertHexToNegativeInteger()
      Console.WriteLine()
      ConvertHexToInteger()
      Console.WriteLine()
      ConvertNegativeHexToByte()
      Console.WRiteLine()
      ConvertHexToByte()
      Console.WriteLine()
      ConvertHexToNegativeShort()
      Console.WriteLine()
      ConvertHexToShort()
      Console.WriteLine()
      ConvertHexToNegativeLong()
      Console.WriteLine()
      ConvertHexToLong()
      Console.WriteLine()
      ConvertHexToNegativeSByte()
      Console.WriteLine()
      ConvertHexToSByte()
      Console.WriteLine()
      ConvertNegativeHexToUInt16()
      Console.WRiteLine()
      ConvertHexToUInt16()
      Console.WriteLine()
      ConvertNegativeHexToUInt32()
      Console.WRiteLine()
      ConvertHexToUInt32()
      Console.WriteLine()
      ConvertNegativeHexToUInt64()
      Console.WRiteLine()
      ConvertHexToUInt64()
   End Sub
   
   Private Sub ConvertHexToNegativeInteger()
     ' <Snippet1>
     ' Create a hexadecimal value out of range of the Integer type.
     Dim value As String = Convert.ToString(CLng(Integer.MaxValue) + 1, 16)
     ' Convert it back to a number.
     Try
        Dim number As Integer = Convert.ToInt32(value, 16)
        Console.WriteLine("0x{0} converts to {1}.", value, number)
     Catch e As OverflowException
        Console.WriteLine("Unable to convert '0x{0}' to an integer.", value)
     End Try   
     ' </Snippet1>
   End Sub
   
   Private Sub ConvertHexToInteger()
      ' <Snippet2>
      ' Create a hexadecimal value out of range of the Integer type.
      Dim sourceNumber As Long = CLng(Integer.MaxValue) + 1
      Dim isNegative As Boolean = (Math.Sign(sourceNumber) = -1)
      Dim value As String = Convert.ToString(sourceNumber, 16)
      Dim targetNumber As Integer
      Try
         targetNumber = Convert.ToInt32(value, 16)
         If Not isNegative And ((targetNumber And &H80000000) <> 0) Then
            Throw New OverflowException()
         Else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber)
         End If    
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to an integer.", value)
      End Try 
      ' Displays the following to the console:
      '    Unable to convert '0x80000000' to an integer.     
      ' </Snippet2>
   End Sub
   
   Private Sub ConvertNegativeHexToByte()
      ' <Snippet3>
      ' Create a hexadecimal value out of range of the Byte type.
      Dim value As String = SByte.MinValue.ToString("X")
      ' Convert it back to a number.
      Try
         Dim number As Byte = Convert.ToByte(value, 16)
         Console.WriteLine("0x{0} converts to {1}.", value, number)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to a byte.", value)
      End Try   
      ' </Snippet3>
   End Sub

   Private Sub ConvertHexToByte()
      ' <Snippet4>
      ' Create a negative hexadecimal value out of range of the Byte type.
      Dim sourceNumber As SByte = SByte.MinValue
      Dim isSigned As Boolean = Math.Sign(sourceNumber.MinValue) = -1
      Dim value As String = sourceNumber.ToString("X")
      Dim targetNumber As Byte
      Try
         targetNumber = Convert.ToByte(value, 16)
         If isSigned And ((targetNumber And &H80) <> 0) Then
            Throw New OverflowException()
         Else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber)
         End If    
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned byte.", value)
      End Try 
      ' Displays the following to the console:
      '    Unable to convert '0x80' to an unsigned byte.     
      ' </Snippet4>
   End Sub
  
   Private Sub ConvertHexToNegativeShort()
     ' <Snippet5>
     ' Create a hexadecimal value out of range of the Int16 type.
     Dim value As String = Convert.ToString(CInt(Short.MaxValue) + 1, 16)
     ' Convert it back to a number.
     Try
        Dim number As Short = Convert.ToInt16(value, 16)
        Console.WriteLine("0x{0} converts to {1}.", value, number)
     Catch e As OverflowException
        Console.WriteLine("Unable to convert '0x{0}' to a 16-bit integer.", value)
     End Try   
     ' </Snippet5>
   End Sub
   
   Private Sub ConvertHexToShort()
      ' <Snippet6>
      ' Create a hexadecimal value out of range of the Short type.
      Dim sourceNumber As Integer = CInt(Short.MaxValue) + 1
      Dim isNegative As Boolean = (Math.Sign(sourceNumber) = -1)
      Dim value As String = Convert.ToString(sourceNumber, 16)
      Dim targetNumber As Short
      Try
         targetNumber = Convert.ToInt16(value, 16)
         If Not isNegative And ((targetNumber And &H8000) <> 0) Then
            Throw New OverflowException()
         Else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber)
         End If    
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to a 16-bit integer.", value)
      End Try 
      ' Displays the following to the console:
      '    Unable to convert '0x8000' to a 16-bit integer.     
      ' </Snippet6>
   End Sub

   Private Sub ConvertHexToNegativeLong()
      ' <Snippet7>
      ' Create a hexadecimal value out of range of the Long type.
      Dim value As String = ULong.MaxValue.ToString("X")
      ' Call Convert.ToInt64 to convert it back to a number.
      Try
         Dim number As Long = Convert.ToInt64(value, 16)
         Console.WriteLine("0x{0} converts to {1}.", value, number)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to a long integer.", value)
      End Try   
      ' </Snippet7>
   End Sub

   Private Sub ConvertHexToLong()
      ' <Snippet8>
      ' Create a negative hexadecimal value out of range of the Long type.
      Dim sourceNumber As ULong = ULong.MaxValue
      Dim isSigned As Boolean = Math.Sign(sourceNumber.MinValue) = -1
      Dim value As String = sourceNumber.ToString("X")
      Dim targetNumber As Long
      Try
         targetNumber = Convert.ToInt64(value, 16)
         If Not isSigned And ((targetNumber And &H8000000000) <> 0) Then
            Throw New OverflowException()
         Else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber)
         End If    
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to a long integer.", value)
      End Try 
      ' Displays the following to the console:
      '    Unable to convert '0xFFFFFFFFFFFFFFFF' to a long integer.     
      ' </Snippet8>
   End Sub
   
   Private Sub ConvertHexToNegativeSByte()
      ' <Snippet9>
      ' Create a hexadecimal value out of range of the SByte type.
      Dim value As String = Convert.ToString(Byte.MaxValue, 16)
      ' Convert it back to a number.
      Try
         Dim number As SByte = Convert.ToSByte(value, 16)
         Console.WriteLine("0x{0} converts to {1}.", value, number)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to a signed byte.", value)
      End Try   
      ' </Snippet9>
   End Sub

   Private Sub ConvertHexToSByte()
      ' <Snippet10>
      ' Create a negative hexadecimal value out of range of the Long type.
      Dim sourceNumber As Byte = Byte.MaxValue
      Dim isSigned As Boolean = Math.Sign(sourceNumber.MinValue) = -1
      Dim value As String = Convert.ToString(sourceNumber, 16)
      Dim targetNumber As SByte
      Try
         targetNumber = Convert.ToSByte(value, 16)
         If Not isSigned And ((targetNumber And &H80) <> 0) Then
            Throw New OverflowException()
         Else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber)
         End If    
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to a signed byte.", value)
      End Try 
      ' Displays the following to the console:
      '    Unable to convert '0xff' to a signed byte.     
      ' </Snippet10>
   End Sub
 
    Private Sub ConvertNegativeHexToUInt16()
      ' <Snippet11>
      ' Create a hexadecimal value out of range of the UInt16 type.
      Dim value As String = Convert.ToString(Short.MinValue, 16)
      ' Convert it back to a number.
      Try
         Dim number As UInt16 = Convert.ToUInt16(value, 16)
         Console.WriteLine("0x{0} converts to {1}.", value, number)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned short integer.", _
                           value)
      End Try   
      ' </Snippet11>
   End Sub

   Private Sub ConvertHexToUInt16()
      ' <Snippet12>
      ' Create a negative hexadecimal value out of range of the UInt16 type.
      Dim sourceNumber As Short = Short.MinValue
      Dim isSigned As Boolean = Math.Sign(sourceNumber.MinValue) = -1
      Dim value As String = Convert.ToString(sourceNumber, 16)
      Dim targetNumber As UInt16
      Try
         targetNumber = Convert.ToUInt16(value, 16)
         If isSigned And ((targetNumber And &H8000) <> 0) Then
            Throw New OverflowException()
         Else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber)
         End If    
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned short integer.", _
                           value)
      End Try 
      ' Displays the following to the console:
      '    Unable to convert '0x8000' to an unsigned short integer.     
      ' </Snippet12>
   End Sub
  
    Private Sub ConvertNegativeHexToUInt32()
      ' <Snippet13>
      ' Create a hexadecimal value out of range of the UInt32 type.
      Dim value As String = Convert.ToString(Integer.MinValue, 16)
      ' Convert it back to a number.
      Try
         Dim number As UInt32 = Convert.ToUInt32(value, 16)
         Console.WriteLine("0x{0} converts to {1}.", value, number)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned integer.", _
                           value)
      End Try   
      ' </Snippet13>
   End Sub

   Private Sub ConvertHexToUInt32()
      ' <Snippet14>
      ' Create a negative hexadecimal value out of range of the UInt32 type.
      Dim sourceNumber As Integer = Integer.MinValue
      Dim isSigned As Boolean = Math.Sign(sourceNumber.MinValue) = -1
      Dim value As String = Convert.ToString(sourceNumber, 16)
      Dim targetNumber As UInt32
      Try
         targetNumber = Convert.ToUInt32(value, 16)
         If isSigned And ((targetNumber And &H80000000) <> 0) Then
            Throw New OverflowException()
         Else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber)
         End If    
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned integer.", _
                           value)
      End Try 
      ' Displays the following to the console:
      '    Unable to convert '0x80000000' to an unsigned integer.    
      ' </Snippet14>
   End Sub
   
    Private Sub ConvertNegativeHexToUInt64()
      ' <Snippet15>
      ' Create a hexadecimal value out of range of the UInt64 type.
      Dim value As String = Convert.ToString(Long.MinValue, 16)
      ' Convert it back to a number.
      Try
         Dim number As UInt64 = Convert.ToUInt64(value, 16)
         Console.WriteLine("0x{0} converts to {1}.", value, number)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned long integer.", _
                           value)
      End Try   
      ' </Snippet15>
   End Sub

   Private Sub ConvertHexToUInt64()
      ' <Snippet16>
      ' Create a negative hexadecimal value out of range of the UInt64 type.
      Dim sourceNumber As Long = Long.MinValue
      Dim isSigned As Boolean = Math.Sign(sourceNumber.MinValue) = -1
      Dim value As String = Convert.ToString(sourceNumber, 16)
      Dim targetNumber As UInt64
      Try
         targetNumber = Convert.ToUInt64(value, 16)
         If isSigned And ((targetNumber And &H8000000000000000ul) <> 0) Then
            Throw New OverflowException()
         Else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber)
         End If    
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned long integer.", _
                           value)
      End Try 
      ' Displays the following to the console:
      '    Unable to convert '0x8000' to an unsigned long integer.     
      ' </Snippet16>
   End Sub
   
End Module

