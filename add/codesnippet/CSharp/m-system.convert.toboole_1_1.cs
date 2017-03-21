      uint[] numbers = { UInt32.MinValue, 612, 4038907, Int32.MaxValue };
      bool result;
      
      foreach (uint number in numbers)
      {
         result = Convert.ToBoolean(number);                                 
         Console.WriteLine("{0,-15:N0}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       0                -->  False
      //       612              -->  True
      //       4,038,907        -->  True
      //       2,147,483,647    -->  True