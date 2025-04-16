// <ExtensionBlock>
namespace CustomExtensionMembers;

public static class MyExtensions
{
    extension(string str)
    {
        public int WordCount() =>
            str.Split([' ', '.', '?'], StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
// </ExtensionBlock>

public interface IMyInterface
{
    void MethodB();
}

//<InterfaceAndExtensions>
public static class Extension
{
    extension(IMyInterface myInterface)
    {
        public void MethodA(int i) =>
            Console.WriteLine("Extension.MethodA(this IMyInterface myInterface, int i)");

        public void MethodA(string s) =>
            Console.WriteLine("Extension.MethodA(this IMyInterface myInterface, string s)");

        // This method is never called in ExtensionMethodsDemo1, because each
        // of the three classes A, B, and C implements a method named MethodB
        // that has a matching signature.
        public void MethodB() =>
            Console.WriteLine("Extension.MethodB(this IMyInterface myInterface)");
    }
}
//</InterfaceAndExtensions>

public class DomainEntity
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}

// <DomainEntity>
static class DomainEntityExtensions
{
    extension(DomainEntity value)
    {
        string FullName => $"{value.FirstName} {value.LastName}";
    }
}
// </DomainEntity>


public enum Grades
{
    F = 0,
    D = 1,
    C = 2,
    B = 3,
    A = 4
};

// <EnumExtensionMembers>
public static class EnumExtensions
{
    private static Grades minimumPassingGrade = Grades.D;

    extension(Grades grade)
    {
        public static Grades MinimumPassingGrade
        {
            get => minimumPassingGrade;
            set => minimumPassingGrade = value;
        }

        public bool Passing => grade >= minimumPassingGrade;
    }
}
// </EnumExtensionMembers>


//<RefExtensions>
public static class IntExtensions
{
    extension(int number)
    {
        public void Increment()
            => number++;
    }

    // Take note of the extra ref keyword here
    extension(ref int number)
    {
        public void RefIncrement()
            => number++;
    }
}
//</RefExtensions>

public struct Account
{
    public uint id;
    public float balance;

    private int secret;
}

//<UserDefinedRef>
public static class AccountExtensions
{
    extension(ref Account account)
    {
        // ref keyword can also appear before the this keyword
        public void Deposit(float amount)
        {
            account.balance += amount;

            // The following line results in an error as an extension
            // method is not allowed to access private members
            // account.secret = 1; // CS0122
        }
    }
}
//</UserDefinedRef>

public static class ExtensionMemberUsage
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
        // <ExampleExtendEnum>
        Grades g1 = Grades.D;
        Grades g2 = Grades.F;
        Console.WriteLine($"First {(g1.Passing ? "is" : "is not")} a passing grade.");
        Console.WriteLine($"Second {(g2.Passing ? "is" : "is not")} a passing grade.");

        Grades.MinimumPassingGrade = Grades.C;
        Console.WriteLine($"\r\nRaising the bar. Passing grade is now {Grades.MinimumPassingGrade}!\r\n");
        Console.WriteLine($"First {(g1.Passing ? "is" : "is not")} a passing grade.");
        Console.WriteLine($"Second {(g2.Passing ? "is" : "is not")} a passing grade.");
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
        // </UseRefExtensions>

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
