    class MainClass11
    {
        static void Main()
        {
            int i = 1;
            long lg = 1;
            // Shift i one bit to the left. The result is 2.
            Console.WriteLine("0x{0:x}", i << 1);
            // In binary, 33 is 100001. Because the value of the five low-order
            // bits is 1, the result of the shift is again 2. 
            Console.WriteLine("0x{0:x}", i << 33);
            // Because the type of lg is long, the shift is the value of the six
            // low-order bits. In this example, the shift is 33, and the value of
            // lg is shifted 33 bits to the left.
            //     In binary:     10 0000 0000 0000 0000 0000 0000 0000 0000 
            //     In hexadecimal: 2    0    0    0    0    0    0    0    0
            Console.WriteLine("0x{0:x}", lg << 33);
        }
    }
    /*
    Output:
    0x2
    0x2
    0x200000000
    */