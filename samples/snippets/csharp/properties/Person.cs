using System;
using System.ComponentModel;

namespace properties
{
    namespace VersionOne
    {
        // <Snippet1>
        public class Person
        {
            public string FirstName;
            // remaining implementation removed from listing
        }
        // </Snippet1>
    }

    namespace VersionTwo
    {
        // <Snippet2>
        public class Person
        {
            public string FirstName { get; set; }

            // remaining implementation removed from listing
        }
        // </Snippet2>
    }

    namespace VersionThree
    {
        // <Snippet3>
        public class Person
        {
            public string FirstName { get; set; } = string.Empty;

            // remaining implementation removed from listing
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
                get { return firstName; }
                set { firstName = value; }
            }
            private string firstName;
            // remaining implementation removed from listing
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
                get => firstName;
                set => firstName = value;
            }
            private string firstName;
            // remaining implementation removed from listing
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
                get => firstName;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("First name must not be blank");
                    firstName = value;
                }
            }
            private string firstName;
            // remaining implementation removed from listing
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
                get => firstName;
                set => firstName = (!string.IsNullOrWhiteSpace(value)) ? value : throw new ArgumentException("First name must not be blank");
            }
            private string firstName;
            // remaining implementation removed from listing
        }
        // </Snippet7>
    }
    namespace VersionEight
    {
        // <Snippet8>
        public class Person
        {
            public string FirstName { get; private set; }

            // remaining implementation removed from listing
        }
        // </Snippet8>
    }
    namespace VersionNine
    {
        // <Snippet9>
        public class Person
        {
            public Person(string firstName) => this.FirstName = firstName;

            public string FirstName { get; }

            // remaining implementation removed from listing
        }
        // </Snippet9>
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

            private string fullName;
            public string FullName
            {
                get
                {
                    if (fullName == null)
                        fullName = $"{FirstName} {LastName}";
                    return fullName;
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
            private string firstName;
            public string FirstName
            {
                get => firstName;
                set
                {
                    firstName = value;
                    fullName = null;
                }
            }

            private string lastName;
            public string LastName
            {
                get => lastName;
                set
                {
                    lastName = value;
                    fullName = null;
                }
            }

            private string fullName;
            public string FullName
            {
                get
                {
                    if (fullName == null)
                        fullName = $"{FirstName} {LastName}";
                    return fullName;
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
                get => firstName;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("First name must not be blank");
                    if (value != firstName)
                    {
                        firstName = value;
                        PropertyChanged?.Invoke(this,
                            new PropertyChangedEventArgs(nameof(FirstName)));
                    }
                }
            }
            private string firstName;

            public event PropertyChangedEventHandler PropertyChanged;
            // remaining implementation removed from listing
        }
        // </Snippet15>
    }
}
