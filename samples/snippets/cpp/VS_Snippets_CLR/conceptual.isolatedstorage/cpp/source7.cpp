//<snippet8>
using namespace System;
using namespace System::IO;
using namespace System::IO::IsolatedStorage;

public ref class CheckingSpace
{
public:
    static void Main()
    {
        // Get an isolated store for this assembly and put it into an
        // IsolatedStoreFile object.
        IsolatedStorageFile^ isoStore =  IsolatedStorageFile::GetStore(IsolatedStorageScope::User |
            IsolatedStorageScope::Assembly, (Type ^)nullptr, (Type ^)nullptr);

        // Create a few placeholder files in the isolated store.
        gcnew IsolatedStorageFileStream("InTheRoot.txt", FileMode::Create, isoStore);
        gcnew IsolatedStorageFileStream("Another.txt", FileMode::Create, isoStore);
        gcnew IsolatedStorageFileStream("AThird.txt", FileMode::Create, isoStore);
        gcnew IsolatedStorageFileStream("AFourth.txt", FileMode::Create, isoStore);
        gcnew IsolatedStorageFileStream("AFifth.txt", FileMode::Create, isoStore);

        Console::WriteLine(isoStore->AvailableFreeSpace + " bytes of space remain in this isolated store.");
    } // End of Main.
};

int main()
{
    CheckingSpace::Main();
}
//</snippet8>
