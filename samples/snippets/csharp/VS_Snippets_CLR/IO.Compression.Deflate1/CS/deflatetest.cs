//<snippet1>
using System;
using System.IO;
using System.IO.Compression;

public class Program
{
    static string directoryPath = @"c:\temp";
    public static void Main()
    {
        
        DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);
           Compress(directorySelected);
    	

        foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.cmp"))
        {
            Decompress(fileToDecompress);
        }
    }

    public static void Compress(DirectoryInfo directorySelected)
    {
        
     
        foreach (FileInfo file in directorySelected.GetFiles("*.xml"))
        using (FileStream originalFileStream = file.OpenRead())
        {
            if ((File.GetAttributes(file.FullName) & FileAttributes.Hidden)
                != FileAttributes.Hidden & file.Extension != ".cmp")
            {
                using (FileStream compressedFileStream = File.Create(file.FullName + ".cmp"))
                {
                    using (DeflateStream compressionStream = new DeflateStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream);
                    }
                }

                FileInfo info = new FileInfo(directoryPath + "\\" + file.Name + ".cmp");
                Console.WriteLine("Compressed {0} from {1} to {2} bytes.", file.Name, file.Length, info.Length);
            }
        }
    }

    public static void Decompress(FileInfo fileToDecompress)
    {
        using (FileStream originalFileStream = fileToDecompress.OpenRead())
        {
            string currentFileName = fileToDecompress.FullName;
            string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

            using (FileStream decompressedFileStream = File.Create(newFileName))
        	{
                using (DeflateStream decompressionStream = new DeflateStream(originalFileStream, CompressionMode.Decompress))
        	    {
                    decompressionStream.CopyTo(decompressedFileStream);
                    Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
        	    }
        	}
        }
    }
}
//</snippet1>