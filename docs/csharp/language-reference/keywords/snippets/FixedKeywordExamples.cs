using System;
using System.Collections.Generic;
using System.Text;

namespace keywords
{
    public static class FixedKeywordExamples
    {
        public static void Examples()
        {
            ModifyFixedStorage();
            FixedSpanExample();
            InitializeFixedStorage();
            MultiplePointers();
            SquarePointValue();
            PointerTypes();
            AccessEmbeddedArray();
            UnsafeCopyArrays();
        }

        // <Snippet1>
        class Point
        {
            public int x;
            public int y;
        }

        unsafe private static void ModifyFixedStorage()
        {
            // Variable pt is a managed variable, subject to garbage collection.
            Point pt = new Point();

            // Using fixed allows the address of pt members to be taken,
            // and "pins" pt so that it is not relocated.

            fixed (int* p = &pt.x)
            {
                *p = 1;
            }
        }
        // </Snippet1>

        // <SnippetFixedSpan>
        unsafe private static void FixedSpanExample()
        {
            int[] PascalsTriangle = {
                          1,
                        1,  1,
                      1,  2,  1,
                    1,  3,  3,  1,
                  1,  4,  6,  4,  1,
                1,  5,  10, 10, 5,  1
            };

            Span<int> RowFive = new Span<int>(PascalsTriangle, 10, 5);

            fixed (int* ptrToRow = RowFive)
            {
                // Sum the numbers 1,4,6,4,1
                var sum = 0;
                for (int i = 0; i < RowFive.Length; i++)
                {
                    sum += *(ptrToRow + i);
                }
                Console.WriteLine(sum);
            }
        }
        // </SnippetFixedSpan>

        unsafe private static void InitializeFixedStorage()
        {
            // <Snippet2>
            Point point = new Point();
            double[] arr = { 0, 1.5, 2.3, 3.4, 4.0, 5.9 };
            string str = "Hello World";

            // The following two assignments are equivalent. Each assigns the address
            // of the first element in array arr to pointer p.

            // You can initialize a pointer by using an array.
            fixed (double* p = arr) { /*...*/ }

            // You can initialize a pointer by using the address of a variable.
            fixed (double* p = &arr[0]) { /*...*/ }

            // The following assignment initializes p by using a string.
            fixed (char* p = str) { /*...*/ }

            // The following assignment is not valid, because str[0] is a char,
            // which is a value, not a variable.
            //fixed (char* p = &str[0]) { /*...*/ }
            // </Snippet2>
        }

        unsafe private static void MultiplePointers()
        {
            Point point = new Point();
            double[] arr = { 0, 1.5, 2.3, 3.4, 4.0, 5.9 };

            // <Snippet3>
            fixed (int* p1 = &point.x)
            {
                fixed (double* p2 = &arr[5])
                {
                    // Do something with p1 and p2.
                }
            }
            // </Snippet3>
        }

        // <Snippet4>
        // Unsafe method: takes a pointer to an int.
        unsafe static void SquarePtrParam(int* p)
        {
            *p *= *p;
        }

        unsafe static void SquarePointValue()
        {
            Point pt = new Point
            {
                x = 5,
                y = 6
            };
            // Pin pt in place:
            fixed (int* p = &pt.x)
            {
                SquarePtrParam(p);
            }
            // pt now unpinned.
            Console.WriteLine("{0} {1}", pt.x, pt.y);
            /*
            Output:
            25 6
             */
        }
        // </Snippet4>

