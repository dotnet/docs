using System;
using System.Runtime;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
      GC.Collect();      
      // </Snippet1>
   }
}
