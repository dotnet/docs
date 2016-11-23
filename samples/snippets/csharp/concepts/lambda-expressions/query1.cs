using System;
using System.Linq;

public class Example
{
   // <Snippet1>
   public delegate TResult Func<TArg, TResult>(TArg arg);
   // </Snippet1>
   
   public static void Main()
   {
      // <Snippet2>
      Func<int, bool> func = (x) => x == 5; 
      // </Snippet2>
      // <Snippet3>
      Console.WriteLine(func(4));      // Returns "False".     
      // </Snippet3>

      // <Snippet4>
      int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };  
      int oddNumbers = numbers.Count(n => n % 2 == 1);  
      Console.WriteLine("There are {0} odd numbers in the set", oddNumbers);
      // Output: There are 5 odd numbers in the set
      // </Snippet4>

     // <Snippet5>
     var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);
     foreach (var number in firstNumbersLessThan6)
        Console.Write("{0}     ", number);  
     // Output: 5     4     1     3
     // </Snippet5>
     Console.WriteLine();   

      // <Snippet6>
      var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);
     foreach (var number in firstSmallNumbers)
        Console.Write("{0}     ", number);
      // Output: 5     4
      // </Snippet6>  
     Console.WriteLine();     
        
   }
}