// <Snippet1>
using System;
using System.Text;

class UTF8EncodingExample {
    public static void Main() {
        UTF8Encoding utf8 = new UTF8Encoding();
        UTF8Encoding utf8EmitBOM = new UTF8Encoding(true);

        Console.WriteLine("utf8 preamble:");
        ShowArray(utf8.GetPreamble());

        Console.WriteLine("utf8EmitBOM:");
        ShowArray(utf8EmitBOM.GetPreamble());
    }

    public static void ShowArray(Array theArray) {
        foreach (Object o in theArray) {
            Console.Write("[{0}]", o);
        }
        Console.WriteLine();
    }
}
// </Snippet1>
