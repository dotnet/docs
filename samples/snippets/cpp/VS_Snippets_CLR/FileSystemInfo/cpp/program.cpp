// <Snippet1>
using namespace System;
using namespace System::IO;


namespace ConsoleApplication2
{
    public ref class Program
    {
    public:
        static void Main()
        {
            //  Loop through all the immediate subdirectories of C.
            for each (String^ entry in Directory::GetDirectories("C:\\"))
            {
                DisplayFileSystemInfoAttributes(gcnew DirectoryInfo(entry));
            }
            //  Loop through all the files in C.
            for each (String^ entry in Directory::GetFiles("C:\\"))
            {
                DisplayFileSystemInfoAttributes(gcnew FileInfo(entry));
            }
        }
        // <Snippet2>
        static void DisplayFileSystemInfoAttributes(FileSystemInfo^ fsi)
        {
            //  Assume that this entry is a file.
            String^ entryType = "File";

            // Determine if entry is really a directory
            if ((fsi->Attributes & FileAttributes::Directory) == FileAttributes::Directory)
            {
                entryType = "Directory";
            }
            //  Show this entry's type, name, and creation date.
            Console::WriteLine("{0} entry {1} was created on {2:D}", entryType, fsi->FullName, fsi->CreationTime);
        }
        // </Snippet2>
    };
};

int main()
{
    ConsoleApplication2::Program::Main();
}

 // Output will vary based on contents of drive C.

 // Directory entry C:\Documents and Settings was created on Tuesday, November 25, 2003
 // Directory entry C:\Inetpub was created on Monday, January 12, 2004
 // Directory entry C:\Program Files was created on Tuesday, November 25, 2003
 // Directory entry C:\RECYCLER was created on Tuesday, November 25, 2003
 // Directory entry C:\System Volume Information was created on Tuesday, November 2, 2003
 // Directory entry C:\WINDOWS was created on Tuesday, November 25, 2003
 // File entry C:\IO.SYS was created on Tuesday, November 25, 2003
 // File entry C:\MSDOS.SYS was created on Tuesday, November 25, 2003
 // File entry C:\pagefile.sys was created on Saturday, December 27, 2003
// </snippet1>