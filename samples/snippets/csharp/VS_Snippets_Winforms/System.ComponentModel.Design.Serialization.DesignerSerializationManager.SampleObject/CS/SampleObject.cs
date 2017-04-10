// <snippet10>
using System;
using System.Collections.Generic;
using System.Text;

namespace DSMSample
{
    // <snippet11>
    public class SampleObject
    {
        private string stringValue = null;
        private int intValue = int.MinValue;
        private SampleObject childValue = null;

        public string StringProperty
        {
            get { return this.stringValue; }

            set { this.stringValue = value; }
        }

        public int IntProperty
        {
            get { return this.intValue; }

            set { this.intValue = value; }
        }

        public SampleObject Child
        {
            get { return this.childValue; }

            set { this.childValue = value; }
        }
    }
    // </snippet11>

    // <snippet12>
    class Program
    {
        // <snippet13>
        static void Main(string[] args)
        {
            // <snippet14>
            SampleObject root = new SampleObject();

            SampleObject currentObject = root;

            for (int i = 0; i < 10; i++)
            {
                SampleObject o = new SampleObject();

                currentObject.Child = o;

                currentObject = o;
            }
            // </snippet14>
        }
        // </snippet13>
    }
    // </snippet12>
}
// </snippet10>