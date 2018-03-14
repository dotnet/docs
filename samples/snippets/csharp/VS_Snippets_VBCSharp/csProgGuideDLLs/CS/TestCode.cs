//-----------------------------------------------------------------------------
//<Snippet3>
// File: TestCode.cs

using UtilityMethods;

class TestCode
{
    static void Main(string[] args) 
    {
        System.Console.WriteLine("Calling methods from MathLibrary.DLL:");

        if (args.Length != 2)
        {
            System.Console.WriteLine("Usage: TestCode <num1> <num2>");
            return;
        }

        long num1 = long.Parse(args[0]);
        long num2 = long.Parse(args[1]);

        long sum = AddClass.Add(num1, num2);
        long product = MultiplyClass.Multiply(num1, num2);

        System.Console.WriteLine("{0} + {1} = {2}", num1, num2, sum);
        System.Console.WriteLine("{0} * {1} = {2}", num1, num2, product);
    }
}
/* Output (assuming 1234 and 5678 are entered as command-line arguments):
    Calling methods from MathLibrary.DLL:
    1234 + 5678 = 6912
    1234 * 5678 = 7006652        
*/
//</Snippet3>


//-----------------------------------------------------------------------------
class Wrap
{
    static void Main(string[] args) 
    {
        long num1 = 100;
        long num2 = 200;

        //<Snippet4>
        MultiplyClass.Multiply(num1, num2);
        //</Snippet4>
        
        //<Snippet5>
        UtilityMethods.MultiplyClass.Multiply(num1, num2);
        //</Snippet5>
    }
}


//-----------------------------------------------------------------------------
//<Snippet1>
// File: Add.cs 
namespace UtilityMethods
{
    public class AddClass 
    {
        public static long Add(long i, long j) 
        { 
            return (i + j);
        }
    }
}
//</Snippet1>


//-----------------------------------------------------------------------------
//<Snippet2>
// File: Mult.cs
namespace UtilityMethods 
{
    public class MultiplyClass
    {
        public static long Multiply(long x, long y) 
        {
            return (x * y); 
        }
    }
}
//</Snippet2>
