        public void GroupBySingleProperty()
        {
            Console.WriteLine("Group by a single property in an object:");

            // Variable queryLastNames is an IEnumerable<IGrouping<string, 
            // DataClass.Student>>. 
            var queryLastNames =
                from student in students
                group student by student.LastName into newGroup
                orderby newGroup.Key
                select newGroup;

            foreach (var nameGroup in queryLastNames)
            {
                Console.WriteLine("Key: {0}", nameGroup.Key);
                foreach (var student in nameGroup)
                {
                    Console.WriteLine("\t{0}, {1}", student.LastName, student.FirstName);
                }
            }
        }
        /* Output:
            Group by a single property in an object:
            Key: Adams
                    Adams, Terry
            Key: Fakhouri
                    Fakhouri, Fadi
            Key: Feng
                    Feng, Hanying
            Key: Garcia
                    Garcia, Cesar
                    Garcia, Debra
                    Garcia, Hugo
            Key: Mortensen
                    Mortensen, Sven
            Key: O'Donnell
                    O'Donnell, Claire
            Key: Omelchenko
                    Omelchenko, Svetlana
            Key: Tucker
                    Tucker, Lance
                    Tucker, Michael
            Key: Zabokritski
                    Zabokritski, Eugene
        */