using namespace System;
using namespace System::IO;
using namespace System::IO::IsolatedStorage;

public ref class IsoFileGetStoreSample
{
public:
    static void Main()
    {
        IsolatedStorageFile^ isoFile;

        // remarks for GetMachineStoreForApplication()
        //<Snippet18>
        isoFile = IsolatedStorageFile::GetStore(IsolatedStorageScope::Application |
            IsolatedStorageScope::Machine, (Type^)nullptr);
        //</Snippet18>
        isoFile->Close();

        // remarks for GetMachineStoreForAssembly()
        //<Snippet19>
        isoFile = IsolatedStorageFile::GetStore(IsolatedStorageScope::Assembly |
            IsolatedStorageScope::Machine, (Type^)nullptr, (Type^)nullptr);
        //</Snippet19>
        isoFile->Close();

        // remarks for GetMachineStoreForDomain()
        //<Snippet20>
        isoFile = IsolatedStorageFile::GetStore(IsolatedStorageScope::Assembly |
            IsolatedStorageScope::Domain | IsolatedStorageScope::Machine,
            (Type^)nullptr, (Type^)nullptr);
        //</Snippet20>
        isoFile->Close();

        // remarks for GetUserStoreForApplication()
        //<Snippet21>
        isoFile = IsolatedStorageFile::GetStore(IsolatedStorageScope::Application |
            IsolatedStorageScope::User, (Type^)nullptr);
        //</Snippet21>
        isoFile->Close();

        // remarks for GetUserStoreForAssembly()
        //<Snippet22>
        isoFile = IsolatedStorageFile::GetStore(IsolatedStorageScope::Assembly |
            IsolatedStorageScope::User, (Type^)nullptr, (Type^)nullptr);
        //</Snippet22>
        isoFile->Close();

        // remarks for GetUserStoreForDomain()
        //<Snippet23>
        isoFile = IsolatedStorageFile::GetStore(IsolatedStorageScope::Assembly |
            IsolatedStorageScope::Domain | IsolatedStorageScope::User,
            (Type^)nullptr, (Type^)nullptr);
        //</Snippet23>
        isoFile->Close();
    }
};

int main()
{
    IsoFileGetStoreSample::Main();
}
