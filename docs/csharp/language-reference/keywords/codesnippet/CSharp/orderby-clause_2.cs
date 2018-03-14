    class OrderbySample2
    {
        // The element type of the data source.
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
        }

        public static List<Student> GetStudents()
        {
            // Use a collection initializer to create the data source. Note that each element
            //  in the list contains an inner sequence of scores.
            List<Student> students = new List<Student>
            {
               new Student {First="Svetlana", Last="Omelchenko", ID=111},
               new Student {First="Claire", Last="O'Donnell", ID=112},
               new Student {First="Sven", Last="Mortensen", ID=113},
               new Student {First="Cesar", Last="Garcia", ID=114},
               new Student {First="Debra", Last="Garcia", ID=115} 
            };

            return students;

        }
        static void Main(string[] args)
        {
            // Create the data source.
            List<Student> students = GetStudents();
            
            // Create the query.
            IEnumerable<Student> sortedStudents =
                from student in students
                orderby student.Last ascending, student.First ascending
                select student;

            // Execute the query.
            Console.WriteLine("sortedStudents:");
            foreach (Student student in sortedStudents)
                Console.WriteLine(student.Last + " " + student.First);           

            // Now create groups and sort the groups. The query first sorts the names
            // of all students so that they will be in alphabetical order after they are
            // grouped. The second orderby sorts the group keys in alpha order.            
            var sortedGroups =
                from student in students
                orderby student.Last, student.First
                group student by student.Last[0] into newGroup
                orderby newGroup.Key
                select newGroup;

            // Execute the query.
            Console.WriteLine(Environment.NewLine + "sortedGroups:");
            foreach (var studentGroup in sortedGroups)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}", student.Last, student.First);
                }
            }

            // Keep the console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:  
    sortedStudents:
    Garcia Cesar
    Garcia Debra
    Mortensen Sven
    O'Donnell Claire
    Omelchenko Svetlana

    sortedGroups:
    G
       Garcia, Cesar
       Garcia, Debra
    M
       Mortensen, Sven
    O
       O'Donnell, Claire
       Omelchenko, Svetlana
    */