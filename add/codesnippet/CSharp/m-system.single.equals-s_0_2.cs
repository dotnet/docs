      // Initialize two floats with apparently identical values
      float float1 = .33333f;
      float float2 = (float) 1/3;
      // Define the tolerance for variation in their values
      float difference = Math.Abs(float1 * .0001f);

      // Compare the values
      // The output to the console indicates that the two values are equal
      if (Math.Abs(float1 - float2) <= difference)
         Console.WriteLine("float1 and float2 are equal.");
      else
         Console.WriteLine("float1 and float2 are unequal.");