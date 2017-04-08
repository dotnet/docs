// <Snippet4>
using System;
using System.Globalization;

public class ParseInt32
{
    public static void Main()
    {
        SnippetA();
        SnippetB();
        SnippetC();
    }

    public static void SnippetA()
    {
        // <Snippet5>
        string MyString = "12345";
        int MyInt = int.Parse(MyString);
        MyInt++;
        Console.WriteLine(MyInt);
        // The result is "12346".
        // </Snippet5>
    }

    public static void SnippetB()
    {
        // <Snippet6>
        CultureInfo MyCultureInfo = new CultureInfo("en-US");
        string MyString = "123,456";
        int MyInt = int.Parse(MyString, MyCultureInfo);
        Console.WriteLine(MyInt);
        // Raises System.Format exception.
        // </Snippet6>
    }

    public static void SnippetC()
    {
        // <Snippet7>
        CultureInfo MyCultureInfo = new CultureInfo("en-US");
        string MyString = "123,456";
        int MyInt = int.Parse(MyString, NumberStyles.AllowThousands, MyCultureInfo);
        Console.WriteLine(MyInt);
        // The result is "123456".
        // </Snippet7>
    }
}
// </Snippet4>
