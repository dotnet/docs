namespace firstExample
{
    // <PersonExample>
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    // </PersonExample>
}

namespace secondExample
{
    // <WithConstructor>
    public class Person
    {
        public Person(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    // </WithConstructor>
}

namespace thirdExample
{
    // <Initializer>
    public class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
    // </Initializer>
}

namespace fourthExample
{
    // <NullableMember>
    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
    // </NullableMember>
}
