using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;

[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
public class MyIconButton : Button
{

    private Icon icon;

    public MyIconButton()
    {
        // Set the button's FlatStyle property.
        FlatStyle = FlatStyle.System;
    }

    public MyIconButton(Icon ButtonIcon)
        : this()
    {
        // Assign the icon to the private field.   
        this.icon = ButtonIcon;


        // Size the button to 4 pixels larger than the icon.
        this.Height = icon.Height + 4;
        this.Width = icon.Width + 4;
    }

    protected override CreateParams CreateParams
    {
        get
        {
            new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();

            // Extend the CreateParams property of the Button class.
            CreateParams cp = base.CreateParams;
            // Update the button Style.
            cp.Style |= 0x00000040; // BS_ICON value

            return cp;
        }
    }

    public Icon Icon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
            UpdateIcon();
            // Size the button to 4 pixels larger than the icon.
            this.Height = icon.Height + 4;
            this.Width = icon.Width + 4;
        }
    }

    [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        // Update the icon on the button if there is currently an icon assigned to the icon field.
        if (icon != null)
        {
            UpdateIcon();
        }
    }

    private void UpdateIcon()
    {
        IntPtr iconHandle = IntPtr.Zero;

        // Get the icon's handle.
        if (icon != null)
        {
            iconHandle = icon.Handle;
        }

        // Send Windows the message to update the button. 
        SendMessage(Handle, 0x00F7 /*BM_SETIMAGE value*/, 1 /*IMAGE_ICON value*/, (int)iconHandle);
    }


    // Import the SendMessage method of the User32 DLL.   
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

}