// <Snippet1>
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

public class ConsoleMonitor : IDisposable
{
   const int STD_INPUT_HANDLE = -10;
   const int STD_OUTPUT_HANDLE = -11;
   const int STD_ERROR_HANDLE = -12;

   [DllImport("kernel32.dll", SetLastError = true)]
   static extern IntPtr GetStdHandle(int nStdHandle); 

   [DllImport("kernel32.dll", SetLastError = true)]
   static extern bool WriteConsole(IntPtr hConsoleOutput, string lpBuffer,
          uint nNumberOfCharsToWrite, out uint lpNumberOfCharsWritten,
          IntPtr lpReserved);   

   [DllImport("kernel32.dll", SetLastError = true)]
   static extern bool CloseHandle(IntPtr handle); 
                    
   private bool disposed = false;
   private IntPtr handle;
   private Component component;
   
   public ConsoleMonitor()
   {
      handle = GetStdHandle(STD_OUTPUT_HANDLE);
      if (handle == IntPtr.Zero)
         throw new InvalidOperationException("A console handle is not available.");

      component = new Component();
      
      string output = "The ConsoleMonitor class constructor.\n";
      uint written = 0;
      WriteConsole(handle, output, (uint) output.Length, out written, IntPtr.Zero);
   }

   // The destructor calls Object.Finalize.
   ~ConsoleMonitor()
   {
      if (handle != IntPtr.Zero) {
         string output = "The ConsoleMonitor finalizer.\n";
         uint written = 0;
         WriteConsole(handle, output, (uint) output.Length, out written, IntPtr.Zero);
      }
      else {     
         Console.Error.WriteLine("Object finalization.");
      }
      // Call Dispose with disposing = false.
      Dispose(false);
   }

   public void Write()
   {
      string output = "The Write method.\n";
      uint written = 0;
      WriteConsole(handle, output, (uint) output.Length, out written, IntPtr.Zero);
   }

   public void Dispose()
   {
      string output = "The Dispose method.\n";
      uint written = 0;
      WriteConsole(handle, output, (uint) output.Length, out written, IntPtr.Zero);

      Dispose(true);
      GC.SuppressFinalize(this); 
   }

   private void Dispose(bool disposing)
   {
      string output = String.Format("The Dispose({0}) method.\n", disposing);
      uint written = 0;
      WriteConsole(handle, output, (uint) output.Length, out written, IntPtr.Zero);

      // Execute if resources have not already been disposed.
      if (! disposed) {
         // If the call is from Dispose, free managed resources.
         if (disposing) {
            Console.Error.WriteLine("Disposing of managed resources.");
            if (component != null)
               component.Dispose();
         }
         // Free unmanaged resources.
         output = "Disposing of unmanaged resources.";
         WriteConsole(handle, output, (uint) output.Length, out written, IntPtr.Zero);
         
         if (handle != IntPtr.Zero) {
            if (! CloseHandle(handle))
               Console.Error.WriteLine("Handle cannot be closed."); 
         }      
      }
      disposed = true;
   }
}

public class Example
{
   public static void Main()
   {
      Console.WriteLine("ConsoleMonitor instance....");
      ConsoleMonitor monitor = new ConsoleMonitor();
      monitor.Write();
      monitor.Dispose();
   }
}
// If the monitor.Dispose method is not called, the example displays the following output:
//       ConsoleMonitor instance....
//       The ConsoleMonitor class constructor.
//       The Write method.
//       The ConsoleMonitor finalizer.
//       The Dispose(False) method.
//       Disposing of unmanaged resources.
//       
// If the monitor.Dispose method is called, the example displays the following output:
//       ConsoleMonitor instance....
//       The ConsoleMonitor class constructor.
//       The Write method.
//       The Dispose method.
//       The Dispose(True) method.
//       Disposing of managed resources.
//       Disposing of unmanaged resources.
// </Snippet1>