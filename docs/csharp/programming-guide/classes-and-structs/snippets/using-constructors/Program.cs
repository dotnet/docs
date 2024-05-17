//<Snippet1>
public class Taxi
{
    public bool IsInitialized;

    public Taxi()
    {
        IsInitialized = true;
    }
}

class TestTaxi
{
    static void Main()
    {
        Taxi t = new Taxi();
        Console.WriteLine(t.IsInitialized);
    }
}
//</Snippet1>

//<Snippet2>
class NLog
{
    // Private Constructor:
    private NLog() { }

    public static double e = Math.E;  //2.71828...
}
//</Snippet2>

//<Snippet3>
public class Employee
{
    public int Salary;

    public Employee() { }

    //<Snippet9>
    public Employee(int annualSalary)
    {
        Salary = annualSalary;
    }
    //</Snippet9>

    public Employee(int weeklySalary, int numberOfWeeks)
    {
        Salary = weeklySalary * numberOfWeeks;
    }
}
//</Snippet3>

class TestEmployee
{
    static void test()
    {
        //<Snippet4>
        Employee e1 = new Employee(30000);
        Employee e2 = new Employee(500, 52);
        //</Snippet4>
    }
}

namespace ManagerCallingBaseConstructor
{
    //<Snippet5>
    public class Manager : Employee
    {
        public Manager(int annualSalary)
            : base(annualSalary)
        {
            //Add further instructions here.
        }
    }
    //</Snippet5>
}

namespace ManagerImplicitlyCallingParameterlessBaseConstructor
{
    public class Manager : Employee
    {
        //<Snippet6>
        public Manager(int initialData)
        {
            //Add further instructions here.
        }
        //</Snippet6>
    }
}

namespace ManagerExplicitlyCallingParameterlessBaseConstructor
{
    public class Manager : Employee
    {
        //<Snippet7>
        public Manager(int initialData)
            : base()
        {
            //Add further instructions here.
        }
        //</Snippet7>
    }
}

namespace EmployeeCallingConstructorInSameClass
{
    public class Employee
    {
        public Employee() { }
        public Employee(int annualSalary) { }
    
        //<Snippet8>
        public Employee(int weeklySalary, int numberOfWeeks)
            : this(weeklySalary * numberOfWeeks)
        {
        }
        //</Snippet8>
    }
}
