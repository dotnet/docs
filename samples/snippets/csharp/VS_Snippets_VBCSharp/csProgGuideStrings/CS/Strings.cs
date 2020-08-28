using System.Text.RegularExpressions;
using System;
using System.Text;
using System.Collections.Generic;

namespace CsCsrefProgrammingStrings
{

    class UsingStrings
    {
        static void Main()
        {
            //<Snippet1>
            // Declare without initializing.
            string message1;

            // Initialize to null.
            string message2 = null;

            // Initialize as an empty string.
            // Use the Empty constant instead of the literal "".
            string message3 = System.String.Empty;

            // Initialize with a regular string literal.
            string oldPath = "c:\\Program Files\\Microsoft Visual Studio 8.0";

            // Initialize with a verbatim string literal.
            string newPath = @"c:\Program Files\Microsoft Visual Studio 9.0";

            // Use System.String if you prefer.
            System.String greeting = "Hello World!";

            // In local variables (i.e. within a method body)
            // you can use implicit typing.
            var temp = "I'm still a strongly-typed System.String!";

            // Use a const string to prevent 'message4' from
            // being used to store another string value.
            const string message4 = "You can't get rid of me!";

            // Use the String constructor only when creating
            // a string from a char*, char[], or sbyte*. See
            // System.String documentation for details.
            char[] letters = { 'A', 'B', 'C' };
            string alphabet = new string(letters);
            //</Snippet1>


            //<Snippet2>
            string s1 = "A string is more ";
            string s2 = "than the sum of its chars.";

            // Concatenate s1 and s2. This actually creates a new
            // string object and stores it in s1, releasing the
            // reference to the original object.
            s1 += s2;

            System.Console.WriteLine(s1);
            // Output: A string is more than the sum of its chars.
            //</Snippet2>


            //<Snippet3>
            string columns = "Column 1\tColumn 2\tColumn 3";
            //Output: Column 1        Column 2        Column 3

            string rows = "Row 1\r\nRow 2\r\nRow 3";
            /* Output:
              Row 1
              Row 2
              Row 3
            */

            string title = "\"The \u00C6olean Harp\", by Samuel Taylor Coleridge";
            //Output: "The Æolean Harp", by Samuel Taylor Coleridge
            //</Snippet3>

            System.Console.WriteLine(columns);
            System.Console.WriteLine(rows);
            System.Console.WriteLine(title);


            //PARSNIP NOTE: This snippet is far left indented to preserve formatting on multiline verbatim string
            //<Snippet4>
            string filePath = @"C:\Users\scoleridge\Documents\";
            //Output: C:\Users\scoleridge\Documents\

            string text = @"My pensive SARA ! thy soft cheek reclined
                Thus on mine arm, most soothing sweet it is
                To sit beside our Cot,...";
            /* Output:
            My pensive SARA ! thy soft cheek reclined
               Thus on mine arm, most soothing sweet it is
               To sit beside our Cot,...
            */

            string quote = @"Her name was ""Sara.""";
            //Output: Her name was "Sara."
            //</Snippet4>
            System.Console.WriteLine(filePath);
            System.Console.WriteLine(text);
            System.Console.WriteLine(quote);


            //<Snippet5>
            string p1 = "\\\\My Documents\\My Files\\";
            string p2 = @"\\My Documents\My Files\";
            //</Snippet5>

            System.Console.WriteLine(p1);
            System.Console.WriteLine(p2);


            //<Snippet6>
            int year = 1999;
            string msg = "Eve was born in " + year.ToString();
            System.Console.WriteLine(msg);  // outputs "Eve was born in 1999"
            //</Snippet6>


            //<Snippet7>
            string s3 = "Visual C# Express";
            System.Console.WriteLine(s3.Substring(7, 2));
            // Output: "C#"

            System.Console.WriteLine(s3.Replace("C#", "Basic"));
            // Output: "Visual Basic Express"

            // Index values are zero-based
            int index = s3.IndexOf("C");
            // index = 7
            //</Snippet7>
            System.Console.WriteLine("index =" + index);

            //<Snippet8>
            string s5 = "Printing backwards";

            for (int i = 0; i < s5.Length; i++)
            {
                System.Console.Write(s5[s5.Length - i - 1]);
            }
            // Output: "sdrawkcab gnitnirP"
            //</Snippet8>
            System.Console.WriteLine();


            //<Snippet10>
            string s6 = "Battle of Hastings, 1066";

            System.Console.WriteLine(s6.ToUpper());
            // outputs "BATTLE OF HASTINGS 1066"
            System.Console.WriteLine(s6.ToLower());
            // outputs "battle of hastings 1066"
            //</Snippet10>




            System.Console.ReadKey();
        }
    }


