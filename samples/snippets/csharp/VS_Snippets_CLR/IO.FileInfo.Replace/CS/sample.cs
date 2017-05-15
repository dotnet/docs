//<SNIPPET1>
using System;
using System.IO;

namespace FileSystemExample
{
    class FileExample
    {
        public static void Main()
        {
            try
            {
                // originalFile and fileToReplace must contain the path to files that already exist in the  
                // file system. backUpOfFileToReplace is created during the execution of the Replace method.

                string originalFile  = "test.txt";
                string fileToReplace = "test2.txt";
                string backUpOfFileToReplace = "test2.txt.bak";

                if (File.Exists(originalFile) && (File.Exists(fileToReplace)))
                {
                    Console.WriteLine("Move the contents of " + originalFile + " into " + fileToReplace + ", delete "
                        + originalFile + ", and create a backup of " + fileToReplace + ".");

                    // Replace the file.
                    ReplaceFile(originalFile, fileToReplace, backUpOfFileToReplace);

                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Either the file {0} or {1} doesn't " + "exist.", originalFile, fileToReplace);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        // Move a file into another file, delete the original, and create a backup of the replaced file.
        public static void ReplaceFile(string fileToMoveAndDelete, string fileToReplace, string backupOfFileToReplace)
        {
            // Create a new FileInfo object.
            FileInfo fInfo = new FileInfo(fileToMoveAndDelete);

            // replace the file.
            fInfo.Replace(fileToReplace, backupOfFileToReplace, false);
        }
    }
}
//Move the contents of test.txt into test2.txt, delete test.txt, and 
//create a backup of test2.txt.
//Done

//</SNIPPET1>