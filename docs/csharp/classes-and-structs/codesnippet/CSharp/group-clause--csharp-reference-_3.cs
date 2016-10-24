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