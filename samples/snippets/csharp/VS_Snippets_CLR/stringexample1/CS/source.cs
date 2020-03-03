using System;
using System.Text;

namespace Microsoft.Demo
{
    class ConsoleApp
    {
        [STAThread]
        static void Main(string[] args)
        {
//<snippet1>
            // Unicode Mathematical operators
            char [] charArr1 = {'\u2200','\u2202','\u200F','\u2205'};
            String szMathSymbols = new String(charArr1);

            // Unicode Letterlike Symbols
            char [] charArr2 = {'\u2111','\u2118','\u2122','\u2126'};
            String szLetterLike = new String (charArr2);

            // Compare Strings - the result is false
            Console.WriteLine("The Strings are equal? " +
                (String.Compare(szMathSymbols, szLetterLike)==0?"true":"false") );
//</snippet1>
//<snippet2>
            unsafe
            {
                // Null terminated ASCII characters in an sbyte array
                String szAsciiUpper = null;
                sbyte[] sbArr1 = new sbyte[] { 0x41, 0x42, 0x43, 0x00 };
                // Instruct the Garbage Collector not to move the memory
                fixed(sbyte* pAsciiUpper = sbArr1)
                {
                    szAsciiUpper = new String(pAsciiUpper);
                }
                String szAsciiLower = null;
                sbyte[] sbArr2 = { 0x61, 0x62, 0x63, 0x00 };
                // Instruct the Garbage Collector not to move the memory
                fixed(sbyte* pAsciiLower = sbArr2)
                {
                    szAsciiLower = new String(pAsciiLower, 0, sbArr2.Length);
                }
                // Prints "ABC abc"
                Console.WriteLine(szAsciiUpper + " " + szAsciiLower);

                // Compare Strings - the result is true
                Console.WriteLine("The Strings are equal when capitalized ? " +
                    (String.Compare(szAsciiUpper.ToUpper(), szAsciiLower.ToUpper())==0?"true":"false") );

                // This is the effective equivalent of another Compare method, which ignores case
                Console.WriteLine("The Strings are equal when capitalized ? " +
                    (String.Compare(szAsciiUpper, szAsciiLower, true)==0?"true":"false") );
            }
//</snippet2>
//<snippet3>
            // Create a Unicode String with 5 Greek Alpha characters
            String szGreekAlpha = new String('\u0391',5);
            // Create a Unicode String with a Greek Omega character
            String szGreekOmega = new String(new char [] {'\u03A9','\u03A9','\u03A9'},2,1);

            String szGreekLetters = String.Concat(szGreekOmega, szGreekAlpha, szGreekOmega.Clone());

            // Examine the result
            Console.WriteLine(szGreekLetters);

            // The first index of Alpha
            int ialpha = szGreekLetters.IndexOf('\u0391');
            // The last index of Omega
            int iomega = szGreekLetters.LastIndexOf('\u03A9');

            Console.WriteLine("The Greek letter Alpha first appears at index " + ialpha +
                " and Omega last appears at index " + iomega + " in this String.");
//</snippet3>

//<snippet4>
            unsafe
            {
                String utfeightstring = null;
                sbyte [] asciiChars = new sbyte[] { 0x51,0x52,0x53,0x54,0x54,0x56 };
                UTF8Encoding encoding = new UTF8Encoding(true, true);

                // Instruct the Garbage Collector not to move the memory
                fixed(sbyte* pAsciiChars = asciiChars)
                {
                    utfeightstring = new String(pAsciiChars,0,asciiChars.Length,encoding);
                }
                Console.WriteLine("The UTF8 String is " + utfeightstring ); // prints "QRSTTV"
            }
//</snippet4>
        }
    }
}