// <snippet10>
using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms.Design;

namespace ReadOnlyPropertyDescriptorTest
{   
    class DemoControlDesigner : ControlDesigner
    {
        // The PostFilterProperties method replaces the control's 
        // Size property with a read-only Size property by using 
        // the SerializeReadOnlyPropertyDescriptor class.
        protected override void PostFilterProperties(IDictionary properties)
        {
            if (properties.Contains("Size"))
            {
                PropertyDescriptor original = properties["Size"] as PropertyDescriptor;
                SerializeReadOnlyPropertyDescriptor readOnlyDescriptor = 
                    new SerializeReadOnlyPropertyDescriptor(original);

                properties["Size"] = readOnlyDescriptor;
            }

            base.PostFilterProperties(properties);
        }
    }
}
// </snippet10>