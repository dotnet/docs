// System.Diagnostics.Process.StandardInput
//
//
// The following example illustrates how to redirect the StandardInput
// stream of a process.  The example starts the sort command with
// redirected input.  It then prompts the user for text, and passes 
// that to the sort command by means of the redirected input stream.
// The sort command results are displayed to the user on the console.

// <Snippet1>

using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace Process_StandardInput_Sample
{
   class StandardInputTest
   {
      static void Main()
      {
         Console.WriteLine("Ready to sort one or more text lines...");

         // Start the Sort.exe process with redirected input.
         // Use the sort command to sort the input text.
         Process myProcess = new Process();
         
         myProcess.StartInfo.FileName = "Sort.exe";
         myProcess.StartInfo.UseShellExecute = false;
         myProcess.StartInfo.RedirectStandardInput = true;

         myProcess.Start();

         StreamWriter myStreamWriter = myProcess.StandardInput;

         // Prompt the user for input text lines to sort. 
         // Write each line to the StandardInput stream of
         // the sort command.
         String inputText;
         int numLines = 0;
         do 
         {
            Console.WriteLine("Enter a line of text (or press the Enter key to stop):");
            
            inputText = Console.ReadLine();
            if (inputText.Length > 0)
            {
               numLines ++;
               myStreamWriter.WriteLine(inputText);
            }
         } while (inputText.Length != 0);


         // Write a report header to the console.
         if (numLines > 0)
         {
            Console.WriteLine(" {0} sorted text line(s) ", numLines);
            Console.WriteLine("------------------------");
         }
         else 
         {
            Console.WriteLine(" No input was sorted");
         }

         // End the input stream to the sort command.
         // When the stream closes, the sort command
         // writes the sorted text lines to the 
         // console.
         myStreamWriter.Close();


         // Wait for the sort process to write the sorted text lines.
         myProcess.WaitForExit();
         myProcess.Close();
       
      }
   }
}
// </Snippet1>
