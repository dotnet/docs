//<ClassicExtensionMethod>
namespace CustomExtensionMethods;

public static class MyExtensions
{
    public static int WordCount(this string str) =>
        str.Split([' ', '.', '?'], StringSplitOptions.RemoveEmptyEntries).Length;
}
//</ClassicExtensionMethod>

//<InterfaceAndExtensions>
public interface IMyInterface
{
    void MethodB();
}

// Define extension methods for IMyInterface.

// The following extension methods can be accessed by instances of any
// class that implements IMyInterface.
public static class Extension
{
    public static void MethodA(this IMyInterface myInterface, int i) =>
        Console.WriteLine("Extension.MethodA(this IMyInterface myInterface, int i)");

    public static void MethodA(this IMyInterface myInterface, string s) =>
        Console.WriteLine("Extension.MethodA(this IMyInterface myInterface, string s)");

    // This method is never called in ExtensionMethodsDemo1, because each
    // of the three classes A, B, and C implements a method named MethodB
    // that has a matching signature.
    public static void MethodB(this IMyInterface myInterface) =>
        Console.WriteLine("Extension.MethodB(this IMyInterface myInterface)");
}
//</InterfaceAndExtensions>

// <Classes>
// Define three classes that implement IMyInterface, and then use them to test
// the extension methods.
class A : IMyInterface
{
    public void MethodB() { Console.WriteLine("A.MethodB()"); }
}

class B : IMyInterface
{
    public void MethodB() { Console.WriteLine("B.MethodB()"); }
    public void MethodA(int i) { Console.WriteLine("B.MethodA(int i)"); }
}

class C : IMyInterface
{
    public void MethodB() { Console.WriteLine("C.MethodB()"); }
    public void MethodA(object obj)
    {
        Console.WriteLine("C.MethodA(object obj)");
    }
}
// </Classes>

// <DomainEntity>
public class DomainEntity
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}

static class DomainEntityExtensions
{
    static string FullName(this DomainEntity value)
        => $"{value.FirstName} {value.LastName}";
}
// </DomainEntity>


//<ExtendEnumType>
public enum Grades
{
    F = 0,
    D = 1,
    C = 2,
    B = 3,
    A = 4
};

// Define an extension method in a non-nested static class.
public static class Extensions
{
    public static bool Passing(this Grades grade, Grades minPassing = Grades.D) =>
        grade >= minPassing;
}
//</ExtendEnumType>

//<RefExtensions>
public static class IntExtensions
{
    public static void Increment(this int number)
        => number++;

    // Take note of the extra ref keyword here
    public static void RefIncrement(this ref int number)
        => number++;
}
//</RefExtensions>

//<UserDefinedRef>
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
//</UserDefinedRef>


public static class ExtensionMethodUsage
{
    public static void Examples()
    {
        {
            // <CallAsInstanceMethod>
            string s = "Hello Extension Methods";
            int i = s.WordCount();
            // </CallAsInstanceMethod>
        }

        {
            // <CallAsStaticMethod>
            string s = "Hello Extension Methods";
            int i = MyExtensions.WordCount(s);
            // </CallAsStaticMethod>
        }
        // <CallExtensionMethods>
        // Declare an instance of class A, class B, and class C.
        A a = new A();
        B b = new B();
        C c = new C();

        // For a, b, and c, call the following methods:
        //      -- MethodA with an int argument
        //      -- MethodA with a string argument
        //      -- MethodB with no argument.

        // A contains no MethodA, so each call to MethodA resolves to
        // the extension method that has a matching signature.
        a.MethodA(1);           // Extension.MethodA(IMyInterface, int)
        a.MethodA("hello");     // Extension.MethodA(IMyInterface, string)

        // A has a method that matches the signature of the following call
        // to MethodB.
        a.MethodB();            // A.MethodB()

        // B has methods that match the signatures of the following
        // method calls.
        b.MethodA(1);           // B.MethodA(int)
        b.MethodB();            // B.MethodB()

        // B has no matching method for the following call, but
        // class Extension does.
        b.MethodA("hello");     // Extension.MethodA(IMyInterface, string)

        // C contains an instance method that matches each of the following
        // method calls.
        c.MethodA(1);           // C.MethodA(object)
        c.MethodA("hello");     // C.MethodA(object)
        c.MethodB();            // C.MethodB()
        /* Output:
            Extension.MethodA(this IMyInterface myInterface, int i)
            Extension.MethodA(this IMyInterface myInterface, string s)
            A.MethodB()
            B.MethodA(int i)
            B.MethodB()
            Extension.MethodA(this IMyInterface myInterface, string s)
            C.MethodA(object obj)
            C.MethodA(object obj)
            C.MethodB()
         */
        // </CallExtensionMethods>

        // <ExampleExtendEnum>
        Grades g1 = Grades.D;
        Grades g2 = Grades.F;
        Console.WriteLine($"First {(g1.Passing() ? "is" : "is not")} a passing grade.");
        Console.WriteLine($"Second {(g2.Passing() ? "is" : "is not")} a passing grade.");

        Console.WriteLine("\r\nRaising the bar!\r\n");
        Console.WriteLine($"First {(g1.Passing(Grades.C) ? "is" : "is not")} a passing grade.");
        Console.WriteLine($"Second {(g2.Passing(Grades.C) ? "is" : "is not")} a passing grade.");
        /* Output:
            First is a passing grade.
            Second is not a passing grade.

            Raising the bar!

            First is not a passing grade.
            Second is not a passing grade.
        */
        // </ExampleExtendEnum>

        // <UseRefExtension>
        int x = 1;

        // Takes x by value leading to the extension method
        // Increment modifying its own copy, leaving x unchanged
        x.Increment();
        Console.WriteLine($"x is now {x}"); // x is now 1

        // Takes x by reference leading to the extension method
        // RefIncrement changing the value of x directly
        x.RefIncrement();
        Console.WriteLine($"x is now {x}"); // x is now 2
        // </UseRefExtension>

        // <TestUserDefinedRef>
        Account account = new()
        {
            id = 1,
            balance = 100f
        };

        Console.WriteLine($"I have ${account.balance}"); // I have $100

        account.Deposit(50f);
        Console.WriteLine($"I have ${account.balance}"); // I have $150
        // </TestUserDefinedRef>
    }
}
