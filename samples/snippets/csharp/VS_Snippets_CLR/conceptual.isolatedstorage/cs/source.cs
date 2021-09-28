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
            isoStore.CreateDirectory("AnotherTopLevelDirectory/InsideDirectory");
            Console.WriteLine("Created directories.");

            isoStore.CreateFile("InTheRoot.txt");
            Console.WriteLine("Created a new file in the root.");

            isoStore.CreateFile("AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt");
            Console.WriteLine("Created a new file in the InsideDirectory.");
        }
    }
}
//</snippet1>