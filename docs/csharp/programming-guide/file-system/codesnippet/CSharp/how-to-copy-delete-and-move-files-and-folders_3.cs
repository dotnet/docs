    // Simple synchronous file deletion operations with no user interface.
    // To run this sample, create the following files on your drive:
    // C:\Users\Public\DeleteTest\test1.txt
    // C:\Users\Public\DeleteTest\test2.txt
    // C:\Users\Public\DeleteTest\SubDir\test2.txt

    public class SimpleFileDelete
    {
        static void Main()
        {
            // Delete a file by using File class static method...
            if(System.IO.File.Exists(@"C:\Users\Public\DeleteTest\test.txt"))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(@"C:\Users\Public\DeleteTest\test.txt");
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            // ...or by using FileInfo instance method.
            System.IO.FileInfo fi = new System.IO.FileInfo(@"C:\Users\Public\DeleteTest\test2.txt");
            try
            {
                fi.Delete();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }

            // Delete a directory. Must be writable or empty.
            try
            {
                System.IO.Directory.Delete(@"C:\Users\Public\DeleteTest");
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
            // Delete a directory and all subdirectories with Directory static method...
            if(System.IO.Directory.Exists(@"C:\Users\Public\DeleteTest"))
            {
                try
                {
                    System.IO.Directory.Delete(@"C:\Users\Public\DeleteTest", true);
                }

                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            // ...or with DirectoryInfo instance method.
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@"C:\Users\Public\public");
            // Delete this dir and all subdirs.
            try
            {
                di.Delete(true);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }