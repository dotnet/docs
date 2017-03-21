      BigInteger bigIntValue = BigInteger.Parse("3221123045552");

      byte byteValue = 16;
      sbyte sbyteValue = -16;
      short shortValue = 1233;      
      ushort ushortValue = 1233;
      int intValue = -12233;
      uint uintValue = 12233;
      long longValue = 12382222;
      ulong ulongValue = 1238222;

      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, byteValue, 
                        bigIntValue.CompareTo(byteValue));
      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, sbyteValue, 
                        bigIntValue.CompareTo(sbyteValue)); 
      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, shortValue, 
                        bigIntValue.CompareTo(shortValue));
      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, ushortValue, 
                        bigIntValue.CompareTo(ushortValue)); 
      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, intValue, 
                        bigIntValue.CompareTo(intValue));
      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, uintValue, 
                        bigIntValue.CompareTo(uintValue)); 
      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, longValue, 
                        bigIntValue.CompareTo(longValue));
      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, ulongValue, 
                        bigIntValue.CompareTo(ulongValue));
      // The example displays the following output:
      //       Comparing 3221123045552 with 16: 1
      //       Comparing 3221123045552 with -16: 1
      //       Comparing 3221123045552 with 1233: 1
      //       Comparing 3221123045552 with 1233: 1
      //       Comparing 3221123045552 with -12233: 1
      //       Comparing 3221123045552 with 12233: 1
      //       Comparing 3221123045552 with 12382222: 1
      //       Comparing 3221123045552 with 1238222: 1