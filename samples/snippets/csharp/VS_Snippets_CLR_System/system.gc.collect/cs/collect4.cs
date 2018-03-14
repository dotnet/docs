using System;
using System.Runtime;

public class Example
{
   public static void Main()
   {
      CreateObjects();
      Console.WriteLine("Memory allocated before GC: {0:N0}",
                        GC.GetTotalMemory(false));
      // <Snippet1>
      GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
      GC.Collect(2, GCCollectionMode.Forced, true, true);
      // </Snippet1>
      Console.WriteLine("Memory allocated after GC: {0:N0}",
                        GC.GetTotalMemory(false));
   }

   private static void CreateObjects()
   {
       String[] str = new String[10000];
       for (int ctr = 0; ctr <= 99999; ctr++) {
          String s1 = "word1";
          String s2 = "word2";
          str[ctr] = s1 + " " + s2;
       }

   }
}
