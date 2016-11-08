    class XOR
    {
        static void Main()
        {
            // Logical exclusive-OR

            // When one operand is true and the other is false, exclusive-OR 
            // returns True.
            Console.WriteLine(true ^ false);
            // When both operands are false, exclusive-OR returns False.
            Console.WriteLine(false ^ false);
            // When both operands are true, exclusive-OR returns False.
            Console.WriteLine(true ^ true);


            // Bitwise exclusive-OR

            // Bitwise exclusive-OR of 0 and 1 returns 1.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x0 ^ 0x1, 2));
            // Bitwise exclusive-OR of 0 and 0 returns 0.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x0 ^ 0x0, 2));
            // Bitwise exclusive-OR of 1 and 1 returns 0.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x1 ^ 0x1, 2));

            // With more than one digit, perform the exclusive-OR column by column.
            //    10
            //    11
            //    --
            //    01
            // Bitwise exclusive-OR of 10 (2) and 11 (3) returns 01 (1).
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x2 ^ 0x3, 2));

            // Bitwise exclusive-OR of 101 (5) and 011 (3) returns 110 (6).
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x5 ^ 0x3, 2));

            // Bitwise exclusive-OR of 1111 (decimal 15, hexadecimal F) and 0101 (5)
            // returns 1010 (decimal 10, hexadecimal A).
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0xf ^ 0x5, 2));

            // Finally, bitwise exclusive-OR of 11111000 (decimal 248, hexadecimal F8)
            // and 00111111 (decimal 63, hexadecimal 3F) returns 11000111, which is 
            // 199 in decimal, C7 in hexadecimal.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0xf8 ^ 0x3f, 2));
        }
    }
    /*
    Output:
    True
    False
    False
    Bitwise result: 1
    Bitwise result: 0
    Bitwise result: 0
    Bitwise result: 1
    Bitwise result: 110
    Bitwise result: 1010
    Bitwise result: 11000111
    */
