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
