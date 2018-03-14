//<snippet1>
// Note: You must compile this file using the C# /unsafe switch.
using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Security.Permissions;

[assembly: SecurityPermission(
SecurityAction.RequestMinimum, Execution = true)]
// This class includes several Win32 interop definitions.
internal class Win32
{
    public static readonly IntPtr InvalidHandleValue = new IntPtr(-1);
    public const UInt32 FILE_MAP_WRITE = 2;
    public const UInt32 PAGE_READWRITE = 0x04;

    [DllImport("Kernel32",CharSet=CharSet.Unicode)]
    public static extern IntPtr CreateFileMapping(IntPtr hFile,
        IntPtr pAttributes, UInt32 flProtect,
        UInt32 dwMaximumSizeHigh, UInt32 dwMaximumSizeLow, String pName);

    [DllImport("Kernel32",CharSet=CharSet.Unicode)]
    public static extern IntPtr OpenFileMapping(UInt32 dwDesiredAccess,
        Boolean bInheritHandle, String name);

    [DllImport("Kernel32",CharSet=CharSet.Unicode)]
    public static extern Boolean CloseHandle(IntPtr handle);

    [DllImport("Kernel32",CharSet=CharSet.Unicode)]
    public static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject,
        UInt32 dwDesiredAccess,
        UInt32 dwFileOffsetHigh, UInt32 dwFileOffsetLow,
        IntPtr dwNumberOfBytesToMap);

    [DllImport("Kernel32",CharSet=CharSet.Unicode)]
    public static extern Boolean UnmapViewOfFile(IntPtr address);

    [DllImport("Kernel32",CharSet=CharSet.Unicode)]
    public static extern Boolean DuplicateHandle(IntPtr hSourceProcessHandle,
        IntPtr hSourceHandle,
        IntPtr hTargetProcessHandle, ref IntPtr lpTargetHandle,
        UInt32 dwDesiredAccess, Boolean bInheritHandle, UInt32 dwOptions);
    public const UInt32 DUPLICATE_CLOSE_SOURCE = 0x00000001;
    public const UInt32 DUPLICATE_SAME_ACCESS = 0x00000002;

    [DllImport("Kernel32",CharSet=CharSet.Unicode)]
    public static extern IntPtr GetCurrentProcess();
}


// This class wraps memory that can be simultaneously 
// shared by multiple AppDomains and Processes.
[Serializable]
public sealed class SharedMemory : ISerializable, IDisposable
{
    // The handle and string that identify 
    // the Windows file-mapping object.
    private IntPtr m_hFileMap = IntPtr.Zero;
    private String m_name;

    // The address of the memory-mapped file-mapping object.
    private IntPtr m_address;

    public unsafe Byte* Address
    {
        get { return (Byte*)m_address; }
    }

    // The constructors.
    public SharedMemory(Int32 size) : this(size, null) { }

    public SharedMemory(Int32 size, String name)
    {
        m_hFileMap = Win32.CreateFileMapping(Win32.InvalidHandleValue,
            IntPtr.Zero, Win32.PAGE_READWRITE,
            0, unchecked((UInt32)size), name);
        if (m_hFileMap == IntPtr.Zero)
            throw new Exception("Could not create memory-mapped file.");
        m_name = name;
        m_address = Win32.MapViewOfFile(m_hFileMap, Win32.FILE_MAP_WRITE,
            0, 0, IntPtr.Zero);
    }

