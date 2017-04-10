// <Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main(string[] args)
   {
      int value = Int32.Parse(args[0]);
      List<String> names;
      if (value > 0)
         names = new List<String>();
      
      names.Add("Major Major Major");       
   }
}
// Compilation displays a warning like the following:
//    Example1.vb(10) : warning BC42104: Variable //names// is used before it 
//    has been assigned a value. A null reference exception could result 
//    at runtime.
//    
//          names.Add("Major Major Major")
//          ~~~~~
// The example displays output like the following output:
//    Unhandled Exception: System.NullReferenceException: Object reference 
//    not set to an instance of an object.
//       at Example.Main()
// </Snippet1>
