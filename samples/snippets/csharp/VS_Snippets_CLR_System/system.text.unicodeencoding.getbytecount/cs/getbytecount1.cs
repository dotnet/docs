// <Snippet1>
using System;
using System.Text;

class UTF8EncodingExample {
    public static void Main() {
        String chars = "UTF-16 Encoding Example";
        Encoding unicode = Encoding.Unicode;

        Console.WriteLine("Bytes needed to encode '{0}':", chars);
        Console.WriteLine("   Maximum:         {0}",
                          unicode.GetMaxByteCount(chars.Length));
        Console.WriteLine("   Actual:          {0}",
                          unicode.GetByteCount(chars));
        Console.WriteLine("   Actual with BOM: {0}",
                          unicode.GetByteCount(chars) + unicode.GetPreamble().Length);
    }
}
// The example displays the following output:
//       Bytes needed to encode 'UTF-16 Encoding Example':
//          Maximum:         48
//          Actual:          46
//          Actual with BOM: 48
// </Snippet1>
