    class Equality
    {
        static void Main()
        {
            // Numeric equality: True
            Console.WriteLine((2 + 2) == 4);

            // Reference equality: different objects, 
            // same boxed value: False.
            object s = 1;
            object t = 1;
            Console.WriteLine(s == t);

            // Define some strings:
            string a = "hello";
            string b = String.Copy(a);
            string c = "hello";

            // Compare string values of a constant and an instance: True
            Console.WriteLine(a == b);

            // Compare string references; 
            // a is a constant but b is an instance: False.
            Console.WriteLine((object)a == (object)b);

            // Compare string references, both constants 
            // have the same value, so string interning
            // points to same reference: True.
            Console.WriteLine((object)a == (object)c);
        }
    }
    /*
    Output:
    True
    False
    True
    False
    True
    */