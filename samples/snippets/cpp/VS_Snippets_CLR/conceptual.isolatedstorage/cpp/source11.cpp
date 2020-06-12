//<snippet16>
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
        //<snippet17>
        IsolatedStorageFile^ isoFile =
            IsolatedStorageFile::GetStore(IsolatedStorageScope::User |
                IsolatedStorageScope::Assembly, (Type^)nullptr, (Type^)nullptr);
        //</snippet17>
    }

    static void SnippetB()
    {
        //<snippet18>
        IsolatedStorageFile^ isoFile = IsolatedStorageFile::GetUserStoreForAssembly();
        //</snippet18>
    }
};

int main()
{
    UserDomainAssembly_IsoStorage::Main();
}
//</snippet16>
