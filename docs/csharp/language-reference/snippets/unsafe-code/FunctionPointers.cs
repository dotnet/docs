using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace UnsafeCodePointers
{
    public unsafe class FunctionPointers
    {
        public static void PointerExamples()
        {
            int sum = Combine((x, y) => x + y, 3, 4);
            Console.WriteLine(sum);

            Console.WriteLine();

            // <InvokeViaFunctionPointer>
            static int localMultiply(int x, int y) => x * y;
            int product = UnsafeCombine(&localMultiply, 3, 4);
            // </InvokeViaFunctionPointer>
            Console.WriteLine(product);


        }

        // <UseDelegateOrPointer>
        public static T Combine<T>(Func<T, T, T> combinator, T left, T right) => 
            combinator(left, right);

        public static T UnsafeCombine<T>(delegate*<T, T, T> combinator, T left, T right) => 
            combinator(left, right);
        // </UseDelegateOrPointer>

        // <UnmanagedFunctionPointers>
        public static T ManagedCombine<T>(delegate* managed<T, T, T> combinator, T left, T right) =>
            combinator(left, right);
        public static T CDeclCombine<T>(delegate* unmanaged[Cdecl]<T, T, T> combinator, T left, T right) =>
            combinator(left, right);
        public static T StdcallCombine<T>(delegate* unmanaged[Stdcall]<T, T, T> combinator, T left, T right) =>
            combinator(left, right);
        public static T FastcallCombine<T>(delegate* unmanaged[Fastcall]<T, T, T> combinator, T left, T right) =>
            combinator(left, right);
        public static T ThiscallCombine<T>(delegate* unmanaged[Thiscall]<T, T, T> combinator, T left, T right) =>
            combinator(left, right);
        public static T UnmanagedCombine<T>(delegate* unmanaged<T, T, T> combinator, T left, T right) =>
            combinator(left, right);
        // </UnmanagedFunctionPointers>

    }
}
