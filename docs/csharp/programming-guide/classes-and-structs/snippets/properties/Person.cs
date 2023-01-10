namespace properties;

// <ExpressionBodiedProperty>
public class Person
{
    private string _firstName;
    private string _lastName;

    public Person(string first, string last)
    {
        _firstName = first;
        _lastName = last;
    }

    public string Name => $"{_firstName} {_lastName}";
}
// </ExpressionBodiedProperty>

// <UsingEmployeeExample>
class Employee
{
    private string _name;  // the name field
    public string Name => _name;     // the Name property
}
// </UsingEmployeeExample>

// <ManageExample>
class Manager
{
    private string _name;
    public string Name => _name != null ? _name : "NA";
}
// </ManageExample>

//<StudentExample>
class Student
{
    private string _name;  // the name field
    public string Name    // the Name property
    {
        get => _name;
        set => _name = value;
    }
}
//</StudentExample>
