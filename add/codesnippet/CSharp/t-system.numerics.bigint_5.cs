      string positiveString = "91389681247993671255432112000000";
      string negativeString = "-90315837410896312071002088037140000";
      BigInteger posBigInt = 0;
      BigInteger negBigInt = 0;

      try {
         posBigInt = BigInteger.Parse(positiveString);
         Console.WriteLine(posBigInt);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to convert the string '{0}' to a BigInteger value.", 
                           positiveString);
      }

      if (BigInteger.TryParse(negativeString, out negBigInt))
        Console.WriteLine(negBigInt);
      else
         Console.WriteLine("Unable to convert the string '{0}' to a BigInteger value.", 
                            negativeString);

      // The example displays the following output:
      //   9.1389681247993671255432112E+31
      //   -9.0315837410896312071002088037E+34