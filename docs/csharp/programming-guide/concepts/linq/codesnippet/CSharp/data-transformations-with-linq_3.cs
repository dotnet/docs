    class XMLTransform
    {
        static void Main()
        {            
            // Create the data source by using a collection initializer.
            // The Student class was defined previously in this topic.
            List<Student> students = new List<Student>()
            {
                new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores = new List<int>{97, 92, 81, 60}},
                new Student {First="Claire", Last="O’Donnell", ID=112, Scores = new List<int>{75, 84, 91, 39}},
                new Student {First="Sven", Last="Mortensen", ID=113, Scores = new List<int>{88, 94, 65, 91}},
            };

            // Create the query.
            var studentsToXML = new XElement("Root",
                from student in students
                let x = String.Format("{0},{1},{2},{3}", student.Scores[0],
                        student.Scores[1], student.Scores[2], student.Scores[3])
                select new XElement("student",
                           new XElement("First", student.First),
                           new XElement("Last", student.Last),
                           new XElement("Scores", x)
                        ) // end "student"
                    ); // end "Root"

            // Execute the query.
            Console.WriteLine(studentsToXML);

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }