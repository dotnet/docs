// <Snippet1>
using System;
using System.Runtime.CompilerServices;

public class Example
{
   public static void Main()
   {
      var mc1 = new ManagedClass();
      var mc2 = new ManagedClass();
      var mc3 = new ManagedClass();
      
      var cwt = new ConditionalWeakTable<ManagedClass, ClassData>();
      cwt.Add(mc1, new ClassData());          
      cwt.Add(mc2, new ClassData());
      cwt.Add(mc3, new ClassData());
      
      var wr2 = new WeakReference(mc2);
      mc2 = null;

      GC.Collect();
      
      ClassData data = null; 

      if (wr2.Target == null)
          Console.WriteLine("No strong reference to mc2 exists.");   
      else if (cwt.TryGetValue(mc2, out data))
          Console.WriteLine("Data created at {0}", data.CreationTime);      
      else
          Console.WriteLine("mc2 not found in the table.");
   }
}

public class ManagedClass
{ 
}

public class ClassData
{
   public DateTime CreationTime;
   public object Data;   
   
   public ClassData()
   {
      CreationTime = DateTime.Now;
      this.Data  = new object();     
   }
}
// The example displays the following output:
//       No strong reference to mc2 exists.
// </Snippet1>