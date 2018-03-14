// <Snippet1>
using System;
using System.Text;

class UTF8EncodingExample {
    public static void Main() {
        String chars = "UTF8 Encoding Example";
        Encoding utf8 = Encoding.UTF8;

        Console.WriteLine("Bytes needed to encode '{0}':", chars);
        Console.WriteLine("   Maximum:         {0}",
                          utf8.GetMaxByteCount(chars.Length));
        Console.WriteLine("   Actual:          {0}",
                          utf8.GetByteCount(chars));
        Console.WriteLine("   Actual with BOM: {0}",
                          utf8.GetByteCount(chars) + utf8.GetPreamble().Length);
    }
}
// The example displays the following output:
//       Bytes needed to encode 'UTF8 Encoding Example':
//          Maximum:         66
//          Actual:          21
//          Actual with BOM: 24
// </Snippet1>
