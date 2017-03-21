      ' Call parse with default values of style and provider
      Console.WriteLine(BigInteger.Parse("  -300   ", _
                        NumberStyles.Integer, CultureInfo.CurrentCulture))
      ' Call parse with default values of style and provider supporting tilde as negative sign
      Console.WriteLine(BigInteger.Parse("   ~300  ", _
                                         NumberStyles.Integer, New BigIntegerFormatProvider()))
      ' Call parse with only AllowLeadingWhite and AllowTrailingWhite
      ' Exception thrown because of presence of negative sign
      Try
         Console.WriteLIne(BigInteger.Parse("    ~300   ", _
                                            NumberStyles.AllowLeadingWhite Or NumberStyles.AllowTrailingWhite, _
                                            New BigIntegerFormatProvider()))
      Catch e As FormatException
         Console.WriteLine("{0}: {1}   {2}", e.GetType().Name, vbCrLf, e.Message)
      End Try                                   
      ' Call parse with only AllowHexSpecifier
      ' Exception thrown because of presence of negative sign
      Try
         Console.WriteLIne(BigInteger.Parse("-3af", NumberStyles.AllowHexSpecifier, _
                                            New BigIntegerFormatProvider()))
      Catch e As FormatException
         Console.WriteLine("{0}: {1}   {2}", e.GetType().Name, vbCrLf, e.Message)
      End Try                                 
      ' Call parse with only NumberStyles.None
      ' Exception thrown because of presence of white space and sign
      Try
         Console.WriteLIne(BigInteger.Parse(" -300 ", NumberStyles.None, _
                                            New BigIntegerFormatProvider()))
      Catch e As FormatException
         Console.WriteLine("{0}: {1}   {2}", e.GetType().Name, vbCrLf, e.Message)
      End Try
      ' The example displays the following output:
      '       -300
      '       -300
      '       FormatException:
      '          The value could not be parsed.
      '       FormatException:
      '          The value could not be parsed.
      '       FormatException:
      '          The value could not be parsed.            