    class GroupSample2
    {
        // The element type of the data source.
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }

        public static List<Student> GetStudents()
        {
            // Use a collection initializer to create the data source. Note that each element
            //  in the list contains an inner sequence of scores.
            List<Student> students = new List<Student>
            {
               new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 72, 81, 60}},
               new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
               new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {99, 89, 91, 95}},
               new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {72, 81, 65, 84}},
               new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {97, 89, 85, 82}} 
            };

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
                group student by (avg == 0 ? 0 : avg / 10) into g
                orderby g.Key
                select g;            

            // Execute the query.
            foreach (var studentGroup in studentQuery)
            {
                int temp = studentGroup.Key * 10;
                Console.WriteLine("Students with an average between {0} and {1}", temp, temp + 10);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}:{2}", student.Last, student.First, student.Scores.Average());
                }
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
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