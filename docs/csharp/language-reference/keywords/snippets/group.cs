namespace Group;

using CommonTypes;
// For the group clause topic, we only use bits and pieces of this class. The same
// class is also used for  How To: Group Results in Various Ways HowTo and
// How To: Enumerate Groups and Group Items

// Code snippets not compilable samples
class GroupCodeExcerpts : CommonTypes.Common
{
    List<Common.Student> students = CommonTypes.Common.GetStudents();
    // Use a compound from to access the inner sequence within each element.
    // Note the similarity to a nested foreach statement.
    void SimpleGroups()
    {

        //<Snippet10>
        // Query variable is an IEnumerable<IGrouping<char, Student>>
        var studentQuery1 =
            from student in students
            group student by student.Last[0];
        //</snippet10>

        // This query could be easily modified to group by the entire last name.
        //<Snippet11>
        // Group students by the first letter of their last name
        // Query variable is an IEnumerable<IGrouping<char, Student>>
        var studentQuery2 =
            from student in students
            group student by student.Last[0] into g
            orderby g.Key
            select g;
        //</snippet11>
        Console.WriteLine("The SimpleGroup method produces this output:\r\n");

       //<snippet12>
       // Iterate group items with a nested foreach. This IGrouping encapsulates
       // a sequence of Student objects, and a Key of type char.
       // For convenience, var can also be used in the foreach statement.
       foreach (IGrouping<char, Student> studentGroup in studentQuery2)
       {
            Console.WriteLine(studentGroup.Key);
            // Explicit type for student could also be used here.
            foreach (var student in studentGroup)
            {
                Console.WriteLine("   {0}, {1}", student.Last, student.First);
            }
        }
        //</snippet12>

        //<Snippet13>
        // Same as previous example except we use the entire last name as a key.
        // Query variable is an IEnumerable<IGrouping<string, Student>>
        var studentQuery3 =
            from student in students
            group student by student.Last;
        //</snippet13>
    }
}

// The rest of the samples must run and produce output
//<snippet14>
class GroupSample1
{
    // The element type of the data source.
    public class Student
    {
        public required string First { get; init; }
        public required string Last { get; init; }
        public required int ID { get; init; }
        public required List<int> Scores;
    }

    public static List<Student> GetStudents()
    {
        // Use a collection initializer to create the data source. Note that each element
        //  in the list contains an inner sequence of scores.
        List<Student> students =
        [
           new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= [97, 72, 81, 60]},
           new Student {First="Claire", Last="O'Donnell", ID=112, Scores= [75, 84, 91, 39]},
           new Student {First="Sven", Last="Mortensen", ID=113, Scores= [99, 89, 91, 95]},
           new Student {First="Cesar", Last="Garcia", ID=114, Scores= [72, 81, 65, 84]},
           new Student {First="Debra", Last="Garcia", ID=115, Scores= [97, 89, 85, 82]}
        ];

        return students;
    }

    static void Main()
    {
        // Obtain the data source.
        List<Student> students = GetStudents();

        // Group by true or false.
        // Query variable is an IEnumerable<IGrouping<bool, Student>>
        var booleanGroupQuery =
            from student in students
            group student by student.Scores.Average() >= 80; //pass or fail!

        // Execute the query and access items in each group
        foreach (var studentGroup in booleanGroupQuery)
        {
            Console.WriteLine(studentGroup.Key == true ? "High averages" : "Low averages");
            foreach (var student in studentGroup)
            {
                Console.WriteLine("   {0}, {1}:{2}", student.Last, student.First, student.Scores.Average());
            }
        }
    }
}
/* Output:
  Low averages
   Omelchenko, Svetlana:77.5
   O'Donnell, Claire:72.25
   Garcia, Cesar:75.5
  High averages
   Mortensen, Sven:93.5
   Garcia, Debra:88.25
*/
//</snippet14>

//<snippet15>
class GroupSample2
{
    // The element type of the data source.
    public class Student
    {
        public required string First { get; init; }
        public required string Last { get; init; }
        public required int ID { get; init; }
        public required List<int> Scores;
    }

    public static List<Student> GetStudents()
    {
        // Use a collection initializer to create the data source. Note that each element
        //  in the list contains an inner sequence of scores.
        List<Student> students =
        [
           new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= [97, 72, 81, 60]},
           new Student {First="Claire", Last="O'Donnell", ID=112, Scores= [75, 84, 91, 39]},
           new Student {First="Sven", Last="Mortensen", ID=113, Scores= [99, 89, 91, 95]},
           new Student {First="Cesar", Last="Garcia", ID=114, Scores= [72, 81, 65, 84]},
           new Student {First="Debra", Last="Garcia", ID=115, Scores= [97, 89, 85, 82]}
        ];

        return students;
    }

    // This method groups students into percentile ranges based on their
    // grade average. The Average method returns a double, so to produce a whole
    // number it is necessary to cast to int before dividing by 10.
    static void Main()
    {
        // Obtain the data source.
        List<Student> students = GetStudents();

        // Write the query.
        var studentQuery =
            from student in students
            let avg = (int)student.Scores.Average()
            group student by (avg / 10) into g
            orderby g.Key
            select g;

        // Execute the query.
        foreach (var studentGroup in studentQuery)
        {
            int temp = studentGroup.Key * 10;
            Console.WriteLine($"Students with an average between {temp} and {temp + 10}");
            foreach (var student in studentGroup)
            {
                Console.WriteLine("   {0}, {1}:{2}", student.Last, student.First, student.Scores.Average());
            }
        }
    }
}
/* Output:
     Students with an average between 70 and 80
       Omelchenko, Svetlana:77.5
       O'Donnell, Claire:72.25
       Garcia, Cesar:75.5
     Students with an average between 80 and 90
       Garcia, Debra:88.25
     Students with an average between 90 and 100
       Mortensen, Sven:93.5
 */
//</snippet15>

//<snippet16>
class GroupExample1
{
    static void Main()
    {
        // Create a data source.
        string[] words = ["blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese"];

        // Create the query.
        var wordGroups =
            from w in words
            group w by w[0];

        // Execute the query.
        foreach (var wordGroup in wordGroups)
        {
            Console.WriteLine($"Words that start with the letter '{wordGroup.Key}':");
            foreach (var word in wordGroup)
            {
                Console.WriteLine(word);
            }
        }
    }
}
/* Output:
      Words that start with the letter 'b':
        blueberry
        banana
      Words that start with the letter 'c':
        chimpanzee
        cheese
      Words that start with the letter 'a':
        abacus
        apple
     */
//</snippet16>

//<snippet17>
class GroupClauseExample2
{
    static void Main()
    {
        // Create the data source.
        string[] words2 = ["blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese", "elephant", "umbrella", "anteater"];

        // Create the query.
        var wordGroups2 =
            from w in words2
            group w by w[0] into grps
            where (grps.Key == 'a' || grps.Key == 'e' || grps.Key == 'i'
                   || grps.Key == 'o' || grps.Key == 'u')
            select grps;

        // Execute the query.
        foreach (var wordGroup in wordGroups2)
        {
            Console.WriteLine($"Groups that start with a vowel: {wordGroup.Key}");
            foreach (var word in wordGroup)
            {
                Console.WriteLine($"   {word}");
            }
        }
    }
}
/* Output:
    Groups that start with a vowel: a
        abacus
        apple
        anteater
    Groups that start with a vowel: e
        elephant
    Groups that start with a vowel: u
        umbrella
*/
//</snippet17>
