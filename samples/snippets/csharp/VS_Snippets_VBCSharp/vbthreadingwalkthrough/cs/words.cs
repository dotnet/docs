using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// <snippet2>
public class Words
{
    // Object to store the current state, for passing to the caller.
    public class CurrentState
    {
        public int LinesCounted;
        public int WordsMatched;
    }

    public string SourceFile;
    public string CompareString;
    private int WordCount;
    private int LinesCounted;

    public void CountWords(
        System.ComponentModel.BackgroundWorker worker,
        System.ComponentModel.DoWorkEventArgs e)
    {
        // Initialize the variables.
        CurrentState state = new CurrentState();
        string line = "";
        int elapsedTime = 20;
        DateTime lastReportDateTime = DateTime.Now;

        if (CompareString == null ||
            CompareString == System.String.Empty)
        {
            throw new Exception("CompareString not specified.");
        }

        // Open a new stream.
        using (System.IO.StreamReader myStream = new System.IO.StreamReader(SourceFile))
        {
            // Process lines while there are lines remaining in the file.
            while (!myStream.EndOfStream)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    line = myStream.ReadLine();
                    WordCount += CountInString(line, CompareString);
                    LinesCounted += 1;

                    // Raise an event so the form can monitor progress.
                    int compare = DateTime.Compare(
                        DateTime.Now, lastReportDateTime.AddMilliseconds(elapsedTime));
                    if (compare > 0)
                    {
                        state.LinesCounted = LinesCounted;
                        state.WordsMatched = WordCount;
                        worker.ReportProgress(0, state);
                        lastReportDateTime = DateTime.Now;
                    }
                }
                // Uncomment for testing.
                //System.Threading.Thread.Sleep(5);
            }

            // Report the final count values.
            state.LinesCounted = LinesCounted;
            state.WordsMatched = WordCount;
            worker.ReportProgress(0, state);
        }
    }


    private int CountInString(
        string SourceString,
        string CompareString)
    {
        // This function counts the number of times
        // a word is found in a line.
        if (SourceString == null)
        {
            return 0;
        }

        string EscapedCompareString =
            System.Text.RegularExpressions.Regex.Escape(CompareString);

        System.Text.RegularExpressions.Regex regex;
        regex = new System.Text.RegularExpressions.Regex( 
            // To count all occurrences of the string, even within words, remove
            // both instances of @"\b" from the following line.
            @"\b" + EscapedCompareString + @"\b",
            System.Text.RegularExpressions.RegexOptions.IgnoreCase);

        System.Text.RegularExpressions.MatchCollection matches;
        matches = regex.Matches(SourceString);
        return matches.Count;
    }

}
// </snippet2>
