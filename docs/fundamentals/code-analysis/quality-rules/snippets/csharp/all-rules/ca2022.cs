using System.IO;
using System.Threading;

namespace ca2022;

class CA2022
{
    // <Snippet1>
    void M1(Stream stream, byte[] buffer)
    {
        // CA2022 violation.
        stream.Read(buffer, 0, buffer.Length);

        // Fix for the violation.
        stream.ReadExactly(buffer);
    }
    // </Snippet1>
}
