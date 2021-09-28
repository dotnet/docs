//<snippet10>
using namespace System;
using namespace System::IO::IsolatedStorage;

ref class RoamingIsoStorage
{
public:
    static void Main()
    {
        SnippetA();
        SnippetB();
    }

    static void SnippetA()
    {
        //<snippet11>
        IsolatedStorageFile^ isoFile =
            IsolatedStorageFile::GetStore(IsolatedStorageScope::User |
                IsolatedStorageScope::Assembly |
                IsolatedStorageScope::Roaming, (Type^)nullptr, (Type^)nullptr);
        //</snippet11>
    }

    static void SnippetB()
    {
        //<snippet12>
        IsolatedStorageFile^ isoFile =
            IsolatedStorageFile::GetStore(IsolatedStorageScope::User |
                IsolatedStorageScope::Assembly | IsolatedStorageScope::Domain |
                IsolatedStorageScope::Roaming, (Type^)nullptr, (Type^)nullptr);
        //</snippet12>
    }
};

int main()
{
    RoamingIsoStorage::Main();
}
//</snippet10>
