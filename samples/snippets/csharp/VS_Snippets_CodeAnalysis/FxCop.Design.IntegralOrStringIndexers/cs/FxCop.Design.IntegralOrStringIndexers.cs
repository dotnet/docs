//<Snippet1>
using System;

namespace DesignLibrary
{
    public class Months
    {
        string[] month = new string[] {"Jan", "Feb", "..."};

        public string this[int index]
        {
            get
            {
                return month[index];
            }
        }
    }
}
//</Snippet1>
