namespace UnsafeCodePointers;

public class FunctionPointers
{
    public static void PointerExamples()
    {
        int sum = Combine((x, y) => x + y, 3, 4);
        Console.WriteLine(sum);

        Console.WriteLine();

        // <InvokeViaFunctionPointer>
        int product = 0;
        static int localMultiply(int x, int y) => x * y;
        unsafe
        {
            product = UnsafeCombine(&localMultiply, 3, 4);
        }
        // </InvokeViaFunctionPointer>
        Console.WriteLine(product);
    }

    // <UseDelegateOrPointer>
    public static T Combine<T>(Func<T, T, T> combinator, T left, T right) => 
        combinator(left, right);

    public static unsafe T UnsafeCombine<T>(delegate*<T, T, T> combinator, T left, T right) => 
        combinator(left, right);
    // </UseDelegateOrPointer>

    // <UnmanagedFunctionPointers>
    public static unsafe T ManagedCombine<T>(delegate* managed<T, T, T> combinator, T left, T right) =>
        combinator(left, right);
    public static unsafe T CDeclCombine<T>(delegate* unmanaged[Cdecl]<T, T, T> combinator, T left, T right) =>
        combinator(left, right);
    public static unsafe T StdcallCombine<T>(delegate* unmanaged[Stdcall]<T, T, T> combinator, T left, T right) =>
        combinator(left, right);
    public static unsafe T FastcallCombine<T>(delegate* unmanaged[Fastcall]<T, T, T> combinator, T left, T right) =>
        combinator(left, right);
    public static unsafe T ThiscallCombine<T>(delegate* unmanaged[Thiscall]<T, T, T> combinator, T left, T right) =>
        combinator(left, right);
    public static unsafe T UnmanagedCombine<T>(delegate* unmanaged<T, T, T> combinator, T left, T right) =>
        combinator(left, right);
    // </UnmanagedFunctionPointers>
}
