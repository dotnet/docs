// REDMOND\glennha
// Simplified snippet per SuzCook tech review.
// <Snippet1>
using System;
using System.Reflection;

public class AssemblyNameDemo
{
   public static void Main()
   {
      // Create an AssemblyName, specifying the display name, and then
      // print the properties.
      AssemblyName myAssemblyName = 
         new AssemblyName("Example, Version=1.0.0.2001, Culture=en-US, PublicKeyToken=null");
      Console.WriteLine("Name: {0}", myAssemblyName.Name);
      Console.WriteLine("Version: {0}", myAssemblyName.Version);
      Console.WriteLine("CultureInfo: {0}", myAssemblyName.CultureInfo);
      Console.WriteLine("FullName: {0}", myAssemblyName.FullName);
   }
}
/* This code example produces output similar to the following:

Name: Example
Version: 1.0.0.2001
CultureInfo: en-US
FullName: Example, Version=1.0.0.2001, Culture=en-US, PublicKeyToken=null
 */
// </Snippet1>
