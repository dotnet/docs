// <Snippet12>
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
// </Snippet12>

public class FileInfoSnippets
{
    public void Attributes()
    {
        // <Snippet1>
        string   fileName = "C:\\autoexec.bat";
        FileInfo fileInfo = new FileInfo(fileName);
        if (!fileInfo.Exists)
        {
            return;
        }
        Console.WriteLine("{0} has attributes of {1}",
            fileName, fileInfo.Attributes);

        // Toggle the archive flag of the file.
        bool archiveFlag = (fileInfo.Attributes & FileAttributes.Archive) == FileAttributes.Archive;
        if (archiveFlag)
        {
            fileInfo.Attributes &= ~FileAttributes.Archive;
        }
        else
        {
            fileInfo.Attributes |= FileAttributes.Archive;
        }

        Console.WriteLine("{0} has attributes of {1}",
            fileName, fileInfo.Attributes);
        /* This code produces output similar to the following,
         * though actual results may vary by machine:
         *
         * C:\autoexec.bat has attributes of Normal
         * C:\autoexec.bat has attributes of Archive
         */
        // </Snippet1>
        Console.WriteLine();
    }

    public void CreationTime()
    {
        // <Snippet2>
        string   fileName = "C:\\autoexec.bat";
        FileInfo fileInfo = new FileInfo(fileName);
        if (!fileInfo.Exists)
        {
            return;
        }

        Console.WriteLine("{0} was created at {1}",
            fileName, fileInfo.CreationTime);

        // Add two hours to the creation time.
        fileInfo.CreationTime += TimeSpan.FromHours(2.0);

        Console.WriteLine("{0} is now created at {1}",
            fileName, fileInfo.CreationTime);
        /* This code produces output similar to the following,
         * though actual results may vary by machine:
         *
         * C:\autoexec.bat was created at 8/17/2004 5:30:13 PM
         * C:\autoexec.bat is now created at 8/17/2004 7:30:13 PM
         */
        // </Snippet2>
        Console.WriteLine();
    }

    public void DirectoryName()
    {
        // <Snippet3>
        string   fileName = @"C:\TMP\log.txt";
        FileInfo fileInfo = new FileInfo(fileName);
        if (!fileInfo.Exists)
        {
            return;
        }

        Console.WriteLine("{0} has a directoryName of {1}",
            fileName, fileInfo.DirectoryName);
        /* This code produces output similar to the following,
         * though actual results may vary by machine:
         *
         * C:\TMP\log.txt has a directory name of C:\TMP
         */
        // </Snippet3>
        Console.WriteLine();
    }

    public void Directory()
    {
        // <Snippet4>
        string   fileName = "C:\\autoexec.bat";
        FileInfo fileInfo = new FileInfo(fileName);
        if (!fileInfo.Exists)
        {
            return;
        }

        DirectoryInfo dirInfo = fileInfo.Directory;
        Console.WriteLine("{0} is in a directory of {1} files.",
            fileName, dirInfo.GetFiles().Length);
        /* This code produces output similar to the following,
         * though actual results may vary by machine:
         *
         * C:\autoexec.bat is in a directory of 24 files.
         */
        // </Snippet4>
        Console.WriteLine();
    }

    public void ExtensionAndName()
    {
        // <Snippet5>
        string        dirName = "C:\\";
        DirectoryInfo dirInfo = new DirectoryInfo(dirName);

        Console.WriteLine("{0} contains the following system files:",
            dirName);
        foreach (FileInfo fileInfo in dirInfo.GetFiles())
        {
            if (fileInfo.Extension.ToLower().Equals(".sys"))
            {
                Console.WriteLine(fileInfo.Name);
            }
        }
        /* This code produces output similar to the following,
         * though actual results may vary by machine:
         *
         * C:\ contains the following system files:
         * CONFIG.SYS
         * IO.SYS
         * MSDOS.SYS
         * pagefile.sys
         */
        // </Snippet5>
        Console.WriteLine();
    }

    public void LastAccessTime()
    {
        // <Snippet6>
        string   fileName = "C:\\autoexec.bat";
        FileInfo fileInfo = new FileInfo(fileName);
        if (!fileInfo.Exists)
        {
            return;
        }

        Console.WriteLine("{0} was last accessed at {1}",
            fileName, fileInfo.LastAccessTime);

        // Set the access time back two hours.
        fileInfo.LastAccessTime -= TimeSpan.FromHours(2.0);

        Console.WriteLine("{0} now was last accessed at {1}",
            fileName, fileInfo.LastAccessTime);
        /* This code produces output similar to the following,
         * though actual results may vary by machine:
         *
         * C:\autoexec.bat was last accessed at 8/17/2004 1:30:13 PM
         * C:\autoexec.bat now was last accessed at 8/17/2004 11:30:13 AM
         */
        // </Snippet6>
        Console.WriteLine();
    }

