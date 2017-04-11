// System.Diagnostics.ProcessModule.BaseAddress

/* The following program demonstrates the use of 'BaseAddress' property of 
   'ProcessModule' class. It creates a notepad, gets the 'MainModule' and 
   all other modules of the process 'notepad.exe', displays 'BaseAddress'
   for all the modules and the main module.
*/
using System;
using System.Diagnostics;

class MyProcessModuleClass
{
   public static void Main()
   {
      try
      {
// <Snippet1>
         Process myProcess = new Process();
         // Get the process start information of notepad.
         ProcessStartInfo  myProcessStartInfo = new ProcessStartInfo("notepad.exe");
         // Assign 'StartInfo' of notepad to 'StartInfo' of 'myProcess' object.
         myProcess.StartInfo = myProcessStartInfo;
         // Create a notepad.
         myProcess.Start();      
         System.Threading.Thread.Sleep(1000);
         ProcessModule myProcessModule;
         // Get all the modules associated with 'myProcess'.
         ProcessModuleCollection myProcessModuleCollection = myProcess.Modules;
         Console.WriteLine("Base addresses of the modules associated "
            +"with 'notepad' are:");
         // Display the 'BaseAddress' of each of the modules.
         for( int i = 0; i < myProcessModuleCollection.Count; i++)
         {
            myProcessModule = myProcessModuleCollection[i];
            Console.WriteLine(myProcessModule.ModuleName+" : "
               +myProcessModule.BaseAddress);
         }
         // Get the main module associated with 'myProcess'.
         myProcessModule = myProcess.MainModule;
         // Display the 'BaseAddress' of the main module.
         Console.WriteLine("The process's main module's base address is: "
            +myProcessModule.BaseAddress);
          myProcess.CloseMainWindow();
// </Snippet1>
      } 
      catch(Exception e)
      {
         Console.WriteLine("Exception : "+ e.Message);
      }
   }
}

