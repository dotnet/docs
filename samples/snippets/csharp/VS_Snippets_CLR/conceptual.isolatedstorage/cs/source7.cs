//<snippet8>
using System;
using System.IO;
using System.IO.IsolatedStorage;

public class CheckingSpace
{
    public static void Main()
    {
        // Get an isolated store for this assembly and put it into an
        // IsolatedStoreFile object.
        IsolatedStorageFile isoStore =  IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
            IsolatedStorageScope.Assembly, null, null);

        // Create a few placeholder files in the isolated store.
        new IsolatedStorageFileStream("InTheRoot.txt", FileMode.Create, isoStore);
        new IsolatedStorageFileStream("Another.txt", FileMode.Create, isoStore);
        new IsolatedStorageFileStream("AThird.txt", FileMode.Create, isoStore);
        new IsolatedStorageFileStream("AFourth.txt", FileMode.Create, isoStore);
        new IsolatedStorageFileStream("AFifth.txt", FileMode.Create, isoStore);

        Console.WriteLine(isoStore.AvailableFreeSpace + " bytes of space remain in this isolated store.");
    } // End of Main.
}
//</snippet8>
