// <Snippet4>
using System;
using System.Runtime.InteropServices;

public class Example
{
   [DllImport("StringUtilities.dll", CharSet = CharSet.Unicode )]
   public static extern String SayGoodMorning(String name);

   public static void Main()
   {
      Console.WriteLine(SayGoodMorning("Dakota"));
   }
}
// The example displays the following output:
//    Unhandled Exception: System.EntryPointNotFoundException: Unable to find an entry point 
//    named 'GoodMorning' in DLL 'StringUtilities.dll'.
//       at Example.GoodMorning(String& name)
//       at Example.Main()
// </Snippet4>
