using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace operators
{
    // <SnippetPersonClass>
    #nullable enable
    public class Person
    {
        public Person(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));

        public string Name { get; }
    }
    // </SnippetPersonClass>

    [TestClass]
    public class PersonTests
    {
        // <SnippetTestPerson>
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NullNameShouldThrowTest()
        {
            var person = new Person(null!);
        }
        // </SnippetTestPerson>
    }

    public static class UseNullForgivingExample
    {
        // <SnippetUseNullForgiving>
        public static void Main()
        {
            Person? p = Find("John");
            if (IsValid(p))
            {
                Console.WriteLine($"Found {p!.Name}");
            }
        }

        public static bool IsValid(Person? person)
            => person is not null && person.Name is not null;
        // </SnippetUseNullForgiving>

        public static Person? Find(string name) => null;
    }

    public static class UseAttributeExample
    {
        // <SnippetUseAttribute>
        public static void Main()
        {
            Person? p = Find("John");
            if (IsValid(p))
            {
                Console.WriteLine($"Found {p.Name}");
            }
        }

        public static bool IsValid([NotNullWhen(true)] Person? person)
            => person is not null && person.Name is not null;
        // </SnippetUseAttribute>

        public static Person? Find(string name) => null;
    }
}
