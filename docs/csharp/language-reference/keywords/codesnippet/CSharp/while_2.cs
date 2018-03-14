    class WhileTest2 
    {
        static void Main() 
        {
            int n = 1;
            while (n++ < 6) 
            {
                Console.WriteLine("Current value of n is {0}", n);
            }
        }
    }
    /*
    Output:
    Current value of n is 2
    Current value of n is 3
    Current value of n is 4
    Current value of n is 5
    Current value of n is 6
    */