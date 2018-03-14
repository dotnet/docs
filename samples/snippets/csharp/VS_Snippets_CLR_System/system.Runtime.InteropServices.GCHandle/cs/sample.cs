// <snippet1>
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Permissions;

public delegate bool CallBack(int handle, IntPtr param);

public class LibWrap
{
	// passing managed object as LPARAM
	// BOOL EnumWindows(WNDENUMPROC lpEnumFunc, LPARAM lParam);

	[DllImport("user32.dll")]
	public static extern bool EnumWindows(CallBack cb, IntPtr param);
}

public class App
{
	public static void Main()
	{
		Run();
	}

        [SecurityPermission(SecurityAction.Demand, UnmanagedCode=true)]
	public static void Run()
        {
		TextWriter tw = System.Console.Out;
		GCHandle gch = GCHandle.Alloc(tw);

		CallBack cewp = new CallBack(CaptureEnumWindowsProc);

		// platform invoke will prevent delegate to be garbage collected
		// before call ends

		LibWrap.EnumWindows(cewp, GCHandle.ToIntPtr(gch));
		gch.Free();
        }

	private static bool CaptureEnumWindowsProc(int handle, IntPtr param)
	{
		GCHandle gch = GCHandle.FromIntPtr(param);
		TextWriter tw = (TextWriter)gch.Target;
		tw.WriteLine(handle);
		return true;
	}
}
// </snippet1>