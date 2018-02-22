using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HowToStrings
{
    public static class ModifyStrings
    {
        private static string replaceWith;

        public static void Examples()
        {
            string s = "The mountains are behind the clouds today.";

            // Replace one substring with another with String.Replace.
            // Only exact matches are supported.
            s = s.Replace("mountains", "peaks");
            Console.WriteLine(s);
            // Output: The peaks are behind the clouds today.

            // Use Regex.Replace for more flexibility. 
            // Replace "the" or "The" with "many" or "Many".
            // using System.Text.RegularExpressions
            replaceWith = "many";
            s = Regex.Replace(s, "the", ReplaceMatchCase, RegexOptions.IgnoreCase);
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

            // Remove trailing and leading whitespace.
            // See also the TrimStart and TrimEnd methods.
            string s2 = "    I'm wider than I need to be.      ";
            // Store the results in a new string variable.
            temp = s2.Trim();
            Console.WriteLine(temp);
            // Output: I'm wider than I need to be.

            // Start of existing example 2
            // ==============================================
            string str = "The quick brown fox jumped over the fence";
            Console.WriteLine(str);

            char[] chars = str.ToCharArray();
            int animalIndex = str.IndexOf("fox");
            if (animalIndex != -1)
            {
                chars[animalIndex++] = 'c';
                chars[animalIndex++] = 'a';
                chars[animalIndex] = 't';
            }

            string str2 = new string(chars);
            Console.WriteLine(str2);

            // Start of existing example 3:
            // ===========================================
            UnsafeSample();
        }

        private static void UnsafeSample()
        {
            unsafe
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
            }
        }

        // I see dead code:
        // Custom match method called by Regex.Replace
        // using System.Text.RegularExpressions
        static string ReplaceMatchCase(Match m)
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
}
