      sbyte[] numbers = { SByte.MinValue, -1, 0, 10, 100, SByte.MaxValue };
      bool result;
      
      foreach (sbyte number in numbers)
      {
         result = Convert.ToBoolean(number);                                 
         Console.WriteLine("{0,-5}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       -128   -->  True
      //       -1     -->  True
      //       0      -->  False
      //       10     -->  True
      //       100    -->  True
      //       127    -->  True