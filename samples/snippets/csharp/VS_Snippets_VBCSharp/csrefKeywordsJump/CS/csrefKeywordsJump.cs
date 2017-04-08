
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csrefKeywordsJump
{

    //<snippet1>    
    class BreakTest
    {
        static void Main()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i == 5)
                {
                    break;
                }
                Console.WriteLine(i);
            }

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* 
     Output:
        1
        2
        3
        4  
    */
    //</snippet1>

    //<snippet2>    
    class Switch
    {
        static void Main()
        {
            Console.Write("Enter your selection (1, 2, or 3): ");
            string s = Console.ReadLine();
            int n = Int32.Parse(s);

            switch (n)
            {
                case 1:
                    Console.WriteLine("Current value is {0}", 1);
                    break;
                case 2:
                    Console.WriteLine("Current value is {0}", 2);
                    break;
                case 3:
                    Console.WriteLine("Current value is {0}", 3);
                    break;
                default:
                    Console.WriteLine("Sorry, invalid selection.");
                    break;
            }

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /*
    Sample Input: 1
     
    Sample Output:
    Enter your selection (1, 2, or 3): 1
    Current value is 1
    */
    //</snippet2>

    //<snippet3>

    class ContinueTest
    {
        static void Main()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i < 9)
                {
                    continue;
                }
                Console.WriteLine(i);
            }

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /*
    Output:
    9
    10
    */
    //</snippet3>

    //<snippet4>
    class SwitchTest
    {
        static void Main()
        {
            Console.WriteLine("Coffee sizes: 1=Small 2=Medium 3=Large");
            Console.Write("Please enter your selection: ");
            string s = Console.ReadLine();
            int n = int.Parse(s);
            int cost = 0;
            switch (n)
            {
                case 1:
                    cost += 25;
                    break;
                case 2:
                    cost += 25;
                    goto case 1;
                case 3:
                    cost += 50;
                    goto case 1;
                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }
            if (cost != 0)
            {
                Console.WriteLine("Please insert {0} cents.", cost);
            }
            Console.WriteLine("Thank you for your business.");

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /*
    Sample Input:  2
     
    Sample Output:
    Coffee sizes: 1=Small 2=Medium 3=Large
    Please enter your selection: 2
    Please insert 50 cents.
    Thank you for your business.
    */

    //</snippet4>

    //<snippet5>
    public class GotoTest1
    {
        static void Main()
        {
            int x = 200, y = 4;
            int count = 0;
            string[,] array = new string[x, y];

            // Initialize the array:
            for (int i = 0; i < x; i++)

                for (int j = 0; j < y; j++)
                    array[i, j] = (++count).ToString();

            // Read input:
            Console.Write("Enter the number to search for: ");

            // Input a string:
            string myNumber = Console.ReadLine();

            // Search:
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (array[i, j].Equals(myNumber))
                    {
                        goto Found;
                    }
                }
            }

            Console.WriteLine("The number {0} was not found.", myNumber);
            goto Finish;

        Found:
            Console.WriteLine("The number {0} is found.", myNumber);

        Finish:
            Console.WriteLine("End of search.");


            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /*
    Sample Input: 44
     
    Sample Output
    Enter the number to search for: 44
    The number 44 is found.
    End of search.
    */
    //</snippet5>

    //<snippet6>
    class ReturnTest
    {
        static double CalculateArea(int r)
        {
            double area = r * r * Math.PI;
            return area;
        }

        static void Main()
        {
            int radius = 5;
            double result = CalculateArea(radius);
            Console.WriteLine("The area is {0:0.00}", result);

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    // Output: The area is 78.54

    //</snippet6>


    //<Snippet7>
    class BreakInNestedLoops
    {
        static void Main(string[] args)
        {

            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };

            // Outer loop
            for (int x = 0; x < numbers.Length; x++)
            {
                Console.WriteLine("num = {0}", numbers[x]);

                // Inner loop
                for (int y = 0; y < letters.Length; y++)
                {
                    if (y == x)
                    {
                        // Return control to outer loop
                        break;
                    }
                    Console.Write(" {0} ", letters[y]);
                }
                Console.WriteLine();
            }

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    /*
     * Output:
        num = 0

        num = 1
         a
        num = 2
         a  b
        num = 3
         a  b  c
        num = 4
         a  b  c  d
        num = 5
         a  b  c  d  e
        num = 6
         a  b  c  d  e  f
        num = 7
         a  b  c  d  e  f  g
        num = 8
         a  b  c  d  e  f  g  h
        num = 9
         a  b  c  d  e  f  g  h  i
     */
    //</Snippet7>  
}