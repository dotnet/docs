                    // Variable queryID could be declared by using 
                    // System.Collections.Generic.IEnumerable<string>
                    // instead of var.
                    var queryID =
                        from student in students
                        where student.ID > 111
                        select student.LastName;

                    // Variable str could be declared by using var instead of string.     
                    foreach (string str in queryID)
                    {
                        Console.WriteLine("Last name: {0}", str);
                    }