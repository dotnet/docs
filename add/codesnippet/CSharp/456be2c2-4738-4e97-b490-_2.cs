      // Call parse with default values of style and provider
      Console.WriteLine(BigInteger.Parse("  -300   ", 
                        NumberStyles.Integer, CultureInfo.CurrentCulture));
      // Call parse with default values of style and provider supporting tilde as negative sign
      Console.WriteLine(BigInteger.Parse("   ~300  ", 
                                         NumberStyles.Integer, new BigIntegerFormatProvider()));
      // Call parse with only AllowLeadingWhite and AllowTrailingWhite
      // Exception thrown because of presence of negative sign
      try
      {
         Console.WriteLine(BigInteger.Parse("    ~300   ", 
                                      NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, 
                                      new BigIntegerFormatProvider()));
      }
      catch (FormatException e)
      {
         Console.WriteLine("{0}: \n   {1}", e.GetType().Name, e.Message);
      }                                   
      // Call parse with only AllowHexSpecifier
      // Exception thrown because of presence of negative sign
      try
      {
         Console.WriteLine(BigInteger.Parse("-3af", NumberStyles.AllowHexSpecifier, 
                                            new BigIntegerFormatProvider()));
      }
      catch (FormatException e)
      {
         Console.WriteLine("{0}: \n   {1}", e.GetType().Name, e.Message);
      }                                 
      // Call parse with only NumberStyles.None
      // Exception thrown because of presence of white space and sign
      try
      {
         Console.WriteLine(BigInteger.Parse(" -300 ", NumberStyles.None, 
                                            new BigIntegerFormatProvider()));
      }
      catch (FormatException e)
      {
         Console.WriteLine("{0}: \n   {1}", e.GetType().Name, e.Message);
      }
      // The example displays the followingoutput:
      //       -300
      //       -300
      //       FormatException:
      //          The value could not be parsed.
      //       FormatException:
      //          The value could not be parsed.
      //       FormatException:
      //          The value could not be parsed.      