namespace StringExamples;

using System;
using System.Text;

public class StringCharacters
{
    public static void StringComponents()
    {
        //<Substrings>
        string s3 = "Visual C# Express";
        System.Console.WriteLine(s3.Substring(7, 2));
        // Output: "C#"

        System.Console.WriteLine(s3.Replace("C#", "Basic"));
        // Output: "Visual Basic Express"

        // Index values are zero-based
        int index = s3.IndexOf("C");
        // index = 7
        //</Substrings>
        System.Console.WriteLine("index =" + index);

        //<ReverseChars>
        string s5 = "Printing backwards";

        for (int i = 0; i < s5.Length; i++)
        {
            System.Console.Write(s5[s5.Length - i - 1]);
        }
        // Output: "sdrawkcab gnitnirP"
        //</ReverseChars>
        System.Console.WriteLine();

        //<AccessChars>
        string question = "hOW DOES mICROSOFT wORD DEAL WITH THE cAPS lOCK KEY?";
        System.Text.StringBuilder sb = new System.Text.StringBuilder(question);

        for (int j = 0; j < sb.Length; j++)
        {
            if (System.Char.IsLower(sb[j]) == true)
                sb[j] = System.Char.ToUpper(sb[j]);
            else if (System.Char.IsUpper(sb[j]) == true)
                sb[j] = System.Char.ToLower(sb[j]);
        }
        // Store the new string.
        string corrected = sb.ToString();
        System.Console.WriteLine(corrected);
        // Output: How does Microsoft Word deal with the Caps Lock key?
        //</AccessChars>
    }

    public static void BuildStrings()
    {
        //<BuildString>
        string str = "hello";
        string? nullStr = null;
        string emptyStr = String.Empty;

        string tempStr = str + nullStr;
        // Output of the following line: hello
        Console.WriteLine(tempStr);

        bool b = (emptyStr == nullStr);
        // Output of the following line: False
        Console.WriteLine(b);

        // The following line creates a new empty string.
        string newStr = emptyStr + nullStr;

        // Null strings and empty strings behave differently. The following
        // two lines display 0.
        Console.WriteLine(emptyStr.Length);
        Console.WriteLine(newStr.Length);
        // The following line raises a NullReferenceException.
        //Console.WriteLine(nullStr.Length);

        // The null character can be displayed and counted, like other chars.
        string s1 = "\x0" + "abc";
        string s2 = "abc" + "\x0";
        // Output of the following line: * abc*
        Console.WriteLine("*" + s1 + "*");
        // Output of the following line: *abc *
        Console.WriteLine("*" + s2 + "*");
        // Output of the following line: 4
        Console.WriteLine(s2.Length);
        //</BuildString>

        //<MutateStringBuilder>
        System.Text.StringBuilder sb = new System.Text.StringBuilder("Rat: the ideal pet");
        sb[0] = 'C';
        System.Console.WriteLine(sb.ToString());
        //Outputs Cat: the ideal pet
        //</MutateStringBuilder>
    }

    public static void TestStringBuilder()
    {
        // <TestStringBuilder>
        var sb = new StringBuilder();

        // Create a string composed of numbers 0 - 9
        for (int i = 0; i < 10; i++)
        {
            sb.Append(i.ToString());
        }
        Console.WriteLine(sb);  // displays 0123456789

        // Copy one character of the string (not possible with a System.String)
        sb[0] = sb[9];

        Console.WriteLine(sb);  // displays 9123456789
        // </TestStringBuilder>
    }

}
