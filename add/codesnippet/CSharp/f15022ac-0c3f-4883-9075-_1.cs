    static void ReadWriteByte()
    {
        // Allocate unmanaged memory. 
        int elementSize = 1;
        IntPtr unmanagedArray = Marshal.AllocHGlobal(10 * elementSize);

        // Set the 10 elements of the C-style unmanagedArray
        for (int i = 0; i < 10; i++)
        {
            Marshal.WriteByte(unmanagedArray, i * elementSize, ((Byte)(i + 1)));
        }
        Console.WriteLine("Unmanaged memory written.");

        Console.WriteLine("Reading unmanaged memory:");
        // Print the 10 elements of the C-style unmanagedArray
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(Marshal.ReadByte(unmanagedArray, i * elementSize));
        }

        Marshal.FreeHGlobal(unmanagedArray);

        Console.WriteLine("Done. Press Enter to continue.");
        Console.ReadLine();
    }