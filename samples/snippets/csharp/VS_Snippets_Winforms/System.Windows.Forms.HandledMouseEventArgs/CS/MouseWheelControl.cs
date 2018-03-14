using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TestMouseWheel
{
    public class MouseWheelControl : UserControl
    {
        public MouseWheelControl()
        {
            // Put control initialization code here.
            this.MouseWheel += new MouseEventHandler(MouseWheelControl_MouseWheel);
        }

        void MouseWheelControl_MouseWheel(object sender, MouseEventArgs e)
        {
            HandledMouseEventArgs me = (HandledMouseEventArgs)e;
            me.Handled = true;
            // Perform custom mouse wheel action here. 
        }
    }
}
