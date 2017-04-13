//<snippet1>
// This example demonstrates the Exception.Data property.
using System;
using System.Collections;

class Sample 
{
   public static void Main()
   {
      Console.WriteLine("\nException with some extra information...");
      RunTest(false);
      Console.WriteLine("\nException with all extra information...");
      RunTest(true);
   }

   public static void RunTest(bool displayDetails)
   {
      try {
         NestedRoutine1(displayDetails);
      }
      catch (Exception e) {
         Console.WriteLine("An exception was thrown.");
         Console.WriteLine(e.Message);
         if (e.Data.Count > 0) {
            Console.WriteLine("  Extra details:");
            foreach (DictionaryEntry de in e.Data)
               Console.WriteLine("    Key: {0,-20}      Value: {1}", 
                                 "'" + de.Key.ToString() + "'", de.Value);
         }
      }
   }
    
   public static void NestedRoutine1(bool displayDetails)
   {
      try {
         NestedRoutine2(displayDetails);
      }
      catch (Exception e) {
         e.Data["ExtraInfo"] = "Information from NestedRoutine1.";
         e.Data.Add("MoreExtraInfo", "More information from NestedRoutine1.");
         throw;
      }
   }
    
   public static void NestedRoutine2(bool displayDetails)
   {
      Exception e = new Exception("This statement is the original exception message.");
      if (displayDetails) {
         string s = "Information from NestedRoutine2.";
         int i = -903;
         DateTime dt = DateTime.Now;
         e.Data.Add("stringInfo", s);
         e.Data["IntInfo"] = i;
         e.Data["DateTimeInfo"] = dt;
      }
      throw e;
   }
}
// The example displays the following output: 
//    Exception with some extra information...
//    An exception was thrown.
//    This statement is the original exception message.
//      Extra details:                                               
//        Key: 'ExtraInfo'               Value: Information from NestedRoutine1.
//        Key: 'MoreExtraInfo'           Value: More information from NestedRoutine1.
//    
//    Exception with all extra information...
//    An exception was thrown.
//    This statement is the original exception message.
//      Extra details:
//        Key: 'stringInfo'              Value: Information from NestedRoutine2.
//        Key: 'IntInfo'                 Value: -903
//        Key: 'DateTimeInfo'            Value: 7/29/2013 10:50:13 AM
//        Key: 'ExtraInfo'               Value: Information from NestedRoutine1.
//        Key: 'MoreExtraInfo'           Value: More information from NestedRoutine1. 
//</snippet1>
