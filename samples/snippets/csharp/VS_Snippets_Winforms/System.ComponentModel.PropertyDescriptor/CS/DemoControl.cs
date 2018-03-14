// <snippet100>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ReadOnlyPropertyDescriptorTest
{
    [Designer(typeof(DemoControlDesigner))]
    public class DemoControl : Control
    {
        public DemoControl()
        {
           
        }
    }
}
// </snippet100>
