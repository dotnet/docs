using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeywordsUberProject
{
    class csrefKeywordsSelection
    {


        static void Main(string[] args)
        {
            //<snippet1>
            bool condition = true;

            if (condition)
            {
                Console.WriteLine("The variable is set to true.");
            }
            else
            {
                Console.WriteLine("The variable is set to false.");
            }
            //</snippet1>

            //<snippet2>
            // Try with m = 12 and then with m = 8.
            int m = 12;
            int n = 18;

            if (m > 10)
                if (n > 20)
                {
                    Console.WriteLine("Result1");
                }
                else
                {
                    Console.WriteLine("Result2");
                }
            //</snippet2>

            //<snippet3>
            // Try with m = 12 and then with m = 8.
            if (m > 10)
            {
                if (n > 20)
                    Console.WriteLine("Result1");
            }
            else
            {
                Console.WriteLine("Result2");
            }
            //</snippet3>


        }
    }



    class IfTest
    {
        static void Main()
        {    
            //<snippet4>
            Console.Write("Enter a character: ");
            char c = (char)Console.Read();
            if (Char.IsLetter(c))
            {
                if (Char.IsLower(c))
                {
                    Console.WriteLine("The character is lowercase.");
                }
                else
                {
                    Console.WriteLine("The character is uppercase.");
                }
            }
            else
            {
                Console.WriteLine("The character isn't an alphabetic character.");
            }

            //Sample Output:

            //Enter a character: 2
            //The character isn't an alphabetic character.

            //Enter a character: A
            //The character is uppercase.

            //Enter a character: h
            //The character is lowercase.
            //</snippet4>
        }


    }


    class IfTest2
    {
        // values aren't used
        bool Condition1 = true;
        bool Condition2 = true;
        bool Condition3 = true;
        bool Condition4 = true;

        void TestMethod()
        {
            //<snippet5>
            // Change the values of these variables to test the results.
            bool Condition1 = true;
            bool Condition2 = true;
            bool Condition3 = true;
            bool Condition4 = true;

            if (Condition1)
            {
                // Condition1 is true.
            }
            else if (Condition2)
            {
                // Condition1 is false and Condition2 is true.
            }
            else if (Condition3)
            {
                if (Condition4)
                {
                    // Condition1 and Condition2 are false. Condition3 and Condition4 are true.
                }
                else
                {
                    // Condition1, Condition2, and Condition4 are false. Condition3 is true.
                }
            }
            else
            {
                // Condition1, Condition2, and Condition3 are false.
            }
            //</snippet5>
        }

    }


    public class IfTest3
    {
        static void Main()
        {
            //<snippet6>
            Console.Write("Enter a character: ");
            char ch = (char)Console.Read();

            if (Char.IsUpper(ch))
            {
                Console.WriteLine("The character is an uppercase letter.");
            }
            else if (Char.IsLower(ch))
            {
                Console.WriteLine("The character is a lowercase letter.");
            }
            else if (Char.IsDigit(ch))
            {
                Console.WriteLine("The character is a number.");
            }
            else
            {
                Console.WriteLine("The character is not alphanumeric.");
            }

            //Sample Input and Output:
            //Enter a character: E
            //The character is an uppercase letter.

            //Enter a character: e
            //The character is a lowercase letter.

            //Enter a character: 4
            //The character is a number.

            //Enter a character: =
            //The character is not alphanumeric.
            //</snippet6>
        }
    }


    class SwitchTest1
    {

        void Test()
        {
            // removed from topicID 44bae8b8-8841-4d85-826b-8a94277daecb
            // on switch statement,left here in case used elsewhere
            //<snippet7>
            int caseSwitch = 1;
            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            //</snippet7>
        }
    }



    //<snippet8>
    class SwitchTest
    {
        static void Main()
        {
            Console.WriteLine("Coffee sizes: 1=small 2=medium 3=large");
            Console.Write("Please enter your selection: ");
            string str = Console.ReadLine();
            int cost = 0;

            // Notice the goto statements in cases 2 and 3. The base cost of 25
            // cents is added to the additional cost for the medium and large sizes.
            switch (str)
            {
                case "1":
                case "small":
                    cost += 25;
                    break;
                case "2":
                case "medium":
                    cost += 25;
                    goto case "1";
                case "3":
                case "large":
                    cost += 50;
                    goto case "1";
                default:
                    Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
                    break;
            }
            if (cost != 0)
            {
                Console.WriteLine("Please insert {0} cents.", cost);
            }
            Console.WriteLine("Thank you for your business.");
        }
    }
    /*
        Sample Input: 2
     
        Sample Output:
        Coffee sizes: 1=small 2=medium 3=large
        Please enter your selection: 2
        Please insert 50 cents.
        Thank you for your business.
    */
    //</snippet8>

    // <snippet9>
    class Program
    {
        static void Main(string[] args)
        {
            int switchExpression = 3;
            switch (switchExpression)
            {
                // A switch section can have more than one case label.
                case 0:
                case 1:
                    Console.WriteLine("Case 0 or 1");
                    // Most switch sections contain a jump statement, such as
                    // a break, goto, or return. The end of the statement list
                    // must be unreachable.
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                    // The following line causes a warning.
                    Console.WriteLine("Unreachable code");
                // 7 - 4 in the following line evaluates to 3.
                case 7 - 4:
                    Console.WriteLine("Case 3");
                    break;
                // If the value of switchExpression is not 0, 1, 2, or 3, the
                // default case is executed.
                default:
                    Console.WriteLine("Default case (optional)");
                    // You cannot "fall through" any switch section, including
                    // the last one.
                    break;
            }
        }
    }
    //</snippet9>


}
