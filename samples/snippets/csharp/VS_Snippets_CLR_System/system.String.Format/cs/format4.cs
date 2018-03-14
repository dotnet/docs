// <Snippet4>
using System;

public class Example
{
   public static void Main()
   {
      string formatString = "    {0,10} ({0,8:X8})\n" + 
                            "And {1,10} ({1,8:X8})\n" + 
                            "  = {2,10} ({2,8:X8})";
      int value1 = 16932;
      int value2 = 15421;
      string result = String.Format(formatString, 
                                    value1, value2, value1 & value2);
      Console.WriteLine(result);
   }
}
// The example displays the following output:
//                16932 (00004224)
//       And      15421 (00003C3D)
//         =         36 (00000024)
// </Snippet4>
