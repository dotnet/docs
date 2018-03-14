// System.Console.OpenStandartInput
// <Snippet1>
using System;
using System.Text;
using System.IO;

public class Decoder {
    public static void Main() {
        Stream inputStream = Console.OpenStandardInput();
        byte[] bytes = new byte[100];
        Console.WriteLine("To decode, type or paste the UTF7 encoded string and press enter:");
        Console.WriteLine("(Example: \"M+APw-nchen ist wundervoll\")");
        int outputLength = inputStream.Read(bytes, 0, 100);
        char[] chars = Encoding.UTF7.GetChars(bytes, 0, outputLength);
        Console.WriteLine("Decoded string:");
        Console.WriteLine(new string(chars));
    }
}
// </Snippet1>
