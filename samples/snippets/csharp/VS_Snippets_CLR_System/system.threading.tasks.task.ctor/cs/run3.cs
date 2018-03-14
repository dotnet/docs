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
         tasks[ctr] = new Task<int>( () => {
                                   // Number of words.
                                   int nWords = 0;
                                   // Create filename from title.
                                   string fn = s + ".txt";

                                   StreamReader sr = new StreamReader(fn);
                                   string input = sr.ReadToEndAsync().Result;
                                   sr.Close();
                                   nWords = Regex.Matches(input, pattern).Count;
                                   return nWords;
                                } );
      }
      // Ensure files exist before launching tasks.
      bool allExist = true;
      foreach (var title in titles) {
         string fn = title + ".txt";
         if (! File.Exists(fn)) {
            allExist = false;
            Console.WriteLine("Cannot find '{0}'", fn);
            break;
         }   
      }
      // Launch tasks 
      if (allExist) {
         foreach (var t in tasks)
            t.Start();
      
        Task.WaitAll(tasks);
  
        Console.WriteLine("Word Counts:\n");
        for (int ctr = 0; ctr < titles.Length; ctr++)
           Console.WriteLine("{0}: {1,10:N0} words", titles[ctr], tasks[ctr].Result);
      }   
   }
}
// The example displays the following output:
//       Sister Carrie:    159,374 words
//       The Financier:    196,362 words
// </Snippet2>
