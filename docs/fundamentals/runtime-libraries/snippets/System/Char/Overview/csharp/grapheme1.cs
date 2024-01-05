// <Snippet1>
using System;
using System.IO;

public class Example1
{
    public static void Main()
    {
        StreamWriter sw = new StreamWriter("chars1.txt");
        char[] chars = { '\u0061', '\u0308' };
        string strng = new String(chars);
        sw.WriteLine(strng);
        sw.Close();
    }
}
// The example produces the following output:
//       ä
// </Snippet1>
