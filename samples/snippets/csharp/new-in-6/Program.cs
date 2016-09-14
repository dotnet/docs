using System;

namespace NewInCSharp6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var t = new OldStyle.Student();
            t.Grades.Add(4.5);

            var person = new NewStyle.Student("first", "last");

            var first = person?.FirstName; 

            first = person?.FirstName ?? "Unspecified";

        }
    }
}
