using System;

namespace NewCsharp9
{
    public static class RecordExamples
    {
        // <RecordDefinition>
        public record Person
        {
            public string LastName { get; }
            public string FirstName { get; }

            public Person(string first, string last) => (FirstName, LastName) = (first, last);
        }
        // </RecordDefinition>

        // <InheritedRecord>
        public record Teacher : Person
        {
            public string Subject { get; }

            public Teacher(string first, string last, string sub)
                : base(first, last) => Subject = sub;
        }
        // </InheritedRecord>

        // <SealedRecord>
        public sealed record Student : Person
        {
            public int Level { get; }

            public Student(string first, string last, int level) : base(first, last) => Level = level;
        }
        // </SealedRecord>

        public static void ExampleCode()
        {
            // <RecordsEquality>
            var person = new Person("Bill", "Wagner");
            var student = new Student("Bill", "Wagner", 11);

            Console.WriteLine(student == person); // false
            // </RecordsEquality>

        }
    }

}
