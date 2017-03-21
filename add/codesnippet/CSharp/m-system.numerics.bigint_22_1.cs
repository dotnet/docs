      BigInteger number1, number2;
      bool succeeded1 = BigInteger.TryParse("-12347534159895123", out number1);
      bool succeeded2 = BigInteger.TryParse("987654321357159852", out number2);
      if (succeeded1 && succeeded2)
      {
         number1 *= 3;
         number2 *= 2;
         switch (BigInteger.Compare(number1, number2))
         {
            case -1:
               Console.WriteLine("{0} is greater than {1}.", number2, number1);
               break;
            case 0:
               Console.WriteLine("{0} is equal to {1}.", number1, number2);
               break;
            case 1:
               Console.WriteLine("{0} is greater than {1}.", number1, number2);
               break;
         }      
      }
      else
      {
         if (! succeeded1) 
            Console.WriteLine("Unable to initialize the first BigInteger value.");

         if (! succeeded2)
            Console.WriteLine("Unable to initialize the second BigInteger value.");
      }
      // The example displays the following output:
      //      1975308642714319704 is greater than -37042602479685369.