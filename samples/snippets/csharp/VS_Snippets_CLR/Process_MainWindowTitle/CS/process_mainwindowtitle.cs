// System.Diagnostics.Process.MainWindowTitle

/* The following program demonstrates the property 'MainWindowTitle' of class 'Process'.
   It creates a new process notepad on local computer and displays its caption to console.
*/
// <Snippet1>
using System;
using System.Diagnostics;

class MainWindowTitleClass
{
   public static void Main()
   {
      try
      {

         // Create an instance of process component.
         Process myProcess = new Process();
         // Create an instance of 'myProcessStartInfo'.
         ProcessStartInfo myProcessStartInfo = new ProcessStartInfo();
         myProcessStartInfo.FileName = "notepad";
         myProcess.StartInfo = myProcessStartInfo;
         // Start process.
         myProcess.Start();
         // Allow the process to finish starting.
         myProcess.WaitForInputIdle();
         Console.Write("Main window Title : " + myProcess.MainWindowTitle);

         myProcess.CloseMainWindow();
         myProcess.Close();
      }
      catch(Exception e)
      {
         Console.Write(" Message : " + e.Message);
      }
    
   }
}

// </Snippet1>