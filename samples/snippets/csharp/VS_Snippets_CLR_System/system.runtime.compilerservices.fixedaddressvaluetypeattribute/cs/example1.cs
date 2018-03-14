// <Snippet1>
using System;
using System.Runtime.CompilerServices;

public struct Age {
   public int years;
   public int months;
}

public class FreeClass
{
   public static Age FreeAge;
   
   public static unsafe IntPtr AddressOfFreeAge()
   { 
      fixed (Age* pointer = &FreeAge) 
      { return (IntPtr) pointer; } 
   }
}

public class FixedClass
{
   [FixedAddressValueType]
   public static Age FixedAge;
   
   public static unsafe IntPtr AddressOfFixedAge()
   { 
      fixed (Age* pointer = &FixedAge) 
      { return (IntPtr) pointer; } 
   }   
}

public class Example
{
   public static void Main()
   {
      AllocateMemory();
      
      // Get addresses of static Age fields.
      IntPtr freePtr1 = FreeClass.AddressOfFreeAge();
      AllocateMemory();
      
      IntPtr fixedPtr1 = FixedClass.AddressOfFixedAge();
      AllocateMemory();

      // Garbage collection.
      GC.Collect();
      GC.WaitForPendingFinalizers();
      
      // Get addresses of static Age fields after garbage collection.
      IntPtr freePtr2 = FreeClass.AddressOfFreeAge();
      IntPtr fixedPtr2 = FixedClass.AddressOfFixedAge();
        
      // Display addresses before and after garbage collection
      Console.WriteLine("Normal static: {0} -> {1}", freePtr1, freePtr2);
      Console.WriteLine("Pinned static:  {0} -> {1}", fixedPtr1, fixedPtr2);  
   }

   // Allocate memory for 100,000 objects.
   static public void AllocateMemory()
   {
      for (int ctr = 0; ctr <= 100000; ctr++)
      {
         object o = new object();      
      }
   }
}
// The example displays output similar to the following:
//       Normal static: 19932420 -> 19863704
//       Pinned static:  19985508 -> 19985508
// </Snippet1>
