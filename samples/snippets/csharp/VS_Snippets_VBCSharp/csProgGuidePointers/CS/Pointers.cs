//using System;
//using System.Runtime.InteropServices;
//using System.Text;


//<Snippet2>
class FileReader
{
    const uint GENERIC_READ = 0x80000000;
    const uint OPEN_EXISTING = 3;
    System.IntPtr handle;

    [System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
    static extern unsafe System.IntPtr CreateFile
    (
        string FileName,          // file name
        uint DesiredAccess,       // access mode
        uint ShareMode,           // share mode
        uint SecurityAttributes,  // Security Attributes
        uint CreationDisposition, // how to create
        uint FlagsAndAttributes,  // file attributes
        int hTemplateFile         // handle to template file
    );

    [System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true)]
    static extern unsafe bool ReadFile
    (
        System.IntPtr hFile,      // handle to file
        void* pBuffer,            // data buffer
        int NumberOfBytesToRead,  // number of bytes to read
        int* pNumberOfBytesRead,  // number of bytes read
        int Overlapped            // overlapped buffer
    );

    [System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true)]
    static extern unsafe bool CloseHandle
    (
        System.IntPtr hObject // handle to object
    );

    public bool Open(string FileName)
    {
        // open the existing file for reading       
        handle = CreateFile
        (
            FileName,
            GENERIC_READ,
            0,
            0,
            OPEN_EXISTING,
            0,
            0
        );

        if (handle != System.IntPtr.Zero)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public unsafe int Read(byte[] buffer, int index, int count)
    {
        int n = 0;
        fixed (byte* p = buffer)
        {
            if (!ReadFile(handle, p + index, count, &n, 0))
            {
                return 0;
            }
        }
        return n;
    }

    public bool Close()
    {
        return CloseHandle(handle);
    }
}

class Test
{
    static int Main(string[] args)
    {
        if (args.Length != 1)
        {
            System.Console.WriteLine("Usage : ReadFile <FileName>");
            return 1;
        }

        if (!System.IO.File.Exists(args[0]))
        {
            System.Console.WriteLine("File " + args[0] + " not found.");
            return 1;
        }

        byte[] buffer = new byte[128];
        FileReader fr = new FileReader();

        if (fr.Open(args[0]))
        {
            // Assume that an ASCII file is being read.
            System.Text.ASCIIEncoding Encoding = new System.Text.ASCIIEncoding();

            int bytesRead;
            do
            {
                bytesRead = fr.Read(buffer, 0, buffer.Length);
                string content = Encoding.GetString(buffer, 0, bytesRead);
                System.Console.Write("{0}", content);
            }
            while (bytesRead > 0);

            fr.Close();
            return 0;
        }
        else
        {
            System.Console.WriteLine("Failed to open requested file");
            return 1;
        }
    }
}
//</Snippet2>


//<Snippet4>
class ClassConvert
{
    static void Main() 
    {
        int number = 1024;

        unsafe 
        {
            // Convert to byte:
            byte* p = (byte*)&number;

            System.Console.Write("The 4 bytes of the integer:");

            // Display the 4 bytes of the int variable:
            for (int i = 0 ; i < sizeof(int) ; ++i)
            {
                System.Console.Write(" {0:X2}", *p);
                // Increment the pointer:
                p++;
            }
            System.Console.WriteLine();
            System.Console.WriteLine("The value of the integer: {0}", number);

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
    /* Output:
        The 4 bytes of the integer: 00 04 00 00
        The value of the integer: 1024
    */
//</Snippet4>


//<Snippet6>
unsafe class TestClass
{
    static void Main()
    {
        char theChar = 'Z';
        char* pChar = &theChar;
        void* pVoid = pChar;
        int* pInt = (int*)pVoid;

        System.Console.WriteLine("Value of theChar = {0}", theChar);
        System.Console.WriteLine("Address of theChar = {0:X2}",(int)pChar);
        System.Console.WriteLine("Value of pChar = {0}", *pChar);
        System.Console.WriteLine("Value of pInt = {0}", *pInt);
    }
}
//</Snippet6>


//<Snippet8>
class AddressOfOperator
{
    static void Main()
    {
        int number;

        unsafe 
        {
            // Assign the address of number to a pointer:
            int* p = &number;

            // Commenting the following statement will remove the
            // initialization of number.
            *p = 0xffff;

            // Print the value of *p:
            System.Console.WriteLine("Value at the location pointed to by p: {0:X}", *p);

            // Print the address stored in p:
            System.Console.WriteLine("The address stored in p: {0}", (int)p);
        }

        // Print the value of the variable number:
        System.Console.WriteLine("Value of the variable number: {0:X}", number);

        System.Console.ReadKey();
    }
}
/* Output:
        Value at the location pointed to by p: FFFF
        The address stored in p: 2420904
        Value of the variable number: FFFF
*/
//</Snippet8>


//<Snippet10>
struct CoOrds
{
    public int x;
    public int y;
}

class AccessMembers
{
    static void Main() 
    {
        CoOrds home;

        unsafe 
        {
            CoOrds* p = &home;
            p->x = 25;
            p->y = 12;

            System.Console.WriteLine("The coordinates are: x={0}, y={1}", p->x, p->y );
        }
    }
}
//</Snippet10>


//<Snippet12>
class Pointers
{
    unsafe static void Main() 
    {
        char* charPointer = stackalloc char[123];

        for (int i = 65; i < 123; i++)
        {
            charPointer[i] = (char)i;
        }

        // Print uppercase letters:
        System.Console.WriteLine("Uppercase letters:");
        for (int i = 65; i < 91; i++)
        {
            System.Console.Write(charPointer[i]);
        }
        System.Console.WriteLine();

        // Print lowercase letters:
        System.Console.WriteLine("Lowercase letters:");
        for (int i = 97; i < 123; i++)
        {
            System.Console.Write(charPointer[i]);
        }
    }
}
//</Snippet12>


//<Snippet13>
class IncrDecr
{
    unsafe static void Main()
    {
        int[] numbers = {0,1,2,3,4};

        // Assign the array address to the pointer:
        fixed (int* p1 = numbers)
        {
            // Step through the array elements:
            for(int* p2=p1; p2<p1+numbers.Length; p2++)
            {
                System.Console.WriteLine("Value:{0} @ Address:{1}", *p2, (long)p2);
            }
        }
    }
}
//</Snippet13>


//<Snippet15>
class PointerArithmetic
{
    unsafe static void Main() 
    {
        int* memory = stackalloc int[30];
        long difference;
        int* p1 = &memory[4];
        int* p2 = &memory[10];

        difference = p2 - p1;

        System.Console.WriteLine("The difference is: {0}", difference);
    }
}
// Output:  The difference is: 6
//</Snippet15>


//<Snippet17>
class CompareOperators
{
    unsafe static void Main() 
    {
        int x = 234;
        int y = 236;
        int* p1 = &x;
        int* p2 = &y;

        System.Console.WriteLine(p1 < p2);
        System.Console.WriteLine(p2 < p1);
    }
}
//</Snippet17>


//<Snippet18>
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
//<Snippet21>
namespace N
{
    /// <summary>
    /// Enter description here for class X. 
    /// ID string generated is "T:N.X". 
    /// </summary>
    public unsafe class X
    {
        /// <summary>
        /// Enter description here for the first constructor.
        /// ID string generated is "M:N.X.#ctor".
        /// </summary>
        public X() { }


        /// <summary>
        /// Enter description here for the second constructor.
        /// ID string generated is "M:N.X.#ctor(System.Int32)".
        /// </summary>
        /// <param name="i">Describe parameter.</param>
        public X(int i) { }


        /// <summary>
        /// Enter description here for field q.
        /// ID string generated is "F:N.X.q".
        /// </summary>
        public string q;


        /// <summary>
        /// Enter description for constant PI.
        /// ID string generated is "F:N.X.PI".
        /// </summary>
        public const double PI = 3.14;


        /// <summary>
        /// Enter description for method f.
        /// ID string generated is "M:N.X.f".
        /// </summary>
        /// <returns>Describe return value.</returns>
        public int f() { return 1; }


        /// <summary>
        /// Enter description for method bb.
        /// ID string generated is "M:N.X.bb(System.String,System.Int32@,System.Void*)".
        /// </summary>
        /// <param name="s">Describe parameter.</param>
        /// <param name="y">Describe parameter.</param>
        /// <param name="z">Describe parameter.</param>
        /// <returns>Describe return value.</returns>
        public int bb(string s, ref int y, void* z) { return 1; }


        /// <summary>
        /// Enter description for method gg.
        /// ID string generated is "M:N.X.gg(System.Int16[],System.Int32[0:,0:])". 
        /// </summary>
        /// <param name="array1">Describe parameter.</param>
        /// <param name="array">Describe parameter.</param>
        /// <returns>Describe return value.</returns>
        public int gg(short[] array1, int[,] array) { return 0; }


        /// <summary>
        /// Enter description for operator.
        /// ID string generated is "M:N.X.op_Addition(N.X,N.X)". 
        /// </summary>
        /// <param name="x">Describe parameter.</param>
        /// <param name="xx">Describe parameter.</param>
        /// <returns>Describe return value.</returns>
        public static X operator +(X x, X xx) { return x; }


        /// <summary>
        /// Enter description for property.
        /// ID string generated is "P:N.X.prop".
        /// </summary>
        public int prop { get { return 1; } set { } }


        /// <summary>
        /// Enter description for event.
        /// ID string generated is "E:N.X.d".
        /// </summary>
        public event D d;


        /// <summary>
        /// Enter description for property.
        /// ID string generated is "P:N.X.Item(System.String)".
        /// </summary>
        /// <param name="s">Describe parameter.</param>
        /// <returns></returns>
        public int this[string s] { get { return 1; } }


        /// <summary>
        /// Enter description for class Nested.
        /// ID string generated is "T:N.X.Nested".
        /// </summary>
        public class Nested { }


        /// <summary>
        /// Enter description for delegate.
        /// ID string generated is "T:N.X.D". 
        /// </summary>
        /// <param name="i">Describe parameter.</param>
        public delegate void D(int i);


        /// <summary>
        /// Enter description for operator.
        /// ID string generated is "M:N.X.op_Explicit(N.X)~System.Int32".
        /// </summary>
        /// <param name="x">Describe parameter.</param>
        /// <returns>Describe return value.</returns>
        public static explicit operator int(X x) { return 1; }

    }
}
//</Snippet21>


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
