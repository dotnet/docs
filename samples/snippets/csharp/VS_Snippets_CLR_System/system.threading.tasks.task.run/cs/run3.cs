// <Snippet2>
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      string pattern = @"\p{P}*\s+";
      string[] titles = { "Sister Carrie", "The Financier" };
      Task<int>[] tasks = new Task<int>[titles.Length];

      for (int ctr = 0; ctr < titles.Length; ctr++) {
         string s = titles[ctr];
         tasks[ctr] = Task.Run( () => {
                                   // Number of words.
                                   int nWords = 0;
                                   // Create filename from title.
                                   string fn = s + ".txt";
                                   if (File.Exists(fn)) {
                                      StreamReader sr = new StreamReader(fn);
                                      string input = sr.ReadToEndAsync().Result;
                                      nWords = Regex.Matches(input, pattern).Count;
                                   }
                                   return nWords;
                                } );
      }
      Task.WaitAll(tasks);

      Console.WriteLine("Word Counts:\n");
      for (int ctr = 0; ctr < titles.Length; ctr++)
         Console.WriteLine("{0}: {1,10:N0} words", titles[ctr], tasks[ctr].Result);
   }
}
// The example displays the following output:
//       Sister Carrie:    159,374 words
//       The Financier:    196,362 words
// </Snippet2>
