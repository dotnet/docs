// This file demonstrates the C# 15 memory safety relaxations verified against
// .NET 11 Preview 5. Creating pointers, the fixed statement, stackalloc-to-pointer,
// and sizeof no longer require an unsafe context. Only operations that access the
// pointed-to memory still require one.

namespace MemorySafety;

public class Relaxations
{
    // <CreatePointer>
    public static void CreatePointer()
    {
        int value = 42;
        // Creating a pointer doesn't require an unsafe context.
        int* pointer = &value;
        int** pointerToPointer = &pointer;
    }
    // </CreatePointer>

    // <FixedStatement>
    public static void PinArray(int[] numbers)
    {
        // The fixed statement no longer requires an unsafe context.
        fixed (int* first = numbers)
        {
            int* current = first;
        }
    }
    // </FixedStatement>

    // <StackallocToPointer>
    public static void AllocateOnStack()
    {
        // Converting a stackalloc to a pointer no longer requires an unsafe context.
        int* buffer = stackalloc int[10];
    }
    // </StackallocToPointer>

    // <SizeOf>
    public static int SizeOfStruct()
    {
        // sizeof of any unmanaged type no longer requires an unsafe context.
        return sizeof(System.Guid);
    }
    // </SizeOf>

    // <Dereference>
    public static int ReadValue(int[] numbers)
    {
        fixed (int* first = numbers)
        {
            // Dereferencing a pointer accesses unmanaged memory, so it still
            // requires an unsafe context.
            unsafe
            {
                return *first;
            }
        }
    }
    // </Dereference>
}
