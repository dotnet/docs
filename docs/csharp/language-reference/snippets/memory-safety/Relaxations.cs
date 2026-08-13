// This file demonstrates the C# 15 memory safety relaxations and the `unsafe`
// expression, verified against .NET 11 Preview 6. Creating pointers, the fixed
// statement, stackalloc-to-pointer, and sizeof no longer require an unsafe
// context. Only operations that access the pointed-to memory still require one.

using System.Threading.Tasks;

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

    // <UnsafeExpression>
    // A field initializer can't contain an unsafe block, but it can contain an
    // unsafe expression. The unsafe context ends at the closing parenthesis.
    public static readonly int Signature = unsafe(ReadSignature());

    private static unsafe int ReadSignature()
    {
        int rawValue = 0x1234;
        int* pointer = &rawValue;
        return *pointer;
    }
    // </UnsafeExpression>

    // <AwaitUnsafeExpression>
    public static async Task<int> ReadSignatureAsync()
    {
        // The unsafe expression scopes the unsafe context to the call that
        // produces the task. The 'await' itself stays outside that context.
        return await unsafe(ReadSignatureCoreAsync());
    }

    private static unsafe Task<int> ReadSignatureCoreAsync()
    {
        int rawValue = 0x1234;
        int* pointer = &rawValue;
        return Task.FromResult(*pointer);
    }
    // </AwaitUnsafeExpression>
}
