            string[] names = { "Svetlana Omelchenko", "Claire O'Donnell", "Sven Mortensen", "Cesar Garcia" };
            IEnumerable<string> queryFirstNames =
                from name in names
                let firstName = name.Split(' ')[0]
                select firstName;

            foreach (string s in queryFirstNames)
                Console.Write(s + " ");
            //Output: Svetlana Claire Sven Cesar