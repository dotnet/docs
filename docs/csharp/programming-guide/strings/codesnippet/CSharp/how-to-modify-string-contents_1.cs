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

            // Remove trailing and leading whitespace.
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