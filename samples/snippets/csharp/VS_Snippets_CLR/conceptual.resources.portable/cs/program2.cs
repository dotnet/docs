using System.Resources;

// <Snippet3>
using System;
using System.Collections.Generic;
using System.Globalization;

using MyCompany.Employees;
 
class Program
{
   static void Main(string[] args)
   {
     
      // Get the data from some data source.
      var employees = InitializeData();

      // Display application title.
      string title = UILibrary.GetTitle();
      int start = (Console.WindowWidth + title.Length) / 2;
      string titlefmt = String.Format("{{0,{0}{1}", start, "}");
      Console.WriteLine(titlefmt, title);
      Console.WriteLine();

      // Retrieve resources.
      string[] fields = UILibrary.GetFieldNames();
      int[] lengths = UILibrary.GetFieldLengths();
      string fmtString = String.Empty;
      // Create format string for field headers and data.
      for (int ctr = 0; ctr < fields.Length; ctr++)
         fmtString += String.Format("{{{0},-{1}{2}{3}   ", ctr, lengths[ctr], ctr >= 2 ? ":d" : "", "}");

      // Display the headers.
      Console.WriteLine(fmtString, fields);
      Console.WriteLine();
      // Display the data.
      foreach (var e in employees)
         Console.WriteLine(fmtString, e.Item1, e.Item2, e.Item3, e.Item4);

      Console.ReadLine();
   }

   private static List<Tuple<String, String, DateTime, DateTime>> InitializeData() 
   {
      List<Tuple<String, String, DateTime, DateTime>> employees = new List<Tuple<String, String, DateTime, DateTime>>();
      var t1 = Tuple.Create("John", "16302", new DateTime(1954, 8, 18), new DateTime(2006, 9, 8));
      employees.Add(t1);
      t1 = Tuple.Create("Alice", "19745", new DateTime(1995, 5, 10), new DateTime(2012, 10, 17));
      employees.Add(t1);
      return employees;
   }

}
// </Snippet3>

namespace MyCompany.Employees
{
   public class UILibrary
   {
      private static ResourceManager rm;
      private const int nFields = 4;

      static UILibrary()
      {
         rm = new ResourceManager("MyCompany.Employees.LibResources", typeof(UILibrary).Assembly);
      }

      public static string GetTitle()
      {
         string retval = rm.GetString("Title");
         if (String.IsNullOrEmpty(retval))
            retval = "";

         return retval;
      }

      public static string[] GetFieldNames()
      {
         string[] fieldnames = new string[nFields];
         fieldnames[0] = rm.GetString("Name");
         fieldnames[1] = rm.GetString("ID");
         fieldnames[2] = rm.GetString("Born");
         fieldnames[3] = rm.GetString("Hired");
         return fieldnames;
      }

      public static int[] GetFieldLengths()
      {
         int[] fieldLengths = new int[nFields];
         fieldLengths[0] = Int32.Parse(rm.GetString("NameLength"));
         fieldLengths[1] = Int32.Parse(rm.GetString("IDLength"));
         fieldLengths[2] = Int32.Parse(rm.GetString("BornLength"));
         fieldLengths[3] = Int32.Parse(rm.GetString("HiredLength"));
         return fieldLengths;
      }
   }
}



