        // First, in class Program, define the delegate type and a method that  
        // has a matching signature.

        // Define the type.
        public delegate void Del(string message);

        // Define a method that has a matching signature.
        public static void DelMethod(string str)
        {
            Console.WriteLine("DelMethod argument: {0}", str);
        }