//<snippet1>  
// This sample demonstrates methods of classes found in the System.IO IsolatedStorage namespace.
using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Security.Policy;
using Microsoft.Win32.SafeHandles;
using System.Security.Permissions;

[assembly: CLSCompliantAttribute(true)]

class ConsoleApp
{
    [STAThread]
    static void Main(string[] args)
    {

        // Prompt the user for their username.

        Console.WriteLine("Login:");

        // Does no error checking.
        LoginPrefs lp = new LoginPrefs(Console.ReadLine());

        if (lp.NewPrefs)
        {
            Console.WriteLine("Please set preferences for a new user.");
            GatherInfoFromUser(lp);

            // Write the new preferences to storage.
            double percentUsed = lp.SetPrefsForUser();
            Console.WriteLine("Your preferences have been written. Current space used is " + percentUsed.ToString() + " %");
        }
        else
        {
            Console.WriteLine("Welcome back.");

            Console.WriteLine("Your preferences have expired, please reset them.");
            GatherInfoFromUser(lp);
            lp.SetNewPrefsForUser();

            Console.WriteLine("Your news site has been set to {0}\n and your sports site has been set to {1}.", lp.NewsUrl, lp.SportsUrl);
        }
        lp.GetIsoStoreInfo();
        Console.WriteLine("Enter 'd' to delete the IsolatedStorage files and exit, or press any other key to exit without deleting files.");
        string consoleInput = Console.ReadLine();
        if (consoleInput.ToLower() == "d")
        {
            lp.DeleteFiles();
            lp.DeleteDirectories();
        }

    }

    static void GatherInfoFromUser(LoginPrefs lp)
    {
        Console.WriteLine("Please enter the URL of your news site.");
        lp.NewsUrl = Console.ReadLine();
        Console.WriteLine("Please enter the URL of your sports site.");
        lp.SportsUrl = Console.ReadLine();
    }
}
[SecurityPermissionAttribute(SecurityAction.Demand, Flags=SecurityPermissionFlag.UnmanagedCode)]
public class LoginPrefs
{
    public LoginPrefs(string myUserName)
    {
        userName = myUserName;
        myNewPrefs = GetPrefsForUser();
    }
    string userName;

    string myNewsUrl;
    public string NewsUrl
    {
        get { return myNewsUrl; }
        set { myNewsUrl = value; }
    }

    string mySportsUrl;
    public string SportsUrl
    {
        get { return mySportsUrl; }
        set { mySportsUrl = value; }
    }
    bool myNewPrefs;
    public bool NewPrefs
    {
        get { return myNewPrefs; }
    }

