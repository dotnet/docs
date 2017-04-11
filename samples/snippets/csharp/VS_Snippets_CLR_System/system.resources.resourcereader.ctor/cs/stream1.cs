// <Snippet1>
using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Resources;

public class Example
{
   public static void Main()
   {
      var assem = typeof(Example).Assembly;
      var fs = assem.GetManifestResourceStream("PatientForm.resources");
      var rr = new ResourceReader(fs);
      IDictionaryEnumerator dict = rr.GetEnumerator();
      int ctr = 0;

      while (dict.MoveNext()) {
         ctr++;
         Console.WriteLine("{0:00}: {1} = {2}", ctr, dict.Key, dict.Value);
      }
      rr.Close();
   }
}
// The example displays the following output:
//       01: Label3 = "Species:"
//       02: Label2 = "Pet Name:"
//       03: Label1 = "Patient Number:"
//       04: Label7 = "Owner:"
//       05: Label6 = "Age:"
//       06: Label5 = "Date of Birth:"
//       07: Label4 = "Breed:"
//       08: Label9 = "Home Phone:"
//       09: Label8 = "Address:"
//       10: Title = "Top Pet Animal Clinic"
//       11: Label10 = "Work Phone:"
//       12: Label11 = "Mobile Phone:"
// </Snippet1>