    public void LastWriteTime()
    {
        // <Snippet7>
        string   fileName = "C:\\autoexec.bat";
        FileInfo fileInfo = new FileInfo(fileName);
        if (!fileInfo.Exists)
        {
            return;
        }

        Console.WriteLine("{0} was last written to at {1}",
            fileName, fileInfo.LastWriteTime);

        // Set the access time back two hours.
        fileInfo.LastWriteTime -= TimeSpan.FromHours(2.0);

        Console.WriteLine("{0} now was last written to at {1}",
            fileName, fileInfo.LastWriteTime);
        /* This code produces output similar to the following,
         * though actual results may vary by machine:
         *
         * C:\autoexec.bat was last written to at 8/17/2004 1:30:13 PM
         * C:\autoexec.bat now was last written to at 8/17/2004 11:30:13 AM
         */
        // </Snippet7>
        Console.WriteLine();
    }

    public void Length()
    {
        // <Snippet8>
        string        dirName = "C:\\";
        DirectoryInfo dirInfo = new DirectoryInfo(dirName);

        Console.WriteLine("{0} contains the following files:", dirName);
        Console.WriteLine("Size\t Filename");
        foreach (FileInfo fileInfo in dirInfo.GetFiles())
        {
            try
            {
                Console.WriteLine("{0}\t {1}",
                    fileInfo.Length, fileInfo.Name);
            }
            catch (IOException e)
            {
                Console.WriteLine("\t {0}: {1}", fileInfo.Name, e.Message);
            }
        }
        /* This code produces output similar to the following,
         * though actual results may vary by machine:
         *
         * C:\ contains the following files:
         * Size  Filename
         * 0     AUTOEXEC.BAT
         * 211   boot.ini
         * 0     CONFIG.SYS
         * 885   InoSetRTThread.log
         * 0     IO.SYS
         * 0     MSDOS.SYS
         * 47564     NTDETECT.COM
         * 250032    ntldr
         * 1610612736    pagefile.sys
         * 1479  PatchInfo.txt
         * 102   Platform.ini
         * 548   RISGX280.log
         * 196568    UpdatePatch.log
         */
        // </Snippet8>
        Console.WriteLine();
    }

    public void AppendTextAndOpenText()
    {
        // <Snippet9>
        string    fileName = Path.GetTempFileName();
        FileInfo  fileInfo = new FileInfo(fileName);
        Console.WriteLine("File '{0}' created of size {1} bytes",
            fileName, fileInfo.Length);

        // Append some text to the file.
        StreamWriter s = fileInfo.AppendText();
        s.WriteLine("The text in the file");
        s.Close();

        fileInfo.Refresh();
        Console.WriteLine("File '{0}' now has size {1} bytes",
            fileName, fileInfo.Length);

        // Read the text file.
        StreamReader r = fileInfo.OpenText();
        string textLine;
        while ((textLine = r.ReadLine()) != null)
        {
            Console.WriteLine(textLine);
        }
        r.Close();
        /* This code produces output similar to the following,
         * though actual results may vary by machine:
         *
         * File 'C:\DOCUME~1\cliffc\LOCALS~1\Temp\tmp12C.tmp' created of size 0 bytes
         * File 'C:\DOCUME~1\cliffc\LOCALS~1\Temp\tmp12C.tmp' now has size 22 bytes
         * The text in the file
         */
        // </Snippet9>
        Console.WriteLine();
    }

    public void CreateText()
    {
        // <Snippet10>
        FileInfo  fileInfo = new FileInfo("myFile");

        // Create the file and output some text to it.
        StreamWriter s = fileInfo.CreateText();
        s.WriteLine("Output to the file");
        s.Close();

        fileInfo.Refresh();
        Console.WriteLine("File '{0}' now has size {1} bytes",
            fileInfo.Name, fileInfo.Length);
        /* This code produces output similar to the following,
         * though actual results may vary by machine:
         *
         * File 'myFile' now has size 20 bytes
         */
        // </Snippet10>
        Console.WriteLine();
    }

    public void OpenWriteAndOpenRead()
    {
        // <Snippet11>

        // Create a temporary file.
        string      fileName = Path.GetTempFileName();
        FileInfo    fileInfo = new FileInfo(fileName);

        // Write the current time to the file in binary form.
        DateTime   currentTime = DateTime.Now;
        FileStream fileWriteStream = fileInfo.OpenWrite();
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileWriteStream, currentTime);
        fileWriteStream.Close();

        // Read the time back from the file.
        FileStream fileReadStream = fileInfo.OpenRead();
        DateTime   timeRead = (DateTime)binaryFormatter.Deserialize(fileReadStream);
        fileReadStream.Close();

        Console.WriteLine("Value written {0}", currentTime);
        Console.WriteLine("Value read    {0}", timeRead);
        /* This code produces output similar to the following,
         * though actual results may vary by machine:
         *
         * Value written 9/9/2005 3:46:24 PM
         * Value read    9/9/2005 3:46:24 PM
         */
        // </Snippet11>
        Console.WriteLine();
    }
    public static void Main()
    {
        Console.WriteLine();
        FileInfoSnippets fileInfoSnippets = new FileInfoSnippets();
        fileInfoSnippets.Attributes();
        fileInfoSnippets.CreationTime();
        fileInfoSnippets.DirectoryName();
        fileInfoSnippets.Directory();
        fileInfoSnippets.ExtensionAndName();
        fileInfoSnippets.LastAccessTime();
        fileInfoSnippets.LastWriteTime();
        fileInfoSnippets.Length();
        fileInfoSnippets.AppendTextAndOpenText();
        fileInfoSnippets.CreateText();
        fileInfoSnippets.OpenWriteAndOpenRead();
    }
}
