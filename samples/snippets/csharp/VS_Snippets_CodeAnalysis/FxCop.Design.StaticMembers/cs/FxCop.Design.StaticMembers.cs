//<Snippet1>
using System;

namespace DesignLibrary
{
    public class StaticMembers
    {
        static int someField;

        public static int SomeProperty
        {
            get
            {
                return someField;
            }
            set
            {
                someField = value;
            }
        }

        StaticMembers() {}

        public static void SomeMethod() {}
    }
}
//</Snippet1>
