using System;
using System.Text;

namespace NewCsharp9
{
    public static class PositionalRecords
    {
        // <PositionalRecords>
        public record Person(string FirstName, string LastName);

        public record Teacher(string FirstName, string LastName,
            string Subject)
            : Person(FirstName, LastName);

        public sealed record Student(string FirstName,
            string LastName, int Level)
            : Person(FirstName, LastName);
        // </PositionalRecords>

        /*
        // <RecordsWithMethods>
        public record Pet(string Name)
        {
            public void ShredTheFurniture() =>
                Console.WriteLine("Shredding furniture");
        }

        public record Dog(string Name) : Pet(Name)
        {
            public void WagTail() =>
                Console.WriteLine("It's tail wagging time");

            public override string ToString()
            {
                StringBuilder s = new();
                base.PrintMembers(s);
                return $"{s.ToString()} is a dog";
            }
        }
        // </RecordsWithMethods>
        */

        public static void PositionalExamples()
        {
            // <DeconstructRecord>
            var person = new Person("Bill", "Wagner");

            var (first, last) = person;
            Console.WriteLine(first);
            Console.WriteLine(last);
            // </DeconstructRecord>

            // <Wither>
            Person brother = person with { FirstName = "Paul" };
            // </Wither>

            // <WithCopy>
            Person clone = person with { };
            // </WithCopy>
        }
    }
}
