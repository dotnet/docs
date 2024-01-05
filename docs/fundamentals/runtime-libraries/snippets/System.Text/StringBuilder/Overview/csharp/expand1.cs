// <Snippet9>
using System;
using System.Text;

public class Example6
{
    public static void Main()
    {
        // Create a StringBuilder object with no text.
        StringBuilder sb = new StringBuilder();
        // Append some text.
        sb.Append('*', 10).Append(" Adding Text to a StringBuilder Object ").Append('*', 10);
        sb.AppendLine("\n");
        sb.AppendLine("Some code points and their corresponding characters:");
        // Append some formatted text.
        for (int ctr = 50; ctr <= 60; ctr++)
        {
            sb.AppendFormat("{0,12:X4} {1,12}", ctr, Convert.ToChar(ctr));
            sb.AppendLine();
        }
        // Find the end of the introduction to the column.
        int pos = sb.ToString().IndexOf("characters:") + 11 +
                  Environment.NewLine.Length;
        // Insert a column header.
        sb.Insert(pos, String.Format("{2}{0,12:X4} {1,12}{2}", "Code Unit",
                                     "Character", "\n"));

        // Convert the StringBuilder to a string and display it.      
        Console.WriteLine(sb.ToString());
    }
}
// The example displays the following output:
//    ********** Adding Text to a StringBuilder Object **********
//    
//    Some code points and their corresponding characters:
//    
//       Code Unit    Character
//            0032            2
//            0033            3
//            0034            4
//            0035            5
//            0036            6
//            0037            7
//            0038            8
//            0039            9
//            003A            :
//            003B            ;
//            003C            <
// </Snippet9>
