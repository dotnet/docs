// <Snippet13>
using System;
using System.Text;
using System.Text.RegularExpressions;

public class Example10
{
    public static void Main()
    {
        // Create a StringBuilder object with 4 successive occurrences 
        // of each character in the English alphabet. 
        StringBuilder sb = new StringBuilder();
        for (ushort ctr = (ushort)'a'; ctr <= (ushort)'z'; ctr++)
            sb.Append(Convert.ToChar(ctr), 4);

        // Create a parallel string object.
        String sbString = sb.ToString();
        // Determine where each new character sequence begins.
        String pattern = @"(\w)\1+";
        MatchCollection matches = Regex.Matches(sbString, pattern);

        // Uppercase the first occurrence of the sequence, and separate it
        // from the previous sequence by an underscore character.
        for (int ctr = matches.Count - 1; ctr >= 0; ctr--)
        {
            Match m = matches[ctr];
            sb[m.Index] = Char.ToUpper(sb[m.Index]);
            if (m.Index > 0) sb.Insert(m.Index, "_");
        }
        // Display the resulting string.
        sbString = sb.ToString();
        int line = 0;
        do
        {
            int nChars = line * 80 + 79 <= sbString.Length ?
                                80 : sbString.Length - line * 80;
            Console.WriteLine(sbString.Substring(line * 80, nChars));
            line++;
        } while (line * 80 < sbString.Length);
    }
}
// The example displays the following output:
//    Aaaa_Bbbb_Cccc_Dddd_Eeee_Ffff_Gggg_Hhhh_Iiii_Jjjj_Kkkk_Llll_Mmmm_Nnnn_Oooo_Pppp_
//    Qqqq_Rrrr_Ssss_Tttt_Uuuu_Vvvv_Wwww_Xxxx_Yyyy_Zzzz
// </Snippet13>
