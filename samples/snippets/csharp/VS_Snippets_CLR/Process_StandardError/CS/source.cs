// System.Diagnostics.Process.StandardError
/*
The following example demonstrates property 'StandardError' of
'Process' class.

It starts a process(net.exe) which writes an error message on to the standard
error when a bad network path is given.This program gets 'StandardError' of
net.exe process and reads output from its stream reader.*/

using System;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;

namespace Process_StandardError
{
   class Class1
   {
      static void Main(string[] args)
      {
         if (args.Length <1) 
         {
            Console.WriteLine("\nThis requires a machine name as a parameter which is not on the network.");
            Console.WriteLine("\nUsage:");
            Console.WriteLine("Process_StandardError <\\\\machine name>");
         }
         else
         {
            GetStandardError(args);
         }
         return;
      }

      public static void GetStandardError(string[] args)
      {
         try
         {
// <Snippet1>
            Process myProcess = new Process();
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("net ","use "+ args[0]);

            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardError = true;
            myProcess.StartInfo = myProcessStartInfo;
            myProcess.Start();

            StreamReader myStreamReader = myProcess.StandardError;
            // Read the standard error of net.exe and write it on to console.
            Console.WriteLine( myStreamReader.ReadLine());
            myProcess.Close();
// </Snippet1>
         }
         catch( Win32Exception e)
         {
            Console.WriteLine(e.Message);
         }
         catch( SystemException e)
         {
            Console.WriteLine(e.Message);
         }
         catch( Exception e)
         {
            Console.WriteLine(e.Message);
         }
      }
   }
}