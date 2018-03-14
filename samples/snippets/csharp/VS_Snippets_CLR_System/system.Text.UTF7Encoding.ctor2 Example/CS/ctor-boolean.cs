// <Snippet1>
using System;
using System.Text;

class UTF7EncodingExample {
    public static void Main() {

        // A few optional characters.
        string chars = "!@#$";

        // The default Encoding does not allow optional characters.
        // Alternate byte values are used.
        UTF7Encoding utf7 = new UTF7Encoding();
        Byte[] bytes1 = utf7.GetBytes(chars);
        
        Console.WriteLine("Default UTF7 Encoding:");
        ShowArray(bytes1);

        // Convert back to characters.
        Console.WriteLine("Characters:");
        ShowArray(utf7.GetChars(bytes1));

        // Now, allow optional characters.
        // Optional characters are encoded with their normal code points.
        UTF7Encoding utf7AllowOptionals = new UTF7Encoding(true);
        Byte[] bytes2 = utf7AllowOptionals.GetBytes(chars);
        
        Console.WriteLine("UTF7 Encoding with optional characters allowed:");
        ShowArray(bytes2);

        // Convert back to characters.
        Console.WriteLine("Characters:");
        ShowArray(utf7AllowOptionals.GetChars(bytes2));
    }

    public static void ShowArray(Array theArray) {
        foreach (Object o in theArray) {
            Console.Write("[{0}]", o);
        }
        Console.WriteLine();
    }
}

// </Snippet1>
