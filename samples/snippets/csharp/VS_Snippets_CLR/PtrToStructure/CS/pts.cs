using System;
using System.Runtime.InteropServices;

namespace Testing
{
	class Class1
	{
		// <snippet1>
		[StructLayout(LayoutKind.Sequential)]
		public class  INNER
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst =  10)]
			public string field1 = "Test";
	 
		}	
		[StructLayout(LayoutKind.Sequential)]
		public struct OUTER
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst =  10)]
			public string field1;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst =  100)]
			public byte[] inner;
		}


		[DllImport(@"SomeTestDLL.dll")]
		public static extern void CallTest( ref OUTER po);

		static void Main(string[] args)
		{
			OUTER ed = new OUTER();
			INNER[] inn=new INNER[10];
			INNER test = new INNER();
			int iStructSize = Marshal.SizeOf(test);

			int sz =inn.Length * iStructSize;
			ed.inner = new byte[sz];

			try
			{
				CallTest( ref ed);
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			IntPtr buffer = Marshal.AllocCoTaskMem(iStructSize*10);
			Marshal.Copy(ed.inner,0,buffer,iStructSize*10);
			
			int iCurOffset = 0;
			for(int i=0;i<10;i++)
			{
				
				inn[i] = (INNER)Marshal.PtrToStructure(new
IntPtr(buffer.ToInt32()+iCurOffset),typeof(INNER) );
				iCurOffset += iStructSize;
			}
			Console.WriteLine(ed.field1);
			Marshal.FreeCoTaskMem(buffer);
		}
		// </snippet1>
	}
}
