// <Snippet10>
using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

public class DisposableStreamResource2 : DisposableStreamResource
{
   // Define additional constants.
   protected const uint GENERIC_WRITE = 0x40000000; 
   protected const uint OPEN_ALWAYS = 4;
   
   // Define additional APIs.
   [DllImport("kernel32.dll")]   
   protected static extern bool WriteFile(
                                SafeFileHandle safeHandle, string lpBuffer, 
                                int nNumberOfBytesToWrite, out int lpNumberOfBytesWritten,
                                IntPtr lpOverlapped);
   
   // Define locals.
   private bool disposed = false;
   private string filename;
   private bool created = false;
   private SafeFileHandle safeHandle;
   
   public DisposableStreamResource2(string filename) : base(filename)
   {
      this.filename = filename;
   }
   
   public void WriteFileInfo()
   { 
      if (! created) {
         IntPtr hFile = CreateFile(@".\FileInfo.txt", GENERIC_WRITE, 0, 
                                   IntPtr.Zero, OPEN_ALWAYS, 
                                   FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
         if (hFile != INVALID_HANDLE_VALUE)
            safeHandle = new SafeFileHandle(hFile, true);
         else
            throw new IOException("Unable to create output file.");

         created = true;
      }

      string output = String.Format("{0}: {1:N0} bytes\n", filename, Size);
      int bytesWritten;
      bool result = WriteFile(safeHandle, output, output.Length, out bytesWritten, IntPtr.Zero);                                     
   }

   protected new virtual void Dispose(bool disposing)
   {
      if (disposed) return;
      
      // Release any managed resources here.
      if (disposing)
         safeHandle.Dispose();
      
      disposed = true;
      
      // Release any unmanaged resources not wrapped by safe handles here.
      
      // Call the base class implementation.
      base.Dispose(true);
   }
}
// </Snippet10>

public class Example
{
   public static void Main()
   {
      DisposableStreamResource2 d = new DisposableStreamResource2(@"C:\Windows\Explorer.exe");
      d.WriteFileInfo();
      d.Dispose();
   }
}

public class DisposableStreamResource : IDisposable
{
   // Define constants.
   protected const uint GENERIC_READ = 0x80000000;
   protected const uint FILE_SHARE_READ = 0x00000001;
   protected const uint OPEN_EXISTING = 3;
   protected const uint FILE_ATTRIBUTE_NORMAL = 0x80;
   protected IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
   private const int INVALID_FILE_SIZE = unchecked((int) 0xFFFFFFFF);
   
   // Define Windows APIs.
   [DllImport("kernel32.dll", EntryPoint = "CreateFileW", CharSet = CharSet.Unicode)]
   protected static extern IntPtr CreateFile (
                                  string lpFileName, uint dwDesiredAccess, 
                                  uint dwShareMode, IntPtr lpSecurityAttributes, 
                                  uint dwCreationDisposition, uint dwFlagsAndAttributes, 
                                  IntPtr hTemplateFile);
   
   [DllImport("kernel32.dll")]
   private static extern int GetFileSize(SafeFileHandle hFile, out int lpFileSizeHigh);
    
   // Define locals.
   private bool disposed = false;
   private SafeFileHandle safeHandle; 
   private long bufferSize;
   private int upperWord;
   
   public DisposableStreamResource(string filename)
   {
      if (filename == null)
         throw new ArgumentNullException("The filename cannot be null.");
      else if (filename == "")
         throw new ArgumentException("The filename cannot be an empty string.");
            
      IntPtr handle = CreateFile(filename, GENERIC_READ, FILE_SHARE_READ,
                                 IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL,
                                 IntPtr.Zero);
      if (handle != INVALID_HANDLE_VALUE)
         safeHandle = new SafeFileHandle(handle, true);
      else
         throw new FileNotFoundException(String.Format("Cannot open '{0}'", filename));
      
      // Get file size.
      bufferSize = GetFileSize(safeHandle, out upperWord); 
      if (bufferSize == INVALID_FILE_SIZE)
         bufferSize = -1;
      else if (upperWord > 0) 
         bufferSize = (((long)upperWord) << 32) + bufferSize;
   }
   
   public long Size 
   { get { return bufferSize; } }

   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }           

   protected virtual void Dispose(bool disposing)
   {
      if (disposed) return;

      // Dispose of managed resources here.
      if (disposing)
         safeHandle.Dispose();
      
      // Dispose of any unmanaged resources not wrapped in safe handles.
      
      disposed = true;
   }  
}