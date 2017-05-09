//<SNIPPET1>
using System;
using System.IO;
using System.Security.AccessControl;

namespace FileSystemExample
{
    class FileExample
    {
        public static void Main()
        {
            try
            {
                string FileName = @"c:\MyTest.txt";

                Console.WriteLine("Encrypt " + FileName);

                // Encrypt the file.
                AddEncryption(FileName);

                Console.WriteLine("Decrypt " + FileName);

                // Decrypt the file.
                RemoveEncryption(FileName);

                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void AddEncryption(string FileName)
        {
            // Create a new FileInfo object.
            FileInfo fInfo = new FileInfo(FileName);
            if (!fInfo.Exists)
            {
                //Create the file.
                fInfo.Create();
            }
            // Add encryption.
            fInfo.Encrypt();
        }

        public static void RemoveEncryption(string FileName)
        {
            // Create a new FileInfo object.
            FileInfo fInfo = new FileInfo(FileName);
            if (!fInfo.Exists)
            {
                //Create the file.
                fInfo.Create();
            }
            // Remove encryption.
            fInfo.Decrypt();

        }
    }
}

//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//Encrypt c:\MyTest.txt
//Decrypt c:\MyTest.txt
//Done
//</SNIPPET1>