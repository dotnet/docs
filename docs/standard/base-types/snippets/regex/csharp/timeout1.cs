// <Snippet12>
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class TimeoutExample
{
    public static void Main()
    {
        RegexUtilities util = new RegexUtilities();
        string title = "Doyle - The Hound of the Baskervilles.txt";
        try
        {
            var info = util.GetWordData(title);
            Console.WriteLine($"Words:               {info.Item1:N0}");
            Console.WriteLine($"Average Word Length: {info.Item2:N2} characters");
        }
        catch (IOException e)
        {
            Console.WriteLine($"IOException reading file '{title}'");
            Console.WriteLine(e.Message);
        }
        catch (RegexMatchTimeoutException e)
        {
            Console.WriteLine($"The operation timed out after {e.MatchTimeout.TotalMilliseconds:N0} milliseconds");
        }
    }
}

public class RegexUtilities
{
    public Tuple<int, double> GetWordData(string filename)
    {
        const int MAX_TIMEOUT = 1000;   // Maximum timeout interval in milliseconds.
        const int INCREMENT = 350;      // Milliseconds increment of timeout.

        List<string> exclusions = new List<string>(new string[] { "a", "an", "the" });
        int[] wordLengths = new int[29];        // Allocate an array of more than ample size.
        string input = null;
        StreamReader sr = null;
        try
        {
            sr = new StreamReader(filename);
            input = sr.ReadToEnd();
        }
        catch (FileNotFoundException e)
        {
            string msg = String.Format("Unable to find the file '{0}'", filename);
            throw new IOException(msg, e);
        }
        catch (IOException e)
        {
            throw new IOException(e.Message, e);
        }
        finally
        {
            if (sr != null) sr.Close();
        }

        int timeoutInterval = INCREMENT;
        bool init = false;
        Regex rgx = null;
        Match m = null;
        int indexPos = 0;
        do
        {
            try
            {
                if (!init)
                {
                    rgx = new Regex(@"\b\w+\b", RegexOptions.None,
                                    TimeSpan.FromMilliseconds(timeoutInterval));
                    m = rgx.Match(input, indexPos);
                    init = true;
                }
                else
                {
                    m = m.NextMatch();
                }
                if (m.Success)
                {
                    if (!exclusions.Contains(m.Value.ToLower()))
                        wordLengths[m.Value.Length]++;

                    indexPos += m.Length + 1;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                if (e.MatchTimeout.TotalMilliseconds < MAX_TIMEOUT)
                {
                    timeoutInterval += INCREMENT;
                    init = false;
                }
                else
                {
                    // Rethrow the exception.
                    throw;
                }
            }
        } while (m.Success);

        // If regex completed successfully, calculate number of words and average length.
        int nWords = 0;
        long totalLength = 0;

        for (int ctr = wordLengths.GetLowerBound(0); ctr <= wordLengths.GetUpperBound(0); ctr++)
        {
            nWords += wordLengths[ctr];
            totalLength += ctr * wordLengths[ctr];
        }
        return new Tuple<int, double>(nWords, totalLength / nWords);
    }
}
// </Snippet12>
