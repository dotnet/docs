//<snippet1>
using System;
using System.ComponentModel;

namespace EditorBrowsableDemo
{
    public class Class1
    {
        public Class1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        int ageval;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Age
        {
            get { return ageval; }
            set
            {
                if (!ageval.Equals(value))
                {
                    ageval = value;
                }
            }
        }
    }
}
//</snippet1>
