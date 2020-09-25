using System;

namespace ca1721
{
    //<snippet1>
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
    //</snippet1>
}
