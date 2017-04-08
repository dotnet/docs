//<Snippet1>
using System;
using System.IO;

namespace DesignLibrary
{
    public class StreamUser
    {
        int anInteger;

        public void ManipulateFileStream(FileStream stream)
        {
            while ((anInteger = stream.ReadByte()) != -1)
            {
                // Do something.
            }
        }

        public void ManipulateAnyStream(Stream anyStream)
        {
            while ((anInteger = anyStream.ReadByte()) != -1)
            {
                // Do something.
            }
        }
    }

    class TestStreams
    {
        static void Main()
        {
            StreamUser someStreamUser = new StreamUser();
            MemoryStream testMemoryStream = new MemoryStream(new byte[] { });
            using (FileStream testFileStream =
                     new FileStream("test.dat", FileMode.OpenOrCreate))
            {
                // Cannot be used with testMemoryStream.
                someStreamUser.ManipulateFileStream(testFileStream);

                someStreamUser.ManipulateAnyStream(testFileStream);
                someStreamUser.ManipulateAnyStream(testMemoryStream);
            }
        }
    }
}
//</Snippet1>

namespace SomeNamespace
{

    class SomeClass
    {
        //<Snippet2>

public virtual void ManipulateFileStream(FileStream stream)
{
    int Byte;
    while ((Byte = stream.ReadByte()) != -1)
    {        // Do something.    
    }
}
//</Snippet2>
    }

}