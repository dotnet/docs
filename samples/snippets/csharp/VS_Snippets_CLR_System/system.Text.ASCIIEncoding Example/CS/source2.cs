//<snippet2>
using System;
using System.Text;

class BaseTypeEncoding
{
    public static void Main()
    {
        SnippetA();
        SnippetB();
    }

    public static void SnippetA()
    {
        //<snippet3>
        string MyString = "Encoding String.";
        ASCIIEncoding AE = new ASCIIEncoding();
        byte[] ByteArray = AE.GetBytes(MyString);
        for (int x = 0; x < ByteArray.Length; x++)
        {
            Console.Write("{0} ", ByteArray[x]);
        }
        //</snippet3>
    }

    public static void SnippetB()
    {
        //<snippet4>
        ASCIIEncoding AE = new ASCIIEncoding();
        byte[] ByteArray = {69, 110, 99, 111, 100, 105, 110, 103,
            32, 83, 116, 114, 105, 110, 103, 46 };
        char[] CharArray = AE.GetChars(ByteArray);
        for (int x = 0; x < CharArray.Length; x++)
        {
            Console.Write(CharArray[x]);
        }
        //</snippet4>
    }
}
//</snippet2>
