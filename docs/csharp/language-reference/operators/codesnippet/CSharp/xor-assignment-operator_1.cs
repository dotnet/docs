    class XORAssignment
    {
        static void Main()
        {
            int a = 0x0c;
            a ^= 0x06;
            Console.WriteLine("0x{0:x8}", a);
            bool b = true;
            b ^= false;
            Console.WriteLine(b);
        }
    }
    /*
    Output:
    0x0000000a
    True
    */