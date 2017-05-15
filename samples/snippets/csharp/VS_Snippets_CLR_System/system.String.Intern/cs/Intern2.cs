using System;
using System.Text;

[assembly: CLSCompliant(true)]
public class Class1
{
   public static void Main()
   {
      // <Snippet2>
		string str1 = String.Empty;
		string str2 = String.Empty;

		StringBuilder sb = new StringBuilder().Append(String.Empty);
		str2 = String.Intern(sb.ToString());	
		
		if((object)str1==(object)str2)
			Console.WriteLine("The strings are equal.");
		else
			Console.WriteLine("The strings are not equal.");
		// </Snippet2>	
   }
}
