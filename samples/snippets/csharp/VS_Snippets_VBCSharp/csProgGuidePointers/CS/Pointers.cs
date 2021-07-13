
//<Snippet18>
class TestCopy
{
    // The unsafe keyword allows pointers to be used in the following method.

    static unsafe void Copy(byte[] source, int sourceOffset, byte[] target,
        int targetOffset, int count)
    {
        // If either array is not instantiated, you cannot complete the copy.
        if (source == null)
        {
            throw new System.ArgumentException("neither array can be null.", nameof(source));
        }
        if (target == null)
        {
            throw new System.ArgumentException("neither array can be null.", nameof(target));
        }

        // If either offset, or the number of bytes to copy, is negative, you
        // cannot complete the copy.
        if (sourceOffset < 0)
        {
            throw new System.ArgumentException("offsets and count must be non-negative.", nameof(sourceOffset));
        }
        if (targetOffset < 0)
        {
            throw new System.ArgumentException("offsets and count must be non-negative.", nameof(targetOffset));
        }
        if (count < 0)
        {
            throw new System.ArgumentException("offsets and count must be non-negative.", nameof(count));
        }

        // If the number of bytes from the offset to the end of the array is
        // less than the number of bytes you want to copy, you cannot complete
        // the copy.
        if ((source.Length - sourceOffset < count) ||
            (target.Length - targetOffset < count))
        {
            throw new System.InvalidOperationException("Cannot copy past the end of source or destination array.");
        }

        // The following fixed statement pins the location of the source and
        // target objects in memory so that they will not be moved by garbage
        // collection.
        fixed (byte* pSource = source, pTarget = target)
        {
            // Set the starting points in source and target for the copying.
            byte* ps = pSource + sourceOffset;
            byte* pt = pTarget + targetOffset;

            // Copy the specified number of bytes from source to target.
            for (int i = 0; i < count; i++)
            {
                *pt = *ps;
                pt++;
                ps++;
            }
        }
    }

    static void Main()
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
    }
}
/* Output:
    The first 10 elements of the original are:
    0 1 2 3 4 5 6 7 8 9

    The first 10 elements of the copy are:
    0 1 2 3 4 5 6 7 8 9

    The first 10 elements of the copy are:
    90 91 92 93 94 95 96 97 98 99
*/
//</Snippet18>

class TestFixed1
{
	//<Snippet19>
	public struct MyArray
	{
        public char[] pathName;
        private int reserved;
	}
	//</Snippet19>
}

//<Snippet20>
namespace FixedSizeBuffers
{
    internal unsafe struct MyBuffer
    {
        public fixed char fixedBuffer[128];
    }

    internal unsafe class MyClass
    {
        public MyBuffer myBuffer = default(MyBuffer);
    }

    internal class Program
    {
        static void Main()
        {
            MyClass myC = new MyClass();

            unsafe
            {
                // Pin the buffer to a fixed location in memory.
                fixed (char* charPtr = myC.myBuffer.fixedBuffer)
                {
                    *charPtr = 'A';
                }
            }
        }
    }
}
//</Snippet20>


//-----------------------------------------------------------------------------
//<Snippet22>
class TestUnsafe
{
    unsafe static void PointyMethod()
    {
        int i=10;

        int *p = &i;
        System.Console.WriteLine("*p = " + *p);
        System.Console.WriteLine("Address of p = {0:X2}\n", (int)p);
    }

    static void StillPointy()
    {
        int i=10;

        unsafe
        {
            int *p = &i;
            System.Console.WriteLine("*p = " + *p);
            System.Console.WriteLine("Address of p = {0:X2}\n", (int)p);
        }
    }

    static void Main()
    {
        PointyMethod();
        StillPointy();
    }
}
//</Snippet22>

//-----------------------------------------------------------------------------
//<Snippet23>
class TestFixed
{
    public static void PointyMethod(char[] array)
    {
        unsafe
        {
            fixed (char *p = array)
            {
                for (int i=0; i<array.Length; i++)
                {
                    System.Console.Write(*(p+i));
                }
            }
        }
    }

    static void Main()
    {
        char[] array = { 'H', 'e', 'l', 'l', 'o' };
        PointyMethod(array);
    }
}
//</Snippet23>
