// <Snippet1>
using System;

class Example
{
   public static void Main() 
   {
      string str1 = "abc";
      string str2 = "xyz";
          
      Console.WriteLine("str1 = '{0}'", str1);
      Console.WriteLine("str2 = '{0}'", str2);
          
      Console.WriteLine("\nAfter String.Copy...");
      str2 = String.Copy(str1);
      Console.WriteLine("str1 = '{0}'", str1);
      Console.WriteLine("str2 = '{0}'", str2);
      Console.WriteLine("ReferenceEquals: {0}", Object.ReferenceEquals(str1, str2));
      Console.WriteLine("Equals: {0}", Object.Equals(str1, str2));
          
      Console.WriteLine("\nAfter Assignment...");
      str2 = str1;
      Console.WriteLine("str1 = '{0}'", str1);
      Console.WriteLine("str2 = '{0}'", str2);
      Console.WriteLine("ReferenceEquals: {0}", Object.ReferenceEquals(str1, str2));
      Console.WriteLine("Equals: {0}", Object.Equals(str1, str2));
   }
}
// The example displays the following output:
//       str1 = 'abc'
//       str2 = 'xyz'
//       
//       After String.Copy...
//       str1 = 'abc'
//       str2 = 'abc'
//       ReferenceEquals: False
//       Equals: True
//       
//       After Assignment...
//       str1 = 'abc'
//       str2 = 'abc'
//       ReferenceEquals: True
//       Equals: True
// </Snippet1>
