//<Snippet1>
using namespace System;

namespace Samples
{
    public interface class IBook  // Fixes the violation by prefixing the interface with 'I'
    {
        property String^ Title
        {
            String^ get();
        }
        void Read();
    };
}
//</Snippet1>

