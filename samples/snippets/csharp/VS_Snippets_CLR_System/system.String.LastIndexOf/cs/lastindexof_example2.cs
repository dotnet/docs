// <Snippet2>
using System;

public class Example 
{
   public static void Main() 
   {
      string[] strSource = { "<b>This is bold text</b>", "<H1>This is large Text</H1>",
               "<b><i><font color=green>This has multiple tags</font></i></b>",
               "<b>This has <i>embedded</i> tags.</b>",
               "This line ends with a greater than symbol and should not be modified>" };

      // Strip HTML start and end tags from each string if they are present.
      foreach (string s in strSource)
      {
         Console.WriteLine("Before: " + s);
         string item = s;
         // Use EndsWith to find a tag at the end of the line.
         if (item.Trim().EndsWith(">")) 
         {
            // Locate the opening tag.
            int endTagStartPosition = item.LastIndexOf("</");
            // Remove the identified section, if it is valid.
            if (endTagStartPosition >= 0 )
               item = item.Substring(0, endTagStartPosition);

            // Use StartsWith to find the opening tag.
            if (item.Trim().StartsWith("<"))
            {
               // Locate the end of opening tab.
               int openTagEndPosition = item.IndexOf(">");
               // Remove the identified section, if it is valid.
               if (openTagEndPosition >= 0)
                  item = item.Substring(openTagEndPosition + 1);
            }      
         }
         // Display the trimmed string.
         Console.WriteLine("After: " + item);
         Console.WriteLine();
      }                   
   }
}
// The example displays the following output:
//    Before: <b>This is bold text</b>
//    After: This is bold text
//    
//    Before: <H1>This is large Text</H1>
//    After: This is large Text
//    
//    Before: <b><i><font color=green>This has multiple tags</font></i></b>
//    After: <i><font color=green>This has multiple tags</font></i>
//    
//    Before: <b>This has <i>embedded</i> tags.</b>
//    After: This has <i>embedded</i> tags.
//    
//    Before: This line ends with a greater than symbol and should not be modified>
//    After: This line ends with a greater than symbol and should not be modified>
// </Snippet2>