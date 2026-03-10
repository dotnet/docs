namespace FromClause;

//<snippet1>
class LowNums
{
    static void Main()
    {
        // A simple data source.
        int[] numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

        // Create the query.
        // lowNums is an IEnumerable<int>
        var lowNums = from num in numbers
            where num < 5
            select num;

        // Execute the query.
        foreach (int i in lowNums)
        {
            Console.Write(i + " ");
        }
    }
}
// Output: 4 1 3 2 0
//</snippet1>

//<Snippet2>
class CompoundFrom
{
    // The element type of the data source.
    public class Student
    {
        public required string LastName { get; init; }
        public required List<int> Scores {get; init;}
    }

    static void Main()
    {

        // Use a collection initializer to create the data source. Note that
        // each element in the list contains an inner sequence of scores.
        List<Student> students =
        [
           new Student {LastName="Omelchenko", Scores= [97, 72, 81, 60]},
           new Student {LastName="O'Donnell", Scores= [75, 84, 91, 39]},
           new Student {LastName="Mortensen", Scores= [88, 94, 65, 85]},
           new Student {LastName="Garcia", Scores= [97, 89, 85, 82]},
           new Student {LastName="Beebe", Scores= [35, 72, 91, 70]}
        ];

        // Use a compound from to access the inner sequence within each element.
        // Note the similarity to a nested foreach statement.
        var scoreQuery = from student in students
                         from score in student.Scores
                            where score > 90
                            select new { Last = student.LastName, score };

        // Execute the queries.
        Console.WriteLine("scoreQuery:");
        // Rest the mouse pointer on scoreQuery in the following line to
        // see its type. The type is IEnumerable<'a>, where 'a is an
        // anonymous type defined as new {string Last, int score}. That is,
        // each instance of this anonymous type has two members, a string
        // (Last) and an int (score).
        foreach (var student in scoreQuery)
        {
            Console.WriteLine($"{student.Last} Score: {student.score}");
        }
    }
}
/*
scoreQuery:
Omelchenko Score: 97
O'Donnell Score: 91
Mortensen Score: 94
Garcia Score: 97
Beebe Score: 91
*/
//</snippet2>

// <snippet3>
class CompoundFrom2
{
    static void Main()
    {
        char[] upperCase = ['A', 'B', 'C'];
        char[] lowerCase = ['x', 'y', 'z'];

        // The type of joinQuery1 is IEnumerable<'a>, where 'a
        // indicates an anonymous type. This anonymous type has two
        // members, upper and lower, both of type char.
        var joinQuery1 =
            from upper in upperCase
            from lower in lowerCase
            select new { upper, lower };

        // The type of joinQuery2 is IEnumerable<'a>, where 'a
        // indicates an anonymous type. This anonymous type has two
        // members, upper and lower, both of type char.
        var joinQuery2 =
            from lower in lowerCase
            where lower != 'x'
            from upper in upperCase
            select new { lower, upper };

        // Execute the queries.
        Console.WriteLine("Cross join:");
        // Rest the mouse pointer on joinQuery1 to verify its type.
        foreach (var pair in joinQuery1)
        {
            Console.WriteLine($"{pair.upper} is matched to {pair.lower}");
        }

        Console.WriteLine("Filtered non-equijoin:");
        // Rest the mouse pointer over joinQuery2 to verify its type.
        foreach (var pair in joinQuery2)
        {
            Console.WriteLine($"{pair.lower} is matched to {pair.upper}");
        }

        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
/* Output:
        Cross join:
        A is matched to x
        A is matched to y
        A is matched to z
        B is matched to x
        B is matched to y
        B is matched to z
        C is matched to x
        C is matched to y
        C is matched to z
        Filtered non-equijoin:
        y is matched to A
        y is matched to B
        y is matched to C
        z is matched to A
        z is matched to B
        z is matched to C
        */
//</Snippet3>

// NOT USED. DELETED FROM TOPIC
//<Snippet4>
//class CompoundFrom3
//{
//    static void Main()
//    {
//        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
//        int[] numbersB = { 1, 3, 5, 7, 8 };

//        var pairQuery2 =
//            from a in numbersA
//            join b in numbersB on a equals b
//            select a;

//        foreach (var prod in pairQuery2)
//        {
//            Console.Write(prod + " ");
//        }
//    }
//}
//Output: 5 8
//</snippet4>
