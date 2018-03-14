        public void GroupByCompositeKey()
        {

            var queryHighScoreGroups =
                from student in students
                group student by new { FirstLetter = student.LastName[0], 
                    Score = student.ExamScores[0] > 85 } into studentGroup
                orderby studentGroup.Key.FirstLetter
                select studentGroup;

            Console.WriteLine("\r\nGroup and order by a compound key:");
            foreach (var scoreGroup in queryHighScoreGroups)
            {
                string s = scoreGroup.Key.Score == true ? "more than" : "less than";
                Console.WriteLine("Name starts with {0} who scored {1} 85", scoreGroup.Key.FirstLetter, s);
                foreach (var item in scoreGroup)
                {
                    Console.WriteLine("\t{0} {1}", item.FirstName, item.LastName);
                }
            }
        }
        /* Output:
            Group and order by a compound key:
            Name starts with A who scored more than 85
                    Terry Adams
            Name starts with F who scored more than 85
                    Fadi Fakhouri
                    Hanying Feng
            Name starts with G who scored more than 85
                    Cesar Garcia
                    Hugo Garcia
            Name starts with G who scored less than 85
                    Debra Garcia
            Name starts with M who scored more than 85
                    Sven Mortensen
            Name starts with O who scored less than 85
                    Claire O'Donnell
            Name starts with O who scored more than 85
                    Svetlana Omelchenko
            Name starts with T who scored less than 85
                    Lance Tucker
            Name starts with T who scored more than 85
                    Michael Tucker
            Name starts with Z who scored more than 85
                    Eugene Zabokritski
        */