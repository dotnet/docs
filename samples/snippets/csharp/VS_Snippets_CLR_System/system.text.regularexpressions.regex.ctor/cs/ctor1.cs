// <Snippet1>
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading;

public class Example
{
    const int MaxTimeoutInSeconds = 3;

    public static void Main()
    {
        string pattern = @"(a+)+$";    // DO NOT REUSE THIS PATTERN.
        Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));
        Stopwatch? sw = null;

        string[] inputs = { "aa", "aaaa>",
                         "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                         "aaaaaaaaaaaaaaaaaaaaaa>",
                         "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa>" };

        foreach (var inputValue in inputs)
        {
            Console.WriteLine("Processing {0}", inputValue);
            bool timedOut = false;
            do
            {
                try
                {
                    sw = Stopwatch.StartNew();
                    // Display the result.
                    if (rgx.IsMatch(inputValue))
                    {
                        sw.Stop();
                        Console.WriteLine(@"Valid: '{0}' ({1:ss\.fffffff} seconds)",
                                          inputValue, sw.Elapsed);
                    }
                    else
                    {
                        sw.Stop();
                        Console.WriteLine(@"'{0}' is not a valid string. ({1:ss\.fffff} seconds)",
                                          inputValue, sw.Elapsed);
                    }
                }
                catch (RegexMatchTimeoutException e)
                {
                    sw.Stop();
                    // Display the elapsed time until the exception.
                    Console.WriteLine(@"Timeout with '{0}' after {1:ss\.fffff}",
                                      inputValue, sw.Elapsed);
                    Thread.Sleep(1500);       // Pause for 1.5 seconds.

                    // Increase the timeout interval and retry.
                    TimeSpan timeout = e.MatchTimeout.Add(TimeSpan.FromSeconds(1));
                    if (timeout.TotalSeconds > MaxTimeoutInSeconds)
                    {
                        Console.WriteLine("Maximum timeout interval of {0} seconds exceeded.",
                                          MaxTimeoutInSeconds);
                        timedOut = false;
                    }
                    else
                    {
                        Console.WriteLine("Changing the timeout interval to {0}",
                                          timeout);
                        rgx = new Regex(pattern, RegexOptions.IgnoreCase, timeout);
                        timedOut = true;
                    }
                }
            } while (timedOut);
            Console.WriteLine();
        }
    }
}
// The example displays output like the following :
//    Processing aa
//    Valid: 'aa' (00.0000779 seconds)
//
//    Processing aaaa>
//    'aaaa>' is not a valid string. (00.00005 seconds)
//
//    Processing aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
//    Valid: 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa' (00.0000043 seconds)
//
//    Processing aaaaaaaaaaaaaaaaaaaaaa>
//    Timeout with 'aaaaaaaaaaaaaaaaaaaaaa>' after 01.00469
//    Changing the timeout interval to 00:00:02
//    Timeout with 'aaaaaaaaaaaaaaaaaaaaaa>' after 02.01202
//    Changing the timeout interval to 00:00:03
//    Timeout with 'aaaaaaaaaaaaaaaaaaaaaa>' after 03.01043
//    Maximum timeout interval of 3 seconds exceeded.
//
//    Processing aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa>
//    Timeout with 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa>' after 03.01018
//    Maximum timeout interval of 3 seconds exceeded.
// </Snippet1>
