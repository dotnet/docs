//<Snippet1>
using System;

namespace NamingLibrary
{
    public class Test
    {
        public DateTime Date
        {
            get { return DateTime.Today; }
        }
         // Violates rule: PropertyNamesShouldNotMatchGetMethods.
        public string GetDate()
        {
            return this.Date.ToString();
        }
    }
}
//</Snippet1>
