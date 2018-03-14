//<snippet42>
using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Runtime::InteropServices;

//<snippet43>
// Declares a managed structure for the unmanaged structure.
[StructLayout(LayoutKind::Sequential)]
public value struct Overlapped
{
    // ...
};

// Declares a managed class for the unmanaged structure.
[StructLayout(LayoutKind::Sequential)]
public ref class Overlapped2
{
    // ...
};

public ref class LibWrap
{
public:
    // Declares managed prototypes for unmanaged functions.
    // Because Overlapped is a structure, you cannot pass null as a
    // parameter. Instead, declares an overloaded method.
    [DllImport("Kernel32.dll")]
    static bool ReadFile(
        HandleRef hndRef,
        StringBuilder^ buffer,
        int numberOfBytesToRead,
        int numberOfBytesRead,
        Overlapped% flag );

    [DllImport("Kernel32.dll")]
    static bool ReadFile(
        HandleRef hndRef,
        StringBuilder^ buffer,
        int numberOfBytesToRead,
        int% numberOfBytesRead,
        IntPtr flag ); // Declares an int instead of a structure reference.

    // Because Overlapped2 is a class, you can pass null as parameter.
    // No overloading is needed.
    [DllImport("Kernel32.dll", EntryPoint="ReadFile")]
    static bool ReadFile2(
        HandleRef hndRef,
        StringBuilder^ buffer,
        int numberOfBytesToRead,
        int% numberOfBytesRead,
        Overlapped2^ flag);
};
//</snippet43>

//<snippet44>
public ref class App
{
public:
    static void Main()
    {
        FileStream^ fs = gcnew FileStream("HandleRef.txt", FileMode::Open);
        // Wraps the FileStream handle in HandleRef to prevent it
        // from being garbage collected before the call ends.
        HandleRef hr = HandleRef(fs, fs->SafeFileHandle->DangerousGetHandle());
        StringBuilder^ buffer = gcnew StringBuilder(5);
        int read = 0;
        // Platform invoke holds a reference to HandleRef until the call
        // ends.
        LibWrap::ReadFile(hr, buffer, 5, read, IntPtr::Zero);
        Console::WriteLine("Read {0} bytes with struct parameter: {1}", read, buffer);
        LibWrap::ReadFile2(hr, buffer, 5, read, nullptr);
        Console::WriteLine("Read {0} bytes with class parameter: {1}", read, buffer);
    }
};
//</snippet44>
int main()
{
    App::Main();
}
//</snippet42>
