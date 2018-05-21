            var studentQuery3 =
                from student in students
                group student by student.Last[0];

            foreach (var groupOfStudents in studentQuery3)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("   {0}, {1}",
                        student.Last, student.First);
                }
            }

            // Output:
            // O
            //   Omelchenko, Svetlana
            //   O'Donnell, Claire
            // M
            //   Mortensen, Sven
            // G
            //   Garcia, Cesar
            //   Garcia, Debra
            //   Garcia, Hugo
            // F
            //   Fakhouri, Fadi
            //   Feng, Hanying
            // T
            //   Tucker, Lance
            //   Tucker, Michael
            // A
            //   Adams, Terry
            // Z
            //   Zabokritski, Eugene