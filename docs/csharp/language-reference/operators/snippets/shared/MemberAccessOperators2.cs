using System;
using System.Collections.Generic;
using System.Linq;

namespace MemberAccessOperators2
{
    public static class NullConditionalShortCircuiting
    {
        public static void Main()
        {
            Person person = null;
            person?.Name.Write(); // no output: Write() is not called due to short-circuit.
            try
            {
                (person?.Name).Write();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("NullReferenceException");
            }; // output: NullReferenceException
        }
    }

    public class Person
    {
        public FullName Name { get; set; }
    }

    public class FullName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public void Write()
        {
            Console.WriteLine($"{FirstName} {LastName}");
        }
    }
}
