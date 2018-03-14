using System;
using System.Runtime;

public class Example
{
   public static void Main()
   {
     // <Snippet1>
     if (GCSettings.LatencyMode == GCLatencyMode.NoGCRegion)
        GC.EndNoGCRegion();
     // </Snippet1>
   }
}

public class GC
{
   public static void EndNoGCRegion() {}
}

 public enum GCLatencyMode
{
   Batch = 0,
   Interactive = 1,
   LowLatency = 2,
   SustainedLowLatency = 3,
   NoGCRegion = 4
}

