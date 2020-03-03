// <Snippet1>
using namespace System;
using namespace System::IO;

public ref class Block
{
public:
    static void Main()
    {
        Stream^ s = gcnew MemoryStream();
        for (int i = 0; i < 100; i++)
        {
            s->WriteByte((Byte)i);
        }
        s->Position = 0;

        // Now read s into a byte buffer.
        array<Byte>^ bytes = gcnew array<Byte>(s->Length);
        int numBytesToRead = (int) s->Length;
        int numBytesRead = 0;
        while (numBytesToRead > 0)
        {
            // Read may return anything from 0 to 10.
            int n = s->Read(bytes, numBytesRead, 10);
            // The end of the file is reached.
            if (n == 0)
            {
                break;
            }
            numBytesRead += n;
            numBytesToRead -= n;
        }
        s->Close();
        // numBytesToRead should be 0 now, and numBytesRead should
        // equal 100.
        Console::WriteLine("number of bytes read: {0:d}", numBytesRead);
    }
};

int main()
{
    Block::Main();
}
// </Snippet1>
