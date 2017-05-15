//<Snippet1>
using namespace System;

namespace DesignLibrary
{
    public ref class StaticMembers
    {
        static int someField;

        StaticMembers() {}

    public:
        static property int SomeProperty
        {
            int get()
            {
                return someField;
            }

            void set(int value)
            {
                someField = value;
            }
        }

        static void SomeMethod() {}
    };
}
//</Snippet1>
