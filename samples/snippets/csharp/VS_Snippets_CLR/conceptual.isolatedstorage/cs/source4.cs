//<snippet4>
using System;
using System.IO.IsolatedStorage;
using System.IO;

public class DeletingFilesDirectories
{
    public static void Main()
    {
        // Get a new isolated store for this user domain and assembly.
        // Put the store into an isolatedStorageFile object.

        IsolatedStorageFile isoStore =  IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
            IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null);

        Console.WriteLine("Creating Directories:");

        // This code creates several different directories.

        isoStore.CreateDirectory("TopLevelDirectory");
        Console.WriteLine("TopLevelDirectory");
        isoStore.CreateDirectory("TopLevelDirectory/SecondLevel");
        Console.WriteLine("TopLevelDirectory/SecondLevel");

        // This code creates two new directories, one inside the other.

        isoStore.CreateDirectory("AnotherTopLevelDirectory/InsideDirectory");
        Console.WriteLine("AnotherTopLevelDirectory/InsideDirectory");
        Console.WriteLine();

        // This code creates a few files and places them in the directories.

        Console.WriteLine("Creating Files:");

        // This file is placed in the root.

        IsolatedStorageFileStream isoStream1 = new IsolatedStorageFileStream("InTheRoot.txt",
            FileMode.Create, isoStore);
        Console.WriteLine("InTheRoot.txt");

        isoStream1.Close();

        // This file is placed in the InsideDirectory.

        IsolatedStorageFileStream isoStream2 = new IsolatedStorageFileStream(
            "AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt", FileMode.Create, isoStore);
        Console.WriteLine("AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt");
        Console.WriteLine();

        isoStream2.Close();

        Console.WriteLine("Deleting File:");

        // This code deletes the HereIAm.txt file.
        isoStore.DeleteFile("AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt");
        Console.WriteLine("AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt");
        Console.WriteLine();

        Console.WriteLine("Deleting Directory:");

        // This code deletes the InsideDirectory.

        isoStore.DeleteDirectory("AnotherTopLevelDirectory/InsideDirectory/");
        Console.WriteLine("AnotherTopLevelDirectory/InsideDirectory/");
        Console.WriteLine();

    } // End of main.
}
//</snippet4>
