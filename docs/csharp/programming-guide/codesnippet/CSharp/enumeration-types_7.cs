            string s = Enum.GetName(typeof(Days), 4);
            Console.WriteLine(s);

            Console.WriteLine("The values of the Days Enum are:");
            foreach (int i in Enum.GetValues(typeof(Days)))
                Console.WriteLine(i);

            Console.WriteLine("The names of the Days Enum are:");
            foreach (string str in Enum.GetNames(typeof(Days)))
                Console.WriteLine(str);