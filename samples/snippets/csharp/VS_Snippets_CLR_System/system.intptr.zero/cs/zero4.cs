// <Snippet2>
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

public class Example
{
   private const uint GENERIC_READ = 0x80000000;
   private const uint OPEN_EXISTING = 3; 
   private const uint FILE_ATTRIBUTE_NORMAL = 128;
   private const uint FILE_FLAG_OVERLAPPED = 0x40000000;

   [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
   private static extern Microsoft.Win32.SafeHandles.SafeFileHandle CreateFile(
            string lpFileName, System.UInt32 dwDesiredAccess, System.UInt32 dwShareMode, 
            IntPtr pSecurityAttributes, System.UInt32 dwCreationDisposition, 
            System.UInt32 dwFlagsAndAttributes, IntPtr hTemplateFile);

   public static void Main()
   {
      SafeFileHandle hnd = CreateFile("CallOfTheWild.txt", GENERIC_READ, 0, 
                                      IntPtr.Zero, OPEN_EXISTING,
                                      FILE_ATTRIBUTE_NORMAL | FILE_FLAG_OVERLAPPED, 
                                      IntPtr.Zero);
      if (hnd.IsInvalid) {
            Exception ex = Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
            Console.WriteLine("Attempt to open file failed:");
            Console.WriteLine("  {0}", ex.Message);
            return;           
      }                        
      else {
         Console.WriteLine("File successfully opened.");
         hnd.Close();     
      }
   }
}
// If the file cannot be found, the example displays the following output:
//    Attempt to open file failed:
//      The system cannot find the file specified. (Exception from HRESULT: 0x80070002)
// </Snippet2>