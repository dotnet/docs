            // Execute the query.
            // var could be used here also.
            foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0}, {1}", student.Last, student.First);
            }

            // Output:
            // Omelchenko, Svetlana
            // Garcia, Cesar
            // Fakhouri, Fadi
            // Feng, Hanying
            // Garcia, Hugo
            // Adams, Terry
            // Zabokritski, Eugene
            // Tucker, Michael