    class ParseStrings
    {
        static void Main()
        {
            //How to: Determine if a string represents a numeric value
            //<Snippet14>

              string numString = "1287543"; //"1287543.0" will return false for a long
              long number1 = 0;
              bool canConvert = long.TryParse(numString, out number1);
              if (canConvert == true)
                Console.WriteLine("number1 now = {0}", number1);
              else
                Console.WriteLine("numString is not a valid long");

              byte number2 = 0;
              numString = "255"; // A value of 256 will return false
              canConvert = byte.TryParse(numString, out number2);
              if (canConvert == true)
                Console.WriteLine("number2 now = {0}", number2);
              else
                Console.WriteLine("numString is not a valid byte");

              decimal number3 = 0;
              numString = "27.3"; //"27" is also a valid decimal
              canConvert = decimal.TryParse(numString, out number3);
              if (canConvert == true)
                Console.WriteLine("number3 now = {0}", number3);
              else
                Console.WriteLine("number3 is not a valid decimal");
            //</Snippet14>

            Console.ReadKey();
        }
    }






    class UsingStringBuilder
    {
        static void Main()
        {
            //-------------------------------------------------------------------------
            //<Snippet15>
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Rat: the ideal pet");
            sb[0] = 'C';
            System.Console.WriteLine(sb.ToString());
            System.Console.ReadLine();

            //Outputs Cat: the ideal pet
            //</Snippet15>
        }
    }


    //-------------------------------------------------------------------------
    //<Snippet16>
    class TestStringSplit
    {
        static void Main()
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string text = "one\ttwo three:four,five six seven";
            System.Console.WriteLine("Original text: '{0}'", text);

            string[] words = text.Split(delimiterChars);
            System.Console.WriteLine("{0} words in text:", words.Length);

            foreach (string s in words)
            {
                System.Console.WriteLine(s);
            }

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    /* Output:
        Original text: 'one     two three:four,five six seven'
        7 words in text:
        one
        two
        three
        four
        five
        six
        seven
     */
    //</Snippet16>


    //-------------------------------------------------------------------------
    //<Snippet17>
    class TestRegularExpressions
    {
        static void Main()
        {
            string[] sentences =
            {
                "C# code",
                "Chapter 2: Writing Code",
                "Unicode",
                "no match here"
            };

            string sPattern = "code";

            foreach (string s in sentences)
            {
                System.Console.Write("{0,24}", s);

                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    System.Console.WriteLine("  (match for '{0}' found)", sPattern);
                }
                else
                {
                    System.Console.WriteLine();
                }
            }

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    /* Output:
               C# code  (match for 'code' found)
               Chapter 2: Writing Code  (match for 'code' found)
               Unicode  (match for 'code' found)
               no match here
    */
    //</Snippet17>


    //-------------------------------------------------------------------------
    //<Snippet18>
    class TestRegularExpressionValidation
    {
        static void Main()
        {
            string[] numbers =
            {
                "123-555-0190",
                "444-234-22450",
                "690-555-0178",
                "146-893-232",
                "146-555-0122",
                "4007-555-0111",
                "407-555-0111",
                "407-2-5555",
            };

            string sPattern = "^\\d{3}-\\d{3}-\\d{4}$";

            foreach (string s in numbers)
            {
                System.Console.Write("{0,14}", s);

                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern))
                {
                    System.Console.WriteLine(" - valid");
                }
                else
                {
                    System.Console.WriteLine(" - invalid");
                }
            }

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    /* Output:
          123-555-0190 - valid
         444-234-22450 - invalid
          690-555-0178 - valid
           146-893-232 - invalid
          146-555-0122 - valid
         4007-555-0111 - invalid
          407-555-0111 - valid
            407-2-5555 - invalid
    */
    //</Snippet18>


    //-------------------------------------------------------------------------
    class StringBuildingExample
    {
        static void Main()
        {
            //<Snippet19>
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("one ");
            sb.Append("two ");
            sb.Append("three");
            string str = sb.ToString();
            System.Console.WriteLine(str);

            // Output: one two three
            //</Snippet19>
        }
    }


    //-------------------------------------------------------------------------
    class StringBuilderExample2
    {
        static void Main()
        {
            //<Snippet20>
            static void Main()
            {
                string str = "hello";
                string nullStr = null;
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
            }
            //</Snippet20>
        }
    }

