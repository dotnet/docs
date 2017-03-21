      Dim bigIntValue As BigInteger 

      Dim byteValue As Byte = 16
      bigIntValue = New BigInteger(byteValue)
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        byteValue.GetType().Name, byteValue, 
                        bigIntValue.Equals(byteValue))
                        
      Dim sbyteValue As SByte = -16
      bigIntValue = New BigInteger(sbyteValue)
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        sbyteValue.GetType().Name, sbyteValue,
                        bigIntValue.Equals(sbyteValue))
      
      Dim shortValue As Short = 1233
      bigIntValue = New BigInteger(shortValue)
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        shortValue.GetType().Name, shortValue, 
                        bigIntValue.Equals(shortValue))
            
      Dim ushortValue As UShort = 64000
      bigIntValue = New BigInteger(ushortValue)
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        ushortValue.GetType().Name, ushortValue, 
                        bigIntValue.Equals(ushortValue))

      Dim intValue As Integer = -1603854
      bigIntValue = New BigInteger(intValue)
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        intValue.GetType().Name, intValue, 
                        bigIntValue.Equals(intValue))
      
      Dim uintValue As UInteger = 1223300
      bigIntValue = New BigInteger(uintValue)
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        uintValue.GetType().Name, uintValue, 
                        bigIntValue.Equals(uintValue))
      
      Dim longValue As Long = -123822229012
      bigIntValue = New BigInteger(longValue)
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        longValue.GetType().Name, longValue, 
                        bigIntValue.Equals(longValue))
      ' The example displays the following output:
      '    BigInteger 16 = Byte 16 : True
      '    BigInteger -16 = SByte -16 : True
      '    BigInteger 1233 = Int16 1233 : True
      '    BigInteger 64000 = UInt16 64000 : True
      '    BigInteger -1603854 = Int32 -1603854 : True
      '    BigInteger 1223300 = UInt32 1223300 : True
      '    BigInteger -123822229012 = Int64 -123822229012 : True