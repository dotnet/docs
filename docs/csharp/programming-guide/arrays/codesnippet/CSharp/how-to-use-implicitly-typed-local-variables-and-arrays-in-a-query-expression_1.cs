                private static void QueryNames(char firstLetter)
                {
                    // Create the query. Use of var is required because
                    // the query produces a sequence of anonymous types:
                    // System.Collections.Generic.IEnumerable<????>.
                    var studentQuery =
                        from student in students
                        where student.FirstName[0] == firstLetter
                        select new { student.FirstName, student.LastName };

                    // Execute the query and display the results.
                    foreach (var anonType in studentQuery)
                    {
                        Console.WriteLine("First = {0}, Last = {1}", anonType.FirstName, anonType.LastName);
                    }
                }