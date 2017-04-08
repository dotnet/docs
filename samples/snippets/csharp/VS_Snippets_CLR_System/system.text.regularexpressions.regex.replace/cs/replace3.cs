// <Snippet3>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      // Get drives available on local computer and form into a single character expression.
      string[] drives = Environment.GetLogicalDrives();
      string driveNames = String.Empty;
      foreach (string drive in drives)
         driveNames += drive.Substring(0,1);
      // Create regular expression pattern dynamically based on local machine information.
      string pattern = @"\\\\(?i:" + Environment.MachineName + @")(?:\.\w+)*\\((?i:[" + driveNames + @"]))\$";

      string replacement = "$1:";
      string[] uncPaths = { @"\\MyMachine.domain1.mycompany.com\C$\ThingsToDo.txt", 
                            @"\\MyMachine\c$\ThingsToDo.txt", 
                            @"\\MyMachine\d$\documents\mydocument.docx" }; 
      
      foreach (string uncPath in uncPaths)
      {
         Console.WriteLine("Input string: " + uncPath);
         Console.WriteLine("Returned string: " + Regex.Replace(uncPath, pattern, replacement));
         Console.WriteLine();
      }
   }
}
// The example displays the following output if run on a machine whose name is
// MyMachine:
//    Input string: \\MyMachine.domain1.mycompany.com\C$\ThingsToTo.txt
//    Returned string: C:\ThingsToDo.txt
//    
//    Input string: \\MyMachine\c$\ThingsToDo.txt
//    Returned string: c:\ThingsToDo.txt
//    
//    Input string: \\MyMachine\d$\documents\mydocument.docx
//    Returned string: d:\documents\mydocument.docx
// </Snippet3>
