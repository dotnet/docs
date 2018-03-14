// System.Diagnostics.ProcessModule

/* The following program demonstrates the use of 'ProcessModule' class. 
   It creates a notepad, gets the 'MainModule' and all other modules of 
   the process 'notepad.exe', displays some of the properties of each modules.
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
         Console.WriteLine("Properties of the modules  associated "
            +"with 'notepad' are:");
         // Display the properties of each of the modules.
         for( int i=0;i<myProcessModuleCollection.Count;i++)
         {
            myProcessModule = myProcessModuleCollection[i];
            Console.WriteLine("The moduleName is "
               +myProcessModule.ModuleName);         
            Console.WriteLine("The " +myProcessModule.ModuleName + "'s base address is: "
               +myProcessModule.BaseAddress);
            Console.WriteLine("The " +myProcessModule.ModuleName + "'s Entry point address is: "
               +myProcessModule.EntryPointAddress);
            Console.WriteLine("The " +myProcessModule.ModuleName + "'s File name is: "
               +myProcessModule.FileName);
         }
         // Get the main module associated with 'myProcess'.
         myProcessModule = myProcess.MainModule;
         // Display the properties of the main module.
         Console.WriteLine("The process's main moduleName is:  "
            +myProcessModule.ModuleName);     
         Console.WriteLine("The process's main module's base address is: "
            +myProcessModule.BaseAddress);
         Console.WriteLine("The process's main module's Entry point address is: "
            +myProcessModule.EntryPointAddress);
         Console.WriteLine("The process's main module's File name is: "
            +myProcessModule.FileName);
         myProcess.CloseMainWindow();
// </Snippet1>
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception : "+ e.Message);
      }
   }
}

