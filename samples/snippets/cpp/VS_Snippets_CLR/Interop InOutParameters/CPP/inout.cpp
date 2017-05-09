
// <Snippet1>
using namespace System;
using namespace System::Runtime::InteropServices;


// Declare a class member for each structure element.

[StructLayout(LayoutKind::Sequential,CharSet=CharSet::Unicode)]
public ref class OpenFileName
{
public:
   int structSize;
   String^ filter;
   String^ file;
   // ...
};

public ref class LibWrap
{
public:

   // Declare a managed prototype for the unmanaged function.

   [DllImport("Comdlg32.dll",CharSet=CharSet::Unicode)]
   static bool GetOpenFileName( [In,Out]OpenFileName^ ofn );
};

void main() {}
// </Snippet1>
