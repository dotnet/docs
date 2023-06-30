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

namespace initializationExample
{
    // <ConstructorChainingAndMemberNotNull>

    using System.Diagnostics.CodeAnalysis;

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person() : this("John", "Doe") { }
    }

    public class Student : Person
    {
        public string Major { get; set; }

        public Student(string firstName, string lastName, string major)
            : base(firstName, lastName)
        {
            SetMajor(major);
        }

        public Student(string firstName, string lastName) :
            base(firstName, lastName)
        {
            SetMajor();
        }

        public Student()
        {
            SetMajor();
        }

        [MemberNotNull(nameof(Major))]
        private void SetMajor(string? major = default)
        {
            Major = major ?? "Undeclared";
        }
    }
        // </ConstructorChainingAndMemberNotNull>
}
