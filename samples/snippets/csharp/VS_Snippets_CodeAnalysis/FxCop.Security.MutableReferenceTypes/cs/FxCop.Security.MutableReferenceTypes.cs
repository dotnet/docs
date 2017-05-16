//<Snippet1>
using System;
using System.Text;

namespace SecurityLibrary
{
    public class MutableReferenceTypes
    {
        static protected readonly StringBuilder SomeStringBuilder;

        static MutableReferenceTypes()
        {
            SomeStringBuilder = new StringBuilder();
        }
    }
}
//</Snippet1>
