using System;
using System.Runtime.CompilerServices;

namespace NewInCSharp6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var t = new OldStyle.Student();
            t.Grades.Add(4.5);

            var person = new NewStyle.Student("first", "last");

            // <NullConditional>
            var first = person?.FirstName;
            // </NullConditional>

            // <NullCoalescing>
            first = person?.FirstName ?? "Unspecified";
            // </NullCoalescing>

            var test = new NewStyle.Student("first", "last");
            test.Grades.Add(1.0);
            test.Grades.Add(1.5);
            test.Grades.Add(2.0);
            test.Grades.Add(3.5);
            test.Grades.Add(2.0);
            test.Grades.Add(4.0);
            test.Grades.Add(1.50);
            test.Grades.Add(2.25);
            test.Grades.Add(3.5);
            test.Grades.Add(1.0);
            test.Grades.Add(1.0);
        }

        private void PerformFailingOperation() {}
    }

    public class RecoverableException : Exception
    {
    }
}
