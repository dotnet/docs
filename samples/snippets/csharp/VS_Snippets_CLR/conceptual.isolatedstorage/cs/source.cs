//<snippet1>
using System;
using System.IO;
using System.IO.IsolatedStorage;

public class CreatingFilesDirectories
{
public static void Main()
{
    using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
    {
        isoStore.CreateDirectory("TopLevelDirectory");
        isoStore.CreateDirectory("TopLevelDirectory/SecondLevel");
        var isofilename = "AnotherTopLevelDirectory/NewFile.txt";
        try
        {
            isoStore.CreateFile(isofilename);
        }
        catch (IsolatedStorageException iex){
            Console.WriteLine(iex.ToString());
        }

        var path = Path.GetDirectoryName(isofilename);
        isoStore.CreateDirectory(path);//Creating "AnotherTopLevelDirectory";
        isoStore.CreateFile(isofilename);//Creating "AnotherTopLevelDirectory/NewFile.txt";
        
        isoStore.CreateDirectory("AnotherTopLevelDirectory/InsideDirectory");
        Console.WriteLine("Created directories.");

        isoStore.CreateFile("InTheRoot.txt");
        Console.WriteLine("Created a new file in the root.");

        isoStore.CreateFile("AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt");
        Console.WriteLine("Created a new file in the InsideDirectory.");
        }
    }

    private string CreateFolders(string folderName, string fileName)
    {

        var isofilename = fileName;
        if (string.IsNullOrEmpty(fileName)) return string.Empty;

        if (!string.IsNullOrEmpty(folderName))
        {
            isofilename = Path.Combine(folderName, fileName);
        }

        //does path have folder?
        var path = Path.GetDirectoryName(isofilename);
        applicationStorageFileForUser.CreateDirectory(path);

        return isofilename;
    }
}
//</snippet1>
