//<snippet13>
using namespace System;
using namespace System::IO::IsolatedStorage;

ref class UserDomainAssembly_IsoStorage
{
public:
    static void Main()
    {
        SnippetA();
        SnippetB();
    }

    static void SnippetA()
    {
        //<snippet14>
        IsolatedStorageFile^ isoFile =
            IsolatedStorageFile::GetStore(IsolatedStorageScope::User |
                IsolatedStorageScope::Domain |
                IsolatedStorageScope::Assembly, (Type^)nullptr, (Type^)nullptr);
        //</snippet14>
    }

    static void SnippetB()
    {
        //<snippet15>
        IsolatedStorageFile^ isoFile = IsolatedStorageFile::GetUserStoreForDomain();
        //</snippet15>
    }
};

int main()
{
    UserDomainAssembly_IsoStorage::Main();
}
//</snippet13>
