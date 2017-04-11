// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      foreach (var t in typeof(Example).Assembly.GetTypes()) {
         Console.WriteLine("{0} derived from: ", t.FullName);
         var derived = t;
         do { 
            derived = derived.BaseType;
            if (derived != null) 
               Console.WriteLine("   {0}", derived.FullName);

         } while (derived != null);
         Console.WriteLine(); 
      } 
   }
}

public class A {} 

public class B : A
{}

public class C : B   
{}
// The example displays the following output:
//       Example derived from:
//          System.Object
//       
//       A derived from:
//          System.Object
//       
//       B derived from:
//          A
//          System.Object
//       
//       C derived from:
//          B
//          A
//          System.Object
// </Snippet2>
