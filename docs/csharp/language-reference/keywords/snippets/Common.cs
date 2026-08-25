namespace CommonTypes;


public class Common
{
    // The element type of the data source
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
           new Student {First="Sven", Last="Mortensen", ID=113, Scores= [88, 94, 65, 85]},
           new Student {First="Cesar", Last="Garcia", ID=114, Scores= [97, 89, 85, 82]},
           new Student {First="Debra", Last="Garcia", ID=115, Scores= [35, 72, 91, 70]}
        ];

        return students;
    }
}
