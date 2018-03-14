//<Snippet1>
using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

public class HashDirectory
{

    [STAThreadAttribute]
    public static void Main(String[] args)
    {
        string directory = "";
        if (args.Length < 1)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
                directory = fbd.SelectedPath;
            else
            {
                Console.WriteLine("No directory selected.");
                return;
            }
        }
        else
            directory = args[0];
        try
        {
            // Create a DirectoryInfo object representing the specified directory.
            DirectoryInfo dir = new DirectoryInfo(directory);
            // Get the FileInfo objects for every file in the directory.
            FileInfo[] files = dir.GetFiles();
            // Initialize a SHA256 hash object.
            SHA256 mySHA256 = SHA256Managed.Create();
           
            byte[] hashValue;
            // Compute and print the hash values for each file in directory.
            foreach (FileInfo fInfo in files)
            {
                // Create a fileStream for the file.
                FileStream fileStream = fInfo.Open(FileMode.Open);
                // Be sure it's positioned to the beginning of the stream.
                fileStream.Position = 0;
                // Compute the hash of the fileStream.
                hashValue = mySHA256.ComputeHash(fileStream);
                // Write the name of the file to the Console.
                Console.Write(fInfo.Name + ": ");
                // Write the hash value to the Console.
                PrintByteArray(hashValue);
                // Close the file.
                fileStream.Close();
            }
            return;
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Error: The directory specified could not be found.");
        }
        catch (IOException)
        {
            Console.WriteLine("Error: A file in the directory could not be accessed.");
        }
    }
    // Print the byte array in a readable format.
    public static void PrintByteArray(byte[] array)
    {
        int i;
        for (i = 0; i < array.Length; i++)
        {
            Console.Write(String.Format("{0:X2}", array[i]));
            if ((i % 4) == 3) Console.Write(" ");
        }
        Console.WriteLine();
    }
}
//</Snippet1>

