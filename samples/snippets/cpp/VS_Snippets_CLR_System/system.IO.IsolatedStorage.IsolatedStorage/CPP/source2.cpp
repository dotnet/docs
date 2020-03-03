using namespace System;
using namespace System::IO;
using namespace System::IO::IsolatedStorage;

public ref class IsoFileCloseSample
{
public:
    static void Main()
    {
        IsoFileCloseSample^ isoClose = gcnew IsoFileCloseSample();

        isoClose->RunExample();
    }

    static String^ userName = "JoeUser";

    void RunExample()
    {
        IsolatedStorageFile^ isoFile = IsolatedStorageFile::GetUserStoreForDomain();
        //<Snippet17>
        IsolatedStorageFileStream^ source =
            gcnew IsolatedStorageFileStream(this->userName,FileMode::Open,isoFile);
        // This stream is the one that data will be read from
        Console::WriteLine("Source can be read?" + (source->CanRead ? "true" : "false"));
        IsolatedStorageFileStream^ target =
            gcnew IsolatedStorageFileStream("Archive\\ " + this->userName,
                FileMode::OpenOrCreate,isoFile);
        // This stream is the one that data will be written to
        Console::WriteLine("Target is writable?" + (target->CanWrite ? "true" : "false"));
        // Do work...
        // After you have read and written to the streams, close them
        source->Close();
        target->Close();
        //</Snippet17>
    }
};

int main()
{
    IsoFileCloseSample::Main();
}
