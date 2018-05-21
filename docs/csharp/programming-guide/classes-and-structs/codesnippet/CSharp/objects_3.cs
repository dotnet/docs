            // Person is defined in the previous example.

            //public struct Person
            //{
            //    public string Name;
            //    public int Age;
            //    public Person(string name, int age)
            //    {
            //        Name = name;
            //        Age = age;
            //    }
            //}

            Person p1 = new Person("Wallace", 75);
            Person p2;
            p2.Name = "Wallace";
            p2.Age = 75;

            if (p2.Equals(p1))
                Console.WriteLine("p2 and p1 have the same values.");

            // Output: p2 and p1 have the same values.