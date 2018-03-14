
namespace LCIDConversion
{ 
	//<Snippet1>
	using System;
	using System.Runtime.InteropServices;
	using System.Reflection;

	class LCIDAttrSample
	{
		private const int LCID_INSTALLED = 1;
		private const int LCID_SUPPORTED = 2;

		[DllImport("KERNEL32.DLL", EntryPoint="IsValidLocale", SetLastError = true, CharSet = CharSet.Auto)]
		[LCIDConversionAttribute(0)] // Position of the LCID argument
		public static extern bool IsValidLocale(
													uint dwFlags            // options
												);

		public void CheckCurrentLCID()
		{
			MethodInfo mthIfo = this.GetType().GetMethod("IsValidLocale");
			Attribute attr = Attribute.GetCustomAttribute(mthIfo,typeof(LCIDConversionAttribute));

			if( attr != null)
			{
				LCIDConversionAttribute lcidAttr = (LCIDConversionAttribute)attr;
				Console.WriteLine("Position of the LCID argument in the unmanaged signature: " + lcidAttr.Value.ToString());
			}

			bool res = IsValidLocale(LCID_INSTALLED);
			Console.WriteLine("Result LCID_INSTALLED " + res.ToString());
			res = IsValidLocale(LCID_SUPPORTED);
			Console.WriteLine("Result LCID_SUPPORTED " + res.ToString());
		}

		static void Main(string[] args)
		{
			LCIDAttrSample smpl = new LCIDAttrSample();
			smpl.CheckCurrentLCID();
		}
	}

	//</Snippet1>
}
