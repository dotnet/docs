    class MergeTwoCSVFiles
    {
        static void Main()
        {
            // See section Compiling the Code for information about the data files.
            string[] names = System.IO.File.ReadAllLines(@"../../../names.csv");
            string[] scores = System.IO.File.ReadAllLines(@"../../../scores.csv");

            // Merge the data sources using a named type.
            // You could use var instead of an explicit type for the query.
            IEnumerable<Student> queryNamesScores =
                // Split each line in the data files into an array of strings.
                from name in names
                let x = name.Split(',')
                from score in scores
                let s = score.Split(',')
                // Look for matching IDs from the two data files.
                where x[2] == s[0]
                // If the IDs match, build a Student object.
                select new Student()
                {
                    FirstName = x[0],
                    LastName = x[1],
                    ID = Convert.ToInt32(x[2]),
                    ExamScores = (from scoreAsText in s.Skip(1)
                                  select Convert.ToInt32(scoreAsText)).
                                  ToList()
                };

            // Optional. Store the newly created student objects in memory
            // for faster access in future queries
            List<Student> students = queryNamesScores.ToList();

            foreach (var student in students)
            {
                Console.WriteLine("The average score of {0} {1} is {2}.",
                    student.FirstName, student.LastName, student.ExamScores.Average());
            }

            //Keep console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public List<int> ExamScores { get; set; }
    }

    /* Output: 
        The average score of Omelchenko Svetlana is 82.5.
        The average score of O'Donnell Claire is 72.25.
        The average score of Mortensen Sven is 84.5.
        The average score of Garcia Cesar is 88.25.
        The average score of Garcia Debra is 67.
        The average score of Fakhouri Fadi is 92.25.
        The average score of Feng Hanying is 88.
        The average score of Garcia Hugo is 85.75.
        The average score of Tucker Lance is 81.75.
        The average score of Adams Terry is 85.25.
        The average score of Zabokritski Eugene is 83.
        The average score of Tucker Michael is 92.
     */