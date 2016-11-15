            var studentQuery4 =
                from student in students
                group student by student.Last[0] into studentGroup
                orderby studentGroup.Key
                select studentGroup;

            foreach (var groupOfStudents in studentQuery4)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("   {0}, {1}",
                        student.Last, student.First);
                }
            }

            // Output:
            //A
            //   Adams, Terry
            //F
            //   Fakhouri, Fadi
            //   Feng, Hanying
            //G
            //   Garcia, Cesar
            //   Garcia, Debra
            //   Garcia, Hugo
            //M
            //   Mortensen, Sven
            //O
            //   Omelchenko, Svetlana
            //   O'Donnell, Claire
            //T
            //   Tucker, Lance
            //   Tucker, Michael
            //Z
            //   Zabokritski, Eugene