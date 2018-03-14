        public static void OpTest<T>(T s, T t) where T : class
        {
            System.Console.WriteLine(s == t);
        }
        static void Main()
        {
            string s1 = "target";
            System.Text.StringBuilder sb = new System.Text.StringBuilder("target");
            string s2 = sb.ToString();
            OpTest<string>(s1, s2);
        }