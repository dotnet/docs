// <snippet1> 
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

// Demonstrates how to create a basic dataflow pipeline.
// This program downloads the book "The Iliad of Homer" by Homer from the Web 
// and finds all reversed words that appear in that book.
class DataflowReversedWords
{
   static void Main(string[] args)
   {
      // <snippet3>
      //
      // Create the members of the pipeline.
      // 

      // Downloads the requested resource as a string.
      var downloadString = new TransformBlock<string, string>(uri =>
      {
         Console.WriteLine("Downloading '{0}'...", uri);

         return new WebClient().DownloadString(uri);
      });

      // Separates the specified text into an array of words.
      var createWordList = new TransformBlock<string, string[]>(text =>
      {
         Console.WriteLine("Creating word list...");

         // Remove common punctuation by replacing all non-letter characters 
         // with a space character to.
         char[] tokens = text.ToArray();
         for (int i = 0; i < tokens.Length; i++)
         {
            if (!char.IsLetter(tokens[i]))
               tokens[i] = ' ';
         }
         text = new string(tokens);

         // Separate the text into an array of words.
         return text.Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);
      });

      // Removes short words, orders the resulting words alphabetically, 
      // and then remove duplicates.
      var filterWordList = new TransformBlock<string[], string[]>(words =>
      {
         Console.WriteLine("Filtering word list...");

         return words.Where(word => word.Length > 3).OrderBy(word => word)
            .Distinct().ToArray();
      });

      // Finds all words in the specified collection whose reverse also 
      // exists in the collection.
      var findReversedWords = new TransformManyBlock<string[], string>(words =>
      {
         Console.WriteLine("Finding reversed words...");

         // Holds reversed words.
         var reversedWords = new ConcurrentQueue<string>();

         // Add each word in the original collection to the result whose 
         // reversed word also exists in the collection.
         Parallel.ForEach(words, word =>
         {
            // Reverse the work.
            string reverse = new string(word.Reverse().ToArray());

            // Enqueue the word if the reversed version also exists
            // in the collection.
            if (Array.BinarySearch<string>(words, reverse) >= 0 &&
                word != reverse)
            {
               reversedWords.Enqueue(word);
            }
         });

         return reversedWords;
      });

      // Prints the provided reversed words to the console.    
      var printReversedWords = new ActionBlock<string>(reversedWord =>
      {
         Console.WriteLine("Found reversed words {0}/{1}",
            reversedWord, new string(reversedWord.Reverse().ToArray()));
      });
      // </snippet3>

      // <snippet4>
      //
      // Connect the dataflow blocks to form a pipeline.
      //

      downloadString.LinkTo(createWordList);
      createWordList.LinkTo(filterWordList);
      filterWordList.LinkTo(findReversedWords);
      findReversedWords.LinkTo(printReversedWords);
      // </snippet4>

      // <snippet5>
      //
      // For each completion task in the pipeline, create a continuation task
      // that marks the next block in the pipeline as completed.
      // A completed dataflow block processes any buffered elements, but does
      // not accept new elements.
      //

      downloadString.Completion.ContinueWith(t =>
      {
         if (t.IsFaulted) ((IDataflowBlock)createWordList).Fault(t.Exception);
         else createWordList.Complete();
      });
      createWordList.Completion.ContinueWith(t =>
      {
         if (t.IsFaulted) ((IDataflowBlock)filterWordList).Fault(t.Exception);
         else filterWordList.Complete();
      });
      filterWordList.Completion.ContinueWith(t =>
      {
         if (t.IsFaulted) ((IDataflowBlock)findReversedWords).Fault(t.Exception);
         else findReversedWords.Complete();
      });
      findReversedWords.Completion.ContinueWith(t =>
      {
         if (t.IsFaulted) ((IDataflowBlock)printReversedWords).Fault(t.Exception);
         else printReversedWords.Complete();
      });
      // </snippet5>

      // <snippet6>
      // Process "The Iliad of Homer" by Homer.
      downloadString.Post("http://www.gutenberg.org/files/6130/6130-0.txt");
      // </snippet6>

      // <snippet7>
      // Mark the head of the pipeline as complete. The continuation tasks 
      // propagate completion through the pipeline as each part of the 
      // pipeline finishes.
      downloadString.Complete();
      // </snippet7>

      // <snippet8>
      // Wait for the last block in the pipeline to process all messages.
      printReversedWords.Completion.Wait();
      // </snippet8>
   }
}
/* Sample output:
   Downloading 'http://www.gutenberg.org/files/6130/6130-0.txt'...
   Creating word list...
   Filtering word list...
   Finding reversed words...
   Found reversed words doom/mood
   Found reversed words draw/ward
   Found reversed words aera/area
   Found reversed words seat/taes
   Found reversed words live/evil
   Found reversed words port/trop
   Found reversed words sleek/keels
   Found reversed words area/aera
   Found reversed words tops/spot
   Found reversed words evil/live
   Found reversed words mood/doom
   Found reversed words speed/deeps
   Found reversed words moor/room
   Found reversed words trop/port
   Found reversed words spot/tops
   Found reversed words spots/stops
   Found reversed words stops/spots
   Found reversed words reed/deer
   Found reversed words keels/sleek
   Found reversed words deeps/speed
   Found reversed words deer/reed
   Found reversed words taes/seat
   Found reversed words room/moor
   Found reversed words ward/draw
*/
// </snippet1> 

/*
// <snippet2> 
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

// Demonstrates how to create a basic dataflow pipeline.
// This program downloads the book "The Iliad of Homer" by Homer from the Web 
// and finds all reversed words that appear in that book.
class Program
{
   static void Main(string[] args)
   {
   }
}
// </snippet2> 
*/