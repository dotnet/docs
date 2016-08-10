using System;

#if !PORTABLE259
// .NET Core libraries can go here.
#else
// Use a library here that is compatible with PCL Profile 329.
#endif

namespace Library
{
	public static class PCL329CompatLibrary
	{
		public static void Foo()
		{
#if !PORTABLE259
			// Using a .NET Core library unavailable to PCL Profile 329
#else
			// Need to use a a PCL Profile 329-compatible library here.
#endif
		}
	}
}