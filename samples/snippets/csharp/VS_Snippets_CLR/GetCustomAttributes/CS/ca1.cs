// <Snippet1>
using System;
using System.Reflection;

[assembly: AssemblyTitle("CustAttrs1CS")]
[assembly: AssemblyDescription("GetCustomAttributes() Demo")]
[assembly: AssemblyCompany("Microsoft")]

class Example {
    static void Main() {
        // Get the Assembly object to access its metadata.
        Assembly assy = typeof(Example).Assembly;

        // Iterate through the attributes for the assembly.
        foreach(Attribute attr in Attribute.GetCustomAttributes(assy)) {
            // Check for the AssemblyTitle attribute.
            if (attr.GetType() == typeof(AssemblyTitleAttribute))
                Console.WriteLine("Assembly title is \"{0}\".",
                    ((AssemblyTitleAttribute)attr).Title);

            // Check for the AssemblyDescription attribute.
            else if (attr.GetType() == 
                typeof(AssemblyDescriptionAttribute))
                Console.WriteLine("Assembly description is \"{0}\".",
                    ((AssemblyDescriptionAttribute)attr).Description);

            // Check for the AssemblyCompany attribute.
            else if (attr.GetType() == typeof(AssemblyCompanyAttribute))
                Console.WriteLine("Assembly company is {0}.",
                    ((AssemblyCompanyAttribute)attr).Company);
        }
   }
}
// The example displays the following output:
//     Assembly title is "CustAttrs1CS".
//     Assembly description is "GetCustomAttributes() Demo".
//     Assembly company is Microsoft.
// </Snippet1>
