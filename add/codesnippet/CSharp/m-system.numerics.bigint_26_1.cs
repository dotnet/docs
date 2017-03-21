      BigInteger bigIntValue; 

      byte byteValue = 16;
      bigIntValue = new BigInteger(byteValue);
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        byteValue.GetType().Name, byteValue, 
                        bigIntValue.Equals(byteValue));
                        
      sbyte sbyteValue = -16;
      bigIntValue = new BigInteger(sbyteValue);
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        sbyteValue.GetType().Name, sbyteValue,
                        bigIntValue.Equals(sbyteValue));
      
      short shortValue = 1233;
      bigIntValue = new BigInteger(shortValue);
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        shortValue.GetType().Name, shortValue, 
                        bigIntValue.Equals(shortValue));
            
      ushort ushortValue = 64000;
      bigIntValue = new BigInteger(ushortValue);
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        ushortValue.GetType().Name, ushortValue, 
                        bigIntValue.Equals(ushortValue));

      int intValue = -1603854;
      bigIntValue = new BigInteger(intValue);
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        intValue.GetType().Name, intValue, 
                        bigIntValue.Equals(intValue));
      
      uint uintValue = 1223300;
      bigIntValue = new BigInteger(uintValue);
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        uintValue.GetType().Name, uintValue, 
                        bigIntValue.Equals(uintValue));
      
      long longValue = -123822229012;
      bigIntValue = new BigInteger(longValue);
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        longValue.GetType().Name, longValue, 
                        bigIntValue.Equals(longValue));
      // The example displays the following output:
      //    BigInteger 16 = Byte 16 : True
      //    BigInteger -16 = SByte -16 : True
      //    BigInteger 1233 = Int16 1233 : True
      //    BigInteger 64000 = UInt16 64000 : True
      //    BigInteger -1603854 = Int32 -1603854 : True
      //    BigInteger 1223300 = UInt32 1223300 : True
      //    BigInteger -123822229012 = Int64 -123822229012 : True