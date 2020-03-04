//<Snippet1>
using namespace System;
using namespace System::Text;

namespace SecurityLibrary
{
    public ref class MutableReferenceTypes
    {
    protected:
        static StringBuilder^ const SomeStringBuilder = 
           gcnew StringBuilder();

    private:
        static MutableReferenceTypes()
        {
        }
    };
}
//</Snippet1>
