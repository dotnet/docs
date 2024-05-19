namespace InitExample;

// <Snippet4>
class Person_InitExampleNullability
{
    private int? _yearOfBirth;

    public int? YearOfBirth
    {
        get => _yearOfBirth;
        init => _yearOfBirth = value;
    }
}
// </Snippet4>

// <SnippetNonNullable>
class Person_InitExampleNonNull
{
    private int _yearOfBirth;

    public required int YearOfBirth
    {
        get => _yearOfBirth;
        init => _yearOfBirth = value;
    }
}
// </SnippetNonNullable>
