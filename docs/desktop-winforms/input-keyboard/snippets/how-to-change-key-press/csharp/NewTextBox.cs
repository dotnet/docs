using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    class NewTextBox : TextBox
    {
        //<PreProcessMessage>
        public override bool PreProcessMessage(ref Message m)
        {
            const int WM_KEYDOWN = 0x100;

            if (m.Msg == WM_KEYDOWN)
            {
                Keys keyCode = (Keys)m.WParam & Keys.KeyCode;

                // Detect F1 through F9.
                m.WParam = keyCode switch
                {
                    Keys.F1 => (IntPtr)Keys.D1,
                    Keys.F2 => (IntPtr)Keys.D2,
                    Keys.F3 => (IntPtr)Keys.D3,
                    Keys.F4 => (IntPtr)Keys.D4,
                    Keys.F5 => (IntPtr)Keys.D5,
                    Keys.F6 => (IntPtr)Keys.D6,
                    Keys.F7 => (IntPtr)Keys.D7,
                    Keys.F8 => (IntPtr)Keys.D8,
                    Keys.F9 => (IntPtr)Keys.D9,
                    Keys.F10 => (IntPtr)Keys.D0,
                    _ => m.WParam
                };
            }

            // Send all other messages to the base method.
            return base.PreProcessMessage(ref m);
        }
        //</PreProcessMessage>
    }
}
