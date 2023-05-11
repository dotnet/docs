PinnedArray();
PinnedVariable();
PinnedSpan();
PinnedString();

static void PinnedArray()
{
    // <PinnedArray>
    unsafe
    {
        byte[] bytes = { 1, 2, 3 };
        fixed (byte* pointerToFirst = bytes)
        {
            Console.WriteLine($"The address of the first array element: {(long)pointerToFirst:X}.");
            Console.WriteLine($"The value of the first array element: {*pointerToFirst}.");
        }
    }
    // Output is similar to:
    // The address of the first array element: 2173F80B5C8.
    // The value of the first array element: 1.
    // </PinnedArray>
}

static void PinnedVariable()
{
    // <PinnedVariable>
    unsafe
    {
        int[] numbers = { 10, 20, 30 };
        fixed (int* toFirst = &numbers[0], toLast = &numbers[^1])
        {
            Console.WriteLine(toLast - toFirst);  // output: 2
        }
    }
    // </PinnedVariable>
}

static void PinnedSpan()
{
    // <PinnedSpan>
    unsafe
    {
        int[] numbers = { 10, 20, 30, 40, 50 };
        Span<int> interior = numbers.AsSpan()[1..^1];
        fixed (int* p = interior)
        {
            for (int i = 0; i < interior.Length; i++)
            {
                Console.Write(p[i]);  
            }
            // output: 203040
        }
    }
    // </PinnedSpan>
    Console.WriteLine();
}

static void PinnedString()
{
    // <PinnedString>
    unsafe
    {
        var message = "Hello!";
        fixed (char* p = message)
        {
            Console.WriteLine(*p);  // output: H
        }
    }
    // </PinnedString>
}
