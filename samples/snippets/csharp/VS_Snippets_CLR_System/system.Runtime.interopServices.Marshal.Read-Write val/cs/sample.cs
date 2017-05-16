//<Snippet1>
using System;
using System.Runtime.InteropServices;

class Example
{
    static void Main(string[] args)
    {
        ReadWriteIntPtr();
        ReadWriteByte();
        ReadWriteInt16();
        ReadWriteInt32();
        ReadWriteInt64();
    }

    //<Snippet2>
    static void ReadWriteIntPtr()
    {
        // Allocate unmanaged memory. 
        int elementSize = Marshal.SizeOf(typeof(IntPtr));
        IntPtr unmanagedArray = Marshal.AllocHGlobal(10 * elementSize);

        // Set the 10 elements of the C-style unmanagedArray
        for (int i = 0; i < 10; i++)
        {
            Marshal.WriteIntPtr(unmanagedArray, i * elementSize, ((IntPtr)(i + 1)));
        }
        Console.WriteLine("Unmanaged memory written.");

        Console.WriteLine("Reading unmanaged memory:");
        // Print the 10 elements of the C-style unmanagedArray
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(Marshal.ReadIntPtr(unmanagedArray, i * elementSize));
        }

        Marshal.FreeHGlobal(unmanagedArray);

        Console.WriteLine("Done. Press Enter to continue.");
        Console.ReadLine();
    }
    //</Snippet2>

    //<Snippet3>
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
    //</Snippet3>

    //<Snippet4>
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
    //</Snippet4>

    //<Snippet5>
    static void ReadWriteInt32()
    {
        // Allocate unmanaged memory. 
        int elementSize = 4;
        IntPtr unmanagedArray = Marshal.AllocHGlobal(10 * elementSize);

        // Set the 10 elements of the C-style unmanagedArray
        for (int i = 0; i < 10; i++)
        {
            Marshal.WriteInt32(unmanagedArray, i * elementSize, ((Int32)(i + 1)));
        }
        Console.WriteLine("Unmanaged memory written.");

        Console.WriteLine("Reading unmanaged memory:");
        // Print the 10 elements of the C-style unmanagedArray
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(Marshal.ReadInt32(unmanagedArray, i * elementSize));
        }

        Marshal.FreeHGlobal(unmanagedArray);

        Console.WriteLine("Done. Press Enter to continue.");
        Console.ReadLine();
    }
    //</Snippet5>

    //<Snippet6>
    static void ReadWriteInt64()
    {
        // Allocate unmanaged memory. 
        int elementSize = 8;
        IntPtr unmanagedArray = Marshal.AllocHGlobal(10 * elementSize);

        // Set the 10 elements of the C-style unmanagedArray
        for (int i = 0; i < 10; i++)
        {
            Marshal.WriteInt64(unmanagedArray, i * elementSize, ((Int64)(i + 1)));
        }
        Console.WriteLine("Unmanaged memory written.");

        Console.WriteLine("Reading unmanaged memory:");
        // Print the 10 elements of the C-style unmanagedArray
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(Marshal.ReadInt64(unmanagedArray, i * elementSize));
        }

        Marshal.FreeHGlobal(unmanagedArray);

        Console.WriteLine("Done. Press Enter to continue.");
        Console.ReadLine();
    }
    //</Snippet6>
}
//</Snippet1>