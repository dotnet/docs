//<Snippet1>
using System;
using System.Runtime.InteropServices;

namespace TypeEquivalenceInterface
{
    [ComImport]
    [Guid("8DA56996-A151-4136-B474-32784559F6DF")]
    public interface ISampleInterface
    {
        void GetUserInput();
        string UserInput { get; }
//</Snippet1>
//<Snippet3>
        DateTime GetDate();
//</Snippet3>
//<Snippet4>
    }
}
//</Snippet4>