    //-------------------------------------------------------------------------
    //<Snippet21>
    class StringSearch
    {
        static void Main()
        {
            string str = "Extension methods have all the capabilities of regular static methods.";

            // Write the string and include the quotation marks.
            System.Console.WriteLine("\"{0}\"", str);

            // Simple comparisons are always case sensitive!
            bool test1 = str.StartsWith("extension");
            System.Console.WriteLine("Starts with \"extension\"? {0}", test1);

            // For user input and strings that will be displayed to the end user,
            // use the StringComparison parameter on methods that have it to specify how to match strings.
            bool test2 = str.StartsWith("extension", System.StringComparison.CurrentCultureIgnoreCase);
            System.Console.WriteLine("Starts with \"extension\"? {0} (ignoring case)", test2);

            bool test3 = str.EndsWith(".", System.StringComparison.CurrentCultureIgnoreCase);
            System.Console.WriteLine("Ends with '.'? {0}", test3);

            // This search returns the substring between two strings, so
            // the first index is moved to the character just after the first string.
            int first = str.IndexOf("methods") + "methods".Length;
            int last = str.LastIndexOf("methods");
            string str2 = str.Substring(first, last - first);
            System.Console.WriteLine("Substring between \"methods\" and \"methods\": '{0}'", str2);

            // Keep the console window open in debug mode
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    /*
    Output:
    "Extension methods have all the capabilities of regular static methods."
    Starts with "extension"? False
    Starts with "extension"? True (ignoring case)
    Ends with '.'? True
    Substring between "methods" and "methods": ' have all the capabilities of regular static '
    Press any key to exit.
    */
    //</Snippet21>

    //-------------------------------------------------------------------------
    //<Snippet22>
    class StringBuilderTest
    {
        static void Main()
        {
            string text = null;

            // Use StringBuilder for concatenation in tight loops.
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                sb.AppendLine(i.ToString());
            }
            System.Console.WriteLine(sb.ToString());

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    // Output:
    // 0
    // 1
    // 2
    // 3
    // 4
    // ...
    //
    //</Snippet22>
    //-------------------------------------------------------------------------

    class JoinStrings
    {
        //<Snippet23>
        static void Main(string[] args)
        {
            // To run this program, provide a command line string.
            // In Visual Studio, see Project > Properties > Debug.
            string userName = args[0];
            string date = DateTime.Today.ToShortDateString();

            // Use the + and += operators for one-time concatenations.
            string str = "Hello " + userName + ". Today is " + date + ".";
            System.Console.WriteLine(str);

            str += " How are you today?";
            System.Console.WriteLine(str);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // Example output:
        //  Hello Alexander. Today is 1/22/2008.
        //  Hello Alexander. Today is 1/22/2008. How are you today?
        //  Press any key to exit.
        //
        //</Snippet23>
    }

    //-------------------------------------------------------------------------
    //<Snippet24>
    class ModifyStrings
    {
        static void Main()
        {
            string str = "The quick brown fox jumped over the fence";
            System.Console.WriteLine(str);

            char[] chars = str.ToCharArray();
            int animalIndex = str.IndexOf("fox");
            if (animalIndex != -1)
            {
                chars[animalIndex++] = 'c';
                chars[animalIndex++] = 'a';
                chars[animalIndex] = 't';
            }

            string str2 = new string(chars);
            System.Console.WriteLine(str2);

            // Keep the console window open in debug mode
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    /* Output:
      The quick brown fox jumped over the fence
      The quick brown cat jumped over the fence
    */
    //</Snippet24>
    //-------------------------------------------------------------------------

    class StringReferenceDemo
    {
        static void Main()
        {
            // <snippet25>
            string s1 = "Hello ";
            string s2 = s1;
            s1 += "World";

            System.Console.WriteLine(s2);
            //Output: Hello
            //</snippet25>

            System.Console.ReadKey();
        }
    }

    //-------------------------------------------------------------------------
    //<snippet26>
    class FormatString
    {
        static void Main()
        {
            // Get user input.
            System.Console.WriteLine("Enter a number");
            string input = System.Console.ReadLine();

            // Convert the input string to an int.
            int j;
            System.Int32.TryParse(input, out j);

            // Write a different string each iteration.
            string s;
            for (int i = 0; i < 10; i++)
            {
                // A simple format string with no alignment formatting.
                s = System.String.Format("{0} times {1} = {2}", i, j, (i * j));
                System.Console.WriteLine(s);
            }

            //Keep the console window open in debug mode.
            System.Console.ReadKey();
        }
    }
    //</snippet26>
    //-------------------------------------------------------------------------

    class StringNullReference
    {
    static void Main()
    {
        //<snippet27>
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
        //</snippet27>
    }
    }
    //-------------------------------------------------------------------------

    //<snippet28>
    class ReplaceSubstrings
    {
        string searchFor;
        string replaceWith;

        static void Main(string[] args)
        {

            ReplaceSubstrings app = new ReplaceSubstrings();
            string s = "The mountains are behind the clouds today.";

            // Replace one substring with another with String.Replace.
            // Only exact matches are supported.
            s = s.Replace("mountains", "peaks");
            Console.WriteLine(s);
            // Output: The peaks are behind the clouds today.

            // Use Regex.Replace for more flexibility.
            // Replace "the" or "The" with "many" or "Many".
            // using System.Text.RegularExpressions
            app.searchFor = "the"; // A very simple regular expression.
            app.replaceWith = "many";
            s = Regex.Replace(s, app.searchFor, app.ReplaceMatchCase, RegexOptions.IgnoreCase);
            Console.WriteLine(s);
            // Output: Many peaks are behind many clouds today.

            // Replace all occurrences of one char with another.
            s = s.Replace(' ', '_');
            Console.WriteLine(s);
            // Output: Many_peaks_are_behind_many_clouds_today.

            // Remove a substring from the middle of the string.
            string temp = "many_";
            int i = s.IndexOf(temp);
            if (i >= 0)
            {
                s = s.Remove(i, temp.Length);
            }
            Console.WriteLine(s);
            // Output: Many_peaks_are_behind_clouds_today.

            // Remove trailing and leading white space.
            // See also the TrimStart and TrimEnd methods.
            string s2 = "    I'm wider than I need to be.      ";
            // Store the results in a new string variable.
            temp = s2.Trim();
            Console.WriteLine(temp);
            // Output: I'm wider than I need to be.

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        // Custom match method called by Regex.Replace
        // using System.Text.RegularExpressions
        string ReplaceMatchCase(Match m)
        {
            // Test whether the match is capitalized
            if (Char.IsUpper(m.Value[0]) == true)
            {
                // Capitalize the replacement string
                // using System.Text;
                StringBuilder sb = new StringBuilder(replaceWith);
                sb[0] = (Char.ToUpper(sb[0]));
                return sb.ToString();
            }
            else
            {
                return replaceWith;
            }
        }
    }
    //</snippet28>

    //<snippet29>
    class UnsafeString
    {
        unsafe static void Main(string[] args)
        {
            // Compiler will store (intern)
            // these strings in same location.
            string s1 = "Hello";
            string s2 = "Hello";

            // Change one string using unsafe code.
            fixed (char* p = s1)
            {
                p[0] = 'C';
            }

            //  Both strings have changed.
            Console.WriteLine(s1);
            Console.WriteLine(s2);

            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    //</snippet29>

    class StringCompilerJoin
    {
        //<snippet30>
        static void Main()
        {
            // Concatenation of literals is performed at compile time, not run time.
            string text = "Historically, the world of data and the world of objects " +
            "have not been well integrated. Programmers work in C# or Visual Basic " +
            "and also in SQL or XQuery. On the one side are concepts such as classes, " +
            "objects, fields, inheritance, and .NET Framework APIs. On the other side " +
            "are tables, columns, rows, nodes, and separate languages for dealing with " +
            "them. Data types often require translation between the two worlds; there are " +
            "different standard functions. Because the object world has no notion of query, a " +
            "query can only be represented as a string without compile-time type checking or " +
            "IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to " +
            "objects in memory is often tedious and error-prone.";

            Console.WriteLine(text);
        }
        //</snippet30>
    }

    #region NOTUSED
    //// Create a file equivalent to the Greek work ψυχή (psyche) using code page 737
    //        System.IO.File.WriteAllBytes(@"C:\users\mblome\documents\extendedascii.txt", new byte[] { 0x94, 0x95, 0x96 });
    //        string s5 = System.IO.File.ReadAllText(@"C:\users\mblome\documents\extendedascii.txt");
    //        richTextBox1.Text = "With code page 1252:" + s5;
    //        Encoding encoding = Encoding.GetEncoding(737); //Greek
    //        byte[] arr = System.IO.File.ReadAllBytes(@"C:\users\mblome\documents\extendedascii.txt");
    //        string s6 = encoding.GetString(arr);

    //        richTextBox1.Text += "\r\nGreek: " + s6;
    #endregion

    //<snippet33>
// Use NotePad to save the following RTF code to a text file in the same folder as
// your .exe file for this project. Name the file test.rtf.
/*
{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}
{\f1\fnil\fprq1\fcharset0 Courier New;}{\f2\fswiss\fprq2\fcharset0 Arial;}}
{\colortbl ;\red0\green128\blue0;\red0\green0\blue0;}
{\*\generator Msftedit 5.41.21.2508;}
\viewkind4\uc1\pard\f0\fs20 The \i Greek \i0 word for "psyche" is spelled \cf1\f1\u968?\u965?\u967?\u942?\cf2\f2 . The Greek letters are encoded in Unicode.\par
These characters are from the extended \b ASCII \b0 character set (Windows code page 1252):  \'e2\'e4\u1233?\'e5\cf0\par }
*/
class ConvertFromRTF
{
    static void Main()
    {
        // If your RTF file isn't in the same folder as the .exe file for the project,
        // specify the path to the file in the following assignment statement.
        string path = @"test.rtf";

        //Create the RichTextBox. (Requires a reference to System.Windows.Forms.)
        System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();

        // Get the contents of the RTF file. When the contents of the file are
        // stored in the string (rtfText), the contents are encoded as UTF-16.
        string rtfText = System.IO.File.ReadAllText(path);

        // Display the RTF text. This should look like the contents of your file.
        System.Windows.Forms.MessageBox.Show(rtfText);

        // Use the RichTextBox to convert the RTF code to plain text.
        rtBox.Rtf = rtfText;
        string plainText = rtBox.Text;

        // Display the plain text in a MessageBox because the console can't
        // display the Greek letters. You should see the following result:
        //   The Greek word for "psyche" is spelled ψυχή. The Greek letters are
        //   encoded in Unicode.
        //   These characters are from the extended ASCII character set (Windows
        //   code page 1252): âäӑå
        System.Windows.Forms.MessageBox.Show(plainText);

        // Output the plain text to a file, encoded as UTF-8.
        System.IO.File.WriteAllText(@"output.txt", plainText);
    }
}
    //</snippet33>

    //<snippet34>
    class ANSIToUnicode
    {
        static void Main()
        {
            // Create a file that contains the Greek work ψυχή (psyche) when interpreted by using
            // code page 737 ((DOS) Greek). You can also create the file by using Character Map
            // to paste the characters into Microsoft Word and then "Save As" by using the DOS
            // (Greek) encoding. (Word will actually create a six-byte file by appending "\r\n" at the end.)
            System.IO.File.WriteAllBytes(@"greek.txt", new byte[] { 0xAF, 0xAC, 0xAE, 0x9E });

            // Specify the code page to correctly interpret byte values
            Encoding encoding = Encoding.GetEncoding(737); //(DOS) Greek code page
            byte[] codePageValues = System.IO.File.ReadAllBytes(@"greek.txt");

            // Same content is now encoded as UTF-16
            string unicodeValues = encoding.GetString(codePageValues);

            // Show that the text content is still intact in Unicode string
            // (Add a reference to System.Windows.Forms.dll)
            System.Windows.Forms.MessageBox.Show(unicodeValues);

            // Same content "ψυχή" is stored as UTF-8
            System.IO.File.WriteAllText(@"greek_unicode.txt", unicodeValues);

            // Conversion is complete. Show the bytes to prove the conversion.
            Console.WriteLine("8-bit encoding byte values:");
            foreach(byte b in codePageValues)
                Console.Write("{0:X}-", b);

            Console.WriteLine();
            Console.WriteLine("Unicode values:");
            string unicodeString = System.IO.File.ReadAllText("greek_unicode.txt");
            System.Globalization.TextElementEnumerator enumerator =
                System.Globalization.StringInfo.GetTextElementEnumerator(unicodeString);
            while(enumerator.MoveNext())
            {
               string s = enumerator.GetTextElement();
               int i = Char.ConvertToUtf32(s, 0);
               Console.Write("{0:X}-", i);
            }
            Console.WriteLine();

            // Keep the console window open in debug mode.
            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }
        /*
         * Output:
            8-bit encoding byte values:
            AF-AC-AE-9E
            Unicode values:
            3C8-3C5-3C7-3B7
        */
    }
    //</snippet34>
}
