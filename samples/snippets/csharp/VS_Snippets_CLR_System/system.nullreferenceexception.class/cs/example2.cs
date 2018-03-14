// <Snippet3>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      List<String> names = GetData();
      PopulateNames(names);
   }

   private static void PopulateNames(List<String> names)
   {
      String[] arrNames = { "Dakota", "Samuel", "Nikita",
                            "Koani", "Saya", "Yiska", "Yumaevsky" };
      foreach (var arrName in arrNames)
         names.Add(arrName);
   }
   
   private static List<String> GetData() 
   {
      return null;   
   
   }
}
// The example displays output like the following:
//    Unhandled Exception: System.NullReferenceException: Object reference 
//    not set to an instance of an object.
//       at Example.PopulateNames(List`1 names)
//       at Example.Main()
// </Snippet3>
