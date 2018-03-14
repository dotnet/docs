// <Snippet1>
using System;
using System.IO;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      Task<String> task = ReadCharacters(@".\CallOfTheWild.txt");
      String text = task.Result;
      
      int nVowels = 0;
      int nNonWhiteSpace = 0;
      Object obj = new Object();

      ParallelLoopResult result = Parallel.ForEach(text, 
                                                   (ch) => {
                                                      Char uCh = Char.ToUpper(ch);
                                                      if ("AEIOUY".IndexOf(uCh) >= 0) {
                                                         lock (obj) {
                                                            nVowels++;
                                                         }
                                                      }
                                                      if (! Char.IsWhiteSpace(uCh)) {
                                                         lock (obj) {
                                                            nNonWhiteSpace++;
                                                         }   
                                                      }
                                                   } );
      Console.WriteLine("Total characters:      {0,10:N0}", text.Length);
      Console.WriteLine("Total vowels:          {0,10:N0}", nVowels);
      Console.WriteLine("Total non-whitespace:  {0,10:N0}", nNonWhiteSpace);
   }

   private static async Task<String> ReadCharacters(String fn)
   {
      String text;
      using (StreamReader sr = new StreamReader(fn)) {
         text = await sr.ReadToEndAsync();
      }
      return text;
   }
}
// The example displays output like the following:
//       Total characters:         198,548
//       Total vowels:              58,421
//       Total non-whitespace:     159,461
// </Snippet1>
