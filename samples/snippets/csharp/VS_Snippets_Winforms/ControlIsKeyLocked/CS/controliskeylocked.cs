// <Snippet1>
using System;
using System.Windows.Forms;

public class CapsLockIndicator
{
    public static void Main()
    {
        if (Control.IsKeyLocked(Keys.CapsLock)) {
            MessageBox.Show("The Caps Lock key is ON.");
        }
        else {
            MessageBox.Show("The Caps Lock key is OFF.");
        }
    }
}
// </Snippet1>