class Person_InitExampleFieldProperty
{
    public int YearOfBirth
    {
        get;
        init
        {
            field = (value <= DateTime.Now.Year)
                ? value
                : throw new ArgumentOutOfRangeException(nameof(value), "Year of birth can't be in the future");
        }
    }
}
