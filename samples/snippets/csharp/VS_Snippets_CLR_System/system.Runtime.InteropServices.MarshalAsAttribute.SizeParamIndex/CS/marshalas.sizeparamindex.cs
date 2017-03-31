//<snippet1>
using System.Runtime.InteropServices;
using SomeNamespace;

namespace SomeNamespace
{
    // Force the layout of your fields to the C style struct layout.
    // Without this, the .NET Framework will reorder your fields.
    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex
    {
    	float	x;
	float	y;
    	float	z;
    }

    class SomeClass
    {
        // Add [In] or [In, Out] attributes as approppriate.
        // Marshal as a C style array of Vertex, where the second (SizeParamIndex is zero-based)
        //  parameter (size) contains the count of array elements.
        [DllImport ("SomeDll.dll")]
        public static extern void SomeUnsafeMethod(
                                      [MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] Vertex[] data,
                                      long size );

        public void SomeMethod()
        {
            Vertex[] verts = new Vertex[3];
            SomeUnsafeMethod( verts, verts.Length );
        }

    }
}

class Test
{
	public static void Main()
    {
        SomeClass AClass = new SomeClass();

        AClass.SomeMethod();
    }
}
//</snippet1>