    //<snippet4>   
    private bool GetPrefsForUser()
    {
        try
        {
            //<Snippet15>

            // Retrieve an IsolatedStorageFile for the current Domain and Assembly.
            IsolatedStorageFile isoFile =
                IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
                IsolatedStorageScope.Assembly |
                IsolatedStorageScope.Domain,
                null,
                null);

            IsolatedStorageFileStream isoStream =
                new IsolatedStorageFileStream("substituteUsername",
                System.IO.FileMode.Open,
                System.IO.FileAccess.Read,
                 System.IO.FileShare.Read);
            //</Snippet15>

            // The code executes to this point only if a file corresponding to the username exists.
            // Though you can perform operations on the stream, you cannot get a handle to the file.

            try
            {

                SafeFileHandle aFileHandle = isoStream.SafeFileHandle;
                Console.WriteLine("A pointer to a file handle has been obtained. "
                    + aFileHandle.ToString() + " "
                    + aFileHandle.GetHashCode());
            }

            catch (Exception e)
            {
                // Handle the exception.
                Console.WriteLine("Expected exception");
                Console.WriteLine(e);
            }

            StreamReader reader = new StreamReader(isoStream);
            // Read the data.
            this.NewsUrl = reader.ReadLine();
            this.SportsUrl = reader.ReadLine();
            reader.Close();
            isoFile.Close();
            return false;
        }
        catch (System.IO.FileNotFoundException)
        {
            // Expected exception if a file cannot be found. This indicates that we have a new user.
            return true;
        }
    }
    //</snippet4>
    //<snippet3>  
    public bool GetIsoStoreInfo()
    {
        // Get a User store with type evidence for the current Domain and the Assembly.
        IsolatedStorageFile isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
            IsolatedStorageScope.Assembly |
            IsolatedStorageScope.Domain,
            typeof(System.Security.Policy.Url),
            typeof(System.Security.Policy.Url));

        String[] dirNames = isoFile.GetDirectoryNames("*");
        String[] fileNames = isoFile.GetFileNames("*");

        // List directories currently in this Isolated Storage.
        if (dirNames.Length > 0)
        {
            for (int i = 0; i < dirNames.Length; ++i)
            {
                Console.WriteLine("Directory Name: " + dirNames[i]);
            }
        }

        // List the files currently in this Isolated Storage.
        // The list represents all users who have personal preferences stored for this application.
        if (fileNames.Length > 0)
        {
            for (int i = 0; i < fileNames.Length; ++i)
            {
                Console.WriteLine("File Name: " + fileNames[i]);
            }
        }

        isoFile.Close();
        return true;
    }
    //</snippet3>

    //<snippet2>
    public double SetPrefsForUser()
    {
        try
        {
            //<snippet10>    
            IsolatedStorageFile isoFile;
            isoFile = IsolatedStorageFile.GetUserStoreForDomain();

            // Open or create a writable file.
            IsolatedStorageFileStream isoStream =
                new IsolatedStorageFileStream(this.userName,
                FileMode.OpenOrCreate,
                FileAccess.Write,
                isoFile);

            StreamWriter writer = new StreamWriter(isoStream);
            writer.WriteLine(this.NewsUrl);
            writer.WriteLine(this.SportsUrl);
            // Calculate the amount of space used to record the user's preferences.
            double d = isoFile.CurrentSize / isoFile.MaximumSize;
            Console.WriteLine("CurrentSize = " + isoFile.CurrentSize.ToString());
            Console.WriteLine("MaximumSize = " + isoFile.MaximumSize.ToString());
            // StreamWriter.Close implicitly closes isoStream.
            writer.Close();
            isoFile.Dispose();
            isoFile.Close();
            return d;
            //</snippet10>
        }
        catch (IsolatedStorageException ex)
        {
            // Add code here to handle the exception.
            Console.WriteLine(ex);
            return 0.0;
        }
    }

    //</snippet2>
    //<snippet6>   
    public void DeleteFiles()
    {
        //<snippet9>  
        try
        {
            IsolatedStorageFile isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
                IsolatedStorageScope.Assembly |
                IsolatedStorageScope.Domain,
                typeof(System.Security.Policy.Url),
                typeof(System.Security.Policy.Url));

            String[] dirNames = isoFile.GetDirectoryNames("*");
            String[] fileNames = isoFile.GetFileNames("*");
            //</snippet9>

            // List the files currently in this Isolated Storage.
            // The list represents all users who have personal
            // preferences stored for this application.
            if (fileNames.Length > 0)
            {
                for (int i = 0; i < fileNames.Length; ++i)
                {
                    // Delete the files.
                    isoFile.DeleteFile(fileNames[i]);
                }
                // Confirm that no files remain.
                fileNames = isoFile.GetFileNames("*");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

    }
    //</snippet6>
    //<snippet8>  
    // This method deletes directories in the specified Isolated Storage, after first 
    // deleting the files they contain. In this example, the Archive directory is deleted. 
    // There should be no other directories in this Isolated Storage.
    public void DeleteDirectories()
    {
        try
        {
            IsolatedStorageFile isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
                IsolatedStorageScope.Assembly |
                IsolatedStorageScope.Domain,
                typeof(System.Security.Policy.Url),
                typeof(System.Security.Policy.Url));
            //<Snippet16>			
            String[] dirNames = isoFile.GetDirectoryNames("*");
            String[] fileNames = isoFile.GetFileNames("Archive\\*");

            // Delete all the files currently in the Archive directory.

            if (fileNames.Length > 0)
            {
                for (int i = 0; i < fileNames.Length; ++i)
                {
                    // Delete the files.
                    isoFile.DeleteFile("Archive\\" + fileNames[i]);
                }
                // Confirm that no files remain.
                fileNames = isoFile.GetFileNames("Archive\\*");
            }


            if (dirNames.Length > 0)
            {
                for (int i = 0; i < dirNames.Length; ++i)
                {
                    // Delete the Archive directory.
                }
            }
            dirNames = isoFile.GetDirectoryNames("*");
            isoFile.Remove();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        //</Snippet16>		
    }
    //</snippet8>
    //<snippet7>  
    public double SetNewPrefsForUser()
    {
        try
        {
            byte inputChar;
            IsolatedStorageFile isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
                IsolatedStorageScope.Assembly |
                IsolatedStorageScope.Domain,
                typeof(System.Security.Policy.Url),
                typeof(System.Security.Policy.Url));

            // If this is not a new user, archive the old preferences and 
            // overwrite them using the new preferences.
            if (!this.myNewPrefs)
            {
                if (isoFile.GetDirectoryNames("Archive").Length == 0)
                    isoFile.CreateDirectory("Archive");
                else
                {
                    //<Snippet11>

                    IsolatedStorageFileStream source =
                        new IsolatedStorageFileStream(this.userName, FileMode.OpenOrCreate,
                        isoFile);
                    // This is the stream from which data will be read.
                    Console.WriteLine("Is the source file readable? " + (source.CanRead ? "true" : "false"));
                    Console.WriteLine("Creating new IsolatedStorageFileStream for Archive.");

                    // Open or create a writable file.
                    IsolatedStorageFileStream target =
                        new IsolatedStorageFileStream("Archive\\ " + this.userName,
                        FileMode.OpenOrCreate,
                        FileAccess.Write,
                        FileShare.Write,
                        isoFile);
                    //</Snippet11>
                    //<Snippet13>
                    Console.WriteLine("Is the target file writable? " + (target.CanWrite ? "true" : "false"));
                    //</Snippet13>
                    // Stream the old file to a new file in the Archive directory.
                    if (source.IsAsync && target.IsAsync)
                    {
                        // IsolatedStorageFileStreams cannot be asynchronous.  However, you
                        // can use the asynchronous BeginRead and BeginWrite functions
                        // with some possible performance penalty.

                        Console.WriteLine("IsolatedStorageFileStreams cannot be asynchronous.");
                    }

                    else
                    {
                        //<Snippet14>
                        Console.WriteLine("Writing data to the new file.");
                        while (source.Position < source.Length)
                        {
                            inputChar = (byte)source.ReadByte();
                            target.WriteByte(inputChar);
                        }

                        // Determine the size of the IsolatedStorageFileStream
                        // by checking its Length property.
                        Console.WriteLine("Total Bytes Read: " + source.Length);
                        //</Snippet14>

                    }

                    // After you have read and written to the streams, close them.
                    target.Close();
                    source.Close();
                }
            }
            //<Snippet12>

            // Open or create a writable file with a maximum size of 10K.
            IsolatedStorageFileStream isoStream =
                new IsolatedStorageFileStream(this.userName,
                FileMode.OpenOrCreate,
                FileAccess.Write,
                FileShare.Write,
                10240,
                isoFile);
            //</Snippet12>
            isoStream.Position = 0;  // Position to overwrite the old data.
            //</snippet7>
            //<snippet5>  
            StreamWriter writer = new StreamWriter(isoStream);
            // Update the data based on the new inputs.
            writer.WriteLine(this.NewsUrl);
            writer.WriteLine(this.SportsUrl);

            // Calculate the amount of space used to record this user's preferences.
            double d = isoFile.CurrentSize / isoFile.MaximumSize;
            Console.WriteLine("CurrentSize = " + isoFile.CurrentSize.ToString());
            Console.WriteLine("MaximumSize = " + isoFile.MaximumSize.ToString());
            //</snippet5>
            // StreamWriter.Close implicitly closes isoStream.
            writer.Close();
            isoFile.Close();

            return d;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return 0.0;
        }
    }
}

//</snippet1>