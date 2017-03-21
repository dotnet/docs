      Dim bigIntValue As BigInteger = BigInteger.Parse("3221123045552")

      Dim byteValue As Byte = 16
      Dim sbyteValue As SByte = -16
      Dim shortValue As Short = 1233      
      Dim ushortValue As UShort = 1233
      Dim intValue As Integer = -12233
      Dim uintValue As UInteger = 12233
      Dim longValue As Long = 12382222
      Dim ulongValue As Integer = 1238222

      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, byteValue, _
                        bigIntValue.CompareTo(byteValue))
      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, sbyteValue, _
                        bigIntValue.CompareTo(sbyteValue)) 
      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, shortValue, _
                        bigIntValue.CompareTo(shortValue)) 
      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, ushortValue, _
                        bigIntValue.CompareTo(ushortValue)) 
      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, intValue, _
                        bigIntValue.CompareTo(intValue)) 
      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, uintValue, _
                        bigIntValue.CompareTo(uintValue)) 
      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, longValue, _
                        bigIntValue.CompareTo(longValue)) 
      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, ulongValue, _
                        bigIntValue.CompareTo(ulongValue))
      ' The example displays the following output:
      '       Comparing 3221123045552 with 16: 1
      '       Comparing 3221123045552 with -16: 1
      '       Comparing 3221123045552 with 1233: 1
      '       Comparing 3221123045552 with 1233: 1
      '       Comparing 3221123045552 with -12233: 1
      '       Comparing 3221123045552 with 12233: 1
      '       Comparing 3221123045552 with 12382222: 1
      '       Comparing 3221123045552 with 1238222: 1