//<snippet9>
using namespace System;
using namespace System::IO;
using namespace System::IO::IsolatedStorage;
using namespace System::Collections;
using namespace System::Collections::Generic;

public class FindingExistingFilesAndDirectories
{
public:
    // Retrieves an array of all directories in the store, and
    // displays the results.
    static void Main()
    {
        // This part of the code sets up a few directories and files in the
        // store.
        IsolatedStorageFile^ isoStore = IsolatedStorageFile::GetStore(IsolatedStorageScope::User |
            IsolatedStorageScope::Assembly, (Type ^)nullptr, (Type ^)nullptr);
        isoStore->CreateDirectory("TopLevelDirectory");
        isoStore->CreateDirectory("TopLevelDirectory/SecondLevel");
        isoStore->CreateDirectory("AnotherTopLevelDirectory/InsideDirectory");
        gcnew IsolatedStorageFileStream("InTheRoot.txt", FileMode::Create, isoStore);
        gcnew IsolatedStorageFileStream("AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt",
            FileMode::Create, isoStore);
        // End of setup.

        Console::WriteLine('\r');
        Console::WriteLine("Here is a list of all directories in this isolated store:");

        for each (String^ directory in GetAllDirectories("*", isoStore))
        {
            Console::WriteLine(directory);
        }
        Console::WriteLine('\r');

        // Retrieve all the files in the directory by calling the GetFiles
        // method.

        Console::WriteLine("Here is a list of all the files in this isolated store:");
        for each (String^ file in GetAllFiles("*", isoStore))
        {
            Console::WriteLine(file);
        }

    } // End of Main.

    // Method to retrieve all directories, recursively, within a store.
    static List<String^>^ GetAllDirectories(String^ pattern, IsolatedStorageFile^ storeFile)
    {
        // Get the root of the search string.
        String^ root = Path::GetDirectoryName(pattern);

        if (root != "")
        {
            root += "/";
        }

        // Retrieve directories.
        array<String^>^ directories = storeFile->GetDirectoryNames(pattern);

        List<String^>^ directoryList = gcnew List<String^>(directories);

        // Retrieve subdirectories of matches.
        for (int i = 0, max = directories->Length; i < max; i++)
        {
             String^ directory = directoryList[i] + "/";
             List<String^>^ more = GetAllDirectories (root + directory + "*", storeFile);

             // For each subdirectory found, add in the base path.
             for (int j = 0; j < more->Count; j++)
             {
                 more[j] = directory + more[j];
             }

            // Insert the subdirectories into the list and
            // update the counter and upper bound.
            directoryList->InsertRange(i + 1, more);
            i += more->Count;
            max += more->Count;
        }

        return directoryList;
    }

    static List<String^>^ GetAllFiles(String^ pattern, IsolatedStorageFile^ storeFile)
    {
        // Get the root and file portions of the search string.
        String^ fileString = Path::GetFileName(pattern);
        array<String^>^ files = storeFile->GetFileNames(pattern);

        List<String^>^ fileList = gcnew List<String^>(files);

        // Loop through the subdirectories, collect matches,
        // and make separators consistent.
        for each (String^ directory in GetAllDirectories( "*", storeFile))
        {
            for each (String^ file in storeFile->GetFileNames(directory + "/" + fileString))
            {
                fileList->Add((directory + "/" + file));
            }
        }

        return fileList;
    } // End of GetFiles.
};

int main()
{
    FindingExistingFilesAndDirectories::Main();
}
//</snippet9>
