    static void ReadWriteInt16()
    {
        // Allocate unmanaged memory. 
        int elementSize = 2;
        IntPtr unmanagedArray = Marshal.AllocHGlobal(10 * elementSize);

        // Set the 10 elements of the C-style unmanagedArray
        for (int i = 0; i < 10; i++)
        {
            Marshal.WriteInt16(unmanagedArray, i * elementSize, ((Int16)(i + 1)));
        }
        Console.WriteLine("Unmanaged memory written.");

        Console.WriteLine("Reading unmanaged memory:");
        // Print the 10 elements of the C-style unmanagedArray
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(Marshal.ReadInt16(unmanagedArray, i * elementSize));
        }

        Marshal.FreeHGlobal(unmanagedArray);

        Console.WriteLine("Done. Press Enter to continue.");
        Console.ReadLine();
    }