// <Snippet15>
using System;
using System.Text;
using System.Text.RegularExpressions;

public class Example12
{
    public static void Main()
    {
        // Create a StringBuilder object with 4 successive occurrences 
        // of each character in the English alphabet. 
        StringBuilder sb = new StringBuilder();
        for (ushort ctr = (ushort)'a'; ctr <= (ushort)'z'; ctr++)
            sb.Append(Convert.ToChar(ctr), 4);

        // Convert it to a string.
        String sbString = sb.ToString();

        // Use a regex to uppercase the first occurrence of the sequence, 
        // and separate it from the previous sequence by an underscore.
        string pattern = @"(\w)(\1+)";
        sbString = Regex.Replace(sbString, pattern,
                                 m => (m.Index > 0 ? "_" : "") +
                                 m.Groups[1].Value.ToUpper() +
                                 m.Groups[2].Value);

        // Display the resulting string.
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
// </Snippet15>
