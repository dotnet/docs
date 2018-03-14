using System.Linq;
using System;
namespace Restriction
{
    public class WhereClause1
    {
        //This example uses the where clause with query syntax to find all 
        //elements of an array less than 5.
        //Outputs the following to Console 
        //
        // Numbers < 5: 
        // 4 
        // 1 
        // 3 
        // 2 
        // 0
        public static void QuerySyntaxExample() 
        { 
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; 
      
            var lowNums = 
                from n in numbers 
                where n < 5 
                select n; 
      
            Console.WriteLine("Numbers < 5:"); 
            foreach (var x in lowNums) 
            {    
                Console.WriteLine(x); 
            } 
        }
        //This example uses the where clause with method syntax to find all 
        //elements of an array less than 5.
        //Outputs the following to Console 
        //
        // Numbers < 5: 
        // 4 
        // 1 
        // 3 
        // 2 
        // 0
        public static void MethodSyntaxExample() 
        { 
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; 
      
            var lowNums = numbers.Where(n => n < 5);
      
            Console.WriteLine("Numbers < 5:"); 
            foreach (var x in lowNums) 
            {    
                Console.WriteLine(x); 
            } 
        }
    }
}