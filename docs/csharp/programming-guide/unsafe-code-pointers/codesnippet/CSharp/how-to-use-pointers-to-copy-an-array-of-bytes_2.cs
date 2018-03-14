class TestCopy
{
    // The unsafe keyword allows pointers to be used in the following method.

    static unsafe void Copy(byte[] source, int sourceOffset, byte[] target,
        int targetOffset, int count)
    {
        // If either array is not instantiated, you cannot complete the copy.
        if ((source == null) || (target == null))
        {
            throw new System.ArgumentException();
        }

        // If either offset, or the number of bytes to copy, is negative, you
        // cannot complete the copy.
        if ((sourceOffset < 0) || (targetOffset < 0) || (count < 0))
        {
            throw new System.ArgumentException();
        }

        // If the number of bytes from the offset to the end of the array is 
        // less than the number of bytes you want to copy, you cannot complete
        // the copy. 
        if ((source.Length - sourceOffset < count) ||
            (target.Length - targetOffset < count))
        {
            throw new System.ArgumentException();
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