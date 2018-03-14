        public void QueryNestedGroups()
        {
            var queryNestedGroups =
                from student in students
                group student by student.Year into newGroup1
                from newGroup2 in
                    (from student in newGroup1
                     group student by student.LastName)
                group newGroup2 by newGroup1.Key;

            // Three nested foreach loops are required to iterate 
            // over all elements of a grouped group. Hover the mouse 
            // cursor over the iteration variables to see their actual type.
            foreach (var outerGroup in queryNestedGroups)
            {
                Console.WriteLine("DataClass.Student Level = {0}", outerGroup.Key);
                foreach (var innerGroup in outerGroup)
                {
                    Console.WriteLine("\tNames that begin with: {0}", innerGroup.Key);
                    foreach (var innerGroupElement in innerGroup)
                    {
                        Console.WriteLine("\t\t{0} {1}", innerGroupElement.LastName, innerGroupElement.FirstName);
                    }
                }
            }
        }
        /*
         Output:
        DataClass.Student Level = SecondYear
                Names that begin with: Adams
                        Adams Terry
                Names that begin with: Garcia
                        Garcia Hugo
                Names that begin with: Omelchenko
                        Omelchenko Svetlana
        DataClass.Student Level = ThirdYear
                Names that begin with: Fakhouri
                        Fakhouri Fadi
                Names that begin with: Garcia
                        Garcia Debra
                Names that begin with: Tucker
                        Tucker Lance
        DataClass.Student Level = FirstYear
                Names that begin with: Feng
                        Feng Hanying
                Names that begin with: Mortensen
                        Mortensen Sven
                Names that begin with: Tucker
                        Tucker Michael
        DataClass.Student Level = FourthYear
                Names that begin with: Garcia
                        Garcia Cesar
                Names that begin with: O'Donnell
                        O'Donnell Claire
                Names that begin with: Zabokritski
                        Zabokritski Eugene        
         */