// <Snippet1>
using System;
using System.Text;

class UTF8EncodingExample {
    public static void Main() {
        String chars = "UTF-32 Encoding Example";
        Encoding enc = Encoding.UTF32;

        Console.WriteLine("Bytes needed to encode '{0}':", chars);
        Console.WriteLine("   Maximum:         {0}",
                          enc.GetMaxByteCount(chars.Length));
        Console.WriteLine("   Actual:          {0}",
                          enc.GetByteCount(chars));
        Console.WriteLine("   Actual with BOM: {0}",
                          enc.GetByteCount(chars) + enc.GetPreamble().Length);
    }
}
// The example displays the following output:
//       Bytes needed to encode 'UTF-32 Encoding Example':
//          Maximum:         96
//          Actual:          92
//          Actual with BOM: 96
// </Snippet1>
