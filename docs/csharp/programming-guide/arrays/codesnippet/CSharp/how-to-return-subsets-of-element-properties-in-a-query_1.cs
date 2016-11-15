                private static void QueryByScore()
                {
                    // Create the query. var is required because
                    // the query produces a sequence of anonymous types.
                    var queryHighScores =
                        from student in students
                        where student.ExamScores[0] > 95
                        select new { student.FirstName, student.LastName };

                    // Execute the query.
                    foreach (var obj in queryHighScores)
                    {
                        // The anonymous type's properties were not named. Therefore 
                        // they have the same names as the Student properties.
                        Console.WriteLine(obj.FirstName + ", " + obj.LastName);
                    }
                }
                /* Output:
                Adams, Terry
                Fakhouri, Fadi
                Garcia, Cesar
                Omelchenko, Svetlana
                Zabokritski, Eugene
                */