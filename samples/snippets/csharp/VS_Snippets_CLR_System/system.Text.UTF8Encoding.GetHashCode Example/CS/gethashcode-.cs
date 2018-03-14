// <Snippet1>
using System;
using System.Text;

class UTF8EncodingExample {
    public static void Main() {
        // Many ways to instantiate a UTF8 encoding.
        UTF8Encoding UTF8a = new UTF8Encoding();
        Encoding UTF8b = Encoding.UTF8;
        Encoding UTF8c = new UTF8Encoding(true, true);
        Encoding UTF8d = new UTF8Encoding(false, false);

        // But not all are the same.
        Console.WriteLine(UTF8a.GetHashCode());
        Console.WriteLine(UTF8b.GetHashCode());
        Console.WriteLine(UTF8c.GetHashCode());
        Console.WriteLine(UTF8d.GetHashCode());
    }
}
// </Snippet1>
