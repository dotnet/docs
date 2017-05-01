using System;

class AppDomainLoad
{
        public static void Main()
        {
		try
		{
// <Snippet1>
		AppDomain ad = AppDomain.CreateDomain("ChildDomain");
		ad.Load("MyAssembly");
// </Snippet1>
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Console.WriteLine(ex.StackTrace);
		}
	}
}