//<Snippet00>
using System;
using System.IO;

namespace touch
{
    class Touch
    {
        static void Main(string[] args)
        {
            // Make sure a filename was provided.
            if (args.Length > 0)
            {
                // Verify that the provided filename exists.
                if (File.Exists(args[0]))
                {
                    FileInfo fi = new FileInfo(args[0]);
                    touchFile(fi);
                }
                else
                {
                    Console.WriteLine(
                        "Could not find the file: {0}.", args[0]);
                }
            }
            else
            {
                Console.WriteLine("No file was specified.");
            }
        }

        static void touchFile(FileSystemInfo fsi)
        {
            Console.WriteLine("Touching: {0}", fsi.FullName);

            // Update the CreationTime, LastWriteTime and LastAccessTime.
            try
            {
                fsi.CreationTime = fsi.LastWriteTime = fsi.LastAccessTime =
                    DateTime.Now;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
    }
}
//</Snippet00>
