// <Snippet14>
using System;
using System.Text;

public class Example11
{
    public static void Main()
    {
        // Create a StringBuilder object with 4 successive occurrences 
        // of each character in the English alphabet. 
        StringBuilder sb = new StringBuilder();
        for (ushort ctr = (ushort)'a'; ctr <= (ushort)'z'; ctr++)
            sb.Append(Convert.ToChar(ctr), 4);

        // Iterate the text to determine when a new character sequence occurs.
        int position = 0;
        Char current = '\u0000';
        do
        {
            if (sb[position] != current)
            {
                current = sb[position];
                sb[position] = Char.ToUpper(sb[position]);
                if (position > 0)
                    sb.Insert(position, "_");
                position += 2;
            }
            else
            {
                position++;
            }
        } while (position <= sb.Length - 1);
        // Display the resulting string.
        String sbString = sb.ToString();
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
// </Snippet14>
