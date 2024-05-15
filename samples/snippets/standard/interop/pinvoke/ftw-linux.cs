using System;
using System.Runtime.InteropServices;

namespace PInvokeSamples
{
    public static partial class Program
    {
        // Define a delegate that has the same signature as the native function.
        private delegate int DirClbk(string fName, ref Stat stat, int typeFlag);

        // Import the libc and define the method to represent the native function.
        [LibraryImport("libc.so.6", StringMarshalling = StringMarshalling.Utf16)]
        private static partial int ftw(string dirpath, DirClbk cl, int descriptors);

        // Implement the above DirClbk delegate;
        // this one just prints out the filename that is passed to it.
        private static int DisplayEntry(string fName, ref Stat stat, int typeFlag)
        {
            Console.WriteLine(fName);
            return 0;
        }

        public static void Main(string[] args)
        {
            // Call the native function.
            // Note the second parameter which represents the delegate (callback).
            ftw(".", DisplayEntry, 10);
        }
    }

    // The native callback takes a pointer to a struct. This type
    // represents that struct in managed code.
    [StructLayout(LayoutKind.Sequential)]
    public struct Stat
    {
        public uint DeviceID;
        public uint InodeNumber;
        public uint Mode;
        public uint HardLinks;
        public uint UserID;
        public uint GroupID;
        public uint SpecialDeviceID;
        public ulong Size;
        public ulong BlockSize;
        public uint Blocks;
        public long TimeLastAccess;
        public long TimeLastModification;
        public long TimeLastStatusChange;
    }
}
