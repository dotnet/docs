      long lNumber = 163245617;
      try {
         int number1 = (int) lNumber;
         Console.WriteLine(number1);
      }
      catch (OverflowException) {
         Console.WriteLine("{0} is out of range of an Int32.", lNumber);
      }
      
      double dbl2 = 35901.997;
      try {
         int number2 = (int) dbl2;
         Console.WriteLine(number2);
      }   
      catch (OverflowException) {
         Console.WriteLine("{0} is out of range of an Int32.", dbl2);
      }
         
      BigInteger bigNumber = 132451;
      try {
         int number3 = (int) bigNumber;
         Console.WriteLine(number3);
      }
      catch (OverflowException) {
         Console.WriteLine("{0} is out of range of an Int32.", bigNumber);
      }    
      // The example displays the following output:
      //       163245617
      //       35902
      //       132451