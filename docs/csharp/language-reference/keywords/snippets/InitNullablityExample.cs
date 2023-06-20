namespace InitExample;

// <Snippet4>
class Person_InitExampleExpressionBodied
{
    private int? _yearOfBirth;

    public int? YearOfBirth
    {
        get => _yearOfBirth;
        init => _yearOfBirth = value;
    }
}
