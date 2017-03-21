      string value;
      decimal number;
      NumberStyles style;
      
      // Parse string with a floating point value using NumberStyles.None. 
      value = "8694.12";
      style = NumberStyles.None;
      try
      {
         number = Decimal.Parse(value, style);  
         Console.WriteLine("'{0}' converted to {1}.", value, number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", value);
      }
      // Displays:
      //    Unable to parse '8694.12'.
      
      // Parse string with a floating point value and allow decimal point. 
      style = NumberStyles.AllowDecimalPoint;
      number = Decimal.Parse(value, style);  
      Console.WriteLine("'{0}' converted to {1}.", value, number);
      // Displays:
      //    '8694.12' converted to 8694.12.
      
      // Parse string with negative value in parentheses
      value = "(1,789.34)";
      style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | 
              NumberStyles.AllowParentheses; 
      number = Decimal.Parse(value, style);  
      Console.WriteLine("'{0}' converted to {1}.", value, number);
      // Displays:
      //    '(1,789.34)' converted to -1789.34.
      
      // Parse string using Number style
      value = " -17,623.49 ";
      style = NumberStyles.Number;
      number = Decimal.Parse(value, style);  
      Console.WriteLine("'{0}' converted to {1}.", value, number);
      // Displays:
      //    ' -17,623.49 ' converted to -17623.49.