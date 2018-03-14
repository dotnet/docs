//<Snippet1>
using System;

namespace DesignLibrary
{
    public class ObsoleteAttributeOnMember
    {
        [ObsoleteAttribute("This property is obsolete and will " +
             "be removed in a future version. Use the FirstName " +
             "and LastName properties instead.", false)]
        public string Name
        {
            get
            {
                return "Name";
            }
        }

        public string FirstName
        {
            get
            {
                return "FirstName";
            }
        }

        public string LastName
        {
            get
            {
                return "LastName";
            }
        }

    }
}
//</Snippet1>
