    class OR
    {
        static void Main()
        {
            Console.WriteLine(true | false);  // logical or
            Console.WriteLine(false | false); // logical or
            Console.WriteLine("0x{0:x}", 0xf8 | 0x3f);   // bitwise or
        }
    }
    /*
    Output:
    True
    False
    0xff
    */