using System.Diagnostics.CodeAnalysis;

namespace VersionOne
{
    // <Field>
    public class Person
    {
        public string? FirstName;

        // Omitted for brevity.
    }
    // </Field>
}

namespace VersionTwo
{
    // <AutoImplemented>
    public class Person
    {
        public string? FirstName { get; set; }

        // Omitted for brevity.
    }
    // </AutoImplemented>
}

namespace VersionTwoPointFive
{
    // <FieldBackedProperty>
    public class Person
    {
        public string? FirstName 
        { 
            get;
            set => field = value.Trim(); 
        }

        // Omitted for brevity.
    }
    // </FieldBackedProperty>
}

namespace VersionThree
{
    // <Initializer>
    public class Person
    {
        public string FirstName { get; set; } = string.Empty;

        // Omitted for brevity.
    }
    // </Initializer>
}

namespace VersionFour
{
    // <AccessorModifiers>
    public class Person
    {
        public string? FirstName { get; private set; }

        // Omitted for brevity.
    }
    // </AccessorModifiers>
}

namespace VersionFive
{
    // <Readonly>
    public class Person
    {
        public Person(string firstName) => FirstName = firstName;

        public string FirstName { get; }

        // Omitted for brevity.
    }
    // </Readonly>
}

namespace VersionSix
{
    // <InitOnly>
    public class Person
    {
        public Person() { }
        public Person(string firstName) => FirstName = firstName;

        public string? FirstName { get; init; }

        // Omitted for brevity.
    }
    // </InitOnly>
}

namespace VersionSeven
{
    // <Required>
    public class Person
    {
        public Person() { }

        [SetsRequiredMembers]
        public Person(string firstName) => FirstName = firstName;

        public required string FirstName { get; init; }

        // Omitted for brevity.
    }
    // </Required>
}

namespace VersionEight
{
    // <ExpressionBodiedProperty>
    public class Person
    {
        public Person() { }

        [SetsRequiredMembers]
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public required string FirstName { get; init; }
        public required string LastName { get; init; }

        public string Name => $"{FirstName} {LastName}";

        // Omitted for brevity.
    }
    // </ExpressionBodiedProperty>
}

namespace VersionNine
{
    // <CachedBackingStore>
    public class Person
    {
        public Person() { }

        [SetsRequiredMembers]
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public required string FirstName { get; init; }
        public required string LastName { get; init; }

        private string? _fullName;
        public string FullName
        {
            get
            {
                if (_fullName is null)
                    _fullName = $"{FirstName} {LastName}";
                return _fullName;
            }
        }
    }
    // </CachedBackingStore>
}

namespace VersionTen
{
    // <UseBackingFields>
    public class Person
    {
        private string? _firstName;
        public string? FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                _fullName = null;
            }
        }

        private string? _lastName;
        public string? LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                _fullName = null;
            }
        }

        private string? _fullName;
        public string FullName
        {
            get
            {
                if (_fullName is null)
                    _fullName = $"{FirstName} {LastName}";
                return _fullName;
            }
        }
    }
    // </UseBackingFields>
}

namespace properties
{

    // <UsingEmployeeExample>
    class Employee
    {
        private string _name;           // the name field
        public string Name => _name;    // the Name property
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
        private string _name;      // the name field
        public string Name         // the Name property
        {
            get => _name;
            set => _name = value;
        }
    }
    //</StudentExample>
}
