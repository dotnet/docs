      BigInteger number = Int64.MaxValue ^ 5;
      int repetitions = 1000000;
      // Perform some repetitive operation 1 million times.
      for (int ctr = 0; ctr <= repetitions; ctr++)
      {
         // Perform some operation. If it fails, exit the loop.
         if (! SomeOperationSucceeds()) break;
         // The following code executes if the operation succeeds.
         number++;
      }