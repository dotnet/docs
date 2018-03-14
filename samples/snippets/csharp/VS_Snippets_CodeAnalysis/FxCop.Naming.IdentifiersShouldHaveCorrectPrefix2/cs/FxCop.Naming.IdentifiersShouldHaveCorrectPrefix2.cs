//<Snippet1>
using System;

namespace Samples
{
    public interface IBook      // Fixes the violation by prefixing the interface with 'I'
    {
        string Title
        {
            get;
        }

        void Read();        
    }
}
//</Snippet1>

