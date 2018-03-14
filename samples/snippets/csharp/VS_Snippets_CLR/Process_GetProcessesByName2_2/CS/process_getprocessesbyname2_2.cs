// System.Diagnostics.Process.GetProcessesByName(String, String)
// System.Diagnostics.Process.MachineName

/* 
   The following program demonstrates the method 'GetProcessesByName(String, String)'
   and property 'MachineName' of class 'Process'.
   It reads the remote computer name from commandline and gets all the notepad 
   processes by name on remote computer and displays its properties to console.
*/
// <Snippet1>
// <Snippet2>
using System;
using System.Diagnostics;

class GetProcessesByNameClass
{
   public static void Main(string[] args)
   {
      try
      {

         Console.Write("Create notepad processes on remote computer \n");
         Console.Write("Enter remote computer name : ");
         string remoteMachineName = Console.ReadLine();
         // Get all notepad processess into Process array.
         Process[] myProcesses = Process.GetProcessesByName("notepad",remoteMachineName);
         if(myProcesses.Length == 0)
            Console.WriteLine("Could not find notepad processes on remote computer.");
         foreach(Process myProcess in myProcesses)
         {
            Console.Write("Process Name : " + myProcess.ProcessName + "  Process ID : "
               + myProcess.Id + "  MachineName : " + myProcess.MachineName + "\n");
         }

      }
      catch(SystemException e)
      {
         Console.Write("Caught Exception .... : " + e.Message);
      }
      catch(Exception e)
      {
         Console.Write("Caught Exception .... : " + e.Message);
      }
   }
}
// </Snippet1> 
// </Snippet2> 