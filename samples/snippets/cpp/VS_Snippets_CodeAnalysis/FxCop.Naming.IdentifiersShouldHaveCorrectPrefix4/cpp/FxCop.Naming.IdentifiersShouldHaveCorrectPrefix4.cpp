//<Snippet1>
using namespace System;

namespace Samples
{
    generic <typename TItem>  // Fixes the violation by prefixing the generic type parameter with 'T'
    public ref class Collection
    {

    };
}
//</Snippet1>

