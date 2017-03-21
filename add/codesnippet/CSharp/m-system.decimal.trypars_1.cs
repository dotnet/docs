      string value;
      decimal number;
      
      // Parse a floating-point value with a thousands separator.
      value = "1,643.57";
      if (Decimal.TryParse(value, out number))
         Console.WriteLine(number);
      else
         Console.WriteLine("Unable to parse '{0}'.", value);      
      
      // Parse a floating-point value with a currency symbol and a 
      // thousands separator.
      value = "$1,643.57";
      if (Decimal.TryParse(value, out number))
         Console.WriteLine(number);
      else
         Console.WriteLine("Unable to parse '{0}'.", value);   
      
      // Parse value in exponential notation.
      value = "-1.643e6";
      if (Decimal.TryParse(value, out number))
         Console.WriteLine(number);
      else
         Console.WriteLine("Unable to parse '{0}'.", value);   
      
      // Parse a negative integer value.
      value = "-1689346178821";
      if (Decimal.TryParse(value, out number))
         Console.WriteLine(number);
      else
         Console.WriteLine("Unable to parse '{0}'.", value);   
      // The example displays the following output to the console:
      //       1643.57
      //       Unable to parse '$1,643.57'.
      //       Unable to parse '-1.643e6'.
      //       -1689346178821      