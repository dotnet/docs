namespace operators;

public static class PointerOperators
{
    public static void Examples()
    {
        AddressOf();
        PointerIndirection();
        PointerMemberAccessExample.Main();
        PointerElementAccess();
        PointerAddition();
        PointerSubtraction();
        Increment();
    }

    private static void AddressOf()
    {
        // <SnippetAddressOf>
        unsafe
        {
            int number = 27;
            int* pointerToNumber = &number;

            Console.WriteLine($"Value of the variable: {number}");
            Console.WriteLine($"Address of the variable: {(long)pointerToNumber:X}");
        }
        // Output is similar to:
        // Value of the variable: 27
        // Address of the variable: 6C1457DBD4
        // </SnippetAddressOf>
    }

    private static void AddressOfFixed()
    {
        // <SnippetAddressOfFixed>
        unsafe
        {
            byte[] bytes = { 1, 2, 3 };
            fixed (byte* pointerToFirst = &bytes[0])
            {
                // The address stored in pointerToFirst
                // is valid only inside this fixed statement block.
            }
        }
        // </SnippetAddressOfFixed>
    }

    private static void PointerIndirection()
    {
        // <SnippetPointerIndirection>
        unsafe
        {
            char letter = 'A';
            char* pointerToLetter = &letter;
            Console.WriteLine($"Value of the `letter` variable: {letter}");
            Console.WriteLine($"Address of the `letter` variable: {(long)pointerToLetter:X}");

            *pointerToLetter = 'Z';
            Console.WriteLine($"Value of the `letter` variable after update: {letter}");
        }
        // Output is similar to:
        // Value of the `letter` variable: A
        // Address of the `letter` variable: DCB977DDF4
        // Value of the `letter` variable after update: Z
        // </SnippetPointerIndirection>
    }

    // <SnippetMemberAccess>
    public struct Coords
    {
        public int X;
        public int Y;
        public override string ToString() => $"({X}, {Y})";
    }

    public class PointerMemberAccessExample
    {
        public static unsafe void Main()
        {
            Coords coords;
            Coords* p = &coords;
            p->X = 3;
            p->Y = 4;
            Console.WriteLine(p->ToString());  // output: (3, 4)
        }
    }
    // </SnippetMemberAccess>

    private static void PointerElementAccess()
    {
        // <SnippetElementAccess>
        unsafe
        {
            char* pointerToChars = stackalloc char[123];

            for (int i = 65; i < 123; i++)
            {
                pointerToChars[i] = (char)i;
            }

            Console.Write("Uppercase letters: ");
            for (int i = 65; i < 91; i++)
            {
                Console.Write(pointerToChars[i]);
            }
        }
        // Output:
        // Uppercase letters: ABCDEFGHIJKLMNOPQRSTUVWXYZ
        // </SnippetElementAccess>
        Console.WriteLine();
    }

    private static void PointerAddition()
    {
        // <SnippetAddNumber>
        unsafe
        {
            const int Count = 3;
            int[] numbers = new int[Count] { 10, 20, 30 };
            fixed (int* pointerToFirst = &numbers[0])
            {
                int* pointerToLast = pointerToFirst + (Count - 1);

                Console.WriteLine($"Value {*pointerToFirst} at address {(long)pointerToFirst}");
                Console.WriteLine($"Value {*pointerToLast} at address {(long)pointerToLast}");
            }
        }
        // Output is similar to:
        // Value 10 at address 1818345918136
        // Value 30 at address 1818345918144
        // </SnippetAddNumber>
    }

    private static void PointerSubtraction()
    {
        // <SnippetSubtractPointers>
        unsafe
        {
            int* numbers = stackalloc int[] { 0, 1, 2, 3, 4, 5 };
            int* p1 = &numbers[1];
            int* p2 = &numbers[5];
            Console.WriteLine(p2 - p1);  // output: 4
        }
        // </SnippetSubtractPointers>
    }

    private static void Increment()
    {
        // <SnippetIncrement>
        unsafe
        {
            int* numbers = stackalloc int[] { 0, 1, 2 };
            int* p1 = &numbers[0];
            int* p2 = p1;
            Console.WriteLine($"Before operation: p1 - {(long)p1}, p2 - {(long)p2}");
            Console.WriteLine($"Postfix increment of p1: {(long)(p1++)}");
            Console.WriteLine($"Prefix increment of p2: {(long)(++p2)}");
            Console.WriteLine($"After operation: p1 - {(long)p1}, p2 - {(long)p2}");
        }
        // Output is similar to
        // Before operation: p1 - 816489946512, p2 - 816489946512
        // Postfix increment of p1: 816489946512
        // Prefix increment of p2: 816489946516
        // After operation: p1 - 816489946516, p2 - 816489946516
        // </SnippetIncrement>
    }
}
