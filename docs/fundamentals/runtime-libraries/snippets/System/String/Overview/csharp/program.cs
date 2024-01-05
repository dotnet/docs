using System;

public class Example16
{
   public static void Main()
   {
      InstantiateByAssignment();
      Console.WriteLine("-----");
      CallConstructors();
      Console.WriteLine("-----");
      Concatenate();
      Console.WriteLine("-----");
      ExtractString();
      Console.WriteLine("-----");
      Formatting();
   }

   private static void InstantiateByAssignment()
   {
      // <Snippet1>
      string string1 = "This is a string created by assignment.";
      Console.WriteLine(string1);
      string string2a = "The path is C:\\PublicDocuments\\Report1.doc";
      Console.WriteLine(string2a);
      string string2b = @"The path is C:\PublicDocuments\Report1.doc";
      Console.WriteLine(string2b);
      // The example displays the following output:
      //       This is a string created by assignment.
      //       The path is C:\PublicDocuments\Report1.doc
      //       The path is C:\PublicDocuments\Report1.doc      
      // </Snippet1>
   }

   private static void CallConstructors()
   {
      // <Snippet2>
      char[] chars = { 'w', 'o', 'r', 'd' };
      sbyte[] bytes = { 0x41, 0x42, 0x43, 0x44, 0x45, 0x00 };

      // Create a string from a character array.
      string string1 = new string(chars);
      Console.WriteLine(string1);

      // Create a string that consists of a character repeated 20 times.
      string string2 = new string('c', 20);
      Console.WriteLine(string2);

      string stringFromBytes = null;
      string stringFromChars = null;
      unsafe
      {
         fixed (sbyte* pbytes = bytes)
         {
            // Create a string from a pointer to a signed byte array.
            stringFromBytes = new string(pbytes);
         }
         fixed (char* pchars = chars)
         {
            // Create a string from a pointer to a character array.
            stringFromChars = new string(pchars);
         }
      }
      Console.WriteLine(stringFromBytes);
      Console.WriteLine(stringFromChars);
      // The example displays the following output:
      //       word
      //       cccccccccccccccccccc
      //       ABCDE
      //       word  
      // </Snippet2> 
   }

   private static void Concatenate()
   {
      // <Snippet3>
      string string1 = "Today is " + DateTime.Now.ToString("D") + ".";
      Console.WriteLine(string1);

      string string2 = "This is one sentence. " + "This is a second. ";
      string2 += "This is a third sentence.";
      Console.WriteLine(string2);
      // The example displays output like the following:
      //    Today is Tuesday, July 06, 2011.
      //    This is one sentence. This is a second. This is a third sentence.
      // </Snippet3>
   }

   private static void ExtractString()
   {
      // <Snippet4>
      string sentence = "This sentence has five words.";
      // Extract the second word.
      int startPosition = sentence.IndexOf(" ") + 1;
      string word2 = sentence.Substring(startPosition,
                                        sentence.IndexOf(" ", startPosition) - startPosition);
      Console.WriteLine("Second word: " + word2);
      // The example displays the following output:
      //       Second word: sentence
      // </Snippet4>
   }

   private static void Formatting()
   {
      // <Snippet5>
      DateTime dateAndTime = new DateTime(2011, 7, 6, 7, 32, 0);
      double temperature = 68.3;
      string result = String.Format("At {0:t} on {0:D}, the temperature was {1:F1} degrees Fahrenheit.",
                                    dateAndTime, temperature);
      Console.WriteLine(result);
      // The example displays the following output:
      //       At 7:32 AM on Wednesday, July 06, 2011, the temperature was 68.3 degrees Fahrenheit.      
      // </Snippet5>
   }
}
