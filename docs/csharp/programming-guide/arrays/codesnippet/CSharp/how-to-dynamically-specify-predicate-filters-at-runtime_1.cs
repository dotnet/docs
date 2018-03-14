    class DynamicPredicates : StudentClass
    {
        static void Main(string[] args)
        {
            string[] ids = { "111", "114", "112" };

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void QueryByID(string[] ids)
        {
            var queryNames =
                from student in students
                let i = student.ID.ToString()
                where ids.Contains(i)
                select new { student.LastName, student.ID };

            foreach (var name in queryNames)
            {
                Console.WriteLine("{0}: {1}", name.LastName, name.ID);
            }
        }
    }