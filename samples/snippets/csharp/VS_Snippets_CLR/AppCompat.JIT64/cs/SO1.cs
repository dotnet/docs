using System;
using System.Runtime.CompilerServices;

public class Example
{
   public static void Main()
   {
   }
   // <Snippet1>
   [MethodImpl(MethodImplOptions.NoOptimization)]
   void LargeMethodBody() 
   // </Snippet1>
   {}

   // <Snippet2>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public int ReturnSomeValue()
   // </Snippet2>
   {  return 10; }

   // <Snippet3>
   [MethodImpl(MethodImplOptions.NoOptimization)]
   public void MethodWithExceptionHandler(bool flag)
   {
      if (flag) {
         // Execute code conditionally.
      }
      try {
         // throw here
         if (flag) { 
            // Code to execute conditionally. 
         }
      } 
      catch (Exception) {     // Turning off optimization prevents the compiler from
                                // removing the if condition and executing the block
                                // unconditionally. 
         if (flag) { 
            // Code to execute conditionally. 
         }  
      }   
   }
   // </Snippet3>

   // <Snippet4>
   [MethodImpl(MethodImplOptions.NoOptimization)]
   public bool TestCondition(int i) 
   {
      // Calls to methods that perform bit tests.    
      return Test1(i) && Test2(i) && Test3(i);
   }
   // </Snippet4>
   public bool Test1(int i) { return true; }
   public bool Test2(int i) { return true; }
   public bool Test3(int i) { return true; }
}
