// <snippet1>
using System;
using System.Collections.Generic;
using System.Text;

namespace DSMSample
{
    // <snippet2>
    public class SampleObject
    {
        private string stringValue = null;
        private int intValue = int.MinValue;

        public string StringProperty 
        { 
            get { return this.stringValue; }

            set { this.stringValue = value; }
        }

        public int IntProperty 
        {
            get { return this.intValue; }

            set{ this.intValue = value; }
        }
    }
    // </snippet2>
}
// </snippet1>