// <Snippet1>
using System;
using System.Collections;
using System.Resources;

public class Example1
{
   public static void Run()
   {
      Console.WriteLine("Resources in ApplicationResources.resources:");
      ResourceReader res = new ResourceReader(@".\ApplicationResources.resources");
      IDictionaryEnumerator dict = res.GetEnumerator();
      while (dict.MoveNext())
         Console.WriteLine($"   {dict.Key}: '{dict.Value}' (Type {dict.Value.GetType().Name})");
      res.Close();
   }
}
// The example displays the following output:
//       Resources in ApplicationResources.resources:
//          Label3: '"Last Name:"' (Type String)
//          Label2: '"Middle Name:"' (Type String)
//          Label1: '"First Name:"' (Type String)
//          Label7: '"State:"' (Type String)
//          Label6: '"City:"' (Type String)
//          Label5: '"Street Address:"' (Type String)
//          Label4: '"SSN:"' (Type String)
//          Label9: '"Home Phone:"' (Type String)
//          Label8: '"Zip Code:"' (Type String)
//          Title: '"Contact Information"' (Type String)
//          Label12: '"Other Phone:"' (Type String)
//          Label13: '"Fax:"' (Type String)
//          Label10: '"Business Phone:"' (Type String)
//          Label11: '"Mobile Phone:"' (Type String)
//          Label14: '"Email Address:"' (Type String)
//          Label15: '"Alternate Email Address:"' (Type String)
// </Snippet1>
