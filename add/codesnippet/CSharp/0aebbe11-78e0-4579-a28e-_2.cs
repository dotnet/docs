      long number1 = 1234567890;
      long number2 = 9876543210;
      try
      {
         long product; 
         product = checked(number1 * number2);
      }
      catch (OverflowException)
      {
         BigInteger product;
         product = BigInteger.Multiply(number1, number2);
         Console.WriteLine(product.ToString());
         }   