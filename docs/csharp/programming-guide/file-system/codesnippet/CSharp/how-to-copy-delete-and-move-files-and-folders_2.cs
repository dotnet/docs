    // Simple synchronous file move operations with no user interface.
    public class SimpleFileMove
    {
        static void Main()
        {
            string sourceFile = @"C:\Users\Public\public\test.txt";
            string destinationFile = @"C:\Users\Public\private\test.txt";

            // To move a file or folder to a new location:
            System.IO.File.Move(sourceFile, destinationFile);

            // To move an entire directory. To programmatically modify or combine
            // path strings, use the System.IO.Path class.
            System.IO.Directory.Move(@"C:\Users\Public\public\test\", @"C:\Users\Public\private");
        }
    }