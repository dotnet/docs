        public void GroupBySubstring()
        {            
            Console.WriteLine("\r\nGroup by something other than a property of the object:");

            var queryFirstLetters =
                from student in students
                group student by student.LastName[0];

            foreach (var studentGroup in queryFirstLetters)
            {
                Console.WriteLine("Key: {0}", studentGroup.Key);
                // Nested foreach is required to access group items.
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("\t{0}, {1}", student.LastName, student.FirstName);
                }
            }           
        }
        /* Output:
            Group by something other than a property of the object:
            Key: A
                    Adams, Terry
            Key: F
                    Fakhouri, Fadi
                    Feng, Hanying
            Key: G
                    Garcia, Cesar
                    Garcia, Debra
                    Garcia, Hugo
            Key: M
                    Mortensen, Sven
            Key: O
                    O'Donnell, Claire
                    Omelchenko, Svetlana
            Key: T
                    Tucker, Lance
                    Tucker, Michael
            Key: Z
                    Zabokritski, Eugene
        */