        private static void PointerTypes()
        {
            // <Snippet5>
            // Normal pointer to an object.
            int[] a = new int[5] { 10, 20, 30, 40, 50 };
            // Must be in unsafe code to use interior pointers.
            unsafe
            {
                // Must pin object on heap so that it doesn't move while using interior pointers.
                fixed (int* p = &a[0])
                {
                    // p is pinned as well as object, so create another pointer to show incrementing it.
                    int* p2 = p;
                    Console.WriteLine(*p2);
                    // Incrementing p2 bumps the pointer by four bytes due to its type ...
                    p2 += 1;
                    Console.WriteLine(*p2);
                    p2 += 1;
                    Console.WriteLine(*p2);
                    Console.WriteLine("--------");
                    Console.WriteLine(*p);
                    // Dereferencing p and incrementing changes the value of a[0] ...
                    *p += 1;
                    Console.WriteLine(*p);
                    *p += 1;
                    Console.WriteLine(*p);
                }
            }

            Console.WriteLine("--------");
            Console.WriteLine(a[0]);

            /*
            Output:
            10
            20
            30
            --------
            10
            11
            12
            --------
            12
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

        // <Snippet8>
        static unsafe void Copy(byte[] source, int sourceOffset, byte[] target,
            int targetOffset, int count)
        {
            // If either array is not instantiated, you cannot complete the copy.
            if ((source == null) || (target == null))
            {
                throw new System.ArgumentException(message: $"Neither {nameof(source)} nor {nameof(target)} can be null");
            }

            // If either offset, or the number of bytes to copy, is negative, you
            // cannot complete the copy.
            if ((sourceOffset < 0) || (targetOffset < 0) || (count < 0))
            {
                throw new System.ArgumentException(message: $"{nameof(sourceOffset)},  {nameof(targetOffset)} and {nameof(count)} must be non-negative numbers.");
            }

            // If the number of bytes from the offset to the end of the array is
            // less than the number of bytes you want to copy, you cannot complete
            // the copy.
            if ((source.Length - sourceOffset < count) ||
                (target.Length - targetOffset < count))
            {
                throw new System.ArgumentException(message: $"Both {nameof(sourceOffset)} and {nameof(targetOffset)} must be at least {nameof(count)} from the end of the storage.");
            }

            // The following fixed statement pins the location of the source and
            // target objects in memory so that they will not be moved by garbage
            // collection.
            fixed (byte* pSource = source, pTarget = target)
            {
                // Copy the specified number of bytes from source to target.
                for (int i = 0; i < count; i++)
                {
                    pTarget[targetOffset + i] = pSource[sourceOffset + i];
                }
            }
        }

        static void UnsafeCopyArrays()
        {
            // Create two arrays of the same length.
            int length = 100;
            byte[] byteArray1 = new byte[length];
            byte[] byteArray2 = new byte[length];

            // Fill byteArray1 with 0 - 99.
            for (int i = 0; i < length; ++i)
            {
                byteArray1[i] = (byte)i;
            }

            // Display the first 10 elements in byteArray1.
            System.Console.WriteLine("The first 10 elements of the original are:");
            for (int i = 0; i < 10; ++i)
            {
                System.Console.Write(byteArray1[i] + " ");
            }
            System.Console.WriteLine("\n");

            // Copy the contents of byteArray1 to byteArray2.
            Copy(byteArray1, 0, byteArray2, 0, length);

            // Display the first 10 elements in the copy, byteArray2.
            System.Console.WriteLine("The first 10 elements of the copy are:");
            for (int i = 0; i < 10; ++i)
            {
                System.Console.Write(byteArray2[i] + " ");
            }
            System.Console.WriteLine("\n");

            // Copy the contents of the last 10 elements of byteArray1 to the
            // beginning of byteArray2.
            // The offset specifies where the copying begins in the source array.
            int offset = length - 10;
            Copy(byteArray1, offset, byteArray2, 0, length - offset);

            // Display the first 10 elements in the copy, byteArray2.
            System.Console.WriteLine("The first 10 elements of the copy are:");
            for (int i = 0; i < 10; ++i)
            {
                System.Console.Write(byteArray2[i] + " ");
            }
            System.Console.WriteLine("\n");
            /* Output:
                The first 10 elements of the original are:
                0 1 2 3 4 5 6 7 8 9

                The first 10 elements of the copy are:
                0 1 2 3 4 5 6 7 8 9

                The first 10 elements of the copy are:
                90 91 92 93 94 95 96 97 98 99
            */
        }
        // </Snippet8>
    }
}
