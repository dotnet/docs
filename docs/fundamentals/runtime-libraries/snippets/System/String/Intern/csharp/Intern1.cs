using System;
using System.Text;

[assembly: CLSCompliant(true)]
public class Class1
{
   public static void Main()
   {
      // <Snippet1>
      string s1 = "MyTest"; 
      string s2 = new StringBuilder().Append("My").Append("Test").ToString(); 
      string s3 = String.Intern(s2); 
      Console.WriteLine((Object)s2==(Object)s1); // Different references.
      Console.WriteLine((Object)s3==(Object)s1); // The same reference.
      // </Snippet1>
   }
}
