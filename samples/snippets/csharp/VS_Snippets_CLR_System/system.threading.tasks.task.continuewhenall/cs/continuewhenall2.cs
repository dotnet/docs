// <Snippet2>
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string[] filenames = { "chapter1.txt", "chapter2.txt", 
                             "chapter3.txt", "chapter4.txt",
                             "chapter5.txt" };
      string pattern = @"\b\w+\b";
      var tasks = new List<Task>();  
      CancellationTokenSource source = new CancellationTokenSource();
      CancellationToken token = source.Token;
      int totalWords = 0;
        
      // Determine the number of words in each file.
      foreach (var filename in filenames)
         tasks.Add( Task.Factory.StartNew( fn => { token.ThrowIfCancellationRequested(); 

                                                   if (! File.Exists(fn.ToString())) {
                                                      source.Cancel();
                                                      token.ThrowIfCancellationRequested();
                                                   }
                                                   
                                                   StreamReader sr = new StreamReader(fn.ToString());
                                                   String content = sr.ReadToEnd();
                                                   sr.Close();
                                                   int words = Regex.Matches(content, pattern).Count;
                                                   Interlocked.Add(ref totalWords, words); 
                                                   Console.WriteLine("{0,-25} {1,6:N0} words", fn, words); }, 
                                           filename, token));

      var finalTask = Task.Factory.ContinueWhenAll(tasks.ToArray(), wordCountTasks => {
                                                    if (! token.IsCancellationRequested) 
                                                       Console.WriteLine("\n{0,-25} {1,6} total words\n", 
                                                                         String.Format("{0} files", wordCountTasks.Length), 
                                                                         totalWords); 
                                                   }, token); 
      try {                                                   
         finalTask.Wait();
      }
      catch (AggregateException ae) {
         foreach (Exception inner in ae.InnerExceptions)
            if (inner is TaskCanceledException)
               Console.WriteLine("\nFailure to determine total word count: a task was cancelled.");
            else
               Console.WriteLine("\nFailure caused by {0}", inner.GetType().Name);      
      }
      finally {
         source.Dispose();
      }
   }
}
// The example displays output like the following:
//       chapter2.txt               1,585 words
//       chapter1.txt               4,012 words
//       
//       Failure to determine total word count: a task was cancelled.
// </Snippet2>
