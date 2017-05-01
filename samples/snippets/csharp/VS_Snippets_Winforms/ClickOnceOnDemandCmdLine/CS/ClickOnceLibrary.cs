using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Samples.ClickOnceOnDemand
{
    public class DynamicClass
    {
        public DynamicClass() {}

        public string Message
        {
            get
            {
                return ("Hello, world!");
            }
        }
    }
}