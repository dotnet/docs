//<Snippet1>
using System;

namespace DesignLibrary
{
    internal class ParentType
    {
        public class NestedType
        {
            public NestedType()
            {
            }
        }

        public ParentType()
        {
            NestedType nt = new NestedType();
        }
    }
}
//</Snippet1>
