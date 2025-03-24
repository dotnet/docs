namespace HidingExample;
//<Hiding>
public class Employee
{
    private string _name;
    public string Name
    {
        get => _name;
        set => _name = value;
    }
}

public class Manager : Employee
{
    private string _name;

    // Notice the use of the new modifier:
    //<NewProperty>
    public new string Name
    //</NewProperty>
    {
        get => _name;
        set => _name = value + ", Manager";
    }
}

class TestHiding
{
    public static void Test()
    {
        Manager m1 = new Manager();

        // Derived class property.
        m1.Name = "John";

        // Base class property.
        //<CastToBase>
        ((Employee)m1).Name = "Mary";
        //</CastToBase>

        System.Console.WriteLine($"Name in the derived class is: {m1.Name}");
        System.Console.WriteLine($"Name in the base class is: {((Employee)m1).Name}");
    }
}
/* Output:
    Name in the derived class is: John, Manager
    Name in the base class is: Mary
*/
//</Hiding>
