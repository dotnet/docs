using System;
using System.IO;
using System.IO.IsolatedStorage;

class IsoFileCloseSample
{
    public static void Main()
    {
        IsoFileCloseSample isoClose = new IsoFileCloseSample();

        isoClose.RunExample();
    }

    public string userName = "JoeUser";

    public void RunExample()
    {
        IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForDomain();
        //<Snippet17>
        IsolatedStorageFileStream source =
            new IsolatedStorageFileStream(this.userName,FileMode.Open,isoFile);
        // This stream is the one that data will be read from
        Console.WriteLine("Source can be read?" + (source.CanRead ? "true" : "false"));
        IsolatedStorageFileStream target =
            new IsolatedStorageFileStream("Archive\\ " + this.userName,
                FileMode.OpenOrCreate,isoFile);
        // This stream is the one that data will be written to
        Console.WriteLine("Target is writable?" + (target.CanWrite ? "true" : "false"));
        // Do work...
        // After you have read and written to the streams, close them
        source.Close();
        target.Close();
        //</Snippet17>
    }
}
