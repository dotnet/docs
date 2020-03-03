//<Snippet1>
using System;
using System.IO;
using System.Security.Cryptography;

public class HashDirectory
{
    public static void Main(String[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("No directory selected.");
            return;
        }

        string directory = args[0];
        if (Directory.Exists(directory))
        {
            // Create a DirectoryInfo object representing the specified directory.
           var dir = new DirectoryInfo(directory);
            // Get the FileInfo objects for every file in the directory.
            FileInfo[] files = dir.GetFiles();
            // Initialize a SHA256 hash object.
            using (SHA256 mySHA256 = SHA256.Create())
            {
                // Compute and print the hash values for each file in directory.
                foreach (FileInfo fInfo in files)
                {
                    try { 
                        // Create a fileStream for the file.
                        FileStream fileStream = fInfo.Open(FileMode.Open);
                        // Be sure it's positioned to the beginning of the stream.
                        fileStream.Position = 0;
                        // Compute the hash of the fileStream.
                        byte[] hashValue = mySHA256.ComputeHash(fileStream);
                        // Write the name and hash value of the file to the console.
                        Console.Write($"{fInfo.Name}: ");
                        PrintByteArray(hashValue);
                        // Close the file.
                        fileStream.Close();
                    }
                    catch (IOException e) {
                        Console.WriteLine($"I/O Exception: {e.Message}");
                    }
                    catch (UnauthorizedAccessException e) {
                        Console.WriteLine($"Access Exception: {e.Message}");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("The directory specified could not be found.");
        }
    }

    // Display the byte array in a readable format.
    public static void PrintByteArray(byte[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i]:X2}");
            if ((i % 4) == 3) Console.Write(" ");
        }
        Console.WriteLine();
    }
}
//</Snippet1>
