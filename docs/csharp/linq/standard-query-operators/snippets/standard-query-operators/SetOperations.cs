namespace StandardQueryOperators;
internal class SetOperations
{
    private static readonly IEnumerable<Teacher> teachers = Sources.Teachers;
    private static readonly IEnumerable<Student> students = Sources.Students;
    public static void RunAllSnippets()
    {
        Console.WriteLine("Distinct");
        Distinct();
        Console.WriteLine("DistinctBy");
        DistinctByExample();
        Console.WriteLine("Except");
        Except();
        Console.WriteLine("ExceptBy");
        ExceptByExample();
        Console.WriteLine("Intersect");
        IntersectInteractive();
        Console.WriteLine("IntersectBy");
        IntersectByExample();
        Console.WriteLine("Union");
        UnionInteractive();
        Console.WriteLine("UnionBy");
        UnionByExample();
    }

    private static void Distinct()
    {
        // <Distinct>
        string[] words = ["the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog"];

        IEnumerable<string> query = from word in words.Distinct()
                                    select word;

        foreach (var str in query)
        {
            Console.WriteLine(str);
        }

        /* This code produces the following output:
         *
         * the
         * quick
         * brown
         * fox
         * jumped
         * over
         * lazy
         * dog
         */
        // </Distinct>
    }

    private static void Except()
    {
        // <Except>
        string[] words1 = ["the", "quick", "brown", "fox"];
        string[] words2 = ["jumped", "over", "the", "lazy", "dog"];

        IEnumerable<string> query = from word in words1.Except(words2)
                                    select word;

        foreach (var str in query)
        {
            Console.WriteLine(str);
        }

        /* This code produces the following output:
         *
         * quick
         * brown
         * fox
         */
        // </Except>
    }


    private static void DistinctByExample()
    {
        Console.WriteLine("DistinctBy:");

        // <DistinctBy>
        string[] words = ["the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog"];

        foreach (string word in words.DistinctBy(p => p.Length))
        {
            Console.WriteLine(word);
        }

        // This code produces the following output:
        //     the
        //     quick
        //     jumped
        //     over
        // </DistinctBy>

        Console.WriteLine();
    }

    private static void ExceptByExample()
    {
        Console.WriteLine("ExceptBy:");

        // Teachers except department chairs.

        // <ExceptBy>
        int[] teachersToExclude =
        [
            901,    // English
            965,    // Mathematics
            932,    // Engineering
            945,    // Economics
            987,    // Physics
            901     // Chemistry
        ];

        foreach (Teacher teacher in
            teachers.ExceptBy(
                teachersToExclude, teacher => teacher.ID))
        {
            Console.WriteLine($"{teacher.First} {teacher.Last}");
        }
        // </ExceptBy>

        Console.WriteLine();
    }

    private static void IntersectInteractive()
    {
        // <Intersect>
        string[] words1 = ["the", "quick", "brown", "fox"];
        string[] words2 = ["jumped", "over", "the", "lazy", "dog"];

        IEnumerable<string> query = from word in words1.Intersect(words2)
                                    select word;

        foreach (var str in query)
        {
            Console.WriteLine(str);
        }

        /* This code produces the following output:
         *
         * the
         */
        // </Intersect>
    }

    internal static void IntersectByExample()
    {
        Console.WriteLine("IntersectBy:");

        // Students who are also teachers.

        // <IntersectBy>
        foreach (Student person in
            students.IntersectBy(
                teachers.Select(t => (t.First, t.Last)), s => (s.FirstName, s.LastName)))
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
        // </IntersectBy>

        Console.WriteLine();
    }

    private static void UnionInteractive()
    {
        // <Union>
        string[] words1 = ["the", "quick", "brown", "fox"];
        string[] words2 = ["jumped", "over", "the", "lazy", "dog"];

        IEnumerable<string> query = from word in words1.Union(words2)
                                    select word;

        foreach (var str in query)
        {
            Console.WriteLine(str);
        }

        /* This code produces the following output:
         *
         * the
         * quick
         * brown
         * fox
         * jumped
         * over
         * lazy
         * dog
        */
        // </Union>
    }

    private static void UnionByExample()
    {
        Console.WriteLine("UnionBy:");

        // All teachers and students
        // <UnionBy>
        foreach (var person in
            students.Select(s => (s.FirstName, s.LastName)).UnionBy(
                teachers.Select(t => (FirstName: t.First, LastName: t.Last)), s => (s.FirstName, s.LastName)))
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
        // </UnionBy>

        Console.WriteLine();
    }
}
