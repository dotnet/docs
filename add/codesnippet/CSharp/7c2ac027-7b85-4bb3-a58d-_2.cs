      BigInteger number; 
      // Method should succeed (white space and sign allowed)
      number = BigInteger.Parse("   -68054   ", NumberStyles.Integer);
      Console.WriteLine(number);
      // Method should succeed (string interpreted as hexadecimal)
      number = BigInteger.Parse("68054", NumberStyles.AllowHexSpecifier);
      Console.WriteLine(number);
      // Method call should fail: sign not allowed
      try
      {
         number = BigInteger.Parse("   -68054  ", NumberStyles.AllowLeadingWhite 
                                                  | NumberStyles.AllowTrailingWhite);
         Console.WriteLine(number);
      }   
      catch (FormatException e)
      {
         Console.WriteLine(e.Message);
      }                                                     
      // Method call should fail: white space not allowed
      try
      {
         number = BigInteger.Parse("   68054  ", NumberStyles.AllowLeadingSign);
         Console.WriteLine(number);
      }
      catch (FormatException e)
      {
         Console.WriteLine(e.Message);
      }    
      //
      // The method produces the following output:
      //
      //     -68054
      //     426068
      //     Input string was not in a correct format.
      //     Input string was not in a correct format.                                                 