      // Initialize two doubles with apparently identical values
      double double1 = .333333;
      double double2 = (double) 1/3;
      // Define the tolerance for variation in their values
      double difference = Math.Abs(double1 * .00001);

      // Compare the values
      // The output to the console indicates that the two values are equal
      if (Math.Abs(double1 - double2) <= difference)
         Console.WriteLine("double1 and double2 are equal.");
      else
         Console.WriteLine("double1 and double2 are unequal.");