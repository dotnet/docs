//<Snippet1>
abstract class Motorcycle
{
    // Anyone can call this.
    public void StartEngine() {/* Method statements here */ }

    // Only derived classes can call this.
    protected void AddGas(int gallons) { /* Method statements here */ }

    // Derived classes can override the base class implementation.
    public virtual int Drive(int miles, int speed) { /* Method statements here */ return 1; }

    // Derived classes must implement this.
    public abstract double GetTopSpeed();
}
//</Snippet1>

//<Snippet2>
class TestMotorcycle : Motorcycle
{
    public override double GetTopSpeed()
    {
        return 108.4;
    }

    static void Main()
    {
        TestMotorcycle moto = new TestMotorcycle();

        moto.StartEngine();
        moto.AddGas(15);
        moto.Drive(5, 20);
        double speed = moto.GetTopSpeed();
        Console.WriteLine("My top speed is {0}", speed);
    }
}
//</Snippet2>

public class ParameterClass
{
    //<Snippet3>
    public void Caller()
    {
        int numA = 4;
        // Call with an int variable.
        int productA = Square(numA);

        int numB = 32;
        // Call with another int variable.
        int productB = Square(numB);

        // Call with an integer literal.
        int productC = Square(12);

        // Call with an expression that evaluates to int.
        productC = Square(productA * 3);
    }

    int Square(int i)
    {
        // Store input argument in a local variable.
        int input = i;
        return input * input;
    }
    //</Snippet3>
}

//-----------------------------------------------------------------------------
//<Snippet4>
public class SampleRefType
{
    public int value;
}
//</Snippet4>

public class TestRefTypeClass
{
    //<Snippet5>
    public static void TestRefType()
    {
        SampleRefType rt = new SampleRefType();
        rt.value = 44;
        ModifyObject(rt);
        Console.WriteLine(rt.value);
    }

    static void ModifyObject(SampleRefType obj)
    {
        obj.value = 33;
    }
    //</Snippet5>
}

//<Snippet6>
class SimpleMath
{
    public int AddTwoNumbers(int number1, int number2)
    {
        return number1 + number2;
    }

    public int SquareANumber(int number)
    {
        return number * number;
    }
}
//</Snippet6>

class TestSimpleMath
{
    static void Test()
    {
        SimpleMath obj = new SimpleMath();

        //<Snippet7>
        int result = obj.AddTwoNumbers(1, 2);
        result = obj.SquareANumber(result);
        // The result is 9.
        Console.WriteLine(result);
        //</Snippet7>

        //<Snippet8>
        result = obj.SquareANumber(obj.AddTwoNumbers(1, 2));
        // The result is 9.
        Console.WriteLine(result);
        //</Snippet8>
    }
}

//<Snippet9>
public static class IntExtensions
{
    public static void Increment(this int number)
        => number++;

    // Take note of the extra ref keyword here
    public static void RefIncrement(this ref int number)
        => number++;
}

public static class IntProgram
{
    public static void Test()
    {
        int x = 1;

        // Takes x by value leading to the extension method
        // Increment modifying its own copy, leaving x unchanged
        x.Increment();
        Console.WriteLine($"x is now {x}"); // x is now 1

        // Takes x by reference leading to the extension method
        // RefIncrement changing the value of x directly
        x.RefIncrement();
        Console.WriteLine($"x is now {x}"); // x is now 2
    }
}
//</Snippet9>

//<Snippet10>
public struct Account
{
    public uint id;
    public float balance;

    private int secret;
}

public static class AccountExtensions
{
    // ref keyword can also appear before the this keyword
    public static void Deposit(ref this Account account, float amount)
    {
        account.balance += amount;

        // The following line results in an error as an extension
        // method is not allowed to access private members
        // account.secret = 1; // CS0122
    }
}

public static class AccountProgram
{
    public static void Test()
    {
        Account account = new()
        {
            id = 1,
            balance = 100f
        };

        Console.WriteLine($"I have ${account.balance}"); // I have $100

        account.Deposit(50f);
        Console.WriteLine($"I have ${account.balance}"); // I have $150
    }
}
//</Snippet10>
