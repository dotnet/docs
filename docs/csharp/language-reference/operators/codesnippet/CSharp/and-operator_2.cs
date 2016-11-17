    class BitwiseAnd
    {
        static void Main()
        {
            // The following two statements perform logical ANDs.
            Console.WriteLine(true & false); 
            Console.WriteLine(true & true);  

            // The following line performs a bitwise AND of F8 (1111 1000) and
            // 3F (0011 1111).
            //    1111 1000
            //    0011 1111
            //    ---------
            //    0011 1000 or 38
            Console.WriteLine("0x{0:x}", 0xf8 & 0x3f); 
        }
    }
    // Output:
    // False
    // True
    // 0x38