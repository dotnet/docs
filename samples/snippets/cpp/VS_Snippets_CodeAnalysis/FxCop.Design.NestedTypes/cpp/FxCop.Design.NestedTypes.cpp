//<Snippet1>
using namespace System;

namespace DesignLibrary
{
    public ref class ParentType
    {
    public:
        ref class NestedType
        {
        public:
            NestedType()
            {
            }
        };

        ParentType()
        {
            NestedType^ nt = gcnew NestedType();
        }
    };
}
//</Snippet1>
