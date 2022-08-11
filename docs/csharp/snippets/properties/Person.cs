using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace VersionOne
{
    // <Snippet1>
    public class Person
    {
        public string FirstName;

        // Omitted for brevity.
    }
    // </Snippet1>
}

namespace VersionTwo
{
    // <Snippet2>
    public class Person
    {
        public string FirstName { get; set; }

        // Omitted for brevity.
    }
    // </Snippet2>
}

namespace VersionThree
{
    // <Snippet3>
    public class Person
    {
        public string FirstName { get; set; } = string.Empty;

        // Omitted for brevity.
    }
    // </Snippet3>
}
namespace VersionFour
{
    // <Snippet4>
    public class Person
    {
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private string _firstName;

        // Omitted for brevity.
    }
    // </Snippet4>
}
namespace VersionFive
{
    // <Snippet5>
    public class Person
    {
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }
        private string _firstName;

        // Omitted for brevity.
    }
    // </Snippet5>
}

namespace VersionSix
{
    // <Snippet6>
    public class Person
    {
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("First name must not be blank");
                _firstName = value;
            }
        }
        private string _firstName;

        // Omitted for brevity.
    }
    // </Snippet6>
}
namespace VersionSeven
{
    // <Snippet7>
    public class Person
    {
        public string FirstName
        {
            get => _firstName;
            set => _firstName = (!string.IsNullOrWhiteSpace(value)) ? value : throw new ArgumentException("First name must not be blank");
        }
        private string _firstName;

        // Omitted for brevity.
    }
    // </Snippet7>
}
namespace VersionEight
{
    // <Snippet8>
    public class Person
    {
        public string FirstName { get; private set; }

        // Omitted for brevity.
    }
    // </Snippet8>
}
namespace VersionNine
{
    // <Snippet9>
    public class Person
    {
        public Person(string firstName) => FirstName = firstName;

        public string FirstName { get; }

        // Omitted for brevity.
    }
    // </Snippet9>
}
namespace VersionNinePoint1
{
    // <Snippet9.1>
    public class Person
    {
        public Person() { }
        public Person(string firstName) => FirstName = firstName;

        public string FirstName { get; init; }

        // Omitted for brevity.
    }
    // </Snippet9.1>
}
namespace VersionNinePoint2
{
    // <Snippet9.2>
    public class Person
    {
        public Person() { }

        [SetsRequiredMembers]
        public Person(string firstName) => FirstName = firstName;

        public required string FirstName { get; init; }

        // Omitted for brevity.
    }
    // </Snippet9.2>
}
namespace VersionTen
{
    // <Snippet10>
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
    // </Snippet10>
}
namespace VersionEleven
{
    // <Snippet11>
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
    // </Snippet11>
}
namespace VersionTwelve
{
    // <Snippet12>
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        private string _fullName;
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
    // </Snippet12>
}
namespace VersionThirteen
{
    // <Snippet13>
    public class Person
    {
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                _fullName = null;
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                _fullName = null;
            }
        }

        private string _fullName;
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
    // </Snippet13>
}
namespace VersionFourteen
{
    // <Snippet14>
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [field:NonSerialized]
        public int Id { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
    // </Snippet14>
}
namespace VersionFifteen
{
    // <Snippet15>
    public class Person : INotifyPropertyChanged
    {
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("First name must not be blank");
                if (value != _firstName)
                {
                    _firstName = value;
                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(FirstName)));
                }
            }
        }
        private string _firstName;

        public event PropertyChangedEventHandler PropertyChanged;
    }
    // </Snippet15>
}
