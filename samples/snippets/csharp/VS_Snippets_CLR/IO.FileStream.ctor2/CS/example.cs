//<SNIPPET1>
using System;
using System.IO;
using System.Text;
using System.Security.AccessControl;

namespace FileSystemExample
{
    class FileStreamExample
    {
        public static void Main()
        {
            try
            {
                // Create a file and write data to it.

                // Create an array of bytes.
                byte[] messageByte = Encoding.ASCII.GetBytes("Here is some data.");

                // Specify an access control list (ACL)
                FileSecurity fs = new FileSecurity();

                fs.AddAccessRule(new FileSystemAccessRule(@"DOMAINNAME\AccountName",
                                                            FileSystemRights.ReadData,
                                                            AccessControlType.Allow));

                // Create a file using the FileStream class.
                FileStream fWrite = new FileStream("test.txt", FileMode.Create, FileSystemRights.Modify, FileShare.None, 8, FileOptions.None, fs);

                // Write the number of bytes to the file.
                fWrite.WriteByte((byte)messageByte.Length);

                // Write the bytes to the file.
                fWrite.Write(messageByte, 0, messageByte.Length);

                // Close the stream.
                fWrite.Close();

                
                // Open a file and read the number of bytes.

                FileStream fRead = new FileStream("test.txt", FileMode.Open);

                // The first byte is the string length.
                int length = (int)fRead.ReadByte();

                // Create a new byte array for the data.
                byte[] readBytes = new byte[length];

                // Read the data from the file.
                fRead.Read(readBytes, 0, readBytes.Length);

                // Close the stream.
                fRead.Close();

                // Display the data.
                Console.WriteLine(Encoding.ASCII.GetString(readBytes));

                Console.WriteLine("Done writing and reading data.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
    }
}

//</SNIPPET1>