      ulong ulNumber = 163245617943825;
      try {
         long number1 = (long) ulNumber;
         Console.WriteLine(number1);
      }
      catch (OverflowException) {
         Console.WriteLine("{0} is out of range of an Int64.", ulNumber);
      }
      
      double dbl2 = 35901.997;
      try {
         long number2 = (long) dbl2;
         Console.WriteLine(number2);
      }   
      catch (OverflowException) {
         Console.WriteLine("{0} is out of range of an Int64.", dbl2);
      }
         
      BigInteger bigNumber = (BigInteger) 1.63201978555e30;
      try {
         long number3 = (long) bigNumber;
         Console.WriteLine(number3);
      }
      catch (OverflowException) {
         Console.WriteLine("{0} is out of range of an Int64.", bigNumber);
      }    
      // The example displays the following output:
      //    163245617943825
      //    35902
      //    1,632,019,785,549,999,969,612,091,883,520 is out of range of an Int64.