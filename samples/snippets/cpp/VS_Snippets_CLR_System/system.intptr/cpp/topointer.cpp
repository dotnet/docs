//<snippet1>
using namespace System;
using namespace System::Runtime::InteropServices;

class NotTooSafeStringReverse
{
public:
    static void Main()
    {
        String^ stringA = "I seem to be turned around!";
        int copylen = stringA->Length;

        // Allocate HGlobal memory for source and destination strings
        IntPtr sptr = Marshal::StringToHGlobalAnsi(stringA);
        IntPtr dptr = Marshal::AllocHGlobal(copylen + 1);

        char *src = (char *)sptr.ToPointer();
        char *dst = (char *)dptr.ToPointer();

        if (copylen > 0)
        {
            // set the source pointer to the end of the string
            // to do a reverse copy.
            src += copylen - 1;

            while (copylen-- > 0)
            {
                *dst++ = *src--;
            }
            *dst = 0;
        }
        String^ stringB = Marshal::PtrToStringAnsi(dptr);

        Console::WriteLine("Original:\n{0}\n", stringA);
        Console::WriteLine("Reversed:\n{0}", stringB);

        // Free HGlobal memory
        Marshal::FreeHGlobal(dptr);
        Marshal::FreeHGlobal(sptr);
    }
};

int main()
{
    NotTooSafeStringReverse::Main();
}

// The progam has the following output:
//
// Original:
// I seem to be turned around!
//
// Reversed:
// !dnuora denrut eb ot mees I
//</snippet1>
