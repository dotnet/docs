using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuples
{
    #region 12_TypeWithDeconstructMethod
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Person(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }

        public void Deconstruct(out string firstName, out string lastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }
    }
    #endregion

    #region 13_ExtensionDeconstructMethod
    public class Student : Person
    {
        public double GPA { get; }
        public Student(string first, string last, double gpa) :
            base(first, last)
        {
            GPA = gpa;
        }
    }

    public static class Extensions
    {
        public static void Deconstruct(this Student s, out string first, out string last, out double gpa)
        {
            first = s.FirstName;
            last = s.LastName;
            gpa = s.GPA;
        }
    }
    #endregion
}

namespace TupleEquality
{
    public static class Tests
    {
        public static void EqualityTests()
        {
            Person nil = default;
            Person blank = new Person(null, null);
            Person sample = new Person("Bill", "Wagner");

            Console.WriteLine("Starting Equality Tests");
            Console.WriteLine($"nil equals nil: {nil == nil}");
            Console.WriteLine($"nil equals blank: {nil == blank}");
            Console.WriteLine($"nil equals sample: {nil == sample}");

            Console.WriteLine($"blank equals nil: {blank == nil}");
            Console.WriteLine($"blank equals blank: {blank == blank}");
            Console.WriteLine($"blank equals sanple: {blank == sample}");

            Console.WriteLine($"sample equals nil: {sample == nil}");
            Console.WriteLine($"sample equals blank: {sample == blank}");
            Console.WriteLine($"sample equals sanple: {sample == sample}");

            Console.WriteLine($"nil not equals nil: {nil != nil}");
            Console.WriteLine($"nil not equals blank: {nil != blank}");
            Console.WriteLine($"nil not equals sample: {nil != sample}");

            Console.WriteLine($"blank not equals nil: {blank != nil}");
            Console.WriteLine($"blank not equals blank: {blank != blank}");
            Console.WriteLine($"blank not equals sanple: {blank != sample}");

            Console.WriteLine($"sample not equals nil: {sample != nil}");
            Console.WriteLine($"sample not equals blank: {sample != blank}");
            Console.WriteLine($"sample not equals sanple: {sample != sample}");
        }
    }
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Person(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }

        public void Deconstruct(out string firstName, out string lastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }

        // <SnippetEqualityTests>
        public override bool Equals(object other) =>
            (other is Person p) 
            ? (FirstName, LastName) == (p.FirstName, p.LastName) 
            : false;

        public static bool operator ==(Person left, Person right) => 
            (object.ReferenceEquals(left, null)) 
            ? (object.ReferenceEquals(right, null)) 
            : left.Equals(right);

        public static bool operator !=(Person left, Person right) => !(left == right);
        public override int GetHashCode() => (LastName, FirstName).GetHashCode();
        // </SnippetEqualityTests>
    }
}
