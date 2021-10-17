using System;

namespace operators
{
    public static class BitwiseAndShiftOperators
    {
        public static void Examples()
        {
            Console.WriteLine("==== ~, &, ^, and | operators");
            BitwiseComplement();
            BitwiseAnd();
            BitwiseXor();
            BitwiseOr();

            Console.WriteLine("==== << and >> operators");
            LeftShift();
            RightShift();
            ShiftCount();

            Console.WriteLine("==== Additional examples");
            CompoundAssignment();
            CompoundAssignmentWithCast();
            Precedence();
        }

        private static void BitwiseComplement()
        {
            // <SnippetBitwiseComplement>
            uint a = 0b_0000_1111_0000_1111_0000_1111_0000_1100;
            uint b = ~a;
            Console.WriteLine(Convert.ToString(b, toBase: 2));
            // Output:
            // 11110000111100001111000011110011
            // </SnippetBitwiseComplement>
        }

        private static void BitwiseAnd()
        {
            // <SnippetBitwiseAnd>
            uint a = 0b_1111_1000;
            uint b = 0b_1001_1101;
            uint c = a & b;
            Console.WriteLine(Convert.ToString(c, toBase: 2));
            // Output:
            // 10011000
            // </SnippetBitwiseAnd>
        }

        private static void BitwiseXor()
        {
            // <SnippetBitwiseXor>
            uint a = 0b_1111_1000;
            uint b = 0b_0001_1100;
            uint c = a ^ b;
            Console.WriteLine(Convert.ToString(c, toBase: 2));
            // Output:
            // 11100100
            // </SnippetBitwiseXor>
        }

        private static void BitwiseOr()
        {
            // <SnippetBitwiseOr>
            uint a = 0b_1010_0000;
            uint b = 0b_1001_0001;
            uint c = a | b;
            Console.WriteLine(Convert.ToString(c, toBase: 2));
            // Output:
            // 10110001
            // </SnippetBitwiseOr>
        }

        private static void LeftShift()
        {
            // <SnippetLeftShift>
            uint x = 0b_1100_1001_0000_0000_0000_0000_0001_0001;
            Console.WriteLine($"Before: {Convert.ToString(x, toBase: 2)}");

            uint y = x << 4;
            Console.WriteLine($"After:  {Convert.ToString(y, toBase: 2)}");
            // Output:
            // Before: 11001001000000000000000000010001
            // After:  10010000000000000000000100010000
            // </SnippetLeftShift>

            // <SnippetLeftShiftPromoted>
            byte a = 0b_1111_0001;

            var b = a << 8;
            Console.WriteLine(b.GetType());
            Console.WriteLine($"Shifted byte: {Convert.ToString(b, toBase: 2)}");
            // Output:
            // System.Int32
            // Shifted byte: 1111000100000000
            // </SnippetLeftShiftPromoted>
        }

        private static void RightShift()
        {
            // <SnippetRightShift>
            uint x = 0b_1001;
            Console.WriteLine($"Before: {Convert.ToString(x, toBase: 2), 4}");

            uint y = x >> 2;
            Console.WriteLine($"After:  {Convert.ToString(y, toBase: 2), 4}");
            // Output:
            // Before: 1001
            // After:    10
            // </SnippetRightShift>

            // <SnippetArithmeticRightShift>
            int a = int.MinValue;
            Console.WriteLine($"Before: {Convert.ToString(a, toBase: 2)}");

            int b = a >> 3;
            Console.WriteLine($"After:  {Convert.ToString(b, toBase: 2)}");
            // Output:
            // Before: 10000000000000000000000000000000
            // After:  11110000000000000000000000000000
            // </SnippetArithmeticRightShift>

            // <SnippetLogicalRightShift>
            uint c = 0b_1000_0000_0000_0000_0000_0000_0000_0000;
            Console.WriteLine($"Before: {Convert.ToString(c, toBase: 2), 32}");

            uint d = c >> 3;
            Console.WriteLine($"After:  {Convert.ToString(d, toBase: 2), 32}");
            // Output:
            // Before: 10000000000000000000000000000000
            // After:     10000000000000000000000000000
            // </SnippetLogicalRightShift>
        }

        private static void ShiftCount()
        {
            // <SnippetShiftCount>
            int count1 = 0b_0000_0001;
            int count2 = 0b_1110_0001;

            int a = 0b_0001;
            Console.WriteLine($"{a} << {count1} is {a << count1}; {a} << {count2} is {a << count2}");
            // Output:
            // 1 << 1 is 2; 1 << 225 is 2

            int b = 0b_0100;
            Console.WriteLine($"{b} >> {count1} is {b >> count1}; {b} >> {count2} is {b >> count2}");
            // Output:
            // 4 >> 1 is 2; 4 >> 225 is 2
            // </SnippetShiftCount>
        }

        private static void CompoundAssignment()
        {
            // <SnippetCompoundAssignment>
            uint INITIAL_VALUE = 0b_1111_1000;
            
            uint a = INITIAL_VALUE;
            a &= 0b_1001_1101; 
            Display(a);  // output: 10011000

            a = INITIAL_VALUE;
            a |= 0b_0011_0001; 
            Display(a);  // output: 11111001

            a = INITIAL_VALUE;
            a ^= 0b_1000_0000;
            Display(a);  // output: 1111000

            a = INITIAL_VALUE;
            a <<= 2;
            Display(a);  // output: 1111100000

            a = INITIAL_VALUE;
            a >>= 4;
            Display(a);  // output: 1111

            void Display(uint x) => Console.WriteLine($"{Convert.ToString(x, toBase: 2), 8}");
            // </SnippetCompoundAssignment>
        }

        private static void CompoundAssignmentWithCast()
        {
            // <SnippetCompoundAssignmentWithCast>
            byte x = 0b_1111_0001;

            int b = x << 8;
            Console.WriteLine($"{Convert.ToString(b, toBase: 2)}");  // output: 1111000100000000

            x <<= 8;
            Console.WriteLine(x);  // output: 0
            // </SnippetCompoundAssignmentWithCast>
        }

        private static void Precedence()
        {
            // <SnippetPrecedence>
            uint a = 0b_1101;
            uint b = 0b_1001;
            uint c = 0b_1010;

            uint d1 = a | b & c;
            Display(d1);  // output: 1101

            uint d2 = (a | b) & c;
            Display(d2);  // output: 1000

            void Display(uint x) => Console.WriteLine($"{Convert.ToString(x, toBase: 2), 4}");
            // </SnippetPrecedence>
        }
    }
}
