      Dim values() As Object = { BigInteger.Pow(Int64.MaxValue, 10), Nothing, 
                                 12.534, Int64.MaxValue, BigInteger.One }
      Dim number As BigInteger = UInt64.MaxValue
      
      For Each value As Object In values
         Try
            Console.WriteLine("Comparing {0} with '{1}': {2}", number, value, 
                              number.CompareTo(value))
         Catch e As ArgumentException
            Console.WriteLine("Unable to compare the {0} value {1} with a BigInteger.",
                              value.GetType().Name, value)
         End Try                     
      Next                                 
      ' The example displays the following output:
      '    Comparing 18446744073709551615 with '4.4555084156466750133735972424E+189': -1
      '    Comparing 18446744073709551615 with '': 1
      '    Unable to compare the Double value 12.534 with a BigInteger.
      '    Unable to compare the Int64 value 9223372036854775807 with a BigInteger.
      '    Comparing 18446744073709551615 with '1': 1