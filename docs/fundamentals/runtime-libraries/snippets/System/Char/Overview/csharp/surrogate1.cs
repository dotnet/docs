// <Snippet2>
using System;
using System.IO;

public class Example3
{
    public static void Main()
    {
        StreamWriter sw = new StreamWriter(@".\chars2.txt");
        int utf32 = 0x1D160;
        string surrogate = Char.ConvertFromUtf32(utf32);
        sw.WriteLine("U+{0:X6} UTF-32 = {1} ({2}) UTF-16",
                     utf32, surrogate, ShowCodePoints(surrogate));
        sw.Close();
    }

    private static string ShowCodePoints(string value)
    {
        string retval = null;
        foreach (var ch in value)
            retval += String.Format("U+{0:X4} ", Convert.ToUInt16(ch));

        return retval.Trim();
    }
}
// The example produces the following output:
//       U+01D160 UTF-32 = ð (U+D834 U+DD60) UTF-16
// </Snippet2>
