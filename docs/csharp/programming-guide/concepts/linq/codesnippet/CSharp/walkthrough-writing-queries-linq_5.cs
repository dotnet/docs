            // studentGroup is a IGrouping<char, Student>
            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (Student student in studentGroup)
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