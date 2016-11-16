        // To run this sample, first specify an integer value of 1 to 4 for the command
        // line. This number will be converted to a GradeLevel value that specifies which
        // set of students to query. 
        // Call the method: QueryByYear(args[0]);

        static void QueryByYear(string level)
        {
            GradeLevel year = (GradeLevel)Convert.ToInt32(level);
            IEnumerable<Student> studentQuery = null;
            switch (year)
            {
                case GradeLevel.FirstYear:
                    studentQuery = from student in students
                                   where student.Year == GradeLevel.FirstYear
                                   select student;
                    break;
                case GradeLevel.SecondYear:
                    studentQuery = from student in students
                                   where student.Year == GradeLevel.SecondYear
                                   select student;
                    break;
                case GradeLevel.ThirdYear:
                    studentQuery = from student in students
                                   where student.Year == GradeLevel.ThirdYear
                                   select student;
                    break;
                case GradeLevel.FourthYear:
                    studentQuery = from student in students
                                   where student.Year == GradeLevel.FourthYear
                                   select student;
                    break;

                default:
                    break;
            }
            Console.WriteLine("The following students are at level {0}", year.ToString());
            foreach (Student name in studentQuery)
            {
                Console.WriteLine("{0}: {1}", name.LastName, name.ID);
            }
        }