
//<snippet1>
using namespace System;
using namespace System::Runtime::InteropServices;

// Force the layout of your fields to the C-style struct layout.
// Without this, the .NET Framework will reorder your fields.

[StructLayoutAttribute(LayoutKind::Sequential)]
value struct Vertex
{
public:
   float x;
   float y;
   float z;
};


// Add [In] or [In, Out] attributes as appropriate.
// Marshal as a C-style array of Vertex, where the second (SizeParamIndex is zero-based)
// parameter (size) contains the count of array elements.

[DllImport("SomeDLL.dll")]
extern void SomeUnsafeMethod( [MarshalAs(UnmanagedType::LPArray,SizeParamIndex=1)]array<Vertex>^data, long size );
int main()
{
   array<Vertex>^verts = gcnew array<Vertex>(3);
   SomeUnsafeMethod( verts, verts->Length );
}

//</snippet1>
