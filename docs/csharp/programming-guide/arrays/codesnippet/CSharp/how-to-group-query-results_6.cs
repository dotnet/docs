        public void GroupByBoolean()
        {            
            Console.WriteLine("\r\nGroup by a Boolean into two groups with string keys");
            Console.WriteLine("\"True\" and \"False\" and project into a new anonymous type:");
            var queryGroupByAverages = from student in students
                                       group new { student.FirstName, student.LastName }
                                            by student.ExamScores.Average() > 75 into studentGroup
                                       select studentGroup;

            foreach (var studentGroup in queryGroupByAverages)
            {
                Console.WriteLine("Key: {0}", studentGroup.Key);
                foreach (var student in studentGroup)
                    Console.WriteLine("\t{0} {1}", student.FirstName, student.LastName);
            }            
        }
        /* Output:
            Group by a Boolean into two groups with string keys
            "True" and "False" and project into a new anonymous type:
            Key: True
                    Terry Adams
                    Fadi Fakhouri
                    Hanying Feng
                    Cesar Garcia
                    Hugo Garcia
                    Sven Mortensen
                    Svetlana Omelchenko
                    Lance Tucker
                    Michael Tucker
                    Eugene Zabokritski
            Key: False
                    Debra Garcia
                    Claire O'Donnell
        */