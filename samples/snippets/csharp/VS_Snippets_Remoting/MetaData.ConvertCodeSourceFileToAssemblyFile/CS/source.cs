// <Snippet1>
using System;
using System.Runtime.Remoting.MetadataServices;


public class Test
{
   public static void Main()
   {
      MetaData.ConvertCodeSourceFileToAssemblyFile("CsSource.cs", "testAssm.dll", "");
   }
}
// </Snippet1>