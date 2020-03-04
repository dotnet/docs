//<Snippet1>
using namespace System;

namespace Samples
{
    public interface class Book     // Violates this rule
    {
        property String^ Title
        {
            String^ get();
        }
        void Read();
    };
}
//</Snippet1>