    // The cleanup methods.
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Dispose(true);
    }

    private void Dispose(Boolean disposing)
    {
        Win32.UnmapViewOfFile(m_address);
        Win32.CloseHandle(m_hFileMap);
        m_address = IntPtr.Zero;
        m_hFileMap = IntPtr.Zero;
    }

    ~SharedMemory()
    {
        Dispose(false);
    }

    // Private helper methods.
    private static Boolean AllFlagsSet(Int32 flags, Int32 flagsToTest)
    {
        return (flags & flagsToTest) == flagsToTest;
    }

    private static Boolean AnyFlagsSet(Int32 flags, Int32 flagsToTest)
    {
        return (flags & flagsToTest) != 0;
    }


    // The security attribute demands that code that calls  
    // this method have permission to perform serialization.
    [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    {
        // The context's State member indicates
        // where the object will be deserialized.

        // A SharedMemory object cannot be serialized 
        // to any of the following destinations.
        const StreamingContextStates InvalidDestinations =
                  StreamingContextStates.CrossMachine |
                  StreamingContextStates.File |
                  StreamingContextStates.Other |
                  StreamingContextStates.Persistence |
                  StreamingContextStates.Remoting;
        if (AnyFlagsSet((Int32)context.State, (Int32)InvalidDestinations))
            throw new SerializationException("The SharedMemory object " +
                "cannot be serialized to any of the following streaming contexts: " +
                InvalidDestinations);

        const StreamingContextStates DeserializableByHandle =
                  StreamingContextStates.Clone |
            // The same process.
                  StreamingContextStates.CrossAppDomain;
        if (AnyFlagsSet((Int32)context.State, (Int32)DeserializableByHandle))
            info.AddValue("hFileMap", m_hFileMap);

        const StreamingContextStates DeserializableByName =
            // The same computer.
                  StreamingContextStates.CrossProcess;
        if (AnyFlagsSet((Int32)context.State, (Int32)DeserializableByName))
        {
            if (m_name == null)
                throw new SerializationException("The SharedMemory object " +
                    "cannot be serialized CrossProcess because it was not constructed " +
                    "with a String name.");
            info.AddValue("name", m_name);
        }
    }


    // The security attribute demands that code that calls  
    // this method have permission to perform serialization.
    [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    private SharedMemory(SerializationInfo info, StreamingContext context)
    {
        // The context's State member indicates 
        // where the object was serialized from.

        const StreamingContextStates InvalidSources =
                  StreamingContextStates.CrossMachine |
                  StreamingContextStates.File |
                  StreamingContextStates.Other |
                  StreamingContextStates.Persistence |
                  StreamingContextStates.Remoting;
        if (AnyFlagsSet((Int32)context.State, (Int32)InvalidSources))
            throw new SerializationException("The SharedMemory object " +
                "cannot be deserialized from any of the following stream contexts: " +
                InvalidSources);

        const StreamingContextStates SerializedByHandle =
                  StreamingContextStates.Clone |
            // The same process.
                  StreamingContextStates.CrossAppDomain;
        if (AnyFlagsSet((Int32)context.State, (Int32)SerializedByHandle))
        {
            try
            {
                Win32.DuplicateHandle(Win32.GetCurrentProcess(),
                    (IntPtr)info.GetValue("hFileMap", typeof(IntPtr)),
                    Win32.GetCurrentProcess(), ref m_hFileMap, 0, false,
                    Win32.DUPLICATE_SAME_ACCESS);
            }
            catch (SerializationException)
            {
                throw new SerializationException("A SharedMemory was not serialized " +
                    "using any of the following streaming contexts: " +
                    SerializedByHandle);
            }
        }

        const StreamingContextStates SerializedByName =
            // The same computer.
                  StreamingContextStates.CrossProcess;
        if (AnyFlagsSet((Int32)context.State, (Int32)SerializedByName))
        {
            try
            {
                m_name = info.GetString("name");
            }
            catch (SerializationException)
            {
                throw new SerializationException("A SharedMemory object was not " +
                    "serialized using any of the following streaming contexts: " +
                    SerializedByName);
            }
            m_hFileMap = Win32.OpenFileMapping(Win32.FILE_MAP_WRITE, false, m_name);
        }
        if (m_hFileMap != IntPtr.Zero)
        {
            m_address = Win32.MapViewOfFile(m_hFileMap, Win32.FILE_MAP_WRITE,
                0, 0, IntPtr.Zero);
        }
        else
        {
            throw new SerializationException("A SharedMemory object could not " +
                "be deserialized.");
        }
    }
}


class App
{
    [STAThread]
    static void Main(string[] args)
    {
        Serialize();
        Console.WriteLine();
        Deserialize();
    }

    unsafe static void Serialize()
    {
        // Create a hashtable of values that will eventually be serialized.
        SharedMemory sm = new SharedMemory(1024, "JeffMemory");
        for (Int32 x = 0; x < 100; x++)
            *(sm.Address + x) = (Byte)x;

        Byte[] b = new Byte[10];
        for (Int32 x = 0; x < b.Length; x++) b[x] = *(sm.Address + x);
        Console.WriteLine(BitConverter.ToString(b));

        // To serialize the SharedMemory object, 
        // you must first open a stream for writing. 
        // Use a file stream here.
        FileStream fs = new FileStream("DataFile.dat", FileMode.Create);

        // Construct a BinaryFormatter and tell it where 
        // the objects will be serialized to.
        BinaryFormatter formatter = new BinaryFormatter(null,
            new StreamingContext(StreamingContextStates.CrossAppDomain));
        try
        {
            formatter.Serialize(fs, sm);
        }
        catch (SerializationException e)
        {
            Console.WriteLine("Failed to serialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            fs.Close();
        }
    }


    unsafe static void Deserialize()
    {
        // Declare a SharedMemory reference.
        SharedMemory sm = null;

        // Open the file containing the data that you want to deserialize.
        FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
        try
        {
            BinaryFormatter formatter = new BinaryFormatter(null,
                new StreamingContext(StreamingContextStates.CrossAppDomain));

            // Deserialize the SharedMemory object from the file and 
            // assign the reference to the local variable.
            sm = (SharedMemory)formatter.Deserialize(fs);
        }
        catch (SerializationException e)
        {
            Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            fs.Close();
        }

        // To prove that the SharedMemory object deserialized correctly, 
        // display some of its bytes to the console.
        Byte[] b = new Byte[10];
        for (Int32 x = 0; x < b.Length; x++) b[x] = *(sm.Address + x);
        Console.WriteLine(BitConverter.ToString(b));
    }
}
//</snippet1>
