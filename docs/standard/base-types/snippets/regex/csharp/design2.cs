// <Snippet1>
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

public class DesignExample
{
    public static void Main()
    {
        Stopwatch sw;
        string[] addresses = { "AAAAAAAAAAA@contoso.com",
                             "AAAAAAAAAAaaaaaaaaaa!@contoso.com" };
        // The following regular expression should not actually be used to
        // validate an email address.
        string pattern = @"^[0-9A-Z]([-.\w]*[0-9A-Z])*$";
        string input;

        foreach (var address in addresses)
        {
            string mailBox = address.Substring(0, address.IndexOf("@"));
            int index = 0;
            for (int ctr = mailBox.Length - 1; ctr >= 0; ctr--)
            {
                index++;

                input = mailBox.Substring(ctr, index);
                sw = Stopwatch.StartNew();
                Match m = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
                sw.Stop();
                if (m.Success)
                    Console.WriteLine("{0,2}. Matched '{1,25}' in {2}",
                                      index, m.Value, sw.Elapsed);
                else
                    Console.WriteLine("{0,2}. Failed  '{1,25}' in {2}",
                                      index, input, sw.Elapsed);
            }
            Console.WriteLine();
        }
    }
}

// The example displays output similar to the following:
//     1. Matched '                        A' in 00:00:00.0007122
//     2. Matched '                       AA' in 00:00:00.0000282
//     3. Matched '                      AAA' in 00:00:00.0000042
//     4. Matched '                     AAAA' in 00:00:00.0000038
//     5. Matched '                    AAAAA' in 00:00:00.0000042
//     6. Matched '                   AAAAAA' in 00:00:00.0000042
//     7. Matched '                  AAAAAAA' in 00:00:00.0000042
//     8. Matched '                 AAAAAAAA' in 00:00:00.0000087
//     9. Matched '                AAAAAAAAA' in 00:00:00.0000045
//    10. Matched '               AAAAAAAAAA' in 00:00:00.0000045
//    11. Matched '              AAAAAAAAAAA' in 00:00:00.0000045
//
//     1. Failed  '                        !' in 00:00:00.0000447
//     2. Failed  '                       a!' in 00:00:00.0000071
//     3. Failed  '                      aa!' in 00:00:00.0000071
//     4. Failed  '                     aaa!' in 00:00:00.0000061
//     5. Failed  '                    aaaa!' in 00:00:00.0000081
//     6. Failed  '                   aaaaa!' in 00:00:00.0000126
//     7. Failed  '                  aaaaaa!' in 00:00:00.0000359
//     8. Failed  '                 aaaaaaa!' in 00:00:00.0000414
//     9. Failed  '                aaaaaaaa!' in 00:00:00.0000758
//    10. Failed  '               aaaaaaaaa!' in 00:00:00.0001462
//    11. Failed  '              aaaaaaaaaa!' in 00:00:00.0002885
//    12. Failed  '             Aaaaaaaaaaa!' in 00:00:00.0005780
//    13. Failed  '            AAaaaaaaaaaa!' in 00:00:00.0011628
//    14. Failed  '           AAAaaaaaaaaaa!' in 00:00:00.0022851
//    15. Failed  '          AAAAaaaaaaaaaa!' in 00:00:00.0045864
//    16. Failed  '         AAAAAaaaaaaaaaa!' in 00:00:00.0093168
//    17. Failed  '        AAAAAAaaaaaaaaaa!' in 00:00:00.0185993
//    18. Failed  '       AAAAAAAaaaaaaaaaa!' in 00:00:00.0366723
//    19. Failed  '      AAAAAAAAaaaaaaaaaa!' in 00:00:00.1370108
//    20. Failed  '     AAAAAAAAAaaaaaaaaaa!' in 00:00:00.1553966
//    21. Failed  '    AAAAAAAAAAaaaaaaaaaa!' in 00:00:00.3223372
// </Snippet1>
