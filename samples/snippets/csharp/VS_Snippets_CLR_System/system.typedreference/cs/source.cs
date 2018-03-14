using System;
using System.Reflection;

class TypedReferenceArray
{
        public static void Main()
        {
		try
		{
// <Snippet1>
		Assembly.Load("mscorlib.dll").GetType("System.TypedReference[]");
// </Snippet1>
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Console.WriteLine(ex.StackTrace);
		}
	}
}