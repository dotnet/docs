// <Snippet1>

// HandleRef.cs
using namespace System::Runtime::InteropServices;
using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Runtime::InteropServices;

/*
typedef struct _OVERLAPPED { 
ULONG_PTR  Internal; 
ULONG_PTR  InternalHigh; 
DWORD  Offset; 
DWORD  OffsetHigh; 
HANDLE hEvent; 
} OVERLAPPED; 
*/

// declared as structure
[StructLayout(LayoutKind::Sequential)]
public value struct Overlapped
{
private:
   IntPtr intrnal;
   IntPtr internalHigh;
   int offset;
   int offsetHigh;
   IntPtr hEvent;
};

// declared as class
[StructLayout(LayoutKind::Sequential)]
public ref class Overlapped2
{
private:
   IntPtr intrnal;
   IntPtr internalHigh;
   int offset;
   int offsetHigh;
   IntPtr hEvent;
};

public ref class LibWrap
{
public:
   // to prevent FileStream to be GC-ed before call ends, 
   // its handle should be wrapped in HandleRef
   //BOOL ReadFile(HANDLE hFile, LPVOID lpBuffer, DWORD nNumberOfBytesToRead,
   //    LPDWORD lpNumberOfBytesRead, LPOVERLAPPED lpOverlapped);    

   [DllImport("Kernel32.dll", CharSet=CharSet::Unicode)]
   static bool ReadFile( HandleRef hndRef, StringBuilder^ buffer, int numberOfBytesToRead, [Out]int * numberOfBytesRead, Overlapped ** flag );

   // since Overlapped is struct, null can't be passed instead, 
   // we must declare overload method if we will use this 

   [DllImport("Kernel32.dll", CharSet=CharSet::Unicode)]
   static bool ReadFile( HandleRef hndRef, StringBuilder^ buffer, int numberOfBytesToRead, [Out]int * numberOfBytesRead, int flag ); // int instead of structure reference

   // since Overlapped2 is class, we can pass null as parameter,
   // no overload is needed 
   [DllImport("Kernel32.dll", CharSet=CharSet::Unicode, EntryPoint="ReadFile")]
   static bool ReadFile2( HandleRef hndRef, StringBuilder^ buffer, int numberOfBytesToRead, [Out]int * numberOfBytesRead, Overlapped2^ flag );
};

int main()
{

   FileStream^ fs = gcnew FileStream( "HandleRef.txt", FileMode::Open );
   HandleRef hr = HandleRef(fs,fs->Handle);
   StringBuilder^ buffer = gcnew StringBuilder( 5 );
   int read = 0;
   
   // platform invoke will hold reference to HandleRef until call ends
   LibWrap::ReadFile( hr, buffer, 5,  &read, 0 );
   Console::WriteLine( "Read with struct parameter: {0}", buffer );
   
       
   LibWrap::ReadFile2( hr, buffer, 5,  &read, nullptr );
   Console::WriteLine( "Read with class parameter: {0}", buffer );
}
// </Snippet1> 
