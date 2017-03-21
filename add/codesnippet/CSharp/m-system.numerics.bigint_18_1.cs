      uint[] unsignedValues = { 0, 16704, 199365, UInt32.MaxValue };
      foreach (uint unsignedValue in unsignedValues)
      {
         BigInteger constructedNumber = new BigInteger(unsignedValue);
         BigInteger assignedNumber = unsignedValue;
         if (constructedNumber.Equals(assignedNumber))
            Console.WriteLine("Both methods create a BigInteger whose value is {0:N0}.",
                              constructedNumber);
         else
            Console.WriteLine("{0:N0} ≠ {1:N0}", constructedNumber, assignedNumber);

      }
      // The example displays the following output:
      //    Both methods create a BigInteger whose value is 0.
      //    Both methods create a BigInteger whose value is 16,704.
      //    Both methods create a BigInteger whose value is 199,365.
      //    Both methods create a BigInteger whose value is 4,294,967,295.