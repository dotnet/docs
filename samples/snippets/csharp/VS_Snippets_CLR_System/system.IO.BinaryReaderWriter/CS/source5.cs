//<snippet6>
using System;
using System.IO;
using System.Text;

public class DumpFileSample
{
    private static readonly int CHUNK_SIZE = 1024;
    public static void Main(String[] args)
    {
        if ((args.Length == 0) || !File.Exists(args[0]))
        {
            Console.WriteLine("Please provide an existing file name.");
        }
        else
        {
            using (FileStream fs = new FileStream(args[0], FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs, new ASCIIEncoding()))
                {
                    byte[] chunk;

                    chunk = br.ReadBytes(CHUNK_SIZE);
                    while(chunk.Length > 0)
                    {
                        DumpBytes(chunk, chunk.Length);
                        chunk = br.ReadBytes(CHUNK_SIZE);
                    }
                }
            }
        }
    }

    public static void DumpBytes(byte[] bdata, int len)
    {
        int i;
        int j = 0;
        char dchar;
        // 3 * 16 chars for hex display, 16 chars for text and 8 chars
        // for the 'gutter' int the middle.
        StringBuilder dumptext = new StringBuilder("        ", 16 * 4 + 8);
        for (i = 0; i < len; i++)
        {
            dumptext.Insert(j * 3, String.Format("{0:X2} ", (int)bdata[i]));
            dchar = (char)bdata[i];
            //' replace 'non-printable' chars with a '.'.
            if (Char.IsWhiteSpace(dchar) || Char.IsControl(dchar))
            {
                dchar = '.';
            }
            dumptext.Append(dchar);
            j++;
            if (j == 16)
            {
                Console.WriteLine(dumptext);
                dumptext.Length = 0;
                dumptext.Append("        ");
                j = 0;
            }
        }
        // display the remaining line
        if (j > 0)
        {
            for (i = j; i < 16; i++)
            {
                dumptext.Insert(j * 3, "   ");
            }
            Console.WriteLine(dumptext);
        }
    }
}
//</snippet6>
