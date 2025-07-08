namespace UnsafeCodePointers;

public static class FixedKeywordExamples
{
    public static void Examples()
    {
        PointerTypes();
        AccessEmbeddedArray();
        UnsafeCopyArrays();
    }

    private static void PointerTypes()
    {
        // <Snippet5>
        // Normal pointer to an object.
        int[] a = [10, 20, 30, 40, 50];
        // Must be in unsafe code to use interior pointers.
        unsafe
        {
            // Must pin object on heap so that it doesn't move while using interior pointers.
            fixed (int* p = &a[0])
            {
                Console.WriteLine("Print first two elements using interior pointers:");
                Console.WriteLine(*p);
                // p and its container object a are pinned
                // The fixed pointer (p) cannot be incremented directly
                // Another pointer is required for incrementing
                int* p2 = p;
                // Increment the p2 pointer by the size of one int
                p2 += 1;
                Console.WriteLine(*p2);
                // Increment the p2 pointer by the size of three ints (to the last element)
                p2 += 3;
                Console.WriteLine(*p2);
                Console.WriteLine("Increment each element by 5 using interior pointers");
                for (int i = 0; i < a.Length; i++)
                {
                    // p3 will reference past the end of the loop on the last iteration
                    // a good reason to keep it private to the loop
                    int* p3 = p + i;
                    *p3 += 5; // Increment the value at the pointer
                }
            }
        }

        Console.WriteLine("Print final values:");
        foreach (var item in a)
        {
            Console.WriteLine(item);
        }

        /* Output:
        Print first two elements using interior pointers:
        10
        20
        50
        Increment each element by 5 using interior pointers
        Print final values:
        15
        25
        35
        45
        55
        */
        // </Snippet5>
    }

    // <Snippet6>
    public struct PathArray
    {
        public char[] pathName;
        private int reserved;
    }
    // </Snippet6>

    // <Snippet7>
    internal unsafe struct Buffer
    {
        public fixed char fixedBuffer[128];
    }

    internal unsafe class Example
    {
        public Buffer buffer = default;
    }

    private static void AccessEmbeddedArray()
    {
        var example = new Example();

        unsafe
        {
            // Pin the buffer to a fixed location in memory.
            fixed (char* charPtr = example.buffer.fixedBuffer)
            {
                *charPtr = 'A';
            }
            // Access safely through the index:
            char c = example.buffer.fixedBuffer[0];
            Console.WriteLine(c);

            // Modify through the index:
            example.buffer.fixedBuffer[0] = 'B';
            Console.WriteLine(example.buffer.fixedBuffer[0]);
        }
    }
    // </Snippet7>
}
