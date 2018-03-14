        public void GroupByRange()
        {            
            Console.WriteLine("\r\nGroup by numeric range and project into a new anonymous type:");

            var queryNumericRange =
                from student in students
                let percentile = GetPercentile(student)
                group new { student.FirstName, student.LastName } by percentile into percentGroup
                orderby percentGroup.Key
                select percentGroup;

            // Nested foreach required to iterate over groups and group items.
            foreach (var studentGroup in queryNumericRange)
            {
                Console.WriteLine("Key: {0}", (studentGroup.Key * 10));
                foreach (var item in studentGroup)
                {
                    Console.WriteLine("\t{0}, {1}", item.LastName, item.FirstName);
                }
            }            
        }
        /* Output:
            Group by numeric range and project into a new anonymous type:
            Key: 60
                    Garcia, Debra
            Key: 70
                    O'Donnell, Claire
            Key: 80
                    Adams, Terry
                    Feng, Hanying
                    Garcia, Cesar
                    Garcia, Hugo
                    Mortensen, Sven
                    Omelchenko, Svetlana
                    Tucker, Lance
                    Zabokritski, Eugene
            Key: 90
                    Fakhouri, Fadi
                    Tucker, Michael
        */