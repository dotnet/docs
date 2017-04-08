using System;
using System.Runtime.CompilerServices;

public class Example
{
   public static void Main()
   {
   }

   // <Snippet5>
   [MethodImpl(MethodImplOptions.NoOptimization)]
   public bool TestCondition(int i) 
   {
      // Calls to methods that perform bit tests.    
      return Test1(i) && Test2(i) && Test3(i);
   }
   // </Snippet5>
   public bool Test1(int i) { return true; }
   public bool Test2(int i) { return true; }
   public bool Test3(int i) { return true; }
}
