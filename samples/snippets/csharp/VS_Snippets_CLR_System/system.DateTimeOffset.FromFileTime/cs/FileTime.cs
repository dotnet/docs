// <Snippet1>
using System;
using System.IO;
using System.Runtime.InteropServices;

public struct FileTime
{
   public uint dwLowDateTime;
   public uint dwHighDateTime;

   public static implicit operator long(FileTime fileTime)
   {
      long returnedLong;
      // Convert 4 high-order bytes to a byte array
      byte[] highBytes = BitConverter.GetBytes(fileTime.dwHighDateTime);
      // Resize the array to 8 bytes (for a Long)
      Array.Resize(ref highBytes, 8); 

      // Assign high-order bytes to first 4 bytes of Long
      returnedLong = BitConverter.ToInt64(highBytes, 0); 
      // Shift high-order bytes into position
      returnedLong = returnedLong << 32;
      // Or with low-order bytes
      returnedLong = returnedLong | fileTime.dwLowDateTime;
      // Return long 
      return returnedLong;
   }
}

public class FileTimes
{
   private const int OPEN_EXISTING = 3;
   private const int INVALID_HANDLE_VALUE = -1;
      
   [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
   private static extern int CreateFile(string lpFileName, 
                                       int dwDesiredAccess, 
                                       int dwShareMode, 
                                       int lpSecurityAttributes, 
                                       int dwCreationDisposition, 
                                       int dwFlagsAndAttributes, 
                                       int hTemplateFile);

   [DllImport("Kernel32.dll")]
   private static extern bool GetFileTime(int hFile, 
                                          out FileTime lpCreationTime, 
                                          out FileTime lpLastAccessTime, 
                                          out FileTime lpLastWriteTime);

   [DllImport("Kernel32.dll")]
   private static extern bool CloseHandle(int hFile); 

   public static void Main()
   {
      // Open file %windir%\write.exe
      string winDir = Environment.SystemDirectory; 
      if (! (winDir.EndsWith(Path.DirectorySeparatorChar.ToString())))
         winDir += Path.DirectorySeparatorChar; 
      winDir += "write.exe";

      // Get file time using Windows API
      //
      // Open file
      int hFile = CreateFile(winDir, 0, 0, 0, OPEN_EXISTING, 0, 0);
      if (hFile == INVALID_HANDLE_VALUE)
      {
         Console.WriteLine("Unable to access {0}.", winDir);
      }   
      else
      {
         FileTime creationTime, accessTime, writeTime;
         if (GetFileTime(hFile, out creationTime, out accessTime, out writeTime)) 
         {
            CloseHandle(hFile);
            long fileCreationTime = (long) creationTime;
            long fileAccessTime = accessTime;
            long fileWriteTime = (long) writeTime;

            Console.WriteLine("File {0} Retrieved Using the Windows API:", winDir);
            Console.WriteLine("   Created:     {0:d}", DateTimeOffset.FromFileTime(fileCreationTime).ToString());
            Console.WriteLine("   Last Access: {0:d}", DateTimeOffset.FromFileTime(fileAccessTime).ToString());
            Console.WriteLine("   Last Write:  {0:d}", DateTimeOffset.FromFileTime(fileWriteTime).ToString());
            Console.WriteLine();
         }   
      }
      
      // Get date and time, convert to file time, then convert back
      FileInfo fileInfo = new FileInfo(winDir);
      DateTimeOffset infoCreationTime, infoAccessTime, infoWriteTime;
      long ftCreationTime, ftAccessTime, ftWriteTime;
      
      // Get dates and times of file creation, last access, and last write
      infoCreationTime = fileInfo.CreationTime;
      infoAccessTime = fileInfo.LastAccessTime;
      infoWriteTime = fileInfo.LastWriteTime;
      // Convert values to file times
      ftCreationTime = infoCreationTime.ToFileTime();
      ftAccessTime = infoAccessTime.ToFileTime();
      ftWriteTime = infoWriteTime.ToFileTime();
      
      // Convert file times back to DateTimeOffset values
      Console.WriteLine("File {0} Retrieved Using a FileInfo Object:", winDir);
      Console.WriteLine("   Created:     {0:d}", DateTimeOffset.FromFileTime(ftCreationTime).ToString());
      Console.WriteLine("   Last Access: {0:d}", DateTimeOffset.FromFileTime(ftAccessTime).ToString());
      Console.WriteLine("   Last Write:  {0:d}", DateTimeOffset.FromFileTime(ftWriteTime).ToString()); 
   }
}
// The example produces the following output:
//    File C:\WINDOWS\system32\write.exe Retrieved Using the Windows API:
//       Created:     10/13/2005 5:26:59 PM -07:00
//       Last Access: 3/20/2007 2:07:00 AM -07:00
//       Last Write:  8/4/2004 5:00:00 AM -07:00
//    
//    File C:\WINDOWS\system32\write.exe Retrieved Using a FileInfo Object:
//       Created:     10/13/2005 5:26:59 PM -07:00
//       Last Access: 3/20/2007 2:07:00 AM -07:00
//       Last Write:  8/4/2004 5:00:00 AM -07:00
// </Snippet